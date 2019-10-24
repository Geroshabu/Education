import java.util.*;
import java.util.stream.*;

class Exercise1 {
    public void execute() {
	ExecutionUtils.ExecuteWithTimeMeasuring(this::sendFile);
	ExecutionUtils.ExecuteWithTimeMeasuring(this::sendBigSizeFile);
    }

    private void sendFile() {
	LinkedList<Integer> list = new LinkedList<Integer>();
	for (int i = 0; i < 1000000; i++) {
	    list.add(i);
	}
	System.out.println(list.size());
    }

    private void sendBigSizeFile() {
	LinkedList<Integer> list = new LinkedList<Integer>();
	for (int i = 0; i < 6000000; i++) {
	    list.add(i);
	}
	System.out.println(list.size());
    }
}
