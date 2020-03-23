using System.ComponentModel.DataAnnotations;

using UniversityApplication.Data.Validators;

namespace UniversityApplication.Data.DTOs
{
    public class TranscriptDTO
    {
        [IdNotSend(ErrorMessage = "You cannot input an Id of an Transcript")]
        public int Id { get; set; }

        public int ExamId { get; set; }

        [Required(ErrorMessage = "You have to add a StudentId")]
        [Range(1, int.MaxValue, ErrorMessage = "StudentId needs to be greater than 0")]
        public int StudentId { get; set; }

        public decimal Points { get; set; }
        
    }
}
