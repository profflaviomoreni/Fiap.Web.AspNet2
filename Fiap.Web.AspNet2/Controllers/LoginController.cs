using AutoMapper;
using Fiap.Web.AspNet2.Models;
using Fiap.Web.AspNet2.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Fiap.Web.AspNet2.Controllers
{
    public class LoginController : Controller
    {

        private readonly IMapper mapper;

        public LoginController(IMapper mapp)
        {
            mapper = mapp;
        }


        public IActionResult Index()
        {
            return View(new LoginViewModel());
        }


        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {

            if ( loginViewModel.Usuario.Equals("admin") && loginViewModel.Senha.Equals("123") )
            {
                LoginModel loginModel = new LoginModel();
                loginModel.NomeUsuario = "Flávio Moreni";
                loginModel.Token = "Token 1123423423423";

                loginViewModel = mapper.Map<LoginViewModel>(loginModel);

                HttpContext.Session.SetString("usuario", loginViewModel.NomeUsuario);
                HttpContext.Session.SetString("token", loginViewModel.Token);

                return RedirectToAction(actionName: "Index", controllerName: "Home" );
            } else
            {
                TempData["mensagemSucesso"] = "Não foi possível efetuar o logon";
                return View("Index", loginViewModel);
            }

        }


        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }


    }
}
