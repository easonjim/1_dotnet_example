using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;

namespace ConsoleApplication_Test
{
    internal static class WinLogonHelper
    {
        /// <summary>
        /// 模拟windows登录域
        /// </summary>
        [DllImport("advapi32.DLL", SetLastError = true)]
        public static extern int LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);
    }

    class Program
    {
        static void Main(string[] args)
        {
            IntPtr admin_token = default(IntPtr);
            WindowsIdentity wid_admin = null;
            WindowsImpersonationContext wic = null;

            //在程序中模拟域帐户登录
            if (WinLogonHelper.LogonUser("User1", "10.18.66.101", "123456", 9, 0, ref admin_token) != 0)
            {
                using (wid_admin = new WindowsIdentity(admin_token))
                {
                    using (wic = wid_admin.Impersonate())
                    {
                        System.IO.File.Create(@"\\10.18.66.101\Upload\test.txt");
                    }
                }
            }
        }
    }
}
