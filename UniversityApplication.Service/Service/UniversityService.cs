using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.EntityFrameworkCore;

using UniversityApplication.Data;
using UniversityApplication.Data.DTOs;
using UniversityApplication.Data.Models;

namespace UniversityApplication.Service.Service
{
    public class UniversityService : IUniversityService
    {
        private readonly IMapper _mapper;
        private readonly UniversityDataContext _dataContext;

        public UniversityService(UniversityDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public IEnumerable<StudentDTO> GetStudents()
        {
            var students = _dataContext.Students
                .Include(s => s.Address);

            return _mapper.Map<IEnumerable<StudentDTO>>(students);
        }

        public async Task<StudentDTO> GetStudent(int id)
        {
            var student = await _dataContext.Students.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<StudentDTO>(student);
        }

        public StudentDTO SaveStudent(StudentDTO student)
        {
            Student newStudent = _mapper.Map<Student>(student);

            _dataContext.Students.Add(newStudent);
            _dataContext.SaveChanges();

            return _mapper.Map<StudentDTO>(newStudent);
        }

        public bool DeleteStudent(int id)
        {

            var student = _dataContext.Students.FirstOrDefault(x => x.Id == id);

            if (student == null)
            {
                return false;
            }

            _dataContext.Students.Remove(student);
            _dataContext.SaveChanges();
            return true;
        }

        public StudentDTO PutStudent(int id, StudentDTO studentObject)
        {
            var student = _dataContext.Students.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                throw new Exception("Student not found");
            }

            studentObject.Id = id;
            student = _mapper.Map<Student>(studentObject);
            _dataContext.SaveChanges();

            return _mapper.Map<StudentDTO>(student);
        }
    }
}
