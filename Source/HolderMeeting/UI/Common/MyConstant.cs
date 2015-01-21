using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace UI.Common
{
    public class MyConstant
    {
        public class Config
        {
            public static string IpAddress = string.Empty;
            public static string KeyWordCondition = "Condition";
            public static string KeyWordVote = "Vote";
            public static string KeyWordConnect = "Connect";
        }

        public enum AnswerType
        {
            No = 0,
            Yes = 1,
            Other = 2
        }
    }
}
