using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIPE.Servico.DTO
{
    public class AgendaDTO
    {
        public int AgendaId { get; set; }
        public TurmaDTO Turma { get; set; }
        public DateTime Data { get; set; }
        public string Conteudo { get; set; }
        public DisciplinaDTO Disciplina { get; set; }
        public bool Excluida { get; set; }
    }
}