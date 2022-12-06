using System;

internal class Program
{
    class Person
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
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
                    throw new ArgumentException("name must be >3!");
                }
                name = value;
            }
        }
        public virtual int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Age must be positive!");
                }
                age = value;
            }
        }

    }
    class Child:Person
    {
        public Child(string name, int age) : base(name, age)
        {
            this.Age = age;
        }
        public override int Age
        {
            get
            {
                return base.Age;
            }
            set
            {
                if (base.Age > 15)
                {
                    throw new ArgumentException("Age must be positive!");
                }
                base.Age = value;
            }
        }

    }
    static void Main()
    {
        string name = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());
        try
        {
            Child child = new Child(name, age);
            Console.WriteLine(child.Name+" "+child.Age);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
    }
}
