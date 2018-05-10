using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Enumeradores
{
    public enum CategorioaDeEnsino
    {
        [Display(Name = @"Ensino Infantil")]
        EnsinoInfantil,
        [Display(Name = @"Ensino Fundamental")]
        EnsinoFundamental,
        [Display(Name = @"Ensino Médio")]
        EnsinoMedio
    }
}
