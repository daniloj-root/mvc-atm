using caixa_eletronico.Application;
using caixa_eletronico.Application.Interfaces;
using caixa_eletronico.Domain.ViewModels;
using caixa_eletronico.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace caixa_eletronico.Controllers
{
    public class WadOfBillsController : Controller
    {
        readonly IBillsApplication _billsApplication;
        readonly IWadOfBillsApplication _wadOfBillsApplication;

        public WadOfBillsController(
            IBillsApplication billApplication,
            IWadOfBillsApplication wadOfBillsApplication)
        {
            _billsApplication = billApplication;
            _wadOfBillsApplication = wadOfBillsApplication;
        }

        public IActionResult Index()
        {
            var wadsOfBills = _wadOfBillsApplication.Get()
                .OrderByDescending(x => x.BillValue);

            return View(new WadOfBillsViewModel(wadsOfBills));
        }

        public IActionResult InsertBills()
        {
            var bills = _billsApplication.Get()
                .OrderByDescending(x => x.MonetaryValue);

            return View(new BillsViewModel(bills));
        }

        [HttpPost]
        public IActionResult AddToCurrentWads(IFormCollection form)
        {
            _wadOfBillsApplication.AddToCurrentWads(form);

            return RedirectToAction("InsertBills", "WadOfBills");
        }

        public IActionResult Withdraw()
        {
            return View(new WithdrawViewModel() { RequestDone = false });
        }

        [HttpPost]
        public IActionResult Withdraw(IFormCollection form)
        {
            var withdrawResult = _wadOfBillsApplication.Withdraw(form);
            return View(new WithdrawViewModel(withdrawResult));
        }
    }
}
