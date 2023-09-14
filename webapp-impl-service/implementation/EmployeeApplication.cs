using System;
using System.Data;
using System.Data.SqlClient;

namespace webapp_impl_service.implementation
{
	public class EmployeeApplication
	{
		private String PREFIX = "Trabajador";
		public EmployeeApplication()
		{
		}

		public DataTable SelectAllEmployees(String search)
		{
			SqlCommand command = dbaccess.DBAccessHelper.CreateSQLCommand(PREFIX + "_LIST");
			dbaccess.DBAccessHelper.ParameterAdd(command, "@pista", System.Data.SqlDbType.VarChar, search);
			return dbaccess.DBAccessHelper.ExecuteSQLSelect(command);
		}
	}
}

