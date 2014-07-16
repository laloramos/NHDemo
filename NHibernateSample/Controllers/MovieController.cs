using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using NHibernateSample.Domain.Entities;
using NHibernateSample.ViewModels;

namespace NHibernateSample.Controllers
{
    public class MovieController : Controller
    {
        private readonly ISession _session;
        //
        // GET: /Movie/
        public MovieController(ISession session)
        {
            _session = session;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            var model = new MovieAddViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(MovieAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newMovie = new Movie
                    {
                        Name = model.Name
                    };
                _session.SaveOrUpdate(newMovie);
              
                return RedirectToAction("Index");
            }

            return View(model);

        }

    }
}
