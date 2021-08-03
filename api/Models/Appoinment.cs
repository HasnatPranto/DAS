using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace api.Models
{
    public partial class Appoinment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public string Id { get; set; }
        [Required]
        public string PatientName { get; set; }
        [Required]
        public string DoctorName { get; set; }
        [Required]
        public DateTime? AppoinmentDate { get; set; }
      
       
        public string PatientPhoneNumber { get; set; }

        public int SerialNumber { get; set; }

  }
}
