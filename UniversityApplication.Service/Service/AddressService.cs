using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.EntityFrameworkCore;

using UniversityApplication.Data;
using UniversityApplication.Data.DTOs;
using UniversityApplication.Data.Models;

namespace UniversityApplication.Service.Service
{
    public class AddressService : IAddressService
    {
        private readonly IMapper _mapper;
        private readonly UniversityDataContext _dataContext;

        public AddressService(UniversityDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public IEnumerable<AddressDTO> GetAddress()
        {
            var address = _dataContext.Addresses
               .Include(s => s.Students);

            return _mapper.Map<IEnumerable<AddressDTO>>(address);
        }

        public async Task<AddressDTO> GetAddres(int id)
        {
            var address = await _dataContext.Addresses.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<AddressDTO>(address);
        }

        //public IEnumerable<AddressDTO> GetAddress()
        //{
        //    return _dataContext.Addresses
        //       .Include(t => t.Students)
        //        .AsEnumerable()
        //        .Select(t => new AddressDTO()
        //        {
        //            Id = t.Id,
        //            StudentId = t.StudentId,
        //           // Points = t.Points,
        //        }).ToList();
        //}

        //public IEnumerable<AddressDTO> GetTranscripts(int studentId)
        //{
        //    var trans = _dataContext.Transcripts.Where(x => x.StudentId == studentId);
        //    return _mapper.Map<IEnumerable<TranscriptDTO>>(trans);
        //}

        //public TranscriptDTO GetTranscript(int studentId, int examId)
        //{
        //    var transcript = _dataContext.Transcripts
        //        .Single(x => x.StudentId == studentId && x.ExamId == examId);

        //    return _mapper.Map<TranscriptDTO>(transcript);
        //}

        public AddressDTO SaveAddress(AddressDTO address)
        {
            Address newAddress = _mapper.Map<Address>(address);

            _dataContext.Addresses.Add(newAddress);
            _dataContext.SaveChanges();

            return _mapper.Map<AddressDTO>(newAddress);
        }

        public bool DeleteAddress(int id)
        {

            var address = _dataContext.Addresses.FirstOrDefault(x => x.Id == id);

            if (address == null)
            {
                return false;
            }

            _dataContext.Addresses.Remove(address);
            _dataContext.SaveChanges();
            return true;
        }

        public AddressDTO PutAddress(int id, AddressDTO addressObject)
        {
            var address = _dataContext.Addresses.FirstOrDefault(x => x.Id == id);
            if (address == null)
            {
                throw new Exception("Address not found");
            }

            addressObject.Id = id;
            address = _mapper.Map<Address>(addressObject);
            _dataContext.SaveChanges();

            return _mapper.Map<AddressDTO>(address);
        }
    }
}

