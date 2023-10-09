namespace DoctorsOffice.Models
{
  public class DoctorPatient //Join Entity
  {
    // primary key
    public int DoctorPatientId { get; set; }

    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    // reference navigation property #1


    public int PatientId { get; set; }
    public Patient Patient { get; set; }
    // refernce navigation property #2

  }
}