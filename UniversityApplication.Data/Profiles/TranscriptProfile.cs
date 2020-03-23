using AutoMapper;

using UniversityApplication.Data.DTOs;
using UniversityApplication.Data.Models;

namespace UniversityApplication.Data.Profiles
{
    public class TranscriptProfile : Profile
    {
        public TranscriptProfile()
        {
            CreateMap<Transcript, TranscriptDTO>()
                .ReverseMap();
        }
    }
}
