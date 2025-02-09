using Microsoft.EntityFrameworkCore;
using WebApiClinica.Data;
using WebApiClinica.Dto.Consulta;
using WebApiClinica.Models;

namespace WebApiClinica.Services.Consulta
{
    public class ConsultaService : IConsultaService
    {

        private readonly ApplicationDbContext _context;

        public ConsultaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<ConsultaModel>>> AtualizarConsulta(ConsultaEdicaoDto consultaEdicaoDto)
        {
            ResponseModel<List<ConsultaModel>> resposta = new ResponseModel<List<ConsultaModel>>();
            try
            {
                var consulta = await _context.Consultas
                    .Include(a => a.Paciente)
                    .Include(a => a.Medico)
                    .FirstOrDefaultAsync(consultaBanco => consultaBanco.ConsultaId == consultaEdicaoDto.ConsultaId);

                var paciente = await _context.Pacientes
                    .FirstOrDefaultAsync(pacienteBanco => pacienteBanco.PacienteId == consultaEdicaoDto.Paciente.Id);

                var medico = await _context.Medicos
                    .FirstOrDefaultAsync(medicoBanco => medicoBanco.MedicoId == consultaEdicaoDto.Medico.Id);


                if (paciente == null)
                {
                    resposta.Mensagem = "Nenhum livro localizado";
                    return resposta;
                }

                if (medico == null)
                {
                    resposta.Mensagem = "Nenhum registro de Autor localizado";
                    return resposta;
                }


                consulta.DataHora = consultaEdicaoDto.DataHora;
                consulta.Descricao = consultaEdicaoDto.Descricao;
                consulta.Status = consultaEdicaoDto.Status;
                consulta.Paciente = paciente;
                consulta.Medico = medico;



                _context.Update(consulta);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Consultas.ToListAsync();
                resposta.Mensagem = "Livro Editado com sucecsso";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }
        }

        public async Task<ResponseModel<List<ConsultaModel>>> CriarConsulta(ConsultaCriacaoDto consultaCriacaoDto)
        {
            ResponseModel<List<ConsultaModel>> resposta = new ResponseModel<List<ConsultaModel>>();
            try
            {
                var medico = await _context.Medicos
                    .FirstOrDefaultAsync(medicoBanco => medicoBanco.MedicoId == consultaCriacaoDto.Medico.MedicoId);
                if (medico == null)
                {
                    resposta.Mensagem = "Nenhum registro de Médico localizado";
                    return resposta;
                }

                var paciente = await _context.Pacientes
                     .FirstOrDefaultAsync(pacienteBanco => pacienteBanco.PacienteId == consultaCriacaoDto.Paciente.PacienteId);
                if (paciente == null)
                {
                    resposta.Mensagem = "Nenhum registro de Paciente localizado";
                    return resposta;
                }


                var consulta = new ConsultaModel()
                {
                    DataHora = consultaCriacaoDto.DataHora,
                    Descricao = consultaCriacaoDto.Descricao,
                    Status = consultaCriacaoDto.Status,
                    Paciente = paciente,
                    Medico = medico
                };

                _context.Add(consulta);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Consultas
                    .Include(p => p.Paciente)
                    .Include(p => p.Medico)
                    .ToListAsync();
                resposta.Mensagem = "Consulta cadastrada com sucesso!";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }

        }

        public async Task<ResponseModel<ConsultaModel>> ListarConsultaPorId(int idConsulta)
        {
            ResponseModel<ConsultaModel> resposta = new ResponseModel<ConsultaModel>();
            try
            {
                var consulta = await _context.Consultas
                    .Include(p => p.Paciente)
                    .Include(p => p.Medico)
                    .FirstOrDefaultAsync(consultaBanco => consultaBanco.ConsultaId == idConsulta);

                resposta.Dados = consulta;
                resposta.Mensagem = "A consulta foi encontrada!";
                resposta.Status = true;

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }
        }

        public async Task<ResponseModel<List<ConsultaModel>>> ListarConsultas()
        {
            ResponseModel<List<ConsultaModel>> resposta = new ResponseModel<List<ConsultaModel>>();
            try
            {
                // Consulta ao banco com projeção para o modelo ConsultaModel
                var consultas = await _context.Consultas
                    .Include(c => c.Paciente) // Inclui os dados do paciente
                    .Include(c => c.Medico)   // Inclui os dados do médico
                    .ToListAsync();

                resposta.Dados = consultas;
                resposta.Mensagem = "Todas as consultas foram encontradas!";
                resposta.Status = true;

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }
        }

        public async Task<ResponseModel<List<ConsultaModel>>> RemoverConsulta(int idConsulta)
        {
            ResponseModel<List<ConsultaModel>> resposta = new ResponseModel<List<ConsultaModel>>();

            try
            {
                var consulta = await _context.Consultas.FirstOrDefaultAsync(consultaBanco => consultaBanco.ConsultaId == idConsulta);

                if (consulta == null)
                {
                    resposta.Mensagem = "Nenhuma consulta localizada";
                    return resposta;
                }

                _context.Consultas.Remove(consulta);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Consultas.ToListAsync();
                resposta.Mensagem = "consulta removida com sucecsso";

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
