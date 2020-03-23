using System;
using System.ComponentModel.DataAnnotations;

using UniversityApplication.Data.Validators;

namespace UniversityApplication.Data.DTOs
{
    public class StudentDTO
    {
        [IdNotSend(ErrorMessage = "You cannot input an Id of a student")]
        public int Id { get; set; }

        [Required(ErrorMessage = "You have to enter a First Name")]
        [StringLength(200)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "You have to enter a Last Name")]
        [StringLength(400)]
        public string LastName { get; set; }

        [Required]
        public DateTime? EnrollmentDate { get; set; }

        public DateTime? DOB { get; set; }

        public string Mail { get; set; }

        [Required(ErrorMessage = "You have to enter an Index number")]
        [Range(1, int.MaxValue, ErrorMessage = "The Index needs to be a number greater than 0")]
        public string StudentIndex { get; set; }

        public decimal? GPA { get; set; }

        [Required(ErrorMessage = "You have to add an Address model.")]
        public int AddressId { get; set; }
       
    }
}
