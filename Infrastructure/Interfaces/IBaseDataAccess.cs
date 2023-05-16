namespace SharedKernel.Interfaces
{
    public interface IBaseDataAccess
    {
        Task<IEnumerable<T>> LoadDataAsync<T, U>(string sql, U parameter, CommandType commandType);
        Task<T> QuerySingleAsync<T, U>(string sql, U parameter, CommandType commandType);
        Task<bool> SaveDataAsync<T>(string sql, T parameter, CommandType commandType);
    }
}
