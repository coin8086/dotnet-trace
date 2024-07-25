using System;
using System.Diagnostics;
using System.Linq;

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
            Console.WriteLine($"[a[{eventCache.DateTime}: {source}-{eventType}-{id}]]");
        }

        public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string message)
        {
            Console.WriteLine($"[b[{eventCache.DateTime}: {source}-{eventType}-{id}-{message}]]");
        }

        public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string format, params object[] args)
        {
            Console.WriteLine($"[c[{eventCache.DateTime}: {source}-{eventType}-{id}-{string.Format(format, args)}]]");
        }

        public override void TraceData(TraceEventCache eventCache, string source, TraceEventType eventType, int id, object data)
        {
            Console.WriteLine($"[d[{eventCache.DateTime}: {source}-{eventType}-{id}-{data}]]");
        }

        public override void TraceData(TraceEventCache eventCache, string source, TraceEventType eventType, int id, params object[] data)
        {
            var msg = string.Join(",", data.Select(x => x.ToString()));
            Console.WriteLine($"[e[{eventCache.DateTime}: {source}-{eventType}-{id}-{msg}]]");
        }

        public override void TraceTransfer(TraceEventCache eventCache, string source, int id, string message, Guid relatedActivityId)
        {
            Console.WriteLine($"[f[{eventCache.DateTime}: {source}-{id}-{message}-{relatedActivityId}]]");
        }
    }
}
