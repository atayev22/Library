using LibraryAPI.DataAccess.Context;
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
        public static List<T> ExecuteFunction<T>(string procedureName, List<SqlParameter> parameters) where T : class
        {
            using var context = new AppDbContext();

            var parametersList = parameters != null ? string.Join(", ", parameters.Select(s=> s.Value)) : "";

            return context.Set<T>().FromSqlRaw($"SELECT * FROM {procedureName}({parametersList})").ToList(); 
        }

        public static void AddParam(this List<SqlParameter> parameters, string paramName, object paramValue)
        {
            parameters.Add(new SqlParameter(paramName, paramValue));
        }
    }
}

