using Core.Utilities.Results;
using LibraryAPI.DataAccess.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Business.Services.Abstract
{
    public interface IReaderService
    {
        Result GetReadersBrowse();
        ResultInfo AddOrUpdateReader(Reader reader);
        Result GetReaderById(int id);
        Result GetReaderByName(string name);
        Result GetReaderByContact(string name);
        ResultInfo DeleteReader(int id);

    }
}
