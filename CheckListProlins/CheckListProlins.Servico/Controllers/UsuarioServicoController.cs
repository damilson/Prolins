using SIPE.Servico.DTO;
using SIPE.Servico.Interface;
using System.Collections.Generic;
using System;
using SIPE.Repositorio.Repositorio;
using AutoMapper;
using SIPE.Repositorio.Model;
using SIPE.Repositorio.Interface;
using SIPE.Repositorio.Data;

namespace SIPE.Servico.Controllers
{
    public class UsuarioServicoController : IUsuarioServico
    {
        private readonly IUsuarioData _usuarioData;
        private readonly IMapper _mapper;

        public UsuarioServicoController(IUsuarioData usuarioData, IMapper mapper)
        {
            _usuarioData = usuarioData;
            _mapper = mapper;
        }

        public List<UsuarioDTO> Get()
        {
            var listaUsuarios = _usuarioData.UsuarioLista();

            var listaUsuarioDTO = _mapper.Map<List<Usuario>, List<UsuarioDTO>>(listaUsuarios);

            return listaUsuarioDTO;
        }

        public UsuarioDTO Get(int Id)
        {
            var usuario = _usuarioData.Buscar(Id);

            var UDTO = _mapper.Map<Usuario, UsuarioDTO>(usuario);
            
            return UDTO;
        }

        public UsuarioDTO Get(string userId)
        {
            var usuario = _usuarioData.Buscar(userId);

            var UDTO = _mapper.Map<Usuario, UsuarioDTO>(usuario);

            return UDTO;
        }

        public void Post(UsuarioDTO usuarioDTO)
        {
            ValidarModel(usuarioDTO);

            var usuario = _mapper.Map<UsuarioDTO, Usuario>(usuarioDTO);
            
            _usuarioData.Salvar(usuario);
        }

        public void Put(UsuarioDTO usuarioDTO)
        {
            ValidarModel(usuarioDTO);

            var usuario = _mapper.Map<UsuarioDTO, Usuario>(usuarioDTO);

            _usuarioData.Editar(usuario);
        }

        public void Delete(int Id)
        {
            _usuarioData.Deletar(Id);
        }

        private void ValidarModel(UsuarioDTO usuario)
        {
            if (string.IsNullOrEmpty(usuario.Nome))
                throw new Exception("Nome não pode ser um campo em branco");

            if (string.IsNullOrEmpty(usuario.Endereco.Rua))
                throw new Exception("Rua não pode ser um campo em branco");

            if (string.IsNullOrEmpty(usuario.CPF))
                throw new Exception("CPF não pode ser um campo em branco");

            if (usuario.DatadeNascimento == null)
                throw new Exception("Data de nascimento não pode ser um campo em branco");

            if (string.IsNullOrEmpty(usuario.Email))
                throw new Exception("Email não pode ser um campo em branco");

            if (string.IsNullOrEmpty(usuario.Telefone))
                throw new Exception("Telefone não pode ser um campo em branco");

            if (string.IsNullOrEmpty(usuario.Endereco.Cidade))
                throw new Exception("Cidade não pode ser um campo em branco");

            if (string.IsNullOrEmpty(usuario.Endereco.Estado))
                throw new Exception("Estado não pode ser um campo em branco");

            if (string.IsNullOrEmpty(usuario.Endereco.Rua))
                throw new Exception("Rua não pode ser um campo em branco");

            if (usuario.Endereco.Numero == 0)
                throw new Exception("Numero não pode ser 0");
        }
    }
}
