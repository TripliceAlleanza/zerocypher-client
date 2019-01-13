namespace CommandParserUnitTest {
    using System;
    using CommandParser.Parser;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ParsingTest {
        [TestMethod]
        public void Parse() {
            CommandAnalyser com = new CommandAnalyser();
            com.Write = Write;
            //Assert.IsFalse(com.TESTING);
            com.Execute("Help");
            //Assert.IsTrue(com.TESTING);
            
        }
        private void Write(string write) {
            Console.Write(write);
        }
    }
}
