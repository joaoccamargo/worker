using Course.Entities.Enums;
using System;

namespace Course.Entities
{
    internal class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; private set; }
        public Department Department { get; set; }
        public List<HourContract> Contracts { get; set; } = new List<HourContract>();

        public Worker(string Name, WorkerLevel Level, double BaseSalary, Department Department) 
        {
            this.Name = Name;
            this.Level = Level;
            this.BaseSalary = BaseSalary;
            this.Department = Department;
        }

        public void AddContract(HourContract contract) 
        { 
            Contracts.Add(contract);
        }

        public void RemoveContract(HourContract contract) 
        { 
           Contracts.Remove(contract);
        }

        public double Income(int year, int month) 
        {
            double sum = BaseSalary;
            foreach(HourContract contract in Contracts)
            {
                if (contract.Date.Year == year && contract.Date.Month == month) 
                {
                    sum += contract.TotalValue();                
                }

            }
            return sum;
        }

    }
}
