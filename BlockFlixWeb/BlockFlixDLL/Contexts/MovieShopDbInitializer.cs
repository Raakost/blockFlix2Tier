using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockFlixDLL.Entities;

namespace BlockFlixDLL.Contexts
{
    class MovieShopDbInitializer : CreateDatabaseIfNotExists<MovieShopContext>
    {
        protected override void Seed(MovieShopContext db)
        {
            var genre1 = new Genre() { ID = 1, Name = "Drama" };
            var genre2 = new Genre() { ID = 2, Name = "Crime" };
            var genre3 = new Genre() { ID = 3, Name = "Action" };
            var genre4 = new Genre() { ID = 4, Name = "Sci-fi" };
            var genre5 = new Genre() { ID = 5, Name = "Horror" };
            var genre6 = new Genre() { ID = 6, Name = "Adventure" };

            db.Genres.Add(genre1);
            db.Genres.Add(genre2);
            db.Genres.Add(genre3);

            db.Movies.Add(new Movie()
            {
                ID = 1,
                Title = "Room",
                Year = 2015,
                Price = 120.00,
                ImageURL = "https://images-na.ssl-images-amazon.com/images/M/MV5BMjE4NzgzNzEwMl5BMl5BanBnXkFtZTgwMTMzMDE0NjE@._V1_UX182_CR0,0,182,268_AL_.jpg",
                TrailerURL = "https://www.youtube.com/embed/PPZqF_TPTGs",
                Genres = new List<Genre> { genre1 }
            });
            db.Movies.Add(new Movie()
            {
                ID = 2,
                Title = "Interstellar",
                Year = 2014,
                Price = 100.00,
                ImageURL = "https://images-na.ssl-images-amazon.com/images/M/MV5BMjIxNTU4MzY4MF5BMl5BanBnXkFtZTgwMzM4ODI3MjE@._V1_UX182_CR0,0,182,268_AL_.jpg",
                TrailerURL = "https://www.youtube.com/embed/2LqzF5WauAw",
                Genres = new List<Genre> { genre1, genre4, genre6 }
            });
            db.Movies.Add(new Movie()
            {
                ID = 3,
                Title = "Green Room",
                Year = 2015,
                Price = 120.00,
                ImageURL = "https://images-na.ssl-images-amazon.com/images/M/MV5BMjU1ODQ5NzA0N15BMl5BanBnXkFtZTgwMDg5MTA5NzE@._V1_UX182_CR0,0,182,268_AL_.jpg",
                TrailerURL = "https://www.youtube.com/embed/eP0Ic6-OShE",
                Genres = new List<Genre> { genre2, genre5 }

            });
            db.Movies.Add(new Movie()
            {
                ID = 4,
                Title = "The Dark Knight",
                Year = 2008,
                Price = 100.00,
                ImageURL = "https://images-na.ssl-images-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_UX182_CR0,0,182,268_AL_.jpg",
                TrailerURL = "https://youtube.com/embed/EXeTwQWrcwY",
                Genres = new List<Genre> { genre1, genre2, genre3 }
            });
            db.Movies.Add(new Movie()
            {
                ID = 5,
                Title = "The Martian",
                Year = 2015,
                Price = 120.00,
                ImageURL = "https://images-na.ssl-images-amazon.com/images/M/MV5BMTc2MTQ3MDA1Nl5BMl5BanBnXkFtZTgwODA3OTI4NjE@._V1_UX182_CR0,0,182,268_AL_.jpg",
                TrailerURL = "https://www.youtube.com/embed/ej3ioOneTy8",
                Genres = new List<Genre> { genre1, genre4, genre6 }
            });
            db.Movies.Add(new Movie()
            {
                ID = 6,
                Title = "Pulp Fiction",
                Year = 1994,
                Price = 100.00,
                ImageURL = "https://images-na.ssl-images-amazon.com/images/M/MV5BMTkxMTA5OTAzMl5BMl5BanBnXkFtZTgwNjA5MDc3NjE@._V1_UX182_CR0,0,182,268_AL_.jpg",
                TrailerURL = "https://youtube.com/embed/ewlwcEBTvcg",
                Genres = new List<Genre> { genre1, genre2 }
            });
            db.Movies.Add(new Movie()
            {
                ID = 7,
                Title = "The Lord of the Rings: The Return of the King",
                Year = 2003,
                Price = 120.00,
                ImageURL = "https://images-na.ssl-images-amazon.com/images/M/MV5BMjE4MjA1NTAyMV5BMl5BanBnXkFtZTcwNzM1NDQyMQ@@._V1_UX182_CR0,0,182,268_AL_.jpg",
                TrailerURL = "https://youtube.com/embed/r5X-hFf6Bwo",
                Genres = new List<Genre> { genre1, genre6 }
            });
            db.Movies.Add(new Movie()
            {
                ID = 8,
                Title = "Fight Club",
                Year = 1999,
                Price = 100.00,
                ImageURL = "https://images-na.ssl-images-amazon.com/images/M/MV5BNGM2NjQxZTAtMmU5My00YTk5LWFmOWMtYjZlYzk4YzMwNjFlXkEyXkFqcGdeQXVyNDk3NzU2MTQ@._V1_UX182_CR0,0,182,268_AL_.jpg",
                TrailerURL = "https://youtube.com/embed/SUXWAEX2jlg",
                Genres = new List<Genre> { genre1 }
            });
            db.Movies.Add(new Movie()
            {
                ID = 9,
                Title = "The Lord of the Rings: The Fellowship of the Ring",
                Year = 2001,
                Price = 120.00,
                ImageURL = "https://images-na.ssl-images-amazon.com/images/M/MV5BNTEyMjAwMDU1OV5BMl5BanBnXkFtZTcwNDQyNTkxMw@@._V1_UY268_CR0,0,182,268_AL_.jpg",
                TrailerURL = "https://youtube.com/embed/V75dMMIW2B4",
                Genres = new List<Genre> { genre1, genre6 }
            });
            db.Movies.Add(new Movie()
            {
                ID = 10,
                Title = "Star Wars: Episode V - The Empire Strikes Back",
                Year = 1980,
                Price = 100.00,
                ImageURL = "https://images-na.ssl-images-amazon.com/images/M/MV5BYmViY2M2MTYtY2MzOS00YjQ1LWIzYmEtOTBiNjhlMGM0NjZjXkEyXkFqcGdeQXVyNDYyMDk5MTU@._V1_UX182_CR0,0,182,268_AL_.jpg",
                TrailerURL = "https://youtube.com/embed/JNwNXF9Y6kY",
                Genres = new List<Genre> { genre3, genre6 }
            });
            db.Movies.Add(new Movie()
            {
                ID = 11,
                Title = "Forrest Gump",
                Year = 1994,
                Price = 120.00,
                ImageURL = "https://images-na.ssl-images-amazon.com/images/M/MV5BYThjM2MwZGMtMzg3Ny00NGRkLWE4M2EtYTBiNWMzOTY0YTI4XkEyXkFqcGdeQXVyNDYyMDk5MTU@._V1_UY268_CR10,0,182,268_AL_.jpg",
                TrailerURL = "https://youtube.com/embed/bLvqoHBptjg",
                Genres = new List<Genre> { genre1 }
            });
            db.Movies.Add(new Movie()
            {
                ID = 12,
                Title = "Inception",
                Year = 2010,
                Price = 100.00,
                ImageURL = "https://images-na.ssl-images-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_UX182_CR0,0,182,268_AL_.jpg",
                TrailerURL = "https://youtube.com/embed/YoHD9XEInc0",
                Genres = new List<Genre> { genre3, genre4, genre6 }
            });
            db.Movies.Add(new Movie()
            {
                ID = 13,
                Title = "Harry Potter and the Sorcerer's Stone",
                Year = 2001,
                Price = 100.00,
                ImageURL = "https://images-na.ssl-images-amazon.com/images/M/MV5BMTYwNTM5NDkzNV5BMl5BanBnXkFtZTYwODQ4MzY5._V1_UY268_CR6,0,182,268_AL_.jpg",
                TrailerURL = "https://www.youtube.com/embed/VyHV0BRtdxo",
                Genres = new List<Genre> { genre6 }
            });
            db.Movies.Add(new Movie()
            {
                ID = 14,
                Title = "Harry Potter and the Chamber of Secrets",
                Year = 2002,
                Price = 100.00,
                ImageURL = "https://images-na.ssl-images-amazon.com/images/M/MV5BMTcxODgwMDkxNV5BMl5BanBnXkFtZTYwMDk2MDg3._V1_UX182_CR0,0,182,268_AL_.jpg",
                TrailerURL = "https://www.youtube.com/embed/1bq0qff4iF8",
                Genres = new List<Genre> { genre6 }
            });
            db.Movies.Add(new Movie()
            {
                ID = 15,
                Title = "Harry Potter and the Prisoner of Azkaban",
                Year = 2004,
                Price = 100.00,
                ImageURL = "https://images-na.ssl-images-amazon.com/images/M/MV5BMTY4NTIwODg0N15BMl5BanBnXkFtZTcwOTc0MjEzMw@@._V1_UX182_CR0,0,182,268_AL_.jpg",
                TrailerURL = "https://www.youtube.com/embed/lAxgztbYDbs",
                Genres = new List<Genre> { genre6 }
            });
            db.Movies.Add(new Movie()
            {
                ID = 16,
                Title = "Harry Potter and the Goblet of Fire",
                Year = 2005,
                Price = 100.00,
                ImageURL = "https://images-na.ssl-images-amazon.com/images/M/MV5BMTI1NDMyMjExOF5BMl5BanBnXkFtZTcwOTc4MjQzMQ@@._V1_UX182_CR0,0,182,268_AL_.jpg",
                TrailerURL = "https://www.youtube.com/embed/7lJ6Suyp1ok",
                Genres = new List<Genre> { genre6 }
            });

            base.Seed(db);
        }
    }
}
