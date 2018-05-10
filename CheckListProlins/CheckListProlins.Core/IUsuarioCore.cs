using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckListProlins.Core
{
    public interface IUsuarioCore
    {
        List<Usuario> Listar();

        Usuario Buscar(int id);

        void Editar(Usuario usuario);

        Usuario Salvar(Usuario usuario);

        void Deletar(int id);
    }
}
