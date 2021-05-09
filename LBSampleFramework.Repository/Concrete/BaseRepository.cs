using System;
using System.Collections.Generic;
using System.Configuration;
using LBSampleFramework.Helpers;
using System.Data;
using System.Linq;
using System.Data.SqlClient;

namespace LBSampleFramework.Repository.Concrete
{
    public class BaseRepository<TEntity, TKey> where TEntity : class
    {
        internal string ConnectionString = "";
        public BaseRepository()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }

        internal DBCommand CreateSqlCommand(string cmdText)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(cmdText, conn);

            return new DBCommand()
            {
                Connection = conn,
                Command = command
            };
        }

        internal IEnumerable<TEntity> ExecuteReader(DBCommand cmd, Func<IDataRecord, TEntity> map)
        {
            List<TEntity> retVal = new List<TEntity>();
            try
            {
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();
                using (IDataReader rdr = cmd.Command.ExecuteReader(CommandBehavior.Default))
                {
                    while (rdr.Read())
                    {
                        retVal.Add(map(rdr));
                    }
                }
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retVal.AsEnumerable();
        }

        internal int ExecuteNonQuery(DBCommand cmd)
        {
            int retVal;
            try
            {
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();

                retVal = cmd.Command.ExecuteNonQuery();

                cmd.Connection.Close();

                return retVal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal object ExecuteScalar(DBCommand cmd)
        {
            object retVal;
            try
            {
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();

                retVal = cmd.Command.ExecuteScalar();

                cmd.Connection.Close();

                return retVal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
