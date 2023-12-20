namespace Employees
{
    class Employee : Person
    {
        protected int departmentNumber; // номер отдела
        public int dayShiftsCount; // количество дневных смен в месяц
        public int nightShiftsCount; // количество ночных смен в месяц        
        protected int dayShiftsMin = 25; // число обязательных смен для начисления премии начальнику смены
        protected int nightShiftsMin = 15; // число обязательных ночныз смен для начисления премии начальнику смены
        protected double salary; // зарплата        
        private double dayShiftCost = 1600; // дневная смена
        private double nightShiftCost = 2200; // ночная смена

        public Employee(string name, int age, int departmentNumber, int nightShiftsCount, int dayShiftsCount) : base(name, age) // наследование значений из класса Person
        {
            this.dayShiftsCount = dayShiftsCount;
            this.nightShiftsCount = nightShiftsCount;
        }

        public void Shifts(Employee[] people, int i, int age) // заполнение смен
        {
            Random rnd = new Random();
            if (age < 18) // если младше 18, то доступны только дневные смены
            {
                dayShiftsCount = rnd.Next(20, 60); // может как отработать меньше, так и переработать
            }
            else if (age >= 18) // если старше 18 - и дневные, и ночные
            {               
                dayShiftsCount = rnd.Next(20, 40);
                nightShiftsCount = rnd.Next(20, 40);
            }
            DepartmentInfo(people, i); // отдел
        }

        private void DepartmentInfo(Employee[] people, int i)
        {
            if (i < 5) // если индекс меньше 5, то закидываем сотрудников в первый отдел
            {
                people[i].departmentNumber = 1; // указан номер отдела 1                                                  
            }
            else
            {
                people[i].departmentNumber = 2;
            }
        }

        private double EmployeeSalary(double salary) // расчет заработной платы каждого сотрудника
        {
            salary = dayShiftCost * dayShiftsCount + nightShiftCost * nightShiftsCount; // стоимость ночных и дневных смен
            return salary;
        }

        public void EmployeeInfoOutput() // вывод информации о сотрудниках
        {
            base.InfoOutput(); // имя и возраст
            Console.WriteLine($"\tНомер отдела: {departmentNumber}");
            Console.WriteLine($"\tВсего отработано смен за месяц: {dayShiftsCount + nightShiftsCount}, из них:");
            Console.WriteLine($"\t{dayShiftsCount} дневных смен и {nightShiftsCount} ночных смен");
            salary = EmployeeSalary(salary); // расчет зарплаты
            Console.WriteLine($"\tЗарплата: {salary} руб.");
        }
    }
}