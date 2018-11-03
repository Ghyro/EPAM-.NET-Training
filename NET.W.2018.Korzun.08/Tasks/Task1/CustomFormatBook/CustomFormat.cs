using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Tasks.Task1
{
    public class CustomFormat : ICustomFormatter, IFormatProvider
    {
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
            {
                format = "CUSTOM";
            }

            Book book = arg as Book;

            switch (format.ToUpperInvariant())
            {
                case "CUSTOM": return $"ISBN 13: {book.ISBN}. {book.Author} - {book.Title}, {book.Publishing}, {book.YearOfPublishing}, {book.CountOfPages} pages, {book.Price.ToString("C", formatProvider = new CultureInfo("en-US"))}";
            }

            throw new FormatException(nameof(format));
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }

            return null;
        }        
    }
}
