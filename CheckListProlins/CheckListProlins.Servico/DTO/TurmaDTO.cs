using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIPE.Servico.DTO
{
    public class TurmaDTO
    {
        public int TurmaId { get; set; }
        public string Nome { get; set; }
        public IList<ProfessorDTO> Professores { get; set; }
        public IList<FrequenciaDTO> Frequencias { get; set; }
        public IList<AlunoDTO> Alunos { get; set; }
        public bool Excluida { get; set; }
    }
}