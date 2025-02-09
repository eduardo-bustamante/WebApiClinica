using WebApiClinica.Models;

namespace WebApiClinica.Dto.Consulta
{
    public class ConsultaCriacaoDto
    {
        public DateTime DataHora { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; } // Ex: Agendada, Realizada, Cancelada

        public ConsultaPacienteDto Paciente { get; set; }

        public ConsultaMedicoDto Medico { get; set; }

    }
}
