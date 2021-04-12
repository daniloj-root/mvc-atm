using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using caixa_eletronico.Application;
using caixa_eletronico.Domain.ViewModels;
using caixa_eletronico.Infrastructure.Database;
using System.Collections.Generic;
using caixa_eletronico.Application.Interfaces;
using caixa_eletronico.Domain.Models;
using System.Linq;
using System;

namespace caixa_eletronico.Controllers
{
    public class BillsController : Controller
    {
        readonly IBillsApplication _billsApplication;

        public BillsController(IBillsApplication billsApplication)
        {
            _billsApplication = billsApplication;
        }

        [HttpPost]
        public IActionResult Add(IFormCollection form)
        {
            _billsApplication.Add(form);

            return RedirectToAction("Index", "WadOfBills");
        }

        public IActionResult Remove(int value)
        {
            _billsApplication.Remove(value);

            return RedirectToAction("Index", "WadOfBills");
        }
    }
}
