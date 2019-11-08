using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


namespace RegExprForXml
{
    public class Parser
    {
        static string chars = "\\w+";
        static string attribute = $"(?<AttrName>{chars})=(?<AttrValue>{chars})";
        static string node = $"(?<Node>{chars})";
        static string regStr = $"{node}(\\({attribute}(,{attribute})*\\)){{0,1}}";
        static string nodeList = $"(?<NodeList>{regStr})(\\.(?<NodeList>{regStr}))*";
        static string value = "=(?<Value>\\w+)";
        static string element = $"{nodeList}({value}){{0,1}}";

        public Match fun1(string str)
        {
            Regex regex = new Regex(element);
            Match match = regex.Match(str);
            return regex.Match(str);
        }

        public Match fun2(string str)
        {
            Regex regex1 = new Regex(regStr);
            Match match = regex1.Match(str);
            return match;
        }
    }
}
