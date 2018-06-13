using System;
using System.Diagnostics;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Test.Console
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            try
            {
                TestStoreIlr testStoreIlr = new TestStoreIlr(new TestOutputHelper());
                testStoreIlr
                    .StoreIlr(
                        @"C:\Users\DevUser\source\repos\DC-ILR-1819-DataStore\src\ESFA.DC.ILR1819.DataStore.PersistData.Test\ILR-90000062-1819-20180521-135604-00.xml",
                        @"C:\Users\DevUser\source\repos\DC-ILR-1819-DataStore\src\ESFA.DC.ILR1819.DataStore.PersistData.Test\ALBOutput1000.json",
                        @"C:\Users\DevUser\source\repos\DC-ILR-1819-DataStore\src\ESFA.DC.ILR1819.DataStore.PersistData.Test\9999_6_ValidationErrors.json",
                        90000062,
                        new [] { "0Accm01" }).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
            }

            System.Console.WriteLine(stopwatch.ElapsedMilliseconds);
            System.Console.ReadKey();
        }
    }
}
