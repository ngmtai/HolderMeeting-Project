using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.Common;
using DAL;

namespace BLL
{
    public class CompanyBusiness
    {
        private readonly HolderMeetingEntities _holderMeetingEntities;

        public CompanyBusiness()
        {
            _holderMeetingEntities = new HolderMeetingEntities(BoCommon.Connect());
        }

        /// <summary>
        /// Get detail company
        /// </summary>
        /// <returns></returns>
        /// <history>
        /// 12/23/2014 aBc: create new
        /// </history>
        public Company Detail()
        {
            try
            {
                return _holderMeetingEntities.Companies.FirstOrDefault();
            }
            catch { }

            return new Company();
        }
    }
}
