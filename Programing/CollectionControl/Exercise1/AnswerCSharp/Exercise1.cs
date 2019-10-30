using System.Collections.Generic;
using System.Linq;

namespace Exercise1
{
    class Exercise1
    {
        public int SumAgeOfOldestUser3(List<User> users)
	{
	    return users
	        .Select(user => user.Age)
		.OrderByDescending(age => age)
		.Take(3)
		.Sum();
	}
    }
}