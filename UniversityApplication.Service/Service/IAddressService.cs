using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


using UniversityApplication.Data.DTOs;



namespace UniversityApplication.Service.Service
{
    public interface IAddressService
    {
        IEnumerable<AddressDTO> GetAddress();

        Task<AddressDTO> GetAddres(int id);

        //AddressDTO GetAddress(int id);

        AddressDTO SaveAddress(AddressDTO address);

        AddressDTO PutAddress(int id, AddressDTO addressObject);

        bool DeleteAddress(int id);



    }
}
