using System;
using Util.Enumeradores;

namespace SIPE.Servico.DTO
{
    public class UsuarioDTO
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public LogradouroDTO Endereco { get; set; }
        public Sexo Sexo { get; set; }
        public string CPF { get; set; }
        public DateTime DatadeNascimento { get; set; }
        public bool Ativo { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
        public Perfil Perfil { get; set; }
    }
}