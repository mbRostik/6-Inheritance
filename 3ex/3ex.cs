using System;

internal class Program
{
    class Human
    {
        private string name;
        private string surname;

        public Human(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }

        public virtual string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value.Length <= 3)
                {
                    throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
                }
                if (value[0] < 65 || value[0] > 90)
                {
                    throw new ArgumentException("Expected upper case letter! Argument: firstName");
                }
                name = value;
            }
        }
        public virtual string Surname
        {

            get
            {
                return surname;
            }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName ");
                }
                if (value[0] < 65 || value[0] > 90)
                {
                    throw new ArgumentException("Expected upper case letter! Argument: lastName");
                }
                surname = value;
            }
        }

    }
    
    class Student:Human
    {
        private string fn;
        public Student(string name, string surname, string fn) : base(name, surname)
        {
            this.Fn = fn;
        }

        public virtual string Fn
        {
            get
            {
                return fn;
            }
            set
            {
                if (value.Length < 5 || value.Length > 10)
                {
                    throw new ArgumentException("Invalid faculty number!"); 
                }
                fn = value;
            }
        }
    }

    class Worker : Human
    {
        private double salary;
        private int hours;
        public Worker(string name, string surname, double salary, int hours) : base(name, surname){
            this.Salary = salary;
            this.Hours = hours;
        }

        public virtual int Hours
        {
            get
            {
                return hours;
            }
            set
            {
                if (value < 1 || value > 15)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }
                hours = value;
            }
        }

        public virtual double Salary
        {
            get
            {
                return salary;
            }
            set
            {
                if (value < 9)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }
                salary = value;
            }
        }
    }
    static void Main()
    {
        string name = Console.ReadLine();
        string surname = Console.ReadLine();
        string fk = Console.ReadLine();
        try
        {
            Student student = new Student(name, surname, fk);
            Console.WriteLine("\n"+student.Name+" " + student.Surname + " " + student.Fn);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
            return;
        }

        Console.WriteLine("\n\n\n\n\n");


        name = Console.ReadLine();
        surname = Console.ReadLine();
        double salary = double.Parse(Console.ReadLine());
        int hours = int.Parse(Console.ReadLine());
        try
        {
            Worker worker = new Worker(name, surname, salary, hours);
            Console.WriteLine("\n" + worker.Name + " " + worker.Surname + " " + worker.Salary);
            Console.WriteLine("Hours per day: "+worker.Hours);
            Console.WriteLine("Week Salary: " + worker.Salary);
            Console.WriteLine("Salary per hour: " + Math.Round(worker.Salary/7/worker.Hours, 2));
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
            return;
        }
    }
}
