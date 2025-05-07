using APBDkolokwium1GrA.Model;

namespace APBDkolokwium1GrA.Services;

public interface IDbService
{
    Task<int> GetInformationAboutAppointmentByIDAsync(int patientId);
    Task<int> CreateNewAppointmentAsync(int patientId, CreateNewAppointmentDto appointment);
}