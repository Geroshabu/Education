import java.util.*;
import java.util.stream.*;

class Exercise2 {
    public List<String> getOrderedAdultUserNames(List<User> users) {
	return users.stream()
	    .filter(user -> user.getAge() >= 20)
	    .sorted((user1, user2) -> user1.getAge() - user2.getAge())
	    .map(user -> user.getName())
	    .collect(Collectors.toList());
    }
}
