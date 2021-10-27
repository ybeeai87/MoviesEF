using System;
using System.Collections.Generic;
using System.Linq;

namespace MoviesEF
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\t\t\t    Welcome To The GC Movie Theatre!");
            bool runProgram = true;
            while (runProgram)
            {
                // MoviesList();
                MovieSearch();
                runProgram = Validator.Validator.getContinue();
            }
        }

        static void DisplayTitle()
        {
            Console.WriteLine("\t\t\t\t\t\tNOW AIRING:");
            MoviesDBContext context = new MoviesDBContext();
            foreach (Movie m in context.Movies)
            {
                Console.WriteLine($"\t\t\t\t\t\t{m.Title}");
            }
            Console.WriteLine("\t\t\t\t\t-------------------------------------------------");
        }
        static void DisplayGenre()
        {
            MoviesDBContext context = new MoviesDBContext();
            Console.WriteLine("\t\t\t\t\t\tGenres:\n\t\t\t\t\t\t---------");
            Console.WriteLine($"\t\t\t\t\t\tHorror\n\t\t\t\t\t\tAnimated\n\t\t\t\t\t\tFantasy");
            Console.WriteLine("\t\t\t\t\t\t---------");
        }
        static void MovieSearch()
        {
            while (true)
            {
                Console.WriteLine("\t\t\t\tWould you like to search by genre or title?");
                string input = Console.ReadLine().ToLower().Trim();
                if (input == "genre")
                {
                    DisplayGenre();
                    GenreSearch();
                    break;
                }
                else if (input == "title")
                {
                    DisplayTitle();
                    TitleSearch();
                    break;
                }
                else
                {
                    Console.WriteLine("That was not a valid option. Try again");
                }
            }
        }
        static void GenreSearch()
        {
            while (true)
            {
                MoviesDBContext context = new MoviesDBContext();
                Console.WriteLine("\t\t   What genre would you like to search? Horror/Animated/Fantasy");
                string input = Console.ReadLine().ToLower().Trim();
                List<Movie> ByGenre = context.Movies.Where(movie => movie.Genre == input).ToList();
                if (ByGenre.Count() == 0)
                {
                    Console.WriteLine("That was not a valid option. Try again.");
                }
                else
                {
                    foreach (Movie m in ByGenre)
                    {
                        Console.WriteLine($"\t\t\t\t\t\tTitle: {m.Title}\n\t\t\t\t\t\tGenre: {m.Genre}\n\t\t\t\t\t\tRuntime: {m.Runtime} minutes");
                        Console.WriteLine("\t\t\t\t\t--------------------------------------------------\n");
                    }
                    break;
                }
            }
        }

        static void TitleSearch()
        {
            while (true)
            {
                MoviesDBContext context = new MoviesDBContext();
                Console.WriteLine("\t\t\t\t\t\tPlease enter the title of the movie.");
                string input = Console.ReadLine().ToLower().Trim();
                List<Movie> ByTitle = context.Movies.Where(movie => movie.Title == input).ToList();
                if (ByTitle.Count() == 0)
                {
                    Console.WriteLine("That was not a valid option. Try again.");
                }
                else
                {
                    foreach (Movie m in ByTitle)
                    {
                        Console.WriteLine($"\t\t\t\t\t\tTitle: {m.Title}\n\t\t\t\t\t\tGenre: {m.Genre}\n\t\t\t\t\t\tRuntime: {m.Runtime} minutes");
                        Console.WriteLine("\t\t\t\t\t--------------------------------------------------\n");
                    }
                    break;
                }
            }
        }
        public static void MoviesList()
        {
            using (MoviesDBContext context = new MoviesDBContext())
            {
                Movie movie1 = new Movie
                {
                    Title = "Up",
                    Genre = "Animated",
                    Runtime = 98
                };

                Movie movie2 = new Movie
                {
                    Title = "Soul",
                    Genre = "Animated",
                    Runtime = 125
                };

                Movie movie3 = new Movie
                {
                    Title = "The Good Dinosaur",
                    Genre = "Animated",
                    Runtime = 100
                };

                Movie movie4 = new Movie
                {
                    Title = "Halloween",
                    Genre = "Horror",
                    Runtime = 120
                };

                Movie movie5 = new Movie
                {
                    Title = "The Blob",
                    Genre = "Horror",
                    Runtime = 78
                };

                Movie movie6 = new Movie
                {
                    Title = "The Exorcist",
                    Genre = "Horror",
                    Runtime = 120
                };

                Movie movie7 = new Movie
                {
                    Title = "Dune",
                    Genre = "Fantasy",
                    Runtime = 150
                };

                Movie movie8 = new Movie
                {
                    Title = "Fellowship Of The Ring",
                    Genre = "Fantasy",
                    Runtime = 240
                };

                Movie movie9 = new Movie
                {
                    Title = "Willow",
                    Genre = "Fantasy",
                    Runtime = 125
                };

                Movie movie10 = new Movie
                {
                    Title = "Cloudy With A Chance Of Meatballs",
                    Genre = "Animated",
                    Runtime = 104
                };

                context.Movies.Add(movie1);
                context.Movies.Add(movie2);
                context.Movies.Add(movie3);
                context.Movies.Add(movie4);
                context.Movies.Add(movie5);
                context.Movies.Add(movie6);
                context.Movies.Add(movie7);
                context.Movies.Add(movie8);
                context.Movies.Add(movie9);
                context.Movies.Add(movie10);

                context.SaveChanges();
            }
        }
    }
}
