using LibraryAPI.DataAccess.Entities.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace LibraryAPI.DataAccess.Infrastructure.Tools.EfCore
{
    public static class DbTools
    {
        public static List<T> ExecuteFuncion<T>(string procedureName, List<SqlParameter> parameters) where T : class
        {
            using var context = new AppDbContext();

            var parametersList = parameters != null ? string.Join(", ", parameters.Select(s=> s.Value)) : "";

            string query = $"SELECT * FROM {procedureName}({parametersList})";

            //var data = context.Database.SqlQuery<T>(query); 
            return context.Set<T>().FromSqlRaw(query).ToList();//context.Set<T>().FromSqlRaw(query, parametersList.ToArray()).ToList();
        }

        public static void AddParam(this IList<SqlParameter> list, string paramName, object paramValue)
        {
            list.Add(new SqlParameter(paramName, paramValue));
        }
    }
}
