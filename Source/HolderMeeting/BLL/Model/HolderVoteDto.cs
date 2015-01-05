using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Model
{
   public class HolderVoteDto
    {
       public string VoteName { set; get; }

       public string AnswerName { set; get; }

       public decimal? TotalShared { set; get; }

       public DateTime CreateDate { set; get; }
    }
}
