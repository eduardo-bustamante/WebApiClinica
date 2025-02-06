using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiClinica.Dto.Paciente;
using WebApiClinica.Models;
using WebApiClinica.Services.Paciente;

[ApiController]
[Route("api/[controller]")]
public class PacienteController : ControllerBase
{
    private readonly IPacienteService _pacienteService;

    // Injeção de dependência do serviço
    public PacienteController(IPacienteService pacienteService)
    {
        _pacienteService = pacienteService;
    }

    // POST: api/Paciente
    [HttpPost("CriarPaciente")]
    public async Task<ActionResult<ResponseModel<List<PacienteModel>>>> CriarPaciente(PacienteCriacaoDto pacienteCriacaoDto)
    {
        var paciente = await _pacienteService.CriarPaciente(pacienteCriacaoDto);
        return paciente;


    }

    [HttpGet("ListarPacientes")]
    public async Task<ActionResult<ResponseModel<List<PacienteModel>>>> ListarPacientes()
    {
        var pacientes = await _pacienteService.ListarPacientes();

        return Ok(pacientes);

    }

    [HttpGet("BuscarPacientePorId/{idPaciente}")]
    public async Task<ActionResult<ResponseModel<PacienteModel>>> ListarPacientePorId(int idPaciente)
    {
        var paciente = await _pacienteService.ListarPacientePorId(idPaciente);

        return Ok(paciente);

    }

    [HttpPut("AtualizarPaciente")]
    public async Task<ActionResult<ResponseModel<List<PacienteModel>>>> AtualizarPaciente(PacienteEdicaoDto pacienteEdicaoDto)
    {
        var paciente = await _pacienteService.AtualizarPaciente(pacienteEdicaoDto);

        return Ok(paciente);

    }



    [HttpDelete("RemoverPaciente/{idPaciente}")]
    public async Task<ActionResult<ResponseModel<List<PacienteModel>>>> RemoverPaciente(int idPaciente)
    {
        var paciente = await _pacienteService.RemoverPaciente(idPaciente);

        return Ok(paciente);

    }



}