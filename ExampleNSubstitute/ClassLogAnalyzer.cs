namespace ExampleNSubstitute
{
    public class ClassLogAnalyzer
    {
        public bool IsValidFileName(string fileName)
        {
            if (fileName.EndsWith(@".SLF", System.StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }
            return false;
        }
    }
}
