namespace Employees
{
    class ShiftLeader : Employee
    {
        public double shiftLeaderSalary = 108390; // зарплата начальника дневной смены //изначально оклад
        private int overtimeWork = 0;
        public double bonus = 0; // итоговая сумма премии
        private double bonusValue = 0; // сумма за каждого сотрудника (в %)

        public ShiftLeader(string name, int age, int departmentNumber, int nightShiftsCount, int dayShiftsCount) : base(name, age, departmentNumber, nightShiftsCount, dayShiftsCount) { }

        private double LeaderSalary(int overtimeWork, out double bonusValue) // расчет заработной платы начальника смены
        {
            bonusValue = 0;
            bonusValue = BonusCheck(overtimeWork, bonusValue);
            shiftLeaderSalary += shiftLeaderSalary * bonusValue; // условие того, каким будет BonusValue, находится в Main
            return shiftLeaderSalary;
        }

        private double BonusCheck(int overtimeWork, double bonusValue) // расчета размер бонуса за каждого сотрудника
        {
            if (overtimeWork >= 1 && overtimeWork <= 10) // бонус 3% от оклада
            {
                bonusValue = 0.03;
            }
            else if (overtimeWork >= 11 && overtimeWork <= 15) // бонус 5% от оклада
            {
                bonusValue = 0.05;
            }
            else if (overtimeWork >= 16) // бонус 7% от оклада
            {
                bonusValue = 0.07;
            }
            return bonusValue;
        }

        private double BonusCount(double bonusValue) // расчет бонуса
        {
            bonus += shiftLeaderSalary * bonusValue;
            return bonus;
        }

        private int DayOvertimeCount(int dayShiftsCount) // расчет количества переработок в дневных сменах
        {
            overtimeWork += dayShiftsCount - dayShiftsMin;
            return overtimeWork;
        }

        private int NightOvertimeCount(int nightShiftsCount) // расчет количества переработок в ночных сменах
        {
            overtimeWork += nightShiftsCount - nightShiftsMin;
            return overtimeWork;
        }

        public void ShiftLeaderInfoFilling(ShiftLeader[] leaders, Employee[] people, int i) // заполнение информации о начальниках смены
        {
            for (int j = 0; j < people.Length; j++)
            {
                if (people[j].dayShiftsCount > dayShiftsMin && i == 0) // если дневных смен больше обязательного минимума
                {
                    overtimeWork = leaders[i].DayOvertimeCount(people[j].dayShiftsCount);
                }
                else if (people[j].nightShiftsCount > nightShiftsMin && i == 1)
                {
                    overtimeWork = leaders[i].NightOvertimeCount(people[j].nightShiftsCount);
                }
                shiftLeaderSalary = leaders[i].LeaderSalary(overtimeWork, out bonusValue); // расчет зарплаты
                bonus = leaders[i].BonusCount(bonusValue); // расчет размер бонуса за одного сотрудника
            }
        }

        public void LeadersInfoOutput() // вывод информации о начальниках смены
        {
            Console.WriteLine($"Зарплата: {Math.Round(shiftLeaderSalary, 3)}");
            Console.WriteLine($"Всего переработок на {overtimeWork} смены");
            Console.WriteLine($"Итоговый бонус: {Math.Round(bonus, 3)} руб.");
        }
    }
}