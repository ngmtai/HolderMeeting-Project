using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BLL.Common;
using DAL;

namespace BLL
{
    public class VoteBusiness
    {
        private readonly HolderMeetingEntities _holderMeetingEntities;

        public VoteBusiness()
        {
            _holderMeetingEntities = new HolderMeetingEntities(BoCommon.Connect());
        }

        /// <summary>
        /// Save vote
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <history>
        /// 12/22/2014 aBc: create new
        /// </history>
        public int Save(Vote model)
        {
            try
            {
                _holderMeetingEntities.Votes.Add(model);
                _holderMeetingEntities.SaveChanges();

                return model.Id;
            }
            catch { }

            return 0;
        }

        /// <summary>
        /// Get list vote
        /// </summary>
        /// <returns></returns>
        /// <history>
        /// 12/22/2014 aBc: create new
        /// </history>
        public List<Vote> GetAlls(bool? isActive)
        {
            try
            {
                return _holderMeetingEntities.Votes.Where(t => isActive.HasValue == false || t.IsActive == isActive.Value).OrderBy(t => t.Order).ToList();
            }
            catch { }

            return new List<Vote>();
        }

        /// <summary>
        /// Get detail vote by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <history>
        /// 12/22/2014 aBc: create new
        /// </history>
        public Vote Detail(int id)
        {
            try
            {
                var aBc = _holderMeetingEntities.Votes.SingleOrDefault(t => t.Id == id);

                if (aBc != null)
                    return aBc;
            }
            catch { }

            return new Vote();
        }

        /// <summary>
        /// Update vote
        /// </summary>
        /// <param name="voteId"></param>
        /// <param name="displayName"></param>
        /// <param name="isActive"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <history>
        /// 12/22/2014 aBc: create new
        /// </history>
        public bool Update(int voteId, string displayName, bool isActive, int order)
        {
            try
            {
                var aBc = _holderMeetingEntities.Votes.SingleOrDefault(t => t.Id == voteId);
                if (aBc != null && aBc.Id > 0)
                {
                    aBc.DisplayName = displayName;
                    aBc.UpdateDate = DateTime.Now;
                    aBc.IsActive = isActive;
                    aBc.Order = order;

                    _holderMeetingEntities.SaveChanges();
                    return true;
                }
            }
            catch { }

            return false;
        }

        /// <summary>
        /// Update vote isactive
        /// </summary>
        /// <param name="voteId"></param>
        /// <param name="isActive"></param>
        /// <returns></returns>
        /// <history>
        /// 12/22/2014 aBc: create new
        /// </history>
        public bool Update(int voteId, bool isActive)
        {
            try
            {
                var aBc = _holderMeetingEntities.Votes.SingleOrDefault(t => t.Id == voteId);

                if (aBc != null && aBc.Id > 0)
                {
                    aBc.UpdateDate = DateTime.Now;
                    aBc.IsActive = isActive;

                    _holderMeetingEntities.SaveChanges();
                    return true;
                }
            }
            catch { }

            return false;
        }

        public bool CheckIsVote(int voteId)
        {
            try
            {
                var aBc = _holderMeetingEntities.Holder_Vote.FirstOrDefault(t => t.VoteId == voteId);
                return aBc != null && aBc.VoteId > 0;
            }
            catch { }

            return false;
        }

        /// <summary>
        /// Delete vote
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <history>
        /// 12/22/2014 aBc: create new
        /// </history>
        public bool Delete(int id)
        {
            try
            {
                var aBc = _holderMeetingEntities.Votes.SingleOrDefault(t => t.Id == id);
                if (aBc != null && aBc.Id > 0)
                {
                    _holderMeetingEntities.Votes.Remove(aBc);
                    _holderMeetingEntities.SaveChanges();

                    return true;
                }
            }
            catch { }

            return false;
        }

        /// <summary>
        /// Count vote is active
        /// </summary>
        /// <returns></returns>
        /// <history>
        /// 12/23/2014 aBc: create new
        /// </history>
        public int CountVoteIsActive()
        {
            try
            {
                return _holderMeetingEntities.Votes.Count(t => t.IsActive == true);
            }
            catch { }

            return 0;
        }
    }
}
