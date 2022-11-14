using CoreFramework.Utilities;
namespace CoreFramework.Reporter
{
    internal class HtmlReportDirectory
    {
        public static string REPORT_ROOT { get; set; }
        public static string REPORT_FOLDER_PATH { get; set; }
        public static string REPORT_FILE_PATH { get; set; }
        public static string SCREENSHOT_PATH { get; set; }
        public static string ACTUAL_SCREENSHOT_PATH { get; set; }
        public static string DIFFERECE_SCREENSHOT_PATH { get; set; }
        public static string BASELINE_SCREENSHOT_PATH { get; set; }
        public static void InitReportDirection()
        {
            string projectPath = FilePath.GetCurrentDirectoryPath();
            REPORT_ROOT = projectPath + "\\Reports";
            REPORT_FOLDER_PATH = REPORT_ROOT + "\\Latest Reports";
            REPORT_FILE_PATH = REPORT_FOLDER_PATH + "\\report.html";
            SCREENSHOT_PATH = REPORT_FILE_PATH + "\\Screenshot";

            ACTUAL_SCREENSHOT_PATH = REPORT_FOLDER_PATH + "\\Actual";
            DIFFERECE_SCREENSHOT_PATH = REPORT_FOLDER_PATH + "\\Difference";
            BASELINE_SCREENSHOT_PATH = FilePath.GetCurrentDirectoryPath() + "\\Resources\\BaseLine";

            FilePath.CreateIfNotExists(REPORT_ROOT);
            checkExistReportAndRename(REPORT_FOLDER_PATH);
            FilePath.CreateIfNotExists(REPORT_FOLDER_PATH);
            FilePath.CreateIfNotExists(REPORT_FILE_PATH);
            FilePath.CreateIfNotExists(SCREENSHOT_PATH);

            FilePath.CreateIfNotExists(ACTUAL_SCREENSHOT_PATH);
            FilePath.CreateIfNotExists(DIFFERECE_SCREENSHOT_PATH);
            FilePath.CreateIfNotExists(BASELINE_SCREENSHOT_PATH);


        }
        public static void checkExistReportAndRename(String reportFolder)
        {
            if (Directory.Exists(reportFolder))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(reportFolder);
                var newPath = REPORT_ROOT + "\\Report_" + dirInfo.CreationTime.ToString().Replace(":", ".").Replace("/", "-");
                Directory.Move(reportFolder, newPath);
            }
        }
    }
}
