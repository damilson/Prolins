namespace SIPE.Servico.DTO
{
    public class NotaDTO
    {
        public int NotaId { get; set; }
        public BoletimDTO Boletim { get; set; }
        public double NotaDiciplina { get; set; }
        public DisciplinaDTO Disciplina { get; set; }
    }
}