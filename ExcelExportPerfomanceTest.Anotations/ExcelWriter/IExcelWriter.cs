public interface IExcelWriter 
{
    public Task WriteExcel<T>(string sheetname, Dictionary<string, Func<T, object>> columns, T[] values);
}