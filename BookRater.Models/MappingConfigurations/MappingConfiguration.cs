using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookRater.Data.Entities;
using BookRater.Models.GenreModels;
using BookRater.Models.ReviewModels;

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
            CreateMap<GenreEntity, GenreListItem>().ReverseMap();
            CreateMap<GenreEntity, GenreListItem>().ReverseMap();
        }
    }
}