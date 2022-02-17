using AutoMapper;
using Fiap.Web.AspNet2.Models;
using Fiap.Web.AspNet2.ViewModel;
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


        public IActionResult Login(LoginViewModel loginViewModel)
        {
            /*
            loginRepository = new LoginRepository(); 
            LoginModel loginModel =  loginRepository.FindByUsuarioAndSenha( loginViewModel.Usuario, loginViewModel.Senha );
            */




            if ( loginViewModel.Usuario.Equals("admin") && loginViewModel.Senha.Equals("123") )
            {
                LoginModel loginModel = new LoginModel();
                loginModel.NomeUsuario = "Flávio Logado";
                loginModel.Token = "Token 1123423423423";

                loginViewModel = mapper.Map<LoginViewModel>(loginModel);

                TempData["mensagemSucesso"] = "Usuário logado com sucesso";
            } else
            {
                TempData["mensagemSucesso"] = "Não foi possível efetuar o logon";
            }

            return View("Index", loginViewModel);
        }

    }
}
