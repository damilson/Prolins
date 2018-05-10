using SIPE.Repositorio.Data;
using SIPE.Servico.DTO;
using System.Collections.Generic;

namespace SIPE.Servico.Interface
{
    public interface IDisciplinaServico
    {
        IList<DisciplinaDTO> Get();

        DisciplinaDTO Get(int Id);

        void Post(DisciplinaDTO disciplina);

        void Put(DisciplinaDTO disciplina);

        void Delete(int Id);
    }
}
