using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIPE.Servico.DTO
{
    public class BoletimDTO
    {
        public int BoletimId { get; set; }
        public DateTime Data { get; set; }
        public IList<NotaDTO> Notas { get; set; }
        public bool Fechado { get; set; }
    }
}
