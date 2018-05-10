using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIPE.Servico.DTO
{
    public class PresencaDTO
    {
        public int PresencaId { get; set; }
        public FrequenciaDTO Frequencia { get; set; }
        public AlunoDTO Aluno { get; set; }
        public bool Presente { get; set; }
    }
}