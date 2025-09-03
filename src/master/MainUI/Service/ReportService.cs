namespace MainUI.Service
{
    /// <summary>
    /// ��������࣬�ṩ�������ļ��Ĺ��ܣ�������ʼ�����ļ�·�����ɺͱ�����Լ�¼
    /// </summary>
    /// <param name="reportPath">����·��</param>
    public class ReportService(string reportPath)
    {
        private string _reportFilename;
        private string _reportFilePath;

        /// <summary>
        /// ��ʼ�������ļ�
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public string InitializeReportFile(ParaConfig config)
        {
            _reportFilename = config.RptFile;
            _reportFilePath = Path.GetFileNameWithoutExtension(_reportFilename);

            string rptPath = Path.Combine(Application.StartupPath, "reports", _reportFilePath);

            Directory.CreateDirectory(Path.GetDirectoryName(reportPath));
            File.Copy($"{rptPath}.xlsx", reportPath, true);

            return rptPath;
        }

        /// <summary>
        /// ���������ļ�·��
        /// </summary>
        /// <param name="modelName">�ͺ�����</param>
        /// <returns></returns>
        public string BuildSaveFilePath(string modelName)
        {
            string rootPath = Path.Combine(Application.StartupPath, "Save");
            Directory.CreateDirectory(rootPath);

            string fileName = $"{modelName}_{DateTime.Now:yyyyMMddHHmmss}";
            return Path.Combine(rootPath, fileName);
        }

        /// <summary>
        /// ������Լ�¼
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="record"></param>
        public void SaveTestRecord(string filePath, TestRecordModel record)
        {
            var recordBll = new TestRecordNewBLL();
            recordBll.SaveTestRecord(record);
        }
    }
}