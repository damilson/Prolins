using SIPE.Servico.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPE.Servico.Interface
{
    public interface ICordenadorServico
    {
        List<CordenadorDTO> Get();

        CordenadorDTO Get(int Id);

        void Post(CordenadorDTO usuario);

        void Put(CordenadorDTO usuario);

        void Delete(int Id);
    }
}
