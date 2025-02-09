namespace WebApiClinica.Dto.Consulta
{
    public class ConsultaEdicaoDto
    {
        public int ConsultaId { get; set; }
        public DateTime DataHora { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; } // Ex: Agendada, Realizada, Cancelada
        public ConsultaEdicaoId Paciente {  get; set; }
        public ConsultaEdicaoId Medico { get; set; }
    }
}
