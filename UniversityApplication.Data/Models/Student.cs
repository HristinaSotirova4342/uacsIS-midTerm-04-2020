using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityApplication.Data.Models
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? EnrollmentDate { get; set; }

        public DateTime? DOB { get; set; }

        public string Mail { get; set; }

        public string StudentIndex { get; set; }

        public decimal? GPA { get; set; }

        [ForeignKey("AddressId")]
        public int AddressId { get; set; }

        public virtual Address Address { get; set; }

        public virtual List<Transcript> Exams { get; set; }

    }
}
