using SIPE.Servico.DTO;
using System;
using System.Collections.Generic;
using System.Web;

namespace SIPE.Servico.Interface
{
    public interface IFrequenciaServico
    {
        List<FrequenciaDTO> Get();

        FrequenciaDTO Get(int Id);

        void Post(FrequenciaDTO frequencia, List<int> presentes);

        void Put(FrequenciaDTO frequencia);
    }
}
