using AutoMapper;
using LibraryAPI.Core.Entities.Dtos.Book;
using LibraryAPI.DataAccess.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApi.BaseLog.Utilities.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Book, BookBrowseDto>().ReverseMap();
            CreateMap<Book, BookAddOrUpdateDto>().ReverseMap();
        }
    }
}
