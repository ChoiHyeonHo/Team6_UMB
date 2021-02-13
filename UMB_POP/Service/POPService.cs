using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_DAC;

namespace UMB_POP.Service
{
    public class POPService
    {
        public void Login(int ID, int Pwd)
        {
            LoginDAC dac = new LoginDAC();
            dac.Login(ID, Pwd);
        }
    }
}
