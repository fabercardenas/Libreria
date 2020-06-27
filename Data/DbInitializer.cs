using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Libreria.Models;

namespace Libreria.Data
{
    public static class DbInitializer
    {
        public static void Initialize(LibraryDbContext context)
        {
            //context.Database.EnsureCreated();

            //// Look for any authors.
            //if (context.Authors.Any())
            //{
            //    return;   // DB has been seeded
            //}

            //var author = new Author[]
            //{
            //    new Author{ Name="Carson", Last_Name="Alexander", Email ="uno@dos.com"},
            //    new Author{Name="Meredith",Last_Name="Alonso",Email ="uno@dos.com"},
            //    new Author{Name="Arturo",Last_Name="Anand",Email ="uno@dos.com"},
            //    new Author{Name="Gytis",Last_Name="Barzdukas",Email ="uno@dos.com"},
            //};
            //foreach (Author s in author)
            //{
            //    context.Authors.Add(s);
            //}
            //context.SaveChanges();

            //var books = new Book[]
            //{
            //    new Book{AuthorID=1, Title="Chemistry",Description="des"},
            //    new Book{AuthorID=2,Title="Microeconomics",Description="des"},
            //    new Book{AuthorID=3,Title="Macroeconomics",Description="des"}
            //};
            //foreach (Book c in books)
            //{
            //    context.Books.Add(c);
            //}
            //context.SaveChanges();
         }
    }
}
