namespace WebApiClinica.Dto.Paciente
{
    public class PacienteCriacaoDto
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

    }
}
