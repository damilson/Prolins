using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIPE.Servico.DTO;

namespace SIPE.Servico.Interface
{
    public interface IAlunoServico
    {

        AlunoDTO Get(int id);
        AlunoDTO Get(string UserId);

        IList<AlunoDTO> Get();
        void Post(AlunoDTO aluno);
        void Delete(int id);
        void Put(AlunoDTO aluno);
        AlunoDTO Get(int matricula, DateTime datadeNascimento);
    }
}
