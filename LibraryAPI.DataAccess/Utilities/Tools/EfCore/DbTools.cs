﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
        public static List<T> ExecuteFuncion<T>(
        string procedureName,
        params SqlParameter[] parameters)
        where T : class
        {
            using var context = new AppDbContext();

            var parametersList = parameters != null ? string.Join(", ", parameters.Select(p => p.ParameterName)) : "";

            string query = $"SELECT * FROM {procedureName} {parametersList}";

            return context.Set<T>().FromSqlRaw(query, parametersList.ToArray()).ToList();
        }
    }
}