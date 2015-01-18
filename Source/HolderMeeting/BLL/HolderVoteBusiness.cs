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

        /// <summary>
        /// Get total share by answerType
        /// </summary>
        /// <param name="answerType"></param>
        /// <param name="voteId"></param>
        /// <returns></returns>
        /// <history>
        /// 1/17/2015 aBc: create new
        /// </history>
        public decimal TotalSharedByAnswerType(int answerType, int voteId)
        {
            try
            {
                var aBc = _holderMeetingEntities.Holder_Vote.Where(t => t.VoteId == voteId && t.AnswerType == answerType && t.IsActive == true).Select(t => t.TotalShare).ToList();
                decimal total = 0;
                foreach (var item in aBc)
                    total += item.Value;
                return total;
            }
            catch { }

            return 0;
        }

        /// <summary>
        /// Get top answerName by other
        /// </summary>
        /// <param name="top"></param>
        /// <param name="answerTypeId"></param>
        /// <param name="voteId"></param>
        /// <returns></returns>
        /// <history>
        /// 1/17/2015 aBc: create new
        /// </history>
        public List<string> GetTopAnswerName(int top, int answerTypeId, int voteId)
        {
            try
            {
                return
                    _holderMeetingEntities.Holder_Vote.OrderByDescending(t => t.TotalShare)
                        .Where(t => t.AnswerType == answerTypeId && t.VoteId == voteId && t.IsActive == true)
                        .Select(t => t.AnswerName)
                        .Skip(0)
                        .Take(top)
                        .ToList();
            }
            catch { }

            return new List<string>();
        }
    }
}
