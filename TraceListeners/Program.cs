using System;
using System.Diagnostics;

namespace TraceListeners
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main");
            Trace.WriteLine("Something happened.");
            Trace.TraceInformation("Some information is.");
        }
    }
}
