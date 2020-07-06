using Application;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private IAnuncioApplication _anuncioApplication;

        public HomeController(
            IAnuncioApplication anuncioApplication)
        {
            _anuncioApplication = anuncioApplication;
        }

        public IActionResult Index()
        {
            var anuncios = _anuncioApplication.ListarTodos().ToList();
            var anunciosViewModel = new List<AnuncioViewModel>();

            anuncios.ForEach(anuncio =>
            {
                anunciosViewModel.Add(new AnuncioViewModel
                {
                    ID = anuncio.ID,
                    Ano = anuncio.Ano,
                    Marca = anuncio.Marca,
                    Modelo = anuncio.Modelo,
                    Observacao = anuncio.Observacao,
                    Quilometragem = anuncio.Quilometragem,
                    Versao = anuncio.Versao
                });

            });

            return View(anunciosViewModel);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add([Bind] AnuncioViewModel anuncioViewModel)
        {
            if (ModelState.IsValid)
            {
                _anuncioApplication.Adicionar(anuncioViewModel);

                return RedirectToAction("Index");
            }
            return View(anuncioViewModel);
        }

        public async Task<JsonResult> ObterMarcas()
        {
            var marcas = await _anuncioApplication.ObterMarcasAsync();

            return Json(marcas.ToList());
        }

        public async Task<JsonResult> ObterModelos(int id)
        {
            var modelos = await _anuncioApplication.ObterModelosAsync(id);

            return Json(modelos);
        }

        public async Task<JsonResult> ObterVersoes(int id)
        {
            var versoes = await _anuncioApplication.ObterVersoesAsync(id);

            return Json(versoes);
        }


        public IActionResult Edit(int id)
        {

            if (id == 0)
            {
                return NotFound();
            }

            var anuncio = _anuncioApplication.ObterPorId(id);

            if (anuncio == null)
            {
                return NotFound();
            }

            var anuncioViewModel = new AnuncioViewModel
            {
                ID = anuncio.ID,
                Ano = anuncio.Ano,
                Marca = anuncio.Marca,
                Modelo = anuncio.Modelo,
                Observacao = anuncio.Observacao,
                Quilometragem = anuncio.Quilometragem,
                Versao = anuncio.Versao
            };

            return View(anuncioViewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind] AnuncioViewModel anuncioViewModel)
        {
            if (ModelState.IsValid)
            {
                _anuncioApplication.Atualizar(anuncioViewModel);

                return RedirectToAction("Index");
            }

            return View(anuncioViewModel);
        }

        public IActionResult Detail(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var anuncio = _anuncioApplication.ObterPorId(id);

            if (anuncio == null)
            {
                return NotFound();
            }

            var anuncioViewModel = new AnuncioViewModel
            {
                ID = anuncio.ID,
                Ano = anuncio.Ano,
                Marca = anuncio.Marca,
                Modelo = anuncio.Modelo,
                Observacao = anuncio.Observacao,
                Quilometragem = anuncio.Quilometragem,
                Versao = anuncio.Versao
            };

            return View(anuncioViewModel);
        }

        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var anuncio = _anuncioApplication.ObterPorId(id);

            if (anuncio == null)
            {
                return NotFound();
            }

            _anuncioApplication.DeletarPorId(anuncio);


            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
