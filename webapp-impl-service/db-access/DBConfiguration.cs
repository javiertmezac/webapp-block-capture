using System;

namespace webapp_impl_service.dbaccess
{
	public class DBConfiguration
	{
		public DBConfiguration()
		{
		}

        public static string DBConnection
        {
            get
            {
                try
                {
                    return "";
                }
                catch (Exception error)
                {
                    //return string.Empty;
                    return error.Data.ToString();
                }
            }
        }
    }
}

