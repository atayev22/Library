using Core.Utilities.Results;
using LibraryAPI.DataAccess.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Business.Services.Abstract
{
    public interface IAuthorService
    {
        Result GetAuthorsBrowse();
        Result GetAuthorById(int id);
        Result GetAuthorByName(string name);
        ResultInfo AddOrUpdateAuthor(Author author);
        ResultInfo DeleteAuthor(int id);

    }
}
