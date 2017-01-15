using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Parser
    {
        public static string Parse(string parsingString)
        {
            string ret = string.Empty;

            ret = parsingString.Split(' ')[1];

            return ret;
        }
    }
}
