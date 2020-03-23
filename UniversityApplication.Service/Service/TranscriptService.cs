using System;
using System.Collections.Generic;
using System.Linq;

using AutoMapper;

using Microsoft.EntityFrameworkCore;

using UniversityApplication.Data;
using UniversityApplication.Data.DTOs;
using UniversityApplication.Data.Models;

namespace UniversityApplication.Service.Service
{
    public class TranscriptService : ITranscriptService
    {
        private readonly IMapper _mapper;
        private readonly UniversityDataContext _dataContext;

        public TranscriptService(UniversityDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public IEnumerable<TranscriptDTO> GetTranscripts()
        {
            return _dataContext.Transcripts
                .Include(t=>t.Exam)
                .AsEnumerable()
                .Select(t => new TranscriptDTO()
            {
                Id = t.Id,
                StudentId = t.StudentId,
                Points = t.Points,
            }).ToList();
        }

        public IEnumerable<TranscriptDTO> GetTranscripts(int studentId)
        {
            var trans = _dataContext.Transcripts.Where(x => x.StudentId == studentId);
            return _mapper.Map<IEnumerable<TranscriptDTO>>(trans);
        }

        public TranscriptDTO GetTranscript(int studentId, int examId)
        {
            var transcript = _dataContext.Transcripts
                .Single(x => x.StudentId == studentId && x.ExamId == examId);

            return _mapper.Map<TranscriptDTO>(transcript);
        }

        public TranscriptDTO SaveTranscript(TranscriptDTO transcript)
        {
            Transcript newTranscript = _mapper.Map<Transcript>(transcript);

            _dataContext.Transcripts.Add(newTranscript);
            _dataContext.SaveChanges();

            return _mapper.Map<TranscriptDTO>(newTranscript);
          
        }

        public bool DeleteTranscript(int id)
        {
            var transcript = _dataContext.Transcripts.FirstOrDefault(x => x.Id == id);

            if (transcript == null)
            {
                return false;
            }

            _dataContext.Transcripts.Remove(transcript);
            return _dataContext.SaveChanges() > 0;
        }

        public TranscriptDTO PutPoints(int id, TranscriptDTO transcriptObject)
        {
            var transcript = _dataContext.Transcripts.FirstOrDefault(x => x.Id == id);
            if (transcript == null)
            {
                throw new Exception("Transcript not found");
            }

            transcriptObject.Id = transcript.Id;
            transcript = _mapper.Map<Transcript>(transcriptObject);
            _dataContext.SaveChanges();
            

            return _mapper.Map<TranscriptDTO>(transcript);
        }

        
    }
}
