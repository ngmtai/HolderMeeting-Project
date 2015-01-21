using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Model
{
   public class ReportDto
   {
       public string Title { set; get; }

       public string VoteName { set; get; }

       public string TotalYes { set; get; }

       public string TotalYesPercent { set; get; }

       public string TotalNo{set; get; }

       public string TotalNoPercent { set; get; }

       public string TotalOther { set; get; }

       public string TotalOtherPercent { set; get; }

       public string OtherText { set; get; }

   }
}
