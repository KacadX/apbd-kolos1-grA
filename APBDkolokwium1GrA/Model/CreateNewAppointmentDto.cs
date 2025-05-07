namespace APBDkolokwium1GrA.Model;

public class CreateNewAppointmentDto
{
    public int AppointmentId { get; set; }
    public int PatientId { get; set; }
    public string PWZ { get; set; }
    public List<ServicesDto> Services { get; set; } = [];
}

public class ServicesDto
{
    public string ServiceName { get; set; }
    public double ServiceFee { get; set; }
}