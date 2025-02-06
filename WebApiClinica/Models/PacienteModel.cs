using System.Text.Json.Serialization;

namespace WebApiClinica.Models
{
    public class PacienteModel
    {
        public int PacienteId { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        // Relacionamento com Consulta
        [JsonIgnore]
        public ICollection<ConsultaModel> Consultas { get; set; }
    }
}
