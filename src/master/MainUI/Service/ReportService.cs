namespace MainUI.Service
{
    /// <summary>
    /// ��������� - �������ء�����ͷ�ҳ����
    /// </summary>
    public class ReportService(string reportsPath, RW.UI.Controls.Report.RWReport report = null)
    {
        // ��ǰ����
        public int CurrentRows { get; private set; } = 1;
        // ���������Ĭ��Ϊ1000��
        public int MaxRows { get; set; } = 1000;

        /// <summary>
        /// ��ȡ�����ļ�����·��
        /// </summary>
        /// <param name="fileName">�����ļ���</param>
        /// <returns>����·��</returns>
        public string GetReportFilePath(string fileName)
        {
            return Path.Combine(reportsPath, fileName);
        }

        /// <summary>
        /// ��ȡĬ�ϱ���·��
        /// </summary>
        /// <returns>��������·��</returns>
        public static string GetDefaultReportPath()
        {
            return Path.Combine(Application.StartupPath, "reports\\");
        }

        /// <summary>
        /// ��ȡ��������·��
        /// </summary>
        /// <returns>��������·��</returns>
        public static string GetWorkingReportPath()
        {
            return Path.Combine(Application.StartupPath, "reports", "report.xlsx");
        }

        /// <summary>
        /// ��֤�����ļ��Ƿ����
        /// </summary>
        /// <param name="fileName">�����ļ���</param>
        /// <returns>�Ƿ����</returns>
        public bool FileExists(string fileName)
        {
            string filePath = GetReportFilePath(fileName);
            return File.Exists(filePath);
        }

        /// <summary>
        /// ���Ʊ����ļ�������Ŀ¼
        /// </summary>
        /// <param name="fileName">Դ�ļ���</param>
        /// <param name="targetPath">Ŀ��·��</param>
        public void CopyReportFile(string fileName, string targetPath)
        {
            string sourceFile = GetReportFilePath(fileName);
            File.Copy(sourceFile, targetPath, true);
        }

        /// <summary>
        /// ���������ļ�·��
        /// </summary>
        /// <param name="modelName">�ͺ�����</param>
        /// <returns>�����ļ�·��</returns>
        public static string BuildSaveFilePath(string modelName)
        {
            string dateFolder = DateTime.Now.ToString("yyyy-MM-dd");
            string timestamp = DateTime.Now.ToString("HHmmss");
            string saveDirectory = Path.Combine(Application.StartupPath, "Save", dateFolder);

            if (!Directory.Exists(saveDirectory))
                Directory.CreateDirectory(saveDirectory);

            return Path.Combine(saveDirectory, $"{modelName}_{timestamp}.xlsx");
        }

        /// <summary>
        /// ������Լ�¼
        /// </summary>
        /// <param name="testRecord">���Լ�¼</param>
        /// <returns>�Ƿ񱣴�ɹ�</returns>
        public static bool SaveTestRecord(TestRecordModel testRecord)
        {
            try
            {
                TestRecordNewBLL testRecordBLL = new();
                return testRecordBLL.SaveTestRecord(testRecord);
            }
            catch (Exception ex)
            {
                NlogHelper.Default.Error("������Լ�¼ʧ��", ex);
                return false;
            }
        }

        #region ����ҳ����

        /// <summary>
        /// ���Ϸ�ҳ
        /// </summary>
        /// <param name="pageSize">��ҳ����</param>
        /// <returns>��ҳ����������Ͱ�ť״̬</returns>
        public (int currentRows, bool upEnabled, bool downEnabled) PageUp(int pageSize)
        {
            CurrentRows -= pageSize;

            if (CurrentRows < 1)
            {
                CurrentRows = 1;
            }

            // ִ�б������
            report?.ScrollIndex(CurrentRows);

            return GetPageButtonStates();
        }

        /// <summary>
        /// ���·�ҳ
        /// </summary>
        /// <param name="pageSize">��ҳ����</param>
        /// <returns>��ҳ����������Ͱ�ť״̬</returns>
        public (int currentRows, bool upEnabled, bool downEnabled) PageDown(int pageSize)
        {
            CurrentRows += pageSize;

            if (CurrentRows > MaxRows)
            {
                CurrentRows = 1; // ѭ������һҳ
            }

            // ִ�б������
            report?.ScrollIndex(CurrentRows);

            return GetPageButtonStates();
        }

        /// <summary>
        /// ��ת��ָ����
        /// </summary>
        /// <param name="targetRow">Ŀ����</param>
        /// <returns>��ת����������Ͱ�ť״̬</returns>
        public (int currentRows, bool upEnabled, bool downEnabled) ScrollToRow(int targetRow)
        {
            if (targetRow < 1) targetRow = 1;
            if (targetRow > MaxRows) targetRow = MaxRows;

            CurrentRows = targetRow;
            report?.ScrollIndex(CurrentRows);

            return GetPageButtonStates();
        }

        /// <summary>
        /// ���õ���һҳ
        /// </summary>
        /// <returns>���ú���������Ͱ�ť״̬</returns>
        public (int currentRows, bool upEnabled, bool downEnabled) ResetToFirstPage()
        {
            CurrentRows = 1;
            report?.ScrollIndex(CurrentRows);
            return GetPageButtonStates();
        }

        /// <summary>
        /// ��ȡ��ҳ��ť������״̬
        /// </summary>
        /// <returns>�Ϸ����·���ť������״̬</returns>
        private (int currentRows, bool upEnabled, bool downEnabled) GetPageButtonStates()
        {
            bool upEnabled = CurrentRows > 1;
            bool downEnabled = CurrentRows < MaxRows;

            return (CurrentRows, upEnabled, downEnabled);
        }

        #endregion
    }

    static class Constants
    {
        public const string ReportsPath = @"reports\report.xlsx";
    }
}