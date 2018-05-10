using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Util.Alerta
{
    public class Alerta 
    {
        public static JsonResult CriaMensagemErro(Exception ex)
        {
            var mensagem = ex.Message;

            return CriaMensagemErro(mensagem);
        }

        public static JsonResult CriaMensagemErro(ArgumentException ex)
        {
            var mensagem = ex.Message;
            if (!string.IsNullOrEmpty(ex.ParamName))
            {
                mensagem = ex.Message.Substring(0, ex.Message.LastIndexOf("\r\n"));
            }

            return CriaMensagemErro(mensagem, ex.ParamName);
        }

        public static JsonResult CriaMensagemErro(string mensagem, string campo = "")
        {
            var retorno = new
            {
                Sucesso = false,
                Campo = campo,
                Mensagem = mensagem
            };

            return new JsonResult { Data = retorno };
        }

        public static JsonResult CriaMensagemSucesso(string mensagem)
        {
            var retorno = new
            {
                Sucesso = true,
                Mensagem = mensagem
            };

            return new JsonResult { Data = retorno };
        }
    }
}
