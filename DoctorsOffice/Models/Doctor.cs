using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DoctorsOffice.Models
{
  public class Doctor
  {
    public int DoctorId { get; set; }
    [Required(ErrorMessage = "Please provide a name.")]
    public string Name { get; set; }

    public List<DoctorPatient> JoinEntities { get; } // collection navigation property.
  }
}