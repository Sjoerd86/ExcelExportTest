public interface IExcelWriter 
{
    public Task WriteExcel<T>(Dictionary<string, Func<T, object>> columns, T[] values);
}