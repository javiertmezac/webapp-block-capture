using System;
using System.Data;
using System.Data.SqlClient;
using webapp_impl_service.dbaccess;
using webapp_impl_service.model;

namespace webapp_impl_service.implementation
{
	public class BlockApplication
	{
        private String PREFIX = "Bloque";
        public BlockApplication()
		{
		}
        public bool RegistertBlock(EmployeeBlock data)
        {
            SqlCommand command = DBAccessHelper.CreateSQLCommand(PREFIX + "_UPSERT");
            int newRegistry = 0;
            DBAccessHelper.ParameterAdd(command, "@id", SqlDbType.Int, newRegistry);
            DBAccessHelper.ParameterAdd(command, "@letra", SqlDbType.NChar, data.letter);
            DBAccessHelper.ParameterAdd(command, "@numInicial", SqlDbType.Int, data.startNumber);
            DBAccessHelper.ParameterAdd(command, "@numFinal", SqlDbType.Int, data.endNumber);
            DBAccessHelper.ParameterAdd(command, "@idChofer", SqlDbType.Int, data.employeeId);
            DBAccessHelper.ParameterAdd(command, "@secuencia", SqlDbType.Int, data.blockNextNumber);
            DBAccessHelper.ParameterAdd(command, "@fechaRegistro", SqlDbType.DateTime, DateTime.Now);
            DBAccessHelper.ParameterAdd(command, "@status", SqlDbType.Bit, true);
            try
            {
                return Convert.ToInt32(DBAccessHelper.ExecuteSQLScalar(command)) > 0;
            } catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}