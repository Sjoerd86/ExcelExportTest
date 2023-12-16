using BenchmarkDotNet.Attributes;
using ExcelExportPerfomanceTest.Core.Models;

namespace ExcelExportPerfomanceTest.Core
{
    public class PerformanceTest(IExcelWriter excelWriter)
    {
        private readonly IExcelWriter excelWriter = excelWriter;

        [GlobalSetup]
        public void Setup()
        {
            System.Diagnostics.Debugger.Launch();
        }

        [Benchmark]
        public async Task RunTest()
        {
            Console.WriteLine("RunTest");
          
            var gebruikers = new[] { GetGebruiker() };
            var columns = new Dictionary<string, Func<Gebruiker, object>>
            {
                {"Naam", i => i.Naam},
                {"Achternaam", i => i.Achternaam},
                {"Status", i => i.status},
                {"Aantal rechten", i => i.Rechten.Length},
            };

            foreach (var recht in gebruikers[0].Rechten)
            {
               
                columns.Add(recht.Naam, i => true);
            }

            await excelWriter.WriteExcel("Sheet1", columns, gebruikers);
        }


        //  Hier moet ik nog iets mooiers voor bouwen maar ik heb nu even geen tijd.
        public static Gebruiker GetGebruiker() => new("Test1", "Manspersoon", Status.Nieuw, [new("Eerste recht"), new("Bla")]);
    }
}