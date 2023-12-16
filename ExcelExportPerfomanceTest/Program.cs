using ExcelExportPerfomanceTest.Core;

// config.WithOptions(ConfigOptions.DisableOptimizationsValidator);
// BenchmarkRunner.Run<PerformanceTest>();
var test = new PerformanceTest(new ExcelWriterLargeExcel());
await test.RunTest();

//BenchmarkRunner.Run<PerformanceTest>();
