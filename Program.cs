using System.Dynamic;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Microsoft.VisualBasic;
using System.Linq;
using System.Security.Cryptography;
using System.ComponentModel.Design;
using System.Collections.Immutable;

namespace Knihovna;


class Program
{

        public static string NactiKnihuOdUzivatele()
        {
            Console.WriteLine(" ADD; [nazev]; [autor]; [datum vydani ve formatu yyyy-mm-dd];[pocet stran]");
            string vstupUzivatele = Console.ReadLine();
            return vstupUzivatele;
        }
        
        
        

        static void Main(string[] args)
        {    
            Book prvniKniha = new Book ("1984","George Orwell", "1949-06-08","328");
            Book druhaKniha = new Book("Brave New World", "Aldous Huxley", "1932-01-01", "311");
            Book tretiKniha = new Book ("Animal Farm", "George Orwell", "1945-08-17", "112");
            Book ctvrtaKniha = new Book("The Light Fantastic", "Terry Pratchett", "1986-02-15", "271");
    
             List<Book> bookList = new List<Book>( ) {prvniKniha, druhaKniha, tretiKniha, ctvrtaKniha };
        

            while (true)
            {
                Console.WriteLine("ADD [ulozit novou knihu]");
                Console.WriteLine("LIST [vypsat knihy podle data vydani]");
                Console.WriteLine("STATS [vypsat průměrný počet stran a počet knih podle autora]");
                Console.WriteLine("FIND [vypsat knihy podle klicoveho slova]");
                Console.WriteLine("END [ukoncit aplikaci]");
                Console.WriteLine("Uzivateli, zvol akci:");
                string akce = Console.ReadLine().ToUpper();

                switch (akce)
                {
                    case "ADD":
                        string[] poleVstupu = NactiKnihuOdUzivatele().Split(";");
                        string title = poleVstupu[1];
                        string author = poleVstupu[2];
                        string publishedDate = poleVstupu[3];
                        string pages = poleVstupu[4];
                        var newBook = new Book(title, author, publishedDate, pages);
                        bookList.Add(newBook);
                        break;

                    case "LIST" :
                        List<Book> booksByDate = bookList.OrderByDescending(book => book.PublishedDate).ToList();
                        foreach (Book book in booksByDate)
                        {
                            book.List();
                        }
                        break;
                    case "STATS":
                        var booksPages = bookList.Where(b => b.Pages > 0).Select(b => b.Pages);
                        double averagePages = booksPages.Average();
                        Console.WriteLine($"Prumerny pocet stran: {averagePages}");

                        Console.WriteLine($"Pocet knih podle autora:");
                          
                                foreach (var booksByAuthor in bookList.GroupBy(b => b.Author))
                            {
                            var jmenaAutoru = booksByAuthor.Key;
                                var numberOfBooksByAuthor = booksByAuthor.Count();
                                Console.WriteLine($"{jmenaAutoru}: {numberOfBooksByAuthor}");

                            }
                        break;
                    case "FIND":
                        Console.WriteLine("Zadej klicove slovo z nazvu knihy:");
                        string hledaneSlovo = Console.ReadLine();


                    var dotaz = from h in bookList.Where(k => k.Title.ToLower().Contains(hledaneSlovo.ToLower()))select h.Title;
                   foreach (var h in dotaz)
                    {
                        Console.WriteLine(h);
                    }
                   

                    
                       

                        break;
                    case "END":
                        Console.WriteLine("Ukoncuji apikaci.");
                        return;


                }

            }


        }// endMain      
    }


