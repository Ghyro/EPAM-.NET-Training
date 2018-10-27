using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Task1;

namespace BookConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IBookListStorage bookListStorage = new BookListToBinary("storage.dat");

            IBookListService bookService = new BookService(bookListStorage);

            bookService.AddBook(new Book("918-1-16197-276-1", "Джеффри Рихтер", "CLR via C#", "Питер", 2016, 896, 55));
            bookService.AddBook(new Book("928-2-26197-376-2", "Джон Скит", "C# программирование для профессионалов", "Вильямс", 2018, 608, 68));
            bookService.AddBook(new Book("938-3-36197-476-3", "Марк Дж. Прайс", "C# 7 и .NET Core.", "Питер", 2018, 640, 75));
            bookService.AddBook(new Book("948-4-46197-576-4", "Эндрю Троелсен", "Язык программирования C# 6.0", "Вильямс", 2017, 1440, 123));
            bookService.AddBook(new Book("958-5-56197-676-5", "Герберт Шилдт", "C# 4.0. Полное руководство", "Вильямс", 2015, 1056, 60));

            var findBook = new List<Book>();
            findBook.Add(bookService.FindBookByTag("CLR via C#"));

            GetFindBook(findBook);

            bookService.SaveBooskInStorage();

            Console.ReadLine();
        }
        
        public static void GetFindBook(List<Book> books)
        {
            foreach (var i in books)
            {
                Console.WriteLine(i);
            }
        }
    }
}
