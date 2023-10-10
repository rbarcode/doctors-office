using System.Collections.Generic;
using System;

namespace DoctorsOffice.Models
{
  public class Patient
  {
    public int PatientId { get; set; }
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public List<DoctorPatient> JoinEntities { get; }
  }
}