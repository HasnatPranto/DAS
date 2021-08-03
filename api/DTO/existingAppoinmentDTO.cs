using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTO
{
  public class existingAppoinmentDTO
  {
    public string PatientName { get; set; }
   
    public string DoctorName { get; set; }
   
    public DateTime? AppoinmentDate { get; set; }

    public string PatientPhoneNumber { get; set; }

    public int SerialNumber { get; set; }
  }
}
