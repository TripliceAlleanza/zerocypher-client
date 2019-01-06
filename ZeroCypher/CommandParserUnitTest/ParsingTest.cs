using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CommandParser.Parser;

namespace CommandParserUnitTest {
    [TestClass]
    public class ParsingTest {
        [TestMethod]
        public void Parse() {
            CommandAnalyser com = new CommandAnalyser();
            Assert.IsFalse(com.TESTING);
            com.Execute("Help");
            Assert.IsTrue(com.TESTING);
        }
    }
}
