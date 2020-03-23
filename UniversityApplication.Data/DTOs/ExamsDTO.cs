using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

using UniversityApplication.Data.Validators;


namespace UniversityApplication.Data.DTOs
{
    public class ExamsDTO
    {
        [IdNotSend(ErrorMessage = "You cannot input an Id of an Exam")]
        public int Id { get; set; }

        [Required(ErrorMessage = "You have to enter Name")]
        [StringLength(200)]
        public string Name { get; set; }

        [Required(ErrorMessage = "You have to enter ProffesorName")]
        [StringLength(400)]
        public string ProfessorName { get; set; }

        [Required(ErrorMessage = "You have to enter Credits")]
        [StringLength(600)]
        public string Credits { get; set; }

        [Required(ErrorMessage = "You have to add a StudentId")]
        [Range(1, int.MaxValue, ErrorMessage = "StudentId needs to be greater than 0")]
        public int StudentId { get; set; }
    }
}
