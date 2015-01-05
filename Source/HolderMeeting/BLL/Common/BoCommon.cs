using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using DAL;

namespace BLL.Common
{
    public class BoCommon
    {
        public static bool IsConnect()
        {
            var result = false;
            try
            {
                var holderMeetingEntities = new HolderMeetingEntities(BoConstant.Config.ConnectionString);
                holderMeetingEntities.Database.Connection.Open();
                result = true;
                holderMeetingEntities.Database.Connection.Close();
            }
            catch { }

            return result;
        }

        public static string Connect()
        {
            var entityString = new EntityConnectionStringBuilder()
            {
                Provider = "System.Data.SqlClient",
                Metadata = "res://*/HolderMeetingModel.csdl|res://*/HolderMeetingModel.ssdl|res://*/HolderMeetingModel.msl",
                ProviderConnectionString = BoConstant.Config.ConnectionString
            };

            return entityString.ConnectionString;
        }
    }
}
