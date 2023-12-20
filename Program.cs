namespace Employees
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            int age;
            ShiftLeader leader = new ShiftLeader("", 0, 0, 0, 0);
            Employee[] people = new Employee[10]; // массив сотрудников
            ShiftLeader[] leaders = new ShiftLeader[2]; // массив начальников смен

            for (int i = 0; i < people.Length; i++) // сотрудники
            {
                Console.WriteLine($"Сотрудник {i + 1}");
                people[i] = new Employee("", 0, 0, 0, 0);

                Console.Write("\tВведите имя: ");
                name = Console.ReadLine();

                Console.Write("\tВведите возраст: ");
                age = Convert.ToInt32(Console.ReadLine());
                age = AgeChecking(age); // проверка на введенный возраст (от 16 до 50)

                people[i].Shifts(people, i, age); // заполнение смен и отдела
                people[i].PersonInfo(name, age); // запись введенных значений в класс
            }
            Console.Clear();

            Console.WriteLine("ИНФОРМАЦИЯ О СОТРУДНИКАХ\n");
            for (int j = 0; j < people.Length; j++) // вывод информации обо всех сотрудниках
            {
                Console.WriteLine($"Сотрудник {j + 1}");
                people[j].EmployeeInfoOutput(); // метод на вывод информации
                Console.ReadKey();
                Console.WriteLine();
            }

            for (int i = 0; i < leaders.Length; i++) // начальники
            {
                leaders[i] = new ShiftLeader("", 0, 0, 0, 0);
                leaders[i].ShiftLeaderInfoFilling(leaders, people, i); // заполнение информации о начальнике смены в классе ShiftLeader
            }

            Console.Write("Нажмите Enter, чтобы увидеть итоговую зарплату начальников каждой из смен");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("ИНФОРМАЦИЯ О НАЧАЛЬНИКАХ СМЕН\n");
            for (int j = 0; j < leaders.Length; j++) // вывод информации обо всех сотрудниках
            {
                Console.WriteLine($"Начальник смены {j + 1}");
                leaders[j].LeadersInfoOutput(); // вывод информации о начальнике смены

                Console.ReadKey();
                Console.WriteLine();
            }
        }

        static int AgeChecking(int age)
        {
            while (age < 16 || age > 50)
            {
                Console.Write("\tОШИБКА: Возраст сотрудников должен быть от 16 до 50 лет. \n\tВведите возраст еще раз: ");
                age = Convert.ToInt32(Console.ReadLine());
            }
            return age;
        }
    }
}