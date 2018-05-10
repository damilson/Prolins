using SIPE.Servico.Interface;
using System;
using System.Collections.Generic;
using SIPE.Servico.DTO;
using AutoMapper;
using SIPE.Repositorio.Interface;
using SIPE.Repositorio.Model;

namespace SIPE.Servico.Controllers
{
    public class TurmaServicoController : ITurmaServico
    {
        private readonly ITurmaData _turmaData;
        private readonly IMapper _mapper;

        public TurmaServicoController(ITurmaData turmaData, IMapper mapper)
        {
            _turmaData = turmaData;
            _mapper = mapper;
        }
        public void Delete(int Id)
        {
            _turmaData.Deletar(Id);
        }

        public List<TurmaDTO> Get()
        {
            var listaTurma = _turmaData.TurmaLista();
            var listaTurmaDTO = _mapper.Map<List<Turma>, List<TurmaDTO>> (listaTurma);

            return listaTurmaDTO;
        }

        public TurmaDTO Get(int Id)
        {
            var turma = _turmaData.Buscar(Id);
            var turmaDTO = _mapper.Map<Turma, TurmaDTO>(turma);

            return turmaDTO;
        }

        public void Post(TurmaDTO turmaDTO)
        {
            var turma = _mapper.Map<TurmaDTO, Turma>(turmaDTO);

            _turmaData.Salvar(turma);
        }

        public void Put(TurmaDTO turmaDTO)
        {
            var turma = _mapper.Map<TurmaDTO, Turma>(turmaDTO);

            _turmaData.Editar(turma);
        }
    }
}
