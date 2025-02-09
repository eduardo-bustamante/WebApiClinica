using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiClinica.Dto.Consulta;
using WebApiClinica.Dto.Medico;
using WebApiClinica.Models;
using WebApiClinica.Services.Consulta;
using WebApiClinica.Services.Medico;

namespace WebApiClinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaService _consultaService;

        // Injeção de dependência do serviço
        public ConsultaController(IConsultaService consultaService)
        {
            _consultaService = consultaService;
        }

        [HttpPost("CriarConsulta")]
        public async Task<ActionResult<ResponseModel<List<ConsultaModel>>>> CriarConsulta(ConsultaCriacaoDto consultaCriacaoDto)
        {
            var consulta = await _consultaService.CriarConsulta(consultaCriacaoDto);
            return consulta;
        }

        [HttpGet("ListarConsultas")]
        public async Task<ActionResult<ResponseModel<List<ConsultaModel>>>> ListarConsultas()
        {
            var consultas = await _consultaService.ListarConsultas();
            return consultas;
        }

        [HttpGet("ListarConsultaPorId")]
        public async Task<ActionResult<ResponseModel<ConsultaModel>>> ListarConsultaPorId(int idConsulta)
        {
            var consulta = await _consultaService.ListarConsultaPorId(idConsulta);
            return consulta;
        }

        [HttpPut("AtualizarConsulta")]
        public async Task<ActionResult<ResponseModel<List<ConsultaModel>>>> AtualizarConsulta(ConsultaEdicaoDto consultaEdicaoDto)
        {
            var consulta = await _consultaService.AtualizarConsulta(consultaEdicaoDto);
            return consulta;
        }



        [HttpDelete("RemoverConsulta")]
        public async Task<ActionResult<ResponseModel<List<ConsultaModel>>>> RemoverConsulta(int idConsulta)
        {
            var consulta = await _consultaService.RemoverConsulta(idConsulta);
            return consulta;
        }
    }
}
