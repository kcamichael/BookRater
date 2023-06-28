using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookRater.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookRater.Data.BookRaterContext
{
    public class BookRaterDBContext : IdentityDbContext<UserEntity>
    {
        public BookRaterDBContext(DbContextOptions options) : base(options) { }

        public DbSet<AuthorEntity> Author { get; set; }
        public DbSet<BookEntity> Book { get; set; }
        public DbSet<GenreEntity> Genre { get; set; }
        public DbSet<ReviewEntity> Review { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<GenreEntity>().HasData(
                new GenreEntity
                {
                    Id = 1,
                    GenreName = "Biography"
                },
                new GenreEntity
                {
                    Id = 2,
                    GenreName = "Romance"
                },
                new GenreEntity
                {
                    Id = 3,
                    GenreName = "Science Fiction"
                },
                new GenreEntity
                {
                    Id = 4,
                    GenreName = "Fantasy"
                },
                new GenreEntity
                {
                    Id = 5,
                    GenreName = "Thriller"
                }
            );

            builder.Entity<AuthorEntity>().HasData(
                new AuthorEntity
                {
                    Id = 1,
                    FirstName = "Jeff",
                    LastName = "Pearlman"
                },
                new AuthorEntity
                {
                    Id = 2,
                    FirstName = "James",
                    LastName = "Patterson"
                },
                new AuthorEntity
                {
                    Id = 3,
                    FirstName = "Stephen",
                    LastName = "King"
                }
                new AuthorEntity
                {
                    Id = 4,
                    FirstName = "Jane",
                    LastName = "Austen"
                }
            );
        }
    }
}