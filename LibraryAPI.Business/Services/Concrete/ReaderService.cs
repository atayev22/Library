using AutoMapper;
using Core.Utilities.Results;
using LibraryAPI.Business.Services.Abstract;
using LibraryAPI.DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Business.Services.Concrete
{
    public class ReaderService : IReaderService
    {
        private readonly IReaderRepository _readerRepository;
        private readonly IMapper _mapper;
        public ReaderService(IReaderRepository readerRepository, IMapper mapper)
        {
            _readerRepository = readerRepository;
            _mapper = mapper;
        }


        public ResultInfo AddOrUpdateReader(int id)
        {
            throw new NotImplementedException();
        }

        public ResultInfo DeleteReader(int id)
        {
            var response = _readerRepository.Delete(id);
            if (response is false)
            {
                return ResultInfo.NotFound;
            }
            return ResultInfo.Deleted;
        }

        public Result GetReaderByContact(string name)
        {
            throw new NotImplementedException();
        }

        public Result GetReaderByName(string name)
        {
            throw new NotImplementedException();
        }

        public Result GetReadersBrowse()
        {
            var result = new Result();

            var response = _readerRepository.GetAll();
            result.Data = response;

            return result;
            
        }
    }
}
