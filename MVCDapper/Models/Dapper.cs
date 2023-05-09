using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System;

namespace MVCDapper.Models
{
    public static class Dapper
    {
        private static string ConnectionStrings = "Server=LAPTOP-0VT9JPBO\\SQLEXPRESS; Database=MVCdapperDb; Trusted_Connection=True; MultipleActiveResultSets=true";

        public static void ExecuteWithoutReturn(string procedureName,DynamicParameters param = null)// This function to be called when there is no data to be return from the data base
        {
            using (SqlConnection SQLconnection = new SqlConnection(ConnectionStrings))
            {
                SQLconnection.Open();
                SQLconnection.Execute(procedureName, param, commandType: CommandType.StoredProcedure);

            }
        }

        public static T ExecuteReturnSclar<T>(string procedureName, DynamicParameters param)//This function is used to tun store procudeure that will return inetger variable
        {
            using (SqlConnection SQLconnection = new SqlConnection(ConnectionStrings))
            {
                SQLconnection.Open();
              return(T) Convert.ChangeType( SQLconnection.ExecuteScalar(procedureName, param, commandType: CommandType.StoredProcedure),typeof(T));

            }
        }

        public static IEnumerable<T> ReturnList<T>(string procedureName, DynamicParameters param = null)// will return list type
        {
            using (SqlConnection SQLconnection = new SqlConnection(ConnectionStrings))
            {
                SQLconnection.Open();
                return SQLconnection.Query<T>(procedureName, param, commandType: CommandType.StoredProcedure);

            }
        }

        //public static IEnumerable<T> ReturnList<T>(string procedureName, DynamicParameters param = null)
        //{
        //    using (SqlConnection con = new SqlConnection(ConnectionStrings))
        //    {
        //        con.Open();
        //        return con.Query<T>(procedureName, param, commandType: CommandType.StoredProcedure);
        //    }
        //}


    }
}

