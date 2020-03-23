using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


using UniversityApplication.Data.DTOs;

namespace UniversityApplication.Service.Service
{
   public interface IExamsService
    {
        IEnumerable<ExamsDTO> GetExams();

        Task<ExamsDTO> GetExam(int id);

        ExamsDTO SaveExams(ExamsDTO exams);

        ExamsDTO PutExams(int id, ExamsDTO examObject);

        bool DeleteExams(int id);
       
    }
}
