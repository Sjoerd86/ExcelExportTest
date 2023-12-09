using System.Reflection.Metadata.Ecma335;
using ExcelExportPerformanceTest.Anotations.Models;
using Microsoft.VisualBasic;

public class PerformanceTest(IExcelWriter excelWriter)
{
    public IExcelWriter ExcelWriter { get; } = excelWriter;

    public async Task RunTest()
    {
        var gebruikers = new[]  { GetGebruiker() };
        var columns = new Dictionary<string, Func<Gebruiker, object>>
        {
            {"Naam", i => i.Naam},
            {"Achternaam", i => i.Achternaam},
            {"Status", i => i.status},
            {"Aantal rechten", i => i.Rechten.Length},
        };

        foreach(var recht in gebruikers[0].Rechten)
        {
            columns.Add(recht.Naam, i => true);
        }

        await excelWriter.WriteExcel(columns, gebruikers);        
    }


    //  Hier moet ik nog iets mooiers voor bouwen maar ik heb nu even geen tijd.
    public static Gebruiker GetGebruiker() => new("Test1", "Manspersoon", Status.Nieuw, [new("Eerste recht"), new("Bla")]);

    

}