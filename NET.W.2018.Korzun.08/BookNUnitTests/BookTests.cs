using System;
using Tasks.Task1;
using NUnit.Framework;

namespace BookNUnitTests
{
    [TestFixture]
    public class BookTests
    {
        [Test]
        [TestCase("IATPYCP", ExpectedResult = "958-5-56197-676-5. Герберт Шилдт - C# 4.0. Полное руководство, Вильямс, 2015, 1056 pages, $60.00.")]
        [TestCase("IATPYC", ExpectedResult = "958-5-56197-676-5. Герберт Шилдт - C# 4.0. Полное руководство, Вильямс, 2015, 1056 pages.")]
        [TestCase("IATPY", ExpectedResult = "958-5-56197-676-5. Герберт Шилдт - C# 4.0. Полное руководство, Вильямс, 2015.")]
        [TestCase("IATP", ExpectedResult = "958-5-56197-676-5. Герберт Шилдт - C# 4.0. Полное руководство, Вильямс.")]
        [TestCase("IAT", ExpectedResult = "958-5-56197-676-5. Герберт Шилдт - C# 4.0. Полное руководство.")]
        [TestCase("AT", ExpectedResult = "Герберт Шилдт - C# 4.0. Полное руководство.")]
        public string Book_InputFormat_NUnit(string format)
        {
            //Arrange
            Book book = new Book("958-5-56197-676-5", "Герберт Шилдт", "C# 4.0. Полное руководство", "Вильямс", 2015, 1056, 60);

            //Act
            return book.FormatToString(format, null);
        }

        [TestCase("CUSTOMFORMAT", ExpectedResult = "958-5-56197-676-5. Герберт Шилдт - C# 4.0. Полное руководство, Вильямс, 2015, 1056 pages, $60.00.")]
        public string Book_InputCustomFormat_NUnit(string format)
        {
            //Arrange
            Book bookCustomFormat = new Book("958-5-56197-676-5", "Герберт Шилдт", "C# 4.0. Полное руководство", "Вильямс", 2015, 1056, 60);

            //Act
            return string.Format(new CustomFormat(), format, bookCustomFormat);
        }
    }
}
