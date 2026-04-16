namespace FileCompare
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLeftDir_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.Description = "폴더를  선택하세요."; if (!string.IsNullOrWhiteSpace(txtLeftDir.Text) && Directory.Exists(txtLeftDir.Text))
                {
                    dlg.SelectedPath = txtLeftDir.Text;
                }
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtLeftDir.Text = dlg.SelectedPath;
                    PopulateListView(lvwLeftDir, dlg.SelectedPath);
                }
            }
        }

        private void btnRightDir_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.Description = "폴더를  선택하세요.";
                if (!string.IsNullOrWhiteSpace(txtRightDir.Text) && Directory.Exists(txtRightDir.Text))
                {
                    dlg.SelectedPath = txtRightDir.Text;
                }
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtRightDir.Text = dlg.SelectedPath;
                    PopulateListView(lvwRightDir, dlg.SelectedPath);
                }
            }
        }
        private void PopulateListView(ListView lv, string path)
        {
            if (string.IsNullOrWhiteSpace(path) || !Directory.Exists(path)) return;

            lv.BeginUpdate();
            lv.Items.Clear();

            try
            {
                DirectoryInfo di = new DirectoryInfo(path);

                // 1. 데이터 채우기
                foreach (var d in di.GetDirectories().OrderBy(d => d.Name))
                {
                    ListViewItem item = new ListViewItem(d.Name);
                    item.SubItems.Add("<DIR>");
                    item.SubItems.Add(d.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    item.UseItemStyleForSubItems = false; // ★ 개별 색상 설정 허용
                    lv.Items.Add(item);
                }

                foreach (var f in di.GetFiles().OrderBy(f => f.Name))
                {
                    ListViewItem item = new ListViewItem(f.Name);
                    item.SubItems.Add(f.Length.ToString("N0"));
                    item.SubItems.Add(f.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    item.UseItemStyleForSubItems = false; // ★ 개별 색상 설정 허용
                    lv.Items.Add(item);
                }

                lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            finally
            {
                lv.EndUpdate();
            }

            // 2. ★ 데이터를 다 채우자마자 비교 함수 실행
            ApplyComparisonColors();
        }
        private void ApplyComparisonColors()
        {
            // 양쪽 리스트뷰 업데이트 일시 중지
            lvwLeftDir.BeginUpdate();
            lvwRightDir.BeginUpdate();

            try
            {
                // 왼쪽 기준 비교
                foreach (ListViewItem leftItem in lvwLeftDir.Items)
                {
                    ListViewItem rightItem = FindMatch(lvwRightDir, leftItem.Text);

                    if (rightItem == null) // 오른쪽엔 없음
                    {
                        leftItem.ForeColor = Color.Blue;
                    }
                    else // 양쪽 다 있음
                    {
                        CompareDates(leftItem, rightItem);
                    }
                }

                // 오른쪽 기준 비교 (왼쪽엔 없는 것 찾기용)
                foreach (ListViewItem rightItem in lvwRightDir.Items)
                {
                    if (FindMatch(lvwLeftDir, rightItem.Text) == null)
                    {
                        rightItem.ForeColor = Color.Blue;
                    }
                }
            }
            finally
            {
                lvwLeftDir.EndUpdate();
                lvwRightDir.EndUpdate();
            }
        }

        // 날짜를 비교해서 색을 입히는 보조 메서드
        private void CompareDates(ListViewItem left, ListViewItem right)
        {
            if (DateTime.TryParse(left.SubItems[2].Text, out DateTime dL) &&
                DateTime.TryParse(right.SubItems[2].Text, out DateTime dR))
            {
                if (dL > dR) { left.ForeColor = Color.Red; right.ForeColor = Color.Gray; }
                else if (dL < dR) { left.ForeColor = Color.Gray; right.ForeColor = Color.Red; }
                else { left.ForeColor = Color.Black; right.ForeColor = Color.Black; }
            }
        }

        // 이름을 찾는 보조 메서드
        private ListViewItem FindMatch(ListView targetLv, string name)
        {
            foreach (ListViewItem item in targetLv.Items)
            {
                if (item.Text == name) return item;
            }
            return null;
        }

        // 왼쪽에서 오른쪽으로 복사
        private void btnCopyFromLeft_Click(object sender, EventArgs e)
        {
           
        }

        // 오른쪽에서 왼쪽으로 복사
        private void btnCopyFromRight_Click(object sender, EventArgs e)
        {

        }
}
}
