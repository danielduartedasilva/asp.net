using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdocaoWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace AdocaoWeb.Controllers
{
    
    public class UsuarioController : Controller
    {
        private readonly Context _context;
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;

        public UsuarioController(Context context, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager)
        {
            _context = context;
            _userManager = userManager;//--------------------------------------------------------------------------------------------- vai servir para controlar o usuario
            _signInManager = signInManager;
        }

        // GET: Usuario
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios.ToListAsync());
        }

        // GET: Usuario/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var usuarioView = await _context.Usuarios
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (usuarioView == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(usuarioView);
        //}

        // GET: Usuario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Email,Senha,Id,CriadoEm,ConfirmacaoSenha,Cep,Logradouro,Bairro,Localidade,Uf")] UsuarioView usuarioView)
        {
            
            if (ModelState.IsValid)
            {
                Usuario usuario = new Usuario
                {
                    UserName = usuarioView.Email,
                    Email = usuarioView.Email,
                    Cep = usuarioView.Cep,
                    Logradouro = usuarioView.Logradouro,
                    Bairro = usuarioView.Bairro,
                    Localidade = usuarioView.Localidade,
                    Uf = usuarioView.Uf
                };

                IdentityResult resultado = await _userManager.CreateAsync(usuario, usuarioView.Senha);
                if (resultado.Succeeded)
                {
                    _context.Add(usuarioView);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                AdicionarErros(resultado);
            }
            return View(usuarioView);
        }

        public void AdicionarErros(IdentityResult resultado)
        {
            foreach (IdentityError erro in resultado.Errors)
            {
                ModelState.AddModelError("", erro.Description);
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([Bind("Email, Senha")] UsuarioView usuarioView)
        {
            var result = await _signInManager.PasswordSignInAsync(usuarioView.Email, usuarioView.Senha, false, false);
            var name = User.Identity.Name;
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Animal");
            }
            ModelState.AddModelError("", "Login ou senha inválidos!");
            return View(usuarioView);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        //// GET: Usuario/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var usuarioView = await _context.Usuarios.FindAsync(id);
        //    if (usuarioView == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(usuarioView);
        //}

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Email,Senha,Id,CriadoEm")] UsuarioView usuarioView)
        //{
        //    if (id != usuarioView.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(usuarioView);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!UsuarioViewExists(usuarioView.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(usuarioView);
        //}

        // GET: Usuario/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var usuarioView = await _context.Usuarios
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (usuarioView == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(usuarioView);
        //}

        // POST: Usuario/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var usuarioView = await _context.Usuarios.FindAsync(id);
        //    _context.Usuarios.Remove(usuarioView);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool UsuarioViewExists(int id)
        //{
        //    return _context.Usuarios.Any(e => e.Id == id);
        //}
    }
}
