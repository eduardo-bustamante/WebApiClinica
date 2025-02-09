using System.Text.Json.Serialization;

namespace WebApiClinica.Models
{
    public class ConsultaModel
    {

        public int ConsultaId { get; set; }
        public DateTime DataHora { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; } // Ex: Agendada, Realizada, Cancelada

        // Relacionamento com Paciente
        public int PacienteId { get; set; }
        public PacienteModel Paciente { get; set; }

        // Relacionamento com Medico
        public int MedicoId { get; set; }
        public MedicoModel Medico { get; set; }
    }
}
