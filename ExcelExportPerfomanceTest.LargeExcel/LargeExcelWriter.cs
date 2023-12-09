public class ExcelWriterLargeExcel : IExcelWriter
{
    public Task WriteExcel<T>(Dictionary<string, Func<T, object>> columns, T[] values)
    {
        return Task.CompletedTask;
    }
}