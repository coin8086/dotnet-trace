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

            var ts = new TraceSource("My Trace Source");
            ts.TraceData(TraceEventType.Start, 1, "some data");
            ts.TraceTransfer(100, "some message", new Guid());
        }
    }
}
