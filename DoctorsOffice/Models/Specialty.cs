using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace DoctorsOffice.Models
{
  public class Specialty
  {
    public int SpecialtyId { get; set; }
    [Required(ErrorMessage = "Please provide a specialty.")]
    public string Name { get; set; }
    public List<DoctorSpecialty> JoinEntities { get; }
  }
}