using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace UMB_DAC
{
    public class ConnectionAccess
    {
        protected string ConnectionString
        {
            get
            {
                string currentPath = System.IO.Directory.GetCurrentDirectory();
                string strConn = string.Empty;
                XmlDocument configXml = new XmlDocument();
                string path = currentPath + "/Sample_DEV.xml";
                configXml.Load(path);

                XmlNodeList addNodes = configXml.SelectNodes("configuration/settings/add");

                foreach (XmlNode node in addNodes)
                {
                    if (node.Attributes["key"].InnerText == "Team6")
                    {
                        EncrytLibrary.AES aes = new EncrytLibrary.AES();
                        strConn = aes.AESDecrypt256((node.ChildNodes[0]).InnerText);
                        break;
                    }
                }

                return strConn;
            }
        }
    }
}
