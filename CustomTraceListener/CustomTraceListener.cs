using System;
using System.Diagnostics;

namespace CustomTraceListener
{
    public class CustomTraceListener : TraceListener
    {
        public override bool IsThreadSafe => true;

        public override void Write(string message)
        {
            Console.Write($"[\"{message}\"]");
        }

        public override void WriteLine(string message)
        {
            Console.WriteLine($"[\"{message}\"]\\n");
        }

        public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id)
        {
            TraceEvent(eventCache, source, eventType, id, string.Empty);
        }

        public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string message)
        {
            TraceEvent(eventCache, source, eventType, id, message, new string[0]);
        }

        public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string format, params object[] args)
        {
            Console.WriteLine($"[[{eventCache.DateTime}: {source}-{eventType}-{id}-{string.Format(format, args)}]]");
        }
    }
}
