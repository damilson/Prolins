using AutoMapper;
using SIPE.Repositorio.Interface;
using SIPE.Servico.Interface;
using System;
using System.Collections.Generic;
using SIPE.Servico.DTO;
using SIPE.Repositorio.Model;

namespace SIPE.Servico.Controllers
{
    public class CordenadorServicoController : ICordenadorServico
    {
        private readonly ICordenadorData _cordenadorData;
        private readonly IMapper _mapper;

        public CordenadorServicoController(ICordenadorData cordenador, IMapper mapper)
        {
            _cordenadorData = cordenador;
            _mapper = mapper;
        }

        public void Delete(int Id)
        {
            _cordenadorData.Deletar(Id);
        }

        public List<CordenadorDTO> Get()
        {
            var listaCordenadores = _cordenadorData.CordenadorLista();
            var listaCordenadorDTO = _mapper.Map<List<Cordenador>, List<CordenadorDTO>>(listaCordenadores);

            return listaCordenadorDTO;
        }

        public CordenadorDTO Get(int Id)
        {
            var coordenador = _mapper.Map<Cordenador, CordenadorDTO>(_cordenadorData.Buscar(Id));

            return coordenador;
        }

        public void Post(CordenadorDTO cordenador)
        {
            ValidaModel(cordenador);

            var usuariobla = _mapper.Map<CordenadorDTO, Cordenador>(cordenador);

            _cordenadorData.Salvar(usuariobla);
        }

        public void Put(CordenadorDTO coordenadorDTO)
        {
            ValidaModel(coordenadorDTO);

            var coordenador = _mapper.Map<CordenadorDTO, Cordenador>(coordenadorDTO);

            _cordenadorData.Editar(coordenador);
        }

        private void ValidaModel(CordenadorDTO coordenador)
        {
            if (coordenador.CategorioDeEnsino == null)
                throw new Exception("Uma categoria de ensino deve ser atribuida ao coordenador.");

            if (string.IsNullOrEmpty(coordenador.Usuario.Nome))
                throw new Exception("Nome não pode ser um campo em branco");

            if (string.IsNullOrEmpty(coordenador.Usuario.Endereco.Rua))
                throw new Exception("Rua não pode ser um campo em branco");

            if (string.IsNullOrEmpty(coordenador.Usuario.CPF))
                throw new Exception("CPF não pode ser um campo em branco");

            if (coordenador.Usuario.DatadeNascimento == null)
                throw new Exception("Data de nascimento não pode ser um campo em branco");

            if (string.IsNullOrEmpty(coordenador.Usuario.Email))
                throw new Exception("Email não pode ser um campo em branco");

            if (string.IsNullOrEmpty(coordenador.Usuario.Telefone))
                throw new Exception("Telefone não pode ser um campo em branco");

            if (string.IsNullOrEmpty(coordenador.Usuario.Endereco.Cidade))
                throw new Exception("Cidade não pode ser um campo em branco");

            if (string.IsNullOrEmpty(coordenador.Usuario.Endereco.Estado))
                throw new Exception("Estado não pode ser um campo em branco");

            if (string.IsNullOrEmpty(coordenador.Usuario.Endereco.Rua))
                throw new Exception("Rua não pode ser um campo em branco");

            if (coordenador.Usuario.Endereco.Numero == 0)
                throw new Exception("Numero não pode ser 0");
        }
    }
}
