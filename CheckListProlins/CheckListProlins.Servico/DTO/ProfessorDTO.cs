using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Util.Enumeradores;

namespace SIPE.Servico.DTO
{
    public class ProfessorDTO
    {
        public int ProfessorId { get; set; }
        public UsuarioDTO Usuario { get; set; }
        public CategorioaDeEnsino CategoriaDeEnsino { get; set; }
        public IList<DisciplinaDTO> Disciplinas { get; set; }
        public IList<TurmaDTO> Turmas { get; set; }
        public CordenadorDTO Cordenador { get; set; }
    }
}