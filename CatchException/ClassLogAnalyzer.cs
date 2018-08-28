using System;

namespace CatchException
{
    public class ClassLogAnalyzer
    {
        public bool IsValidFileName(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentException(@"FileName must be setup.");

            if (fileName.EndsWith(@".SLF", System.StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }
            return false;
        }
    }
}
