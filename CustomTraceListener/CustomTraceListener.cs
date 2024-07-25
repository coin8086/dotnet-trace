using System;
using System.Diagnostics;

namespace CustomTraceListener
{
    public class CustomTraceListener : TraceListener
    {
        public override void Write(string message)
        {
            Console.Write($"[\"{message}\"]");
        }

        public override void WriteLine(string message)
        {
            Console.WriteLine($"[\"{message}\"]\\n");
        }
    }
}
