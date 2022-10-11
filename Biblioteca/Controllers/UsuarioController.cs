using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class UsuarioController : Controller
    {
         public IActionResult CadastroUsuario()
        {
            Autenticacao.CheckLogin(this);
            return View();
        }

        [HttpPost]
        public IActionResult CadastroUsuario(Usuario u)
        {
            UsuarioRepository UsuarioRepository = new UsuarioRepository();

            if(u.IdUsuario == 0)
            {
                UsuarioRepository.Inserir(u);
            }
            else
            {
                UsuarioRepository.Atualizar(u);
            }

            return RedirectToAction("ListagemUsuario");
        }
        
        public IActionResult Listagem(string tipoFiltro, string filtro)
        {
            Autenticacao.CheckLogin(this);
            FiltrosUsuario objFiltro = null;
            if(!string.IsNullOrEmpty(filtro))
            {
                objFiltro = new FiltrosUsuario();
                objFiltro.Filtro = filtro;
                objFiltro.TipoFiltro = tipoFiltro;
            }
            UsuarioRepository UsuarioRepository = new UsuarioRepository();
            return View(UsuarioRepository.ListarTodos(objFiltro));
        }

        public IActionResult Edicao(int id)
        {
            Autenticacao.CheckLogin(this);
            UsuarioRepository Ur = new UsuarioRepository();
            Usuario u = Ur.ObterPorId(id);
            return View(u);
        }

    }
}
