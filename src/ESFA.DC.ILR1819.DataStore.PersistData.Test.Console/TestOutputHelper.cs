using System;
using System.IO;
using Xunit.Abstractions;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Test.Console
{
    public sealed class TestOutputHelper : ITestOutputHelper, IDisposable
    {
        private readonly StreamWriter sw;

        public TestOutputHelper()
        {
            string filename = Path.GetTempFileName();
            System.Console.WriteLine(filename);
            sw = new StreamWriter(filename);
        }

        public void WriteLine(string message)
        {
            System.Console.WriteLine(message);
            sw.WriteLine(message);
        }

        public void WriteLine(string format, params object[] args)
        {
            System.Console.WriteLine(format, args);
            sw.WriteLine(format, args);
        }

        public void Dispose()
        {
            sw?.Dispose();
        }
    }
}
