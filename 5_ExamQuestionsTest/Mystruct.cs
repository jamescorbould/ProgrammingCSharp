namespace _5_ExamQuestionsTest
{
    partial class Program
    {
        // Where struct is a value type.
        // Can specify properties and methods in a struct.
        struct Man
        {
            public string firstName { get; set; }
            public string lastName { get; set; }
            public int age { get; set; }
            public string catchphrase { get; set; }

            public Man(string firstName, string lastName, int age)
            {
                this.firstName = firstName;
                this.lastName = lastName;
                this.age = age;
                this.catchphrase = "That should do it.";
            }

            public string saysomething()
            {
                return catchphrase;
            }
        }
    }
}
