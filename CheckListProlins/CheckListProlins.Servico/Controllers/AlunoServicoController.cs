using System;
using System.Collections.Generic;
using AutoMapper;
using SIPE.Repositorio.Interface;
using SIPE.Repositorio.Model;
using SIPE.Servico.DTO;
using SIPE.Servico.Interface;

namespace SIPE.Servico.Controllers
{
    public class AlunoServicoController : IAlunoServico
    {
        private readonly IAlunoData _aluno;
        private readonly IMapper _mapper;

        public AlunoServicoController(IAlunoData aluno, IMapper mapper)
        {
            _aluno = aluno;
            _mapper = mapper;
        }

        public AlunoDTO Get(int id)
        {
            var aluno = _aluno.Buscar(id);
            return _mapper.Map<Aluno, AlunoDTO>(aluno);
        }

        public AlunoDTO Get(string UserId)
        {
            var aluno = _aluno.Buscar(UserId);
            return _mapper.Map<Aluno, AlunoDTO>(aluno);
        }

        public AlunoDTO Get(int matricula, DateTime datadeNascimento)
        {
            var aluno = _aluno.Buscar(matricula, datadeNascimento);
            return _mapper.Map<Aluno, AlunoDTO>(aluno);
        }

        public IList<AlunoDTO> Get()
        {
            var alunosLista = _aluno.ListarAlunos();
            var alunos = _mapper.Map<List<AlunoDTO>>(alunosLista);

            return alunos;
        }

        public void Post(AlunoDTO aluno)
        {
            Validar(aluno);
            var alunoDTO = _mapper.Map<AlunoDTO, Aluno>(aluno);
            _aluno.Salvar(alunoDTO);
        }

        public void Delete(int id)
        {
            _aluno.Deletar(id);
        }

        public void Put(AlunoDTO aluno)
        {
            var alunoDTO = _mapper.Map<AlunoDTO, Aluno>(aluno);
            _aluno.Editar(alunoDTO);
        }

        private void Validar(AlunoDTO aluno)
        {
            if(string.IsNullOrWhiteSpace(aluno.NomeMae) && string.IsNullOrWhiteSpace(aluno.NomeMae))
                throw new Exception("O pai ou a mãe deve ser informado,");

            if(!string.IsNullOrWhiteSpace(aluno.NomeMae) && aluno.TelMae == 0)
                throw new Exception("0 telefone da mãe deve ser informado.");

            if(!string.IsNullOrWhiteSpace(aluno.NomePai) && aluno.TelPai == 0)
                throw new Exception("0 telefone do pai deve ser informado.");

            if(string.IsNullOrWhiteSpace(aluno.Usuario.Nome))
                throw new Exception("0 nome do aluno deve ser informado.");

        }
    }
}
