namespace DoctorsOffice.Models
{
  public class DoctorSpecialty //Join Entity
  {
    // primary key
    public int DoctorSpecialtyId { get; set; }

    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    // reference navigation property #1


    public int SpecialtyId { get; set; }
    public Specialty Specialty { get; set; }
    // refernce navigation property #2

  }
}