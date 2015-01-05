using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Common;
using DAL;

namespace BLL
{
    public class HolderVoteBusiness
    {
        private readonly HolderMeetingEntities _holderMeetingEntities;

        public HolderVoteBusiness()
        {
            _holderMeetingEntities = new HolderMeetingEntities(BoCommon.Connect());
        }

        /// <summary>
        /// Count holder vote
        /// </summary>
        /// <param name="holderId"></param>
        /// <returns></returns>
        /// <history>
        /// 12/23/2014 aBc: create new
        /// </history>
        public int CountVoteByHolder(int holderId)
        {
            try
            {
                return
                    _holderMeetingEntities.Holder_Vote.Count(t => t.IsActive == true && t.HolderId == holderId);
            }
            catch (Exception)
            {
            }

            return 0;
        }

        /// <summary>
        /// Get total holder is vote
        /// </summary>
        /// <returns></returns>
        /// <history>
        /// 12/23/2014 aBc: create new
        /// </history>
        public int TotalHolderVote()
        {
            try
            {
                return _holderMeetingEntities.Holder_Vote.Where(t => t.IsActive == true).Select(t => t.HolderId).Distinct().Count();
            }
            catch { }

            return 0;
        }

        /// <summary>
        /// Get total shared is vote
        /// </summary>
        /// <returns></returns>
        /// <history>
        /// 12/23/2014 aBc: create new
        /// </history>
        public decimal TotalShareIsVote()
        {
            try
            {
                return _holderMeetingEntities.Holder_Vote.Where(t => t.IsActive == true).Sum(t => t.TotalShare.Value);
            }
            catch { }

            return 0;
        }

        /// <summary>
        /// Get current share is holder
        /// </summary>
        /// <param name="holderId"></param>
        /// <returns></returns>
        /// <history>
        /// 12/23/2014 aBc: create new
        /// </history>
        public decimal TotalSharedIsVote(int holderId)
        {
            try
            {
                return
                    _holderMeetingEntities.Holder_Vote.Where(t => t.IsActive == true && t.HolderId == holderId)
                        .Sum(t => t.TotalShare.Value);
            }
            catch { }

            return 0;
        }

        /// <summary>
        /// Add list holder_vote
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        /// <history>
        /// 12/24/2014 aBc: create new
        /// </history>
        public bool Saves(List<Holder_Vote> lst)
        {
            try
            {
                _holderMeetingEntities.Holder_Vote.AddRange(lst);
                _holderMeetingEntities.SaveChanges();

                return true;
            }
            catch { }

            return false;
        }
    }
}
