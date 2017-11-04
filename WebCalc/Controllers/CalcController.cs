using CalcLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCalc.Models;

namespace WebCalc.Controllers
{
    public class CalcController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var calc = new Calculator();

            foreach (var op in CalcHelper.GetOperations()) {
                calc.Operations.Add(op);
            }

            ViewData.Model = new OperViewModel();
            ViewBag.Operations = new SelectList(calc.Operations, "Name", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Index(OperViewModel model) {

            var calc = new Calculator();
            
            var oper = calc.Operations.FirstOrDefault(o => o.Name == model.OperName);

            if (oper != null) {
                model.Result = oper.Excecute(CalcHelper.StringConvert(model.Args));
            } else {
                ViewBag.Error = "Operation not found";
            }

            return View(model);
        }

    }
}