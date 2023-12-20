namespace Employees
{
    class Person
    {
        protected string name;
        protected int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public void PersonInfo(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public void InfoOutput()
        {
            Console.WriteLine($"\tИмя: {name}");
            Console.WriteLine($"\tВозраст: {age}");
        }
    }
}