using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookRater.Data.Entities;
using BookRater.Models.AuthorModels;
using BookRater.Models.BookModels;
using BookRater.Models.GenreModels;
using BookRater.Models.ReviewModels;
using BookRater.Models.UserModels;

namespace BookRater.Models.MappingConfigurations
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<ReviewEntity, ReviewCreate>().ReverseMap();
            CreateMap<ReviewEntity, ReviewDetail>().ReverseMap();
            CreateMap<ReviewEntity, ReviewEdit>().ReverseMap();
            CreateMap<ReviewEntity, ReviewListItem>().ReverseMap();

            CreateMap<BookRating, BookRatingListItem>().ReverseMap();

            CreateMap<GenreEntity, GenreCreate>().ReverseMap();
            CreateMap<GenreEntity, GenreDetail>().ReverseMap();
            CreateMap<GenreEntity, GenreEdit>().ReverseMap();
            CreateMap<GenreEntity, GenreListItem>().ReverseMap();

            CreateMap<UserEntity, UserEntityVM>().ReverseMap();

            CreateMap<BookEntity, BookCreate>().ReverseMap();
            CreateMap<BookEntity, BookDetail>().ReverseMap();
            CreateMap<BookEntity, BookEdit>().ReverseMap();
            CreateMap<BookEntity, BookListItem>().ReverseMap();

            CreateMap<AuthorEntity, AuthorCreateVM>().ReverseMap();
            CreateMap<AuthorEntity, AuthorDetailVM>().ReverseMap();
            CreateMap<AuthorEntity, AuthorEditVM>().ReverseMap();
            CreateMap<AuthorEntity, AuthorListItemVM>().ReverseMap();
        }
    }
}