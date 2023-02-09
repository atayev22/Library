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
        public static List<T> ExecuteFunction<T>(string functionName, List<SqlParameter> parameters) where T : class
        {
            using var context = new AppDbContext();
         
            var parametersNameList = parameters != null ? string.Join(", ", parameters.Select(p => $"@{p.ParameterName}")) : "";

            var parametersList = new List<object>();
            if (parameters != null)
            {
                parametersList.AddRange(parameters);            
            }

            return context.Set<T>().FromSqlRaw($"SELECT * FROM {functionName}({parametersNameList})",parametersList.ToArray()).ToList(); 
        }

        public static List<T> ExecuteProcedure<T>(string procedureName, List<SqlParameter> parameters) where T : class
        {
            using var context = new AppDbContext();

            var parametersNameList = parameters != null ? string.Join(", ", parameters.Select(p => $"@{p.ParameterName} = @{p.ParameterName}")) : "";   

            var parametersList = new List<object>();
            if (parameters != null)
            {
                parametersList.AddRange(parameters);
            }

            return context.Set<T>().FromSqlRaw($"EXEC {procedureName} {parametersNameList} ", parametersList.ToArray()).ToList();
        }

        public static void AddParam(this List<SqlParameter> parameters, string paramName, object paramValue)
        {
            parameters.Add(new SqlParameter(paramName, paramValue));
        }
    }
}

