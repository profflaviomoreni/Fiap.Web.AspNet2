using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Fiap.Web.AspNet2.Controllers.Filters
{
    public class FiapAuthFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var usuarioLogado = context.HttpContext.Session.GetString("usuario");

            if( String.IsNullOrEmpty(usuarioLogado) )
            {
                var controller = context.Controller as Controller;
                controller.HttpContext.Response.Redirect("/Login");
            } else
            {
                base.OnActionExecuting(context);
            }

        }
    }
}
