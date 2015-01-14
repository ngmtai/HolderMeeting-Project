using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace BLL.Common
{
    public class BoConstant
    {
        public class Config
        {
            public static string ConnectionNonAuthor = "integrated security=True";
            public static string ConnectionAuthorize = "user id={0}; password={1}";
            public static string ConnectionTemp = "Data source={0};initial catalog=HolderMeeting;{1};MultipleActiveResultSets=True";
            public static string ConnectionString = string.Empty;
        }

        public enum AnswerType
        {
            No = 0,
            Yes = 1,
            Other = 2
        }
    }
}
