using NSubstitute;
using NUnit.Framework;
using System;

namespace CatchException
{
    [TestFixture]
    public class ClassLogAnalyzerTests
    {
        private ClassLogAnalyzer _log;

        /// <summary>
        /// Setup Design pattern Singleton and private fields
        /// </summary>
        [SetUp]
        public void Setup()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            _log = Substitute.ForPartsOf<ClassLogAnalyzer>();
            TestContext.WriteLine(@"var " + nameof(_log) + @" = Substitute.ForPartsOf<ClassLogAnalyzer>();");
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
        }

        /// <summary>
        /// Reset Design pattern Singleton and private fields to default state
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            _log = null;
        }

        [TestCase(@"somefile.slf", true)]
        [TestCase(@"SOMEFILE.SLF", true)]
        [TestCase(@"otherfile.foo", false)]
        public void IsValidFileName_ValidExtensions(string fileName, bool expected)
        {
            var result = _log.IsValidFileName(fileName);
            TestContext.WriteLine(@"var result = " + nameof(_log) + @".IsValidFileName(fileName);");
            TestContext.WriteLine(@"result = " + result);
            Assert.AreEqual(expected, result);
        }

        [TestCase(@"", false)]
        [TestCase(null, false)]
        public void IsValidFileName_CatchException(string fileName, bool expected)
        {
            var result = Assert.Catch<Exception>(() => _log.IsValidFileName(fileName));
            TestContext.WriteLine(@"var result = Assert.Catch<Exception>(() => " + nameof(_log) + @".IsValidFileName(fileName));");
            TestContext.WriteLine(@"result.Message = " + result.Message);
            StringAssert.Contains(@"FileName must be", result.Message);
        }
    }
}
