using System.Web.Mvc;

namespace Util.Seguranca
{
    public class Autorizacao : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);

            filterContext.HttpContext.Response.Redirect("/Admin/AcessoNegado");
        }
    }
}
