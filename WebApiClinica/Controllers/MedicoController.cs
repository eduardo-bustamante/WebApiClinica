using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiClinica.Dto.Medico;
using WebApiClinica.Dto.Paciente;
using WebApiClinica.Models;
using WebApiClinica.Services.Medico;
using WebApiClinica.Services.Paciente;

namespace WebApiClinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly IMedicoService _medicoService;

        // Injeção de dependência do serviço
        public MedicoController(IMedicoService medicoService)
        {
            _medicoService = medicoService;
        }

        // POST: api/Paciente
        [HttpPost("CriarMedico")]
        public async Task<ActionResult<ResponseModel<List<MedicoModel>>>> CriarMedico(MedicoCriacaoDto medicoCriacaoDto)
        {
            var paciente = await _medicoService.CriarMedico(medicoCriacaoDto);
            return paciente;
        }

        [HttpGet("ListarMedicos")]
        public async Task<ActionResult<ResponseModel<List<PacienteModel>>>> ListarMedicos()
        {
            var medicos = await _medicoService.ListarMedicos();

            return Ok(medicos);

        }

        [HttpGet("ListarMedicoPorId/{idMedico}")]
        public async Task<ActionResult<ResponseModel<PacienteModel>>> ListarMedicoPorId(int idMedico)
        {
            var medico = await _medicoService.ListarMedicoPorId(idMedico);

            return Ok(medico);

        }

        [HttpPut("AtualizarMedico")]
        public async Task<ActionResult<ResponseModel<MedicoModel>>> AtualizarMedico(MedicoEdicaoDto medicoEdicaoDto)
        {
            var medico = await _medicoService.AtualizarMedico(medicoEdicaoDto);
            return Ok(medico);
        }

        [HttpDelete("RemoverMedico")]
        public async Task<ActionResult<ResponseModel<MedicoModel>>> RemoverMedico(int idMedico)
        {
            var medico = await _medicoService.RemoverMedico(idMedico);
            return Ok(medico);
        }


    }
}
