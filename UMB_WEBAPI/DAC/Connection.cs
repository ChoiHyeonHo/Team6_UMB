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
                string strConn = aes.AESDecrypt256("i6pa+AHin2K+66qIB5p0uzito3JITwRxyQcdJqaZpaOt9YPp/nAdHd+PQ8jvsBUPlubhPSagYyNip5ZA7Yk/H+wefTdlHI+wHHPPuGVZI0c=");

                return strConn;
            }
        }
    }
}