using System.Dynamic;

namespace Knihovna;


class Program
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public DateTime PublishedDate { get; set; }
        public int Pages { get; set; }

        public Book(string title, string author, string publishedDate, string pages)
        {
            Title = title;
            Author = author;
            Pages = int.Parse(pages);
            string[] poleDat = publishedDate.Split("-");
            int year = int.Parse(poleDat[0]);
            int month = int.Parse(poleDat[1]);
            int day = int.Parse(poleDat[2]);
            PublishedDate = new DateTime(year, month, day);
        }


        public void List()
        {   

            Console.WriteLine($"Kniha:{Title}, autor: {Author}, vydáno {PublishedDate.Date}, stran: {Pages}");
        }

        public void Stats()
        {

        }

        public static string NactiKnihuOdUzivatele()
        {
            Console.WriteLine("Zadej nazev knihy, autora, datum vydani a pocet stran ve formátu: ADD; nazev; autor; datum vydani ve formatu [yyyy-mm-dd];pocet stran");
            string vstupUzivatele = Console.ReadLine();
            return vstupUzivatele;
        }


        static void Main(string[] args)
        {


            List<Book> bookList = new List<Book>() { };


            while (true)
            {
                Console.WriteLine("1 - ulozit novou knihu");
                Console.WriteLine("2 - vypsat knihy podle data vydani");
                Console.WriteLine("3 - vypsat počet knih od autora");
                Console.WriteLine("4 - vypsat knihy podle prumerneho poctu stran");
                Console.WriteLine("5 - vypsat knihy podle klicoveho slova");
                Console.WriteLine("6 - ukoncit aplikaci");
                Console.WriteLine("Uzivateli, zvol akci:");
                int akce = int.Parse(Console.ReadLine());

                switch (akce)
                {
                    case 1:
                        string[] poleVstupu = NactiKnihuOdUzivatele().Split(";");
                        string title = poleVstupu[1];
                        string author = poleVstupu[2];
                        string publishedDate = poleVstupu[3];
                        string pages = poleVstupu[4];
                        var newBook = new Book(title, author, publishedDate, pages);
                        bookList.Add(newBook);
                        break;

                    case 2:
                        List<Book> booksByDate = bookList.OrderByDescending(book => book.PublishedDate).ToList();
                        foreach (Book book in booksByDate)
                        {
                            book.List();
                        }
                        break;
                    case 3:

                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        Console.WriteLine("Ukoncuji apikaci");
                        return;


                }

            }


        }// endMain      
    }
}// endProgram

