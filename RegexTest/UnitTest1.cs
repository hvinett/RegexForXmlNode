
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegExprForXml;

namespace regexTest
{
    [TestClass]
    public class UnitTest1
    {
        [DataRow(new string[] { "node" }, new string[] { "node" }, "node", null)]
        [DataRow(new string[] { "node(a=b)" }, new string[] { "node" }, "node(a=b)=value", "value")]
        [DataRow(new string[] { "node(b=c)", "node" }, new string[] { "node", "node" }, "node(b=c).node=value", "value")]
        [DataRow(new string[] { "node(a=b,c=d)", "node" }, new string[] { "node", "node" }, "node(a=b,c=d).node=value", "value")]
        [DataRow(new string[] { "node1" }, new string[] { "node1" }, "node1=value", "value")]
        [TestMethod]
        public void TestMethod2(string[] nodeList, string[] nodeNameList, string str, string value)
        {
            Parser parser = new Parser();
            var match = parser.fun1(str);
            if (match.Groups["NodeList"].Captures.Count > 0 && match.Groups["NodeList"].Captures.Count == nodeList.Length)
            {
                for (var i = 0; i < match.Groups["NodeList"].Captures.Count; i++)
                    Assert.AreEqual(match.Groups["NodeList"].Captures[i].Value, nodeList[i]);
            }
            if (value != null || match.Groups["Value"].Captures.Count > 0)
                Assert.AreEqual(match.Groups["Value"].Captures[0].Value, value);
        }

        [DataRow(".node.node(a=b)(a=d)")]
        [DataRow("node(a=b,c=d)node")]
        [DataRow("node(a=b)=value=value")]
        [DataRow("node(a=b)==value")]
        [DataRow("node(a=b)=value=")]
        [DataRow("node(a=b)=")]
        [TestMethod]
        public void TestMethod5(string str)
        {
            Parser parser = new Parser();
            var match = parser.fun2(str);
            Assert.AreNotEqual(match.Value, str);
        }

        [DataRow(new string[] { "a" }, new string[] { "b" }, "node(a=b)", "node")]
        [DataRow(new string[] { "a", "c" }, new string[] { "b", "d" }, "node(a=b,c=d)", "node")]
        [DataRow(new string[] { }, new string[] { }, "node", "node")]
        [TestMethod]
        public void TestMethod3(string[] AttrNameList, string[] AttrValueList, string str, string node)
        {
            Parser parser = new Parser();
            var match = parser.fun2(str);
            if (match.Groups["AttrName"].Captures.Count > 0 && match.Groups["AttrName"].Captures.Count == AttrNameList.Length)
            {
                for (var i = 0; i < match.Groups["AttrName"].Captures.Count; i++)
                    Assert.AreEqual(match.Groups["AttrName"].Captures[i].Value, AttrNameList[i]);
            }

            if (match.Groups["AttrValue"].Captures.Count > 0 && match.Groups["AttrValue"].Captures.Count == AttrValueList.Length)
            {
                for (var i = 0; i < match.Groups["AttrValue"].Captures.Count; i++)
                {
                    Assert.AreEqual(match.Groups["AttrValue"].Captures[i].Value, AttrValueList[i]);
                }
            }

            Assert.AreEqual(match.Groups["Node"].Captures[0].Value, node);
        }

        [DataRow("node()")]
        [DataRow("node(a=b)(a=d)")]
        [DataRow("node(a=b c=d)")]
        [DataRow("node(=)")]
        [DataRow("node(a=)")]
        [DataRow("node(=a)")]
        [DataRow("node(b=a=)")]
        [TestMethod]
        public void TestMethod4(string str)
        {
            Parser parser = new Parser();
            var match = parser.fun2(str);
            Assert.AreNotEqual(match.Value, str);
        }
    }
}
