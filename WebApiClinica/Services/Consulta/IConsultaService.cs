using WebApiClinica.Dto.Consulta;
using WebApiClinica.Dto.Medico;
using WebApiClinica.Models;

namespace WebApiClinica.Services.Consulta
{
    public interface IConsultaService
    {
        Task<ResponseModel<ConsultaModel>> ListarConsultaPorId(int idConsulta);
        Task<ResponseModel<List<ConsultaModel>>> ListarConsultas();
        Task<ResponseModel<List<ConsultaModel>>> CriarConsulta(ConsultaCriacaoDto consultaCriacaoDto);
        Task<ResponseModel<List<ConsultaModel>>> AtualizarConsulta(ConsultaEdicaoDto consultaEdicaoDto);
        Task<ResponseModel<List<ConsultaModel>>> RemoverConsulta(int idConsulta);

    }
}
