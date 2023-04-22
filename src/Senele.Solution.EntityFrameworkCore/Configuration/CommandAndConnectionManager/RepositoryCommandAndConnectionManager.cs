using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Senele.Solution.Configuration.CommandAndConnectionManager
{
    public static class RepositoryCommandAndConnectionManager
    {
        public static DbCommand CreateCommand(DbContext DbContextObj, string CommandTextParam, CommandType CommandTypeParam, params SqlParameter[] Parameters)
        {
            var Command = DbContextObj.Database.GetDbConnection().CreateCommand();

            Command.CommandText = CommandTextParam;
            Command.CommandType = CommandTypeParam;
            Command.Transaction = DbContextObj.Database.CurrentTransaction?.GetDbTransaction();

            foreach (var Parameter in Parameters)
            {
                Command.Parameters.Add(Parameter);
            }

            return Command;
        }

        public static async Task EnsureConnectionOpenAsync(DbContext DbContextObj, CancellationToken CancellationTokenObj = default)
        {
            var Connection = DbContextObj.Database.GetDbConnection();

            if (Connection.State != ConnectionState.Open)
            {
                await Connection.OpenAsync(CancellationTokenObj);
            }
        }
    }
}
