class ExecutionUtils {
    public static void ExecuteWithTimeMeasuring(Runnable function) {
	if (function == null) {
	    throw new IllegalArgumentException("function is null");
	}
	
	long beginTime = System.currentTimeMillis();
	try {
	    function.run();
	}
	finally {
	    long elapsedTime = System.currentTimeMillis() - beginTime;
	    System.out.println("processing time is " + elapsedTime + "ms");
	}
    }
}
