using AutoMapper;
using LibraryAPI.Core.Entities.Dtos.AuthorDtos;
using LibraryAPI.Core.Entities.Dtos.BookDtos;
using LibraryAPI.Core.Entities.Dtos.UserDtos;
using LibraryAPI.Core.Entities.Models;
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
            #region Book
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Book, BookBrowseDto>().ReverseMap();
            CreateMap<Book, BookAddOrUpdateDto>().ReverseMap();
            #endregion

            #region Author
            CreateMap<Author, AuthorBrowseDto>().ReverseMap();
            #endregion

            #region User
            CreateMap<User, UserRegisterDto>().ReverseMap();
            CreateMap<User, UserLogInDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            #endregion
        }
    }
}
