using System;
internal class Program
{
   class Book
    {
        private string title;
        private string author;
        private double price;

        public Book(string author, string title, double price)
        {
            this.Author = author;
            this.Title = title;
            this.Price = price;
        }
        public string Author
        {
            get
            {
                return author;
            }
            set
            {
                if (value[0] >= 48 && value[0] <= 57)
                {
                    throw new ArgumentException("Shoul not start with number");
                }
                author = value;
            }
        }
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (value.Length <= 3)
                {
                    throw new ArgumentException("Lenght > 3!");
                }
                title = value;
            }
        }
        public virtual double Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price > 0!");
                }
                price = value;
            }
        }

    }
    class GoldenEditionBook:Book
    {
        public GoldenEditionBook(string author, string title, double price) : base(author, title, price)
        {
        }
        public override double Price
        {
            get
            {
                return base.Price * 1.3;
            }

        }
    }
    static void Main()
    {
        try
        {
            string author = Console.ReadLine();
            string title = Console.ReadLine();
            double price = double.Parse(Console.ReadLine());
            Book book = new Book(author, title, price);
            GoldenEditionBook goldenEditionBook = new GoldenEditionBook(author, title, price);
            Console.WriteLine(book + Environment.NewLine);
            Console.WriteLine(goldenEditionBook);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }

    }
}
