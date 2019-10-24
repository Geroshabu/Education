using System;
using System.Collections.Generic;

namespace Exercise1
{
    class Exercise1
    {
        public void Execute()
	{
	    ExecutionUtils.ExecuteWithTimeMeasuring(sendFile);
	    ExecutionUtils.ExecuteWithTimeMeasuring(sendBigSizeFile);
	}

        private void sendFile()
	{
	    var list = new List<int>();
	    for (int i = 0; i < 1000000; i++)
	    {
	        list.Add(i);
	    }
	    Console.WriteLine(list.Count);
	}

        private void sendBigSizeFile()
	{
	    var list = new List<int>();
	    for (int i = 0; i < 6000000; i++)
	    {
	        list.Add(i);
	    }
	    Console.WriteLine(list.Count);
	}
    }
}