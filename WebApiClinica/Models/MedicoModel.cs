using System.Text.Json.Serialization;

namespace WebApiClinica.Models
{
    public class MedicoModel
    {
        public int MedicoId { get; set; }
        public string Nome { get; set; }
        public string CRM { get; set; }
        public string Especialidade { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        // Relacionamento com Consulta
        [JsonIgnore]
        public ICollection<ConsultaModel> Consultas { get; set; }
    }
}
