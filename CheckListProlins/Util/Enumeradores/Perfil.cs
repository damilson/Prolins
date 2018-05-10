using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Enumeradores
{
    public enum Perfil
    {
        [Display(Name =@"Administrador")]
        administrador,
        [Display(Name =@"Coordenador")]
        coordenador,
        [Display(Name =@"Professor")]
        professor,
        [Display(Name =@"Financeiro")]
        financeiro,
        [Display(Name = @"Aluno")]
        aluno
    }
}
