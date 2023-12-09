namespace ExcelExportPerformanceTest.Anotations.Models;

public class Recht(string Naam)
{
    public static Recht operator +(Recht recht1, Recht recht2)
    {
         return new Recht($"{recht1}, {recht2}");
    }
    public string Naam { get; } = Naam;
}