using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace api.Models
{
    public partial class Doctor
    {
       [Key]
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string MedicalDegree { get; set; }
        [Required]
        public string Speciality { get; set; }
        [Required]
        public string Schedule { get; set; }

        public string Description { get; set; }
    }
}
