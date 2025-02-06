using Microsoft.EntityFrameworkCore;
using WebApiClinica.Data;
using WebApiClinica.Dto.Medico;
using WebApiClinica.Dto.Paciente;
using WebApiClinica.Models;

namespace WebApiClinica.Services.Medico
{
    public class MedicoService : IMedicoService
    {
        private readonly ApplicationDbContext _context;

        public MedicoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<MedicoModel>>> AtualizarMedico(MedicoEdicaoDto medicoEdicaoDto)
        {
            ResponseModel<List<MedicoModel>> resposta = new ResponseModel<List<MedicoModel>>();
            try
            {
                var medico = await _context.Medicos.FirstOrDefaultAsync(medicoBanco => medicoBanco.MedicoId == medicoEdicaoDto.MedicoId);

                if (medico == null)
                {
                    resposta.Mensagem = $"O médico {medicoEdicaoDto.MedicoId} não foi localizado";
                    return resposta;
                }

                medico.Nome = medicoEdicaoDto.Nome;
                medico.CRM = medicoEdicaoDto.CRM;
                medico.Especialidade = medicoEdicaoDto.Especialidade;
                medico.Telefone = medicoEdicaoDto.Telefone;
                medico.Email = medicoEdicaoDto.Email;


                _context.Update(medico);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Medicos.ToListAsync();
                resposta.Mensagem = $"Os dados do paciente {medicoEdicaoDto.Nome} foram atualizados!";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }
        }

        public async Task<ResponseModel<List<MedicoModel>>> CriarMedico(MedicoCriacaoDto medicoCriacaoDto)
        {
            ResponseModel<List<MedicoModel>> resposta = new ResponseModel<List<MedicoModel>>();

            try
            {
                var medico = new MedicoModel()
                {
                    Nome = medicoCriacaoDto.Nome,
                    CRM = medicoCriacaoDto.CRM,
                    Especialidade = medicoCriacaoDto.Especialidade,
                    Telefone = medicoCriacaoDto.Telefone,
                    Email = medicoCriacaoDto.Email
                };

                _context.Add(medico);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Medicos.ToListAsync();
                resposta.Mensagem = $"Medico {medicoCriacaoDto.Nome} cadastrado com sucesso!";

                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }


        }

        public async Task<ResponseModel<MedicoModel>> ListarMedicoPorId(int idMedico)
        {
            ResponseModel<MedicoModel> resposta = new ResponseModel<MedicoModel>();

            try
            {
                var medico = await _context.Medicos.FirstOrDefaultAsync(medicoBanco => medicoBanco.MedicoId == idMedico);   

                if (medico == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado";
                    return resposta;

                }

                resposta.Dados = medico;
                resposta.Mensagem = $"Medico {idMedico} Localizado!";


                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }

        }

        public async Task<ResponseModel<List<MedicoModel>>> ListarMedicos()
        {
            ResponseModel<List<MedicoModel>> resposta = new ResponseModel<List<MedicoModel>>();

            try
            {
                var medicos = await _context.Medicos.ToListAsync();

                resposta.Dados = medicos;
                resposta.Mensagem = "Todos os médicos foram encontrados!";

                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }
        }

        public async Task<ResponseModel<List<MedicoModel>>> RemoverMedico(int idMedico)
        {
            ResponseModel<List<MedicoModel>> resposta = new ResponseModel<List<MedicoModel>>();

            try
            {
                var medico = await _context.Medicos.FirstOrDefaultAsync(medicoBanco => medicoBanco.MedicoId == idMedico);

                if (medico == null)
                {
                    resposta.Mensagem = $"O  medico {idMedico} não foi localizado";
                    return resposta;
                }

                _context.Medicos.Remove(medico);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Medicos.ToListAsync();
                resposta.Mensagem = $"Medico {medico.Nome} removido com sucesso!";
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
