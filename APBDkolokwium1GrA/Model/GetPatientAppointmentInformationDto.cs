namespace APBDkolokwium1GrA.Model;

public class GetPatientAppointmentInformationDto
{
    public DateTime AppointmentDate { get; set; }
    public AppointedPatientDto AppointedPatient { get; set; }
    public AppointedDoctorDto AppointedDoctor { get; set; }
    public List<AppointedServicesDto> AppointedServices { get; set; } = [];
}

public class AppointedPatientDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
}

public class AppointedDoctorDto
{
    public int DoctorId { get; set; }
    public string Pwz { get; set; }
}

public class AppointedServicesDto
{
    public string ServiceName { get; set; }
    public double ServiceFee { get; set; }
}
