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

        //*Seed Data - Will Change, This is just a base
        // protected override void OnModelCreating(ModelBuilder builder)
        // {
        //     base.OnModelCreating(builder);

        //     builder.Entity<AuthorEntity>().HasData(
        //         new AuthorEntity
        //         {
        //             Id = 1,
        //             Name = "Happy Readers"
        //         },
        //         new AuthorEntity
        //         {
        //             Id = 2,
        //             Name = "Sad Readers"
        //         },
        //         new AuthorEntity
        //         {
        //             Id = 3,
        //             Name = "Bored Readers"
        //         }
        //     )
        // }
    }
}