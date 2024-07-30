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
            if (Filter != null && !Filter.ShouldTrace(eventCache, source, eventType, id, format, args, null, null))
            {
                return;
            }

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
            Console.WriteLine($"TraceEvent[[{eventCache.DateTime}: {source}-{eventType}-{id}-{msg}]]");
        }

        public override void TraceData(TraceEventCache eventCache, string source, TraceEventType eventType, int id, object data)
        {
            if (Filter != null && !Filter.ShouldTrace(eventCache, source, eventType, id, null, null, data, null))
            {
                return;
            }
            Console.WriteLine($"TraceData[[{eventCache.DateTime}: {source}-{eventType}-{id}-{data}]]");
        }

        public override void TraceData(TraceEventCache eventCache, string source, TraceEventType eventType, int id, params object[] data)
        {
            if (Filter != null && !Filter.ShouldTrace(eventCache, source, eventType, id, null, null, null, data))
            {
                return;
            }
            var msg = string.Join(",", data.Select(x => x.ToString()));
            Console.WriteLine($"TraceData2[[{eventCache.DateTime}: {source}-{eventType}-{id}-{msg}]]");
        }

        public override void TraceTransfer(TraceEventCache eventCache, string source, int id, string message, Guid relatedActivityId)
        {
            if (Filter != null && !Filter.ShouldTrace(eventCache, source, TraceEventType.Transfer, id, message, null, relatedActivityId, null))
            {
                return;
            }
            Console.WriteLine($"TraceTransfer[[{eventCache.DateTime}: {source}-{id}-{message}-{relatedActivityId}]]");
        }
    }
}
