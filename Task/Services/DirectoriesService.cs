using System;
using System.IO;

namespace Task.Services
{
    public static class DirectoriesService
    {
        private const string resultDirectory = "Result";
        private const string xlsTemplateDirectory = "Template";

        public static void CreateResultDirectory()
        {
            string resultDirPath = DirectoriesService.GetResultDirectoryPath();

            if (!Directory.Exists(resultDirPath))
            {
                Directory.CreateDirectory(resultDirPath);
            }
        }

        public static string GetResultDirectoryPath()
        {
            return Path.Combine(GetProjectRootDirectory(), resultDirectory);
        }

        public static string GetXlsTemplateDirectoryPath()
        {
            return Path.Combine(GetProjectRootDirectory(), xlsTemplateDirectory);
        }

        private static string GetProjectRootDirectory()
        {
            return Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
        }
    }
}
