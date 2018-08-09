using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToXMLParser;

namespace URLParser
{
    class Program
    {
        static void Main(string[] args)
        {
            XMLParser urls = new XMLParser("URLS.txt");
            urls.XMLSaver();
        }
    }
}
