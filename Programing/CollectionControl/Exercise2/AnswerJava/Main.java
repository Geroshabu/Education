import java.util.*;

class Main {
    public static void main(String[] args) {
	List<User> users = Arrays.asList(new User("Alice", 20),
					 new User("Bob", 30),
					 new User("Charlie", 40),
					 new User("Dave", 19),
					 new User("Ellen", 30),
					 new User("Frank", 50));
	List<String> names = new Exercise2().getOrderedAdultUserNames(users);
	names.forEach(name -> System.out.println(name));
    }
}
