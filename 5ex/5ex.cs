using System;
using System.Diagnostics;
internal class Program
{
    static void FindWord(ref string v, ref string temp)
    {
        string b = "";
        for (int i = 0; i < v.Length; i++)
        {
            if (v[i] == ' ')
            {
                v = v.Remove(i, 1);
                break;
            }
            else
            {
                b += v[i];
                v = v.Remove(i, 1);
                i--;
            }
        }
        temp = b;
    }
    abstract class FacroryFood
    {
        abstract public string name { get; }
        abstract public int k { get; }
    }

    class Food : FacroryFood
    {
        private string namef;
        private int km;
        public Food(string namef, int km)
        {
            this.km = km;
            this.namef = namef;
        }
        public override int k { get { return km; } }
        public override string name { get { return namef; } }
    }

    class Mood
    {
        int nmood = 0;

        public void SetMood(int a)
        {
            nmood += a;
        }

        public virtual int Nmood
        {
            get
            {
                if (nmood > 15)
                {
                    Console.Write("Gandalf is narkoman - ");
                    return nmood;
                }
                else if (nmood > 0 && nmood < 15)
                {
                    Console.Write("Gandalf is happy - ");
                    return nmood;
                }
                else if (nmood < 0 && nmood > -5)
                {
                    Console.Write("Gandalf is sad - ");
                    return nmood;
                }
                else
                {
                    Console.Write("Gandalf is angry - ");
                    return nmood;
                }
            }
        }

    }
    static void Main()
    {
        Stopwatch stopwatch = new Stopwatch();
        Mood Gandalf = new Mood();
        Food[] prod = new Food[6];
        prod[0] = new Food("Cram", 2);
        prod[1] = new Food("Lembas", 3);
        prod[2] = new Food("Apple", 1);
        prod[3] = new Food("Melon", 1);
        prod[4] = new Food("HoneyCake", 5);
        prod[5] = new Food("Mushrooms", -10);

        string a = Console.ReadLine();
        if (a.Length >= 1000)
        {
            Console.WriteLine("Tebe pizda");
            return;
        }
        stopwatch.Start();
        int kn = 0;
        while (true)
        {
            int i = 0;
            string temp = "";
            FindWord(ref a, ref temp);
            foreach (FacroryFood s in prod)
            {
                if (temp == s.name)
                {
                    Gandalf.SetMood(s.k);
                    i++;
                    kn++;
                    break;
                }
            }
            if (i == 0)
            {
                Gandalf.SetMood(1);
                kn++;
            }
            if (a == "" || a == " ")
            {
                break;
            }
            if (kn >= 100)
            {
                Console.WriteLine("A vse, limit");
                break;
            }
        }

        Console.WriteLine(Gandalf.Nmood);
        stopwatch.Stop();
        Console.WriteLine("\n\n\n\n"+ stopwatch.ElapsedMilliseconds +"ms");
        float gd = (int)System.Diagnostics.Process.GetCurrentProcess().WorkingSet64/ 1048576;
        Console.WriteLine(gd+"mb");
    }
}