using AutoMapper;
using SIPE.Repositorio.Interface;
using SIPE.Servico.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SIPE.Servico.DTO;
using SIPE.Repositorio.Model;

namespace SIPE.Servico.Controllers
{
    public class ProfessorSevicoController : IProfessorServico
    {
        private readonly IProfessorData _professorData;
        private readonly IMapper _mapper;

        public ProfessorSevicoController(IProfessorData professorData, IMapper mapper)
        {
            _professorData = professorData;
            _mapper = mapper;
        }

        public void Delete(int Id)
        {
            _professorData.Deletar(Id);
        }

        public List<ProfessorDTO> Get()
        {
            throw new NotImplementedException();
        }

        public ProfessorDTO Get(int Id)
        {
            var professor = _mapper.Map<Professor, ProfessorDTO>(_professorData.Buscar(Id));

            return professor;
        }

        public ProfessorDTO Get(string userId)
        {
            var professor = _mapper.Map<Professor, ProfessorDTO>(_professorData.Buscar(userId));

            return professor;
        }

        public void Post(ProfessorDTO professorDTO)
        {

            ValidaModel(professorDTO);

            var professor = _mapper.Map<ProfessorDTO, Professor>(professorDTO);

            _professorData.Salvar(professor);

        }

        public void Put(ProfessorDTO professorDTO)
        {
            ValidaModel(professorDTO);

            var professor = _mapper.Map<ProfessorDTO, Professor>(professorDTO);

            _professorData.Editar(professor);
        }

        private void ValidaModel(ProfessorDTO professor)
        {
            if(professor.Cordenador == null)
                throw new Exception("O Cordenador deve ser informado");

            if (professor.Disciplinas.Count == 0)
                throw new Exception("Pelo menos uma disciplina deve ser atribuida ao professor.");

            if(professor.Turmas.Count == 0)
                throw new Exception("Pelo menos uma turma deve ser atribuida ao professor.");

            if(professor.CategoriaDeEnsino == 0)
                throw new Exception("Uma categoria de ensino deve ser atribuida ao professor.");

            if (string.IsNullOrEmpty(professor.Usuario.Nome))
                throw new Exception("Nome não pode ser um campo em branco");

            if (string.IsNullOrEmpty(professor.Usuario.Endereco.Rua))
                throw new Exception("Rua não pode ser um campo em branco");

            if (string.IsNullOrEmpty(professor.Usuario.CPF))
                throw new Exception("CPF não pode ser um campo em branco");

            if (professor.Usuario.DatadeNascimento == null)
                throw new Exception("Data de nascimento não pode ser um campo em branco");

            if (string.IsNullOrEmpty(professor.Usuario.Email))
                throw new Exception("Email não pode ser um campo em branco");

            if (string.IsNullOrEmpty(professor.Usuario.Telefone))
                throw new Exception("Telefone não pode ser um campo em branco");

            if (string.IsNullOrEmpty(professor.Usuario.Endereco.Cidade))
                throw new Exception("Cidade não pode ser um campo em branco");

            if (string.IsNullOrEmpty(professor.Usuario.Endereco.Estado))
                throw new Exception("Estado não pode ser um campo em branco");

            if (string.IsNullOrEmpty(professor.Usuario.Endereco.Rua))
                throw new Exception("Rua não pode ser um campo em branco");

            if (professor.Usuario.Endereco.Numero == 0)
                throw new Exception("Numero não pode ser 0");
        } 
    }
}
