using BookRater.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookRater.Data.BookRaterContext
{
    public class BookRaterDBContext : IdentityDbContext<UserEntity>
    {
        public BookRaterDBContext(DbContextOptions<BookRaterDBContext> options) : base(options) { }

        public DbSet<AuthorEntity> Authors { get; set; }
        public DbSet<BookEntity> Book { get; set; }
        public DbSet<GenreEntity> Genre { get; set; }
        public DbSet<ReviewEntity> Reviews { get; set; }
        public DbSet<BookRating> BookRatings { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                }
            );

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
                },
                new AuthorEntity
                {
                    Id = 4,
                    FirstName = "Jane",
                    LastName = "Austen"
                }
            );

            builder.Entity<ReviewEntity>().HasData(
                new ReviewEntity
                {
                    Id = 1,
                    Comment = "Excellent book",
                },
                new ReviewEntity
                {
                    Id = 2,
                    Comment = "Okay book",
                }
);

            builder.Entity<BookRating>().HasData(
                new BookRating
                {
                    Id = 1,
                    Rating = 9,
                    ReviewEntityId = 1

                },
                new BookRating
                {
                    Id = 2,
                    Rating = 10,
                    ReviewEntityId = 1
                },
                new BookRating
                {
                    Id = 3,
                    Rating = 10,
                    ReviewEntityId = 2
                }
            );
        }
    }
}