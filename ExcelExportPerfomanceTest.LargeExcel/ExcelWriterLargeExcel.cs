using LargeXlsx;
using System.Drawing;

public class ExcelWriterLargeExcel : IExcelWriter
{
    public Task WriteExcel<T>(string sheetname, Dictionary<string, Func<T, object>> columns, T[] values)
    {
        using var stream = new FileStream("C:\\Users\\smars\\source\\repos\\Sjoerd86\\ExcelExportTest\\ExcelExportPerfomanceTest.LargeExcel\\Basic.xlsx", FileMode.Create, FileAccess.Write);
        using var xlsxWriter = new XlsxWriter(stream);
        xlsxWriter
            .BeginWorksheet(sheetname);
        //.BeginRow().Write("Name").Write("Location").Write("Height (m)")
        //.BeginRow().Write("Kingda Ka").Write("Six Flags Great Adventure").Write(139)
        //.BeginRow().Write("Top Thrill Dragster").Write("Cedar Point").Write(130)
        //.BeginRow().Write("Superman: Escape from Krypton").Write("Six Flags Magic Mountain").Write(126);
        xlsxWriter.BeginRow();

        foreach (var column in columns) {
            xlsxWriter.Write(column.Key);
        }

        foreach (var row in values)
        {
            xlsxWriter.BeginRow();
            foreach (var column in columns)
            {
                xlsxWriter.Write(column.Value(row).ToString());
            }
        }

        return Task.CompletedTask;
    }
}