import java.util.*;
import java.util.stream.*;

class Exercise1 {
    public int sumAgeOfOldestUser3(List<User> users) {
	return users.stream()
	    .map(user -> user.getAge())
	    .sorted(Comparator.reverseOrder())
	    .limit(3)
	    .reduce(0, (sum, age) -> sum + age);
    }
}
