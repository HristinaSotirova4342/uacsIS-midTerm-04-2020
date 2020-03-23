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
    public class ExamsService : IExamsService
    {
        
            private readonly IMapper _mapper;
            private readonly UniversityDataContext _dataContext;

            public ExamsService(UniversityDataContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }

            public IEnumerable<ExamsDTO> GetExams()
            {
                var exams = _dataContext.Exams
                   .Include(s => s.Students);

                return _mapper.Map<IEnumerable<ExamsDTO>>(exams);
            }

            public async Task<ExamsDTO> GetExam(int id)
            {
                var exams = await _dataContext.Exams.FirstOrDefaultAsync(x => x.Id == id);
                return _mapper.Map<ExamsDTO>(exams);
            }

            public ExamsDTO SaveExams(ExamsDTO exams)
            {
                Exam newExams = _mapper.Map<Exam>(exams);

                _dataContext.Exams.Add(newExams);
                _dataContext.SaveChanges();

                return _mapper.Map<ExamsDTO>(newExams);
            }

            public bool DeleteExams(int id)
            {

                var exam = _dataContext.Exams.FirstOrDefault(x => x.Id == id);

                if (exam == null)
                {
                    return false;
                }

                _dataContext.Exams.Remove(exam);
                _dataContext.SaveChanges();
                return true;
            }

            public ExamsDTO PutExams(int id, ExamsDTO examObject)
            {
                var exam = _dataContext.Exams.FirstOrDefault(x => x.Id == id);
                if (exam == null)
                {
                    throw new Exception("Exam not found");
                }

                examObject.Id = id;
                exam = _mapper.Map<Exam>(examObject);
                _dataContext.SaveChanges();

                return _mapper.Map<ExamsDTO>(exam);
            }
        }
    }

