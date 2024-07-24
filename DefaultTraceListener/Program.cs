using System.Diagnostics;

namespace DefaultTraceListenerDemo;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Original trace listeners:");
        foreach (var item in Trace.Listeners)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("Create a DefaultTraceListener.");
        var listener = new DefaultTraceListener();

        Console.WriteLine($"Thread safe: {listener.IsThreadSafe}");

        var logFile = Environment.GetEnvironmentVariable("LogFile");
        if (!string.IsNullOrEmpty(logFile))
        {
            Console.WriteLine($"Log file: {logFile}");
            listener.LogFileName = logFile;
        }

        Trace.Listeners.RemoveAt(0);
        Trace.Listeners.Add(listener);

        Console.WriteLine("Trace listeners after change:");
        foreach (var item in Trace.Listeners)
        {
            Console.WriteLine(item);
        }

        listener.Write("Something happened.");
        listener.WriteLine("Something happened again.");

        listener.Fail("Something wrong happened.");
    }
}
