using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Util.Enumeradores;

namespace SIPE.Servico.DTO
{
    public class AlunoDTO
    {
        public int AlunoId { get; set; }
        public UsuarioDTO Usuario { get; set; }
        public int Matricula { get; set; }
        public DateTime Ano { get; set; }
        public Turno Turno { get; set; }
        public string NomePai { get; set; }
        public string NomeMae { get; set; }
        public int TelPai { get; set; }
        public int TelMae { get; set; }
        public TurmaDTO Turma { get; set; }
        public IList<BoletimDTO> Boletim { get; set; }
    }
}