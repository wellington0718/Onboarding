using System;

namespace Infrastructure.Repositories
{
    public class BaseDataAccess : IBaseDataAccess
    {
        private readonly IDbConnection connection;

        public BaseDataAccess(string connectionString)
        {
            try
            {
                connection = new SqlConnection(connectionString);

                if (connection is not null && connection.State == ConnectionState.Closed)
                    connection.Open();
            }
            catch (Exception exception) 
            {
            }

        }

        public async Task<IEnumerable<T>> LoadDataAsync<T, U>(string sql, U parameter, CommandType commandType)
        {
            return await connection.QueryAsync<T>(sql, parameter, commandType: commandType);
        }

        public async Task<bool> SaveDataAsync<T>(string sql, T parameter, CommandType commandType)
        {
          return await connection.ExecuteScalarAsync<bool>(sql, parameter, commandType: commandType);
        }
        public async Task<T> QuerySingleAsync<T, U>(string sql, U parameter, CommandType commandType)
        {
            return await connection.QueryFirstOrDefaultAsync<T>(sql, parameter, commandType: commandType);
        }

        public void Dispose()
        {
            connection.Close();
        }
    }
}
