using System.Collections.Generic;
using System.Threading.Tasks;

using UniversityApplication.Data.DTOs;

namespace UniversityApplication.Service.Service
{
    public interface IUniversityService
    {
        IEnumerable<StudentDTO> GetStudents();
        Task<StudentDTO> GetStudent(int id);
        StudentDTO SaveStudent(StudentDTO student);
        StudentDTO PutStudent(int id, StudentDTO studentObject);
        bool DeleteStudent(int id);
    }
}