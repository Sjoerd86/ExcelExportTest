using ExcelExportPerformanceTest.Anotations.Models;

public class PerformanceTest
{
    public PerformanceTest()
    {
    }

    public static Gebruiker GetGebruiker() => new("Test1", "Manspersoon", Status.Nieuw);

    

}