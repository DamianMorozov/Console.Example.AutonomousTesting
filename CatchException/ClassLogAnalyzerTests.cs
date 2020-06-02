using NSubstitute;
using NUnit.Framework;
using System;

namespace ExampleCatchExceptTests
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
        public void IsValidFileName_ValidExtensions_Check(string fileName, bool expected)
        {
            var result = _log.IsValidFileName(fileName);
            TestContext.WriteLine(@"var result = " + nameof(_log) + @".IsValidFileName(fileName);");
            TestContext.WriteLine(@"result = " + result);
            Assert.AreEqual(expected, result);
        }

        [TestCase(@"")]
        [TestCase(null)]
        public void IsValidFileName_CatchException_ThrowsException(string fileName)
        {
            var result = Assert.Catch<Exception>(() => _log.IsValidFileName(fileName));
            TestContext.WriteLine(@"var result = Assert.Catch<Exception>(() => " + nameof(_log) + @".IsValidFileName(fileName));");
            TestContext.WriteLine(@"result.Message = " + result.Message);
            StringAssert.Contains(@"FileName must be", result.Message);
        }

        [TestCase(@"")]
        [TestCase(null)]
        public void IsValidFileName_CatchException_ThrowsFluent(string fileName)
        {
            var result = Assert.Catch<ArgumentException>(() => _log.IsValidFileName(fileName));
            TestContext.WriteLine(@"var result = Assert.Catch<ArgumentException>(() => _log.IsValidFileName(fileName));");
            TestContext.WriteLine(@"result.Message = " + result.Message);
            Assert.That(result.Message, Does.Contain(@"FileName must be"));
        }
    }
}
