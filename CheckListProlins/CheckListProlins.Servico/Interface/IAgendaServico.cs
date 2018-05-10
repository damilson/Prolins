using SIPE.Servico.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPE.Servico.Interface
{
    public interface IAgendaServico
    {
        List<AgendaDTO> Get();

        AgendaDTO Get(int Id);

        void Post(AgendaDTO agenda);

        void Put(AgendaDTO agenda);

        void Delete(int Id);
    }
}
