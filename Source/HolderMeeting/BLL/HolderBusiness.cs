using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using System.Linq;
using BLL.Common;
using BLL.Model;
using DAL;

namespace BLL
{
    public class HolderBusiness
    {
        private readonly HolderMeetingEntities _holderMeetingEntities;

        public HolderBusiness()
        {
            _holderMeetingEntities = new HolderMeetingEntities(BoCommon.Connect());
        }

        /// <summary>
        /// Save holder
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <history>
        /// 12/6/2014 aBc: create new
        /// </history>
        public int Save(Holder model)
        {
            try
            {
                _holderMeetingEntities.Holders.Add(model);
                _holderMeetingEntities.SaveChanges();

                return model.Id;
            }
            catch
            {
            }

            return -1;
        }

        /// <summary>
        /// Save list Holder
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        /// <history>
        /// 12/21/2014 aBc: create new
        /// </history>
        public bool Saves(List<Holder> lst)
        {
            try
            {
                _holderMeetingEntities.Holders.AddRange(lst);
                _holderMeetingEntities.SaveChanges();

                return true;
            }
            catch { }

            return false;
        }

        /// <summary>
        /// Check code and name and authorizerName is exist
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <param name="authorizerName"></param>
        /// <param name="totalShared"></param>
        /// <param name="cmnd"></param>
        /// <returns></returns>
        /// <history>
        /// 12/21/2014 aBc: create new
        /// </history>
        public bool CheckExist(string code, string name, string authorizerName, decimal totalShared, string cmnd)
        {
            try
            {
                var aBc =
                    _holderMeetingEntities.Holders.FirstOrDefault(
                        t => t.Code.Equals(code) && t.Name.Equals(name) && t.AuthorizerName.Equals(authorizerName) &&
                            t.CMND.Equals(cmnd) && t.TotalShare == totalShared);

                return aBc != null && aBc.Id > 0;
            }
            catch { }

            return false;
        }

        /// <summary>
        /// Edit holder
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <history>
        /// 12/6/2014 aBc: create new
        /// </history>
        public bool Edit(Holder model)
        {
            try
            {
                var aBc = _holderMeetingEntities.Holders.SingleOrDefault(t => t.Id == model.Id && t.IsActive == true);
                if (aBc != null)
                {
                    aBc.AuthorizerName = model.AuthorizerName;
                    aBc.IsConfirm = model.IsConfirm;
                    aBc.Name = model.Name;
                    aBc.CMND = model.CMND;
                    aBc.Code = model.Code;
                    aBc.TotalShare = model.TotalShare;
                    aBc.UpdateDate = model.UpdateDate;
                    aBc.UpdateUser = model.UpdateUser;

                    _holderMeetingEntities.SaveChanges();
                    return true;
                }
            }
            catch { }

            return false;
        }

        /// <summary>
        /// Get holder detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <history>
        /// 12/6/2014 aBc: create new
        /// </history>
        public Holder Detail(int id)
        {
            try
            {
                var aBc = _holderMeetingEntities.Holders.SingleOrDefault(t => t.Id == id && t.IsActive == true);
                if (aBc != null) return aBc;
            }
            catch { }

            return new Holder();
        }

        /// <summary>
        /// Get list holder
        /// </summary>
        /// <returns></returns>
        /// <history>
        /// 12/6/2014 aBc: create new
        /// </history>
        public List<Holder> GetAlls(string name, string code, string cmnd, bool? isConfirm)
        {
            try
            {
                var aBc = _holderMeetingEntities.Holders.Where(t => t.IsActive == true &&
                    (isConfirm == null || t.IsConfirm == isConfirm) &&
                    (string.IsNullOrEmpty(name) || t.Name.Contains(name)) &&
                    (string.IsNullOrEmpty(code) || t.Code.Contains(code)) &&
                    (string.IsNullOrEmpty(cmnd) || t.CMND.Contains(cmnd)))
                    .OrderBy(t => t.Name);
                if (aBc.Any()) return aBc.ToList();
            }
            catch { }

            return new List<Holder>();
        }

        /// <summary>
        /// Update holder with isConfirm and AuthorizerName
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <history>
        /// 12/22/2014 aBc: create new
        /// </history>
        public bool UpdateHolder(Holder model)
        {
            try
            {
                var aBc = _holderMeetingEntities.Holders.SingleOrDefault(t => t.Id == model.Id);
                if (aBc != null)
                {
                    aBc.IsConfirm = model.IsConfirm;
                    //aBc.AuthorizerName = model.AuthorizerName;
                    aBc.UpdateDate = DateTime.Now;

                    _holderMeetingEntities.SaveChanges();
                    return true;
                }
            }
            catch { }

            return false;
        }

        /// <summary>
        /// Get all Code in holder
        /// </summary>
        /// <returns></returns>
        /// <history>
        /// 12/22/2014 aBc: create new
        /// </history>
        public List<string> GetAllsCode()
        {
            try
            {
                var aBc = _holderMeetingEntities.Holders.Where(t => t.IsActive == true).OrderBy(t => t.Code);

                if (aBc.Any())
                    return aBc.Select(t => t.Code).ToList();
            }
            catch { }

            return new List<string>();
        }

        /// <summary>
        /// Get all Name in holder
        /// </summary>
        /// <returns></returns>
        /// <history>
        /// 12/22/2014 aBc: create new
        /// </history>
        public List<string> GetAllsName()
        {
            try
            {
                var aBc = _holderMeetingEntities.Holders.Where(t => t.IsActive == true).OrderBy(t => t.Name);

                if (aBc.Any())
                    return aBc.Select(t => t.Name).ToList();
            }
            catch { }

            return new List<string>();
        }

        /// <summary>
        /// Get all CMND
        /// </summary>
        /// <returns></returns>
        /// <history>
        /// 1/7/2015 aBc: create new
        /// </history>
        public List<string> GetAllsCmnd()
        {
            try
            {
                var aBc = _holderMeetingEntities.Holders.Where(t => t.IsActive == true).OrderBy(t => t.CMND);

                if (aBc.Any())
                    return aBc.Select(t => t.CMND).ToList();
            }
            catch { }

            return new List<string>();
        }

        /// <summary>
        /// Get total holder confirm and not confirm
        /// </summary>
        /// <param name="bl"></param>
        /// <returns></returns>
        /// <history>
        /// 12/22/2014 aBc: create new
        /// </history>
        public int TotalConfirm(bool? bl)
        {
            try
            {
                return _holderMeetingEntities.Holders.Count(t => t.IsActive == true && (bl == null || t.IsConfirm == bl));
            }
            catch { }

            return 0;
        }

        /// <summary>
        /// Get total share isConfirm
        /// </summary>
        /// <param name="bl"></param>
        /// <returns></returns>
        /// <history>
        /// 12/22/2014 aBc: create new
        /// </history>
        public decimal TotalShareIsConfirm(bool? bl)
        {
            try
            {
                var aBc = _holderMeetingEntities.Holders.Where(t => t.IsActive == true && (bl == null || t.IsConfirm == bl)).Select(t => t.TotalShare);

                if (aBc.Any())
                {
                    decimal count = 0;
                    foreach (var item in aBc)
                        count += item.HasValue ? item.Value : 0;

                    return count;
                }
            }
            catch { }

            return 0;
        }

    }
}
