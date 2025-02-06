using WebApiClinica.Dto.Medico;
using WebApiClinica.Models;

namespace WebApiClinica.Services.Medico
{
    public interface IMedicoService
    {
        Task<ResponseModel<MedicoModel>> ListarMedicoPorId(int idMedico);
        Task<ResponseModel<List<MedicoModel>>> ListarMedicos();
        Task<ResponseModel<List<MedicoModel>>> CriarMedico(MedicoCriacaoDto medicoCriacaoDto);
        Task<ResponseModel<List<MedicoModel>>> AtualizarMedico(MedicoEdicaoDto medicoEdicaoDto);
        Task<ResponseModel<List<MedicoModel>>> RemoverMedico(int idMedico);
    }
}
