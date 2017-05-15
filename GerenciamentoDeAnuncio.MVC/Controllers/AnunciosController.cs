using AutoMapper;
using GerenciamentoDeAnuncio.Application.Interface;
using GerenciamentoDeAnuncio.Domain.Entities;
using GerenciamentoDeAnuncio.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GerenciamentoDeAnuncio.MVC.Controllers
{
    public class AnunciosController : Controller
    {
        private readonly IAnuncioAppService _anuncioApp;

        public AnunciosController(IAnuncioAppService anuncioApp)
        {
            _anuncioApp = anuncioApp;
        }

        // GET: Anuncios
        public ActionResult Index()
        {
            //var anuncioViewModel = Mapper.Map<IEnumerable<Anuncio>, IEnumerable<AnuncioViewModel>>(_anuncioApp.GetAll());
            return View();
        }

        // GET: Anuncios/Details/5
        public ActionResult Details(int id)
        {
            var anuncio = _anuncioApp.GetById(id);
            var anuncioViewModel = Mapper.Map<Anuncio, AnuncioViewModel>(anuncio);

            return View(anuncioViewModel);

        }

        // GET: Anuncios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Anuncios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AnuncioViewModel anuncio)
        {
            if (ModelState.IsValid)
            {
                var anuncioDomain = Mapper.Map<AnuncioViewModel, Anuncio>(anuncio);
                _anuncioApp.add(anuncioDomain);

                return RedirectToAction("Index");
            }

            return View(anuncio);
        }

        // GET: Anuncios/Edit/5
        public ActionResult Edit(int id)
        {
            var anuncio = _anuncioApp.GetById(id);
            var anuncioViewModel = Mapper.Map<Anuncio, AnuncioViewModel>(anuncio);

            return View(anuncioViewModel);
        }

        // POST: Anuncios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AnuncioViewModel anuncio)
        {
            if (ModelState.IsValid)
            {
                var anuncioDomain = Mapper.Map<AnuncioViewModel, Anuncio>(anuncio);
                _anuncioApp.Update(anuncioDomain);

                return RedirectToAction("Index");
            }

            return View(anuncio);
        }

        // GET: Anuncios/Delete/5
        public ActionResult Delete(int id)
        {
            var anuncio = _anuncioApp.GetById(id);
            var anuncioViewModel = Mapper.Map<Anuncio, AnuncioViewModel>(anuncio);

            return View(anuncioViewModel);
        }

        // POST: Anuncios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var anuuncio = _anuncioApp.GetById(id);
            _anuncioApp.Remove(anuuncio);

            return RedirectToAction("Index");
        }


        public ActionResult Listar()
        {
            try
            {
                var list = Mapper.Map<IEnumerable<Anuncio>, IEnumerable<AnuncioViewModel>>(_anuncioApp.GetAll());

                //para retornar ao ajax, temos que enviar nosso objeto em formato JSON, e LIBERA-LO
                //Para a requisicao GET
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
