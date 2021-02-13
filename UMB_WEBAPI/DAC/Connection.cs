using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Xml;

namespace UMB_WEBAPI.DAC
{
    public class Connection
    {
        protected string ConnectionString
        {
            get
            {
                EncrytLibrary.AES aes = new EncrytLibrary.AES();
                string strConn = aes.AESDecrypt256(WebConfigurationManager.ConnectionStrings["DB"].ConnectionString);

                return strConn;
            }
        }
    }
}