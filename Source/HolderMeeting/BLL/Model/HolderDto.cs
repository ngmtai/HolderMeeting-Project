using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Model
{
    public class HolderDto
    {
        public int Id { set; get; }

        public string Code { set; get; }

        public string Name { set; get; }

        public string AuthorizerName { set; get; }

        public string TotalShare { set; get; }

        public string UpdateDate { set; get; }

        public string CreateDate { set; get; }

        public bool IsConfirm { set; get; }

        public bool IsVote { set; get; }
    }
}
