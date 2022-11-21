using FinalFramework.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFramework.Reporter
{
    internal class HtmlReportDirectory
    {
    public static string Report_Root { get; set; }
    public static string Report_Folder_Path { get; set; }
    public static string Report_File_Path { get; set; }
    public static string Screenshot_Path { get; set; }

    public static void InitReportDirection()
    {
        string projectPath = FilePath.GetCurrentDirectoryPath();
        Report_Root = projectPath + "\\Reports";
        Report_Folder_Path = Report_Root + "\\Latest Reports";
        Report_File_Path = Report_Folder_Path + "\\report.html";
        Screenshot_Path = Report_File_Path + "\\Screenshot";

        FilePath.CreateIfNotExists(Report_Root);
        checkExistReportAndRename(Report_Folder_Path);
        FilePath.CreateIfNotExists(Report_Folder_Path);
        FilePath.CreateIfNotExists(Report_File_Path);
        FilePath.CreateIfNotExists(Screenshot_Path);
    }

    private static void checkExistReportAndRename(string reportFolder)
    {
        if (Directory.Exists(reportFolder))
        {
            DirectoryInfo dirInfo = new DirectoryInfo(reportFolder);
            var newPath = Report_Root + "\\Report_" + dirInfo.CreationTime.ToString().Replace(":", ".").Replace("/", "-");
            Directory.Move(reportFolder, newPath);
        }
    }
}
}
