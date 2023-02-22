using AutoMapper;
using Core.Utilities.Results;
using LibraryAPI.Business.Services.Abstract;
using LibraryAPI.DataAccess.Entities.Models;
using LibraryAPI.DataAccess.Repositories.Abstract;
using LibraryAPI.DataAccess.Repositories.Concrete;
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


        public ResultInfo AddOrUpdateReader(Reader reader)
        {
            var result = new Result();
            if (reader.Id is 0)
            {
                _readerRepository.Add(reader);
            }
            else
            {
                _readerRepository.Update(reader);
            }

            if (reader is null)
            {
                return ResultInfo.NotImplemented;
            }

            return ResultInfo.Success;
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

        public Result GetReaderById(int id)
        {
            var result = new Result();

            var reader = _readerRepository.Get(id);
            result.Data = reader;
            if (result.Data == null)
            {
                return result;
            }
            return result;
        }

        public Result GetReaderByName(string name)
        {
            var result = new Result();

            var response = _readerRepository.GetReaderByName(name);
            if(response is null)
            {
                return result;
            }
            result.Data = response;

            return result;

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
