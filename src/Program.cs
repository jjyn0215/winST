using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winST
{
    internal static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Dictionary를 이용하여, ID와 PW를 1:1 맵핑
            //Dictionary<string, string> credentials = new Dictionary<string, string>();
            Application.Run(new Form1(null));
        }
    }
}
