using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

using UniversityApplication.Data.Validators;

namespace UniversityApplication.Data.DTOs
{
    public class AddressDTO
    {
        [IdNotSend(ErrorMessage = "You cannot input an Id of an Address")]
        public int Id { get; set; }

        [Required(ErrorMessage = "You have to enter Street")]
        [StringLength(200)]
        public string Street { get; set; }

        [Required(ErrorMessage = "You have to enter City")]
        [StringLength(400)]
        public string City { get; set; }

        [Required(ErrorMessage = "You have to enter Country")]
        [StringLength(600)]
        public string Country { get; set; }

        [Required(ErrorMessage = "You have to add a StudentId")]
        [Range(1, int.MaxValue, ErrorMessage = "StudentId needs to be greater than 0")]
        public int StudentId { get; set; }

    }
}
