using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Knihovna;

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


}
