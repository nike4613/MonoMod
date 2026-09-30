using System;
using System.Threading;

static class P
{
    static int Main(string[] a)
    {
        Console.WriteLine("pid " + System.Diagnostics.Process.GetCurrentProcess().Id + " mode " + a[0]);
        switch (a[0])
        {
            case "failfast": Environment.FailFast("exp"); break;
            case "throw": new Thread(() => throw new InvalidOperationException("exp")).Start(); Thread.Sleep(5000); break;
            case "hang": Thread.Sleep(Timeout.Infinite); break;
        }
        return 0;
    }
}
