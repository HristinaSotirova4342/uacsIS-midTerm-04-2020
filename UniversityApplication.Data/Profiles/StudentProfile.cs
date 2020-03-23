using AutoMapper;

using UniversityApplication.Data.DTOs;
using UniversityApplication.Data.Models;

namespace UniversityApplication.Data.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDTO>()
                .ReverseMap();
                //.ForPath(x=>x.Id, x=>x.Ignore());
                //.ForPath(x=>x.Address.Id, x=>x.Ignore())
                //.ForPath(x => x.Address.City, x => x.Ignore())
                //.ForPath(x => x.Address.Students, x => x.Ignore())
                //.ForPath(x => x.Address.Country, x => x.Ignore());
        }
    }
}
