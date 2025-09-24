namespace MainUI.Service
{
    /// <summary>
    /// 报表服务类 - 包含加载、保存和翻页功能
    /// </summary>
    public class ReportService(string reportsPath, RW.UI.Controls.Report.RWReport report = null)
    {
        // 当前行数
        public int CurrentRows { get; private set; } = 1;
        // 最大行数，默认为1000行
        public int MaxRows { get; set; } = 1000;

        /// <summary>
        /// 获取报表文件完整路径
        /// </summary>
        /// <param name="fileName">报表文件名</param>
        /// <returns>完整路径</returns>
        public string GetReportFilePath(string fileName)
        {
            return Path.Combine(reportsPath, fileName);
        }

        /// <summary>
        /// 获取默认报表路径
        /// </summary>
        /// <returns>工作报表路径</returns>
        public static string GetDefaultReportPath()
        {
            return Path.Combine(Application.StartupPath, "reports\\");
        }

        /// <summary>
        /// 获取工作报表路径
        /// </summary>
        /// <returns>工作报表路径</returns>
        public static string GetWorkingReportPath()
        {
            return Path.Combine(Application.StartupPath, "reports", "report.xlsx");
        }

        /// <summary>
        /// 验证报表文件是否存在
        /// </summary>
        /// <param name="fileName">报表文件名</param>
        /// <returns>是否存在</returns>
        public bool FileExists(string fileName)
        {
            string filePath = GetReportFilePath(fileName);
            return File.Exists(filePath);
        }

        /// <summary>
        /// 复制报表文件到工作目录
        /// </summary>
        /// <param name="fileName">源文件名</param>
        /// <param name="targetPath">目标路径</param>
        public void CopyReportFile(string fileName, string targetPath)
        {
            string sourceFile = GetReportFilePath(fileName);
            File.Copy(sourceFile, targetPath, true);
        }

        /// <summary>
        /// 构建保存文件路径
        /// </summary>
        /// <param name="modelName">型号名称</param>
        /// <returns>保存文件路径</returns>
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
        /// 保存测试记录
        /// </summary>
        /// <param name="testRecord">测试记录</param>
        /// <returns>是否保存成功</returns>
        public static bool SaveTestRecord(TestRecordModel testRecord)
        {
            try
            {
                TestRecordNewBLL testRecordBLL = new();
                return testRecordBLL.SaveTestRecord(testRecord);
            }
            catch (Exception ex)
            {
                NlogHelper.Default.Error("保存测试记录失败", ex);
                return false;
            }
        }

        #region 报表翻页功能

        /// <summary>
        /// 向上翻页
        /// </summary>
        /// <param name="pageSize">翻页行数</param>
        /// <returns>翻页后的行索引和按钮状态</returns>
        public (int currentRows, bool upEnabled, bool downEnabled) PageUp(int pageSize)
        {
            CurrentRows -= pageSize;

            if (CurrentRows < 1)
            {
                CurrentRows = 1;
            }

            // 执行报表滚动
            report?.ScrollIndex(CurrentRows);

            return GetPageButtonStates();
        }

        /// <summary>
        /// 向下翻页
        /// </summary>
        /// <param name="pageSize">翻页行数</param>
        /// <returns>翻页后的行索引和按钮状态</returns>
        public (int currentRows, bool upEnabled, bool downEnabled) PageDown(int pageSize)
        {
            CurrentRows += pageSize;

            if (CurrentRows > MaxRows)
            {
                CurrentRows = 1; // 循环到第一页
            }

            // 执行报表滚动
            report?.ScrollIndex(CurrentRows);

            return GetPageButtonStates();
        }

        /// <summary>
        /// 跳转到指定行
        /// </summary>
        /// <param name="targetRow">目标行</param>
        /// <returns>跳转后的行索引和按钮状态</returns>
        public (int currentRows, bool upEnabled, bool downEnabled) ScrollToRow(int targetRow)
        {
            if (targetRow < 1) targetRow = 1;
            if (targetRow > MaxRows) targetRow = MaxRows;

            CurrentRows = targetRow;
            report?.ScrollIndex(CurrentRows);

            return GetPageButtonStates();
        }

        /// <summary>
        /// 重置到第一页
        /// </summary>
        /// <returns>重置后的行索引和按钮状态</returns>
        public (int currentRows, bool upEnabled, bool downEnabled) ResetToFirstPage()
        {
            CurrentRows = 1;
            report?.ScrollIndex(CurrentRows);
            return GetPageButtonStates();
        }

        /// <summary>
        /// 获取翻页按钮的启用状态
        /// </summary>
        /// <returns>上翻和下翻按钮的启用状态</returns>
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