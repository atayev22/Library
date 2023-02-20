using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Business.Services.Abstract
{
    public interface IAutorService
    {
        Result GetAuthorsBrose();
        Result GetAuthorById(int id);
        Result GetAuthorByName(string name);
        ResultInfo AddOrUpdateAuthor(int id);
        ResultInfo DeleteAuthor(int id);

    }
}
