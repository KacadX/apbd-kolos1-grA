using APBDkolokwium1GrA.Model;
using Microsoft.Data.SqlClient;

namespace APBDkolokwium1GrA.Services;

public class DbService : IDbService
{
    private readonly string _connectionString;

    public DbService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
    }

    public async Task<int> GetInformationAboutAppointmentByIDAsync(int patientId)
    {
        var query =
            @"SELECT date, first_name, last_name, date_of_birth, doctor_id, PWZ, name, base_fee" +
            " FROM Appointment a" +
            " JOIN Patient p ON a.patient_id = p.patient_id" +
            " JOIN Doctor d ON d.doctor_id = p.doctor_id" +
            " JOIN Appointment_Service aps ON aps.appointment_id = a.appointment_id" +
            " JOIN Service s ON s.service_id = aps.service_id" +
            " WHERE p.patient_id = @patientId ";
        
        await using SqlConnection connection = new SqlConnection(_connectionString);
        await using SqlCommand command = new SqlCommand();
        
        command.Connection = connection;
        command.CommandText = query;
        await connection.OpenAsync();

        command.Parameters.AddWithValue("@patientID", patientId);
        var reader = await command.ExecuteReaderAsync();

        GetPatientAppointmentInformationDto? appointments = null;

        while (await reader.ReadAsync())
        {
            if (appointments is null)
            {
                appointments = new GetPatientAppointmentInformationDto
                {
                    AppointmentDate = reader.GetDateTime(0),
                    AppointedPatient =
                    {
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        DateOfBirth = reader.GetDateTime(3),
                    },
                    AppointedDoctor =
                    {
                        DoctorId = reader.GetInt32(4),
                        Pwz = reader.GetString(5),
                    },
                    AppointedServices = new List<AppointedServicesDto>()
                };
            }
        }
        
        throw new NotImplementedException();
    }

    public async Task<int> CreateNewAppointmentAsync(int patientId, CreateNewAppointmentDto appointment)
    {
        throw new NotImplementedException();
    }
}