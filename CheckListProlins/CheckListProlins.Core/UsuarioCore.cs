using Entidades;
using CheckListProlins.Repositorio.Repositorio;
using System.Collections.Generic;
using System.Linq;

namespace CheckListProlins.Core
{
    public class UsuarioCore : IUsuarioCore
    {
        private readonly IRepositorio _repositorio;

        public UsuarioCore(IRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public List<Usuario> Listar()
        {
            return _repositorio.List<Usuario>().ToList();
        }

        public Usuario Buscar(int id)
        {
            return _repositorio.Find<Usuario>(x => x.Id == id);
        }

        public void Editar(Usuario usuario)
        {
            var usuarioEdiar = Buscar(usuario.Id);

            usuarioEdiar.Nome = usuario.Nome;
            usuarioEdiar.Email = usuario.Email;
            usuarioEdiar.Senha = usuario.Senha;

            _repositorio.UpdateAndSaveChanges(usuarioEdiar);
        }

        public Usuario Salvar(Usuario usuario)
        {
            return _repositorio.InsertAndSaveChanges(usuario);
        }

        public void Deletar(int id)
        {
            _repositorio.DeleteAndSaveChanges<Usuario>(x => x.Id == id);
        }
    }
}
