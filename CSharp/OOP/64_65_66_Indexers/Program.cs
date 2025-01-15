using System;
using System.Collections.Generic;

namespace _64_65_66_Indexers
{
    public class BookCollection
    {
        private Dictionary<string, Dictionary<int, string>> booksByGenre = new();
        private string[] books = new string[100];
        private int currentCount = 0;

        // Normal indexer for accessing books by integer index
        public string this[int index]
        {
            get
            {
                if (index < 0 || index >= books.Length)
                    throw new IndexOutOfRangeException("Index is out of range");
                return books[index];
            }
            set
            {
                if (index < 0 || index >= books.Length)
                    throw new IndexOutOfRangeException("Index is out of range");
                books[index] = value;
                if (index >= currentCount)
                    currentCount = index + 1;
            }
        }

        // Overloaded indexer that allows accessing books by their ISBN (string)
        public string this[string isbn]
        {
            get
            {
                for (int i = 0; i < currentCount; i++)
                {
                    if (books[i]?.Contains(isbn) == true)
                        return books[i];
                }
                return "Book not found";
            }
        }

        // Multi-parameter indexer to access books by genre and edition number
        public string this[string genre, int edition]
        {
            get
            {
                if (booksByGenre.TryGetValue(genre, out var editionDict))
                {
                    if (editionDict.TryGetValue(edition, out var book))
                        return book;
                    return $"Edition {edition} not found in {genre}";
                }
                return $"Genre {genre} not found";
            }
            set
            {
                if (!booksByGenre.ContainsKey(genre))
                    booksByGenre[genre] = new Dictionary<int, string>();

                booksByGenre[genre][edition] = value;
            }
        }

        public int Count => currentCount;

        public void DisplayGenreCatalog()
        {
            foreach (var genre in booksByGenre)
            {
                Console.WriteLine($"\nGenre: {genre.Key}");
                foreach (var edition in genre.Value)
                {
                    Console.WriteLine($"  Edition {edition.Key}: {edition.Value}");
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var library = new BookCollection();

            // Using integer indexer to add books
            library[0] = "The Great Gatsby (ISBN: 978-0743273565)";
            library[1] = "To Kill a Mockingbird (ISBN: 978-0446310789)";
            library[2] = "1984 (ISBN: 978-0451524935)";

            // Using integer indexer to retrieve a book
            Console.WriteLine("Book at index 1: " + library[1]);

            // Using string indexer to find a book by ISBN
            Console.WriteLine("Searching by ISBN 978-0451524935: " +
                library["978-0451524935"]);

            // Using multi-parameter indexer to add books by genre and edition
            library["Science Fiction", 1] = "Dune (First Edition)";
            library["Science Fiction", 2] = "Foundation (Second Edition)";
            library["Mystery", 1] = "The Da Vinci Code (First Edition)";
            library["Mystery", 2] = "Sherlock Holmes (Second Edition)";

            // Retrieving books using multi-parameter indexer
            Console.WriteLine("\nRetrieving books by genre and edition:");
            Console.WriteLine(library["Science Fiction", 1]);
            Console.WriteLine(library["Mystery", 2]);
            Console.WriteLine(library["Romance", 1]); // Genre not found
            Console.WriteLine(library["Science Fiction", 5]); // Edition not found

            // Display complete genre catalog
            Console.WriteLine("\nComplete Genre Catalog:");
            library.DisplayGenreCatalog();

            // Display total number of books
            Console.WriteLine($"\nTotal books in main collection: {library.Count}");
        }
    }
}



