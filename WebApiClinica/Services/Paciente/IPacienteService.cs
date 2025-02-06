using WebApiClinica.Dto.Paciente;
using WebApiClinica.Models;

namespace WebApiClinica.Services.Paciente
{
    public interface IPacienteService
    {

        Task<ResponseModel<PacienteModel>> ListarPacientePorId(int idPaciente);
        Task<ResponseModel<List<PacienteModel>>> ListarPacientes();
        Task<ResponseModel<List<PacienteModel>>> CriarPaciente(PacienteCriacaoDto pacienteCriacaoDto);
        Task<ResponseModel<List<PacienteModel>>> AtualizarPaciente(PacienteEdicaoDto pacienteEdicaoDto);
        Task<ResponseModel<List<PacienteModel>>> RemoverPaciente(int idPaciente);
    }
}
        
