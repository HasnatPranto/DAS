using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace api.Models
{
    public partial class Schedule
    {
       [Key]
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       [Required]
        public string Id { get; set; }
        [Required]
        public string DoctorName { get; set; }
        [Required]
        public string Day { get; set; }
        [Required]
        public TimeSpan? BeginTime { get; set; }
        [Required]
        public TimeSpan? EndTime { get; set; }
    }
}
