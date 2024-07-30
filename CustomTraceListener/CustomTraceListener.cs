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
            TraceEvent(eventCache, source, eventType, id, null, null);
        }

        public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string message)
        {
            TraceEvent(eventCache, source, eventType, id, message, null);
        }

        public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string format, params object[] args)
        {
            string msg = null;
            if (format == null)
            {
                msg = string.Empty;
            }
            else
            {
                if (args != null)
                {
                    msg = string.Format(format, args);
                }
                else
                {
                    msg = format;
                }
            }
            Console.WriteLine($"[c[{eventCache.DateTime}: {source}-{eventType}-{id}-{msg}]]");
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
