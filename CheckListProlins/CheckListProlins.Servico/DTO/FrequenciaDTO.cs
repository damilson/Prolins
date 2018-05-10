using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Util.Enumeradores;

namespace SIPE.Servico.DTO
{
    public class FrequenciaDTO
    {
        public int FrequenciaId { get; set; }
        public IList<PresencaDTO> Presencas { get; set; }
        public DateTime Data { get; set; }
        public TurmaDTO Turma { get; set; }
        public Turno Turno { get; set; }
        public DisciplinaDTO Disciplína { get; set; }
    }
}