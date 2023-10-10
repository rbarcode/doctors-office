using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace DoctorsOffice.Models
{
  public class Patient
  {
    public int PatientId { get; set; }
    [Required(ErrorMessage = "Please provide a name.")]
    public string Name { get; set; }
    // [Required(ErrorMessage = "Please give us a birthday.")]
    public DateTime BirthDate { get; set; }
    public List<DoctorPatient> JoinEntities { get; }
  }
}