using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WebApiClinica.Data;
using WebApiClinica.Dto.Paciente;
using WebApiClinica.Models;

namespace WebApiClinica.Services.Paciente
{
    public class PacienteService : IPacienteService
    {
        private readonly ApplicationDbContext _context;

        public PacienteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<PacienteModel>>> AtualizarPaciente(PacienteEdicaoDto pacienteEdicaoDto)
        {
            ResponseModel<List<PacienteModel>> resposta = new ResponseModel<List<PacienteModel>>();
            try
            {
                var paciente = await _context.Pacientes.FirstOrDefaultAsync(pacienteBanco => pacienteBanco.PacienteId == pacienteEdicaoDto.PacienteId);

                if (paciente == null)
                {
                    resposta.Mensagem = $"O paciente {pacienteEdicaoDto} não foi localizado";
                    return resposta;
                }

                paciente.Nome = pacienteEdicaoDto.Nome;
                paciente.CPF = pacienteEdicaoDto.CPF;
                paciente.DataNascimento = pacienteEdicaoDto.DataNascimento;
                paciente.Telefone = pacienteEdicaoDto.Telefone;
                paciente.Email = pacienteEdicaoDto.Email;


                _context.Update(paciente);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Pacientes.ToListAsync();
                resposta.Mensagem = $"Os dados do paciente {pacienteEdicaoDto.Nome} foram atualizados!";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }
        }

        public async Task<ResponseModel<List<PacienteModel>>> CriarPaciente(PacienteCriacaoDto pacienteCriacaoDto)
        {
            ResponseModel<List<PacienteModel>> resposta = new ResponseModel<List<PacienteModel>>();

            try
            {
                var paciente = new PacienteModel()
                {
                    Nome = pacienteCriacaoDto.Nome,
                    CPF = pacienteCriacaoDto.CPF,
                    DataNascimento = pacienteCriacaoDto.DataNascimento,
                    Telefone = pacienteCriacaoDto.Telefone,
                    Email = pacienteCriacaoDto.Email
                };

                _context.Add(paciente);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Pacientes.ToListAsync();
                resposta.Mensagem = "Paciente cadastrado com sucesso!";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }

        }

        public async Task<ResponseModel<PacienteModel>> ListarPacientePorId(int idPaciente)
        {
            ResponseModel<PacienteModel> resposta = new ResponseModel<PacienteModel>();

            try
            {

                var paciente = await _context.Pacientes.FirstOrDefaultAsync(pacienteBanco => pacienteBanco.PacienteId == idPaciente);

                if (paciente == null)
                {
                    resposta.Mensagem = $"O  paciente {idPaciente} não foi localizado";
                    return resposta;
                }


                resposta.Dados = paciente;
                resposta.Mensagem = $"O paciente {paciente.Nome} foi encontrado!";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }
        }

        public async Task<ResponseModel<List<PacienteModel>>> ListarPacientes()
        {
            ResponseModel<List<PacienteModel>> resposta = new ResponseModel<List<PacienteModel>>();

            try
            {
                var pacientes = await _context.Pacientes.ToListAsync();
                resposta.Dados = pacientes;
                resposta.Mensagem = "Todos os Pacientes foram Encontrados!";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }
        }

        public async Task<ResponseModel<List<PacienteModel>>> RemoverPaciente(int idPaciente)
        {
            ResponseModel<List<PacienteModel>> resposta = new ResponseModel<List<PacienteModel>>();

            try
            {
                var paciente = await _context.Pacientes.FirstOrDefaultAsync(pacienteBanco => pacienteBanco.PacienteId == idPaciente);

                if (paciente == null)
                {
                    resposta.Mensagem = $"O  paciente {idPaciente} não foi localizado";
                    return resposta;
                }

                _context.Pacientes.Remove(paciente);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Pacientes.ToListAsync();
                resposta.Mensagem = $"Paciente {paciente.Nome} removido com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }
        }
    }
}
