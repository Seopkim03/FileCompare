using System.IO;
using System.Linq;
using System.Collections.Generic;
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

        // 화면의 양쪽 리스트를 최신 상태로 다시 불러오는 함수
        private void RefreshLists()
        {
            // txtLeftDir와 txtRightDir는 경로가 입력된 텍스트박스 이름입니다.
            PopulateListView(lvwLeftDir, txtLeftDir.Text);
            PopulateListView(lvwRightDir, txtRightDir.Text);

            // 만약 색상 비교 함수가 따로 있다면 여기서 같이 호출해줍니다.
            // ApplyComparisonColors(); 
        }

        // [왼쪽 -> 오른쪽 복사]
        private void btnCopyFromLeft_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtLeftDir.Text) || lvwLeftDir.SelectedItems.Count == 0) return;

            foreach (ListViewItem item in lvwLeftDir.SelectedItems)
            {
                string sourcePath = Path.Combine(txtLeftDir.Text, item.Text);
                string destPath = Path.Combine(txtRightDir.Text, item.Text);

                if (Directory.Exists(sourcePath)) // 폴더인 경우
                {
                    CopyDirectory(sourcePath, destPath);
                }
                else if (File.Exists(sourcePath)) // 파일인 경우
                {
                    DoCopyFile(sourcePath, destPath);
                }
            }
            RefreshLists(); // 복사 후 양쪽 새로고침
            //MessageBox.Show("복사 작업이 완료되었습니다!");
        }
        // [오른쪽 -> 왼쪽 복사]
        private void btnCopyFromRight_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtRightDir.Text) || lvwRightDir.SelectedItems.Count == 0) return;

            foreach (ListViewItem item in lvwRightDir.SelectedItems)
            {
                string sourcePath = Path.Combine(txtRightDir.Text, item.Text);
                string destPath = Path.Combine(txtLeftDir.Text, item.Text);

                if (Directory.Exists(sourcePath)) // 폴더인 경우
                {
                    CopyDirectory(sourcePath, destPath);
                }
                else if (File.Exists(sourcePath)) // 파일인 경우
                {
                    DoCopyFile(sourcePath, destPath);
                }
            }
            RefreshLists(); // 복사 후 양쪽 새로고침
            //MessageBox.Show("복사 작업이 완료되었습니다!");
        }

        // [공용 복사 로직: 날짜 비교 포함]
        private bool DoCopyFile(string srcPath, string destPath)
        {
            try
            {
                if (File.Exists(destPath))
                {
                    DateTime srcTime = File.GetLastWriteTime(srcPath);
                    DateTime destTime = File.GetLastWriteTime(destPath);
    
                    // 대상 파일이 더 최신인 경우 질문
                    if (srcTime < destTime)
                    {
                        var result = MessageBox.Show(
                            $"{Path.GetFileName(destPath)} 파일이 대상에 더 최신 버전으로 있습니다. 덮어쓰시겠습니까?",
                            "버전 경고", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
    
                        if (result == DialogResult.No) return false;
                    }
                }
    
                File.Copy(srcPath, destPath, true); // 복사 실행
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("복사 중 오류 발생: " + ex.Message);
                return false;
            }
        }
        // 폴더 통째로 복사하는 함수 (재귀)
        private void CopyDirectory(string sourceDir, string destDir)
        {
            // 대상 폴더가 없으면 생성
            Directory.CreateDirectory(destDir);

            // 1. 모든 파일 복사
            foreach (string file in Directory.GetFiles(sourceDir))
            {
                string fileName = Path.GetFileName(file);
                string destFile = Path.Combine(destDir, fileName);

                // 파일 복사 (기존에 만든 DoCopyFile 활용하여 버전 체크 가능)
                DoCopyFile(file, destFile);
            }

            // 2. 모든 하위 폴더 복사 (자기 자신을 다시 호출 - 재귀)
            foreach (string directory in Directory.GetDirectories(sourceDir))
            {
                string dirName = Path.GetFileName(directory);
                string destSubDir = Path.Combine(destDir, dirName);
                CopyDirectory(directory, destSubDir);
            }
        }
    }
}
