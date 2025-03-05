using System.Linq.Expressions;

namespace InfosecLearningSystem_Backend.Test
{
    public class TestSyntax
    {
        Expression<Func<Person, bool>> isAdult = p1 => p1.Age >= 18;

        // I've given the parameter a different name to allow you to differentiate.
        Expression<Func<Person, bool>> isMale = p2 => p2.Gender == "Male";


    }

    internal class Person
    {
        public int Age { get; set; }
        public string Gender { get; set; }
    }
}
