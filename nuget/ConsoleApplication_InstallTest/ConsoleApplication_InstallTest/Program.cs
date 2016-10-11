using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using Easemob.Restfull4Net;
using Easemob.Restfull4Net.Entity.Request;
using Yunsoft.Json;

namespace ConsoleApplication_InstallTest
{
    class Program
    {
        private static string _userName
        {
            get
            {
                Thread.Sleep(100);
                return DateTime.Now.ToString("yyyyMMddHHmmssffff");
            }
        } //用户名

        static void Main(string[] args)
        {
            var json = new JsonObject();
            json.Put("a","b");
            /*//单个创建
            var syncRequest = Client.DefaultSyncRequest;

            var user = syncRequest.UserCreate(new UserCreateReqeust()
            {
                nickname = string.Concat("Test", _userName),
                password = "123456",
                username = string.Concat("Test", _userName),
            });
            System.Console.Write((user.StatusCode == HttpStatusCode.OK).ToString());*/
        }
    }
}
