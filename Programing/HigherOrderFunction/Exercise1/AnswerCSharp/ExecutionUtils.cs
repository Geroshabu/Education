using System;
using System.Diagnostics;

namespace Exercise1
{
    class ExecutionUtils
    {
        public static void ExecuteWithTimeMeasuring(Action function)
	{
	    if (function == null)
	    {
	        throw new ArgumentNullException(nameof(function));
	    }

            var stopWatch = Stopwatch.StartNew();
	    try
	    {
	        function();
	    }
	    finally
	    {
	        Console.WriteLine($"processing time is {stopWatch.ElapsedMilliseconds}ms");
	    }
	}
    }
}