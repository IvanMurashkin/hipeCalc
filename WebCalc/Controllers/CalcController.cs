using CalcLibrary;
using DBModel;
using DBModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using WebCalc.Models;

namespace WebCalc.Controllers
{
    public class CalcController : Controller
    {

        private Calculator Calc { get; set; }

        private IList<Favorite> favorites { get; set; }

        public CalcController() {
            Calc = new Calculator();

            var extDir = HostingEnvironment.MapPath("~/App_Data");

            foreach (var op in CalcHelper.GetOperations(extDir)) {
                Calc.Operations.Add(op);
            }

            favorites = DB.GetFavorits();
        }

        [HttpGet]
        public ActionResult Index(string favOperName)
        {
            
            var model = new OperViewModel();
            model.Favorites = favorites;

            ViewBag.Operations = new SelectList(Calc.Operations, "Name", "Name", favOperName);

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(OperViewModel model) {

            model.Favorites = favorites;
            ViewBag.Operations = new SelectList(Calc.Operations, "Name", "Name");
            
            if (!ModelState.IsValid) {
                ViewBag.Error = "Все пропало...";
                return View(model);
            }

            var oper = Calc.Operations.FirstOrDefault(o => o.Name == model.OperName);

            if (oper != null) {
                model.Result = oper.Excecute(CalcHelper.StringConvert(model.Args));
            } else {
                ViewBag.Error = "Operation not found";
            }

            return View(model);
        }

        public ActionResult Like(string operName) {

            if (favorites.Any(f => f.Name == operName))
                return Json(new { failed = true });
            //сохранение в бд
            DB.AddFavorite(new Favorite(operName));
            //отображение кнопки
            return PartialView("Like", operName);
        }

        public PartialViewResult GetFavoritesOperation() {
            return PartialView(favorites);
        }

    }
}