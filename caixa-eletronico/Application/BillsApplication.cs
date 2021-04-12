using AutoMapper;
using System.Collections.Generic;
using caixa_eletronico.Services.Interfaces;
using caixa_eletronico.Domain.DTO.WadOfBills;
using caixa_eletronico.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace caixa_eletronico.Application
{
    public class BillsApplication : IBillsApplication
    {
        readonly IMapper _mapper;
        readonly IBillsService _billsService;

        public BillsApplication(
            IMapper mapper,
            IBillsService billsService)
        {
            _mapper = mapper;
            _billsService = billsService;
        }

        public IEnumerable<OutboundBillDTO> Get()
        {
            var bills = _billsService.Get();
            return _mapper.Map<IEnumerable<OutboundBillDTO>>(bills);
        }

        public OutboundBillDTO GetByValue(int value)
        {
            var bill = _billsService.GetByValue(value);
            return _mapper.Map<OutboundBillDTO>(bill);
        }

        public void Add(IFormCollection form)
        {
            var newBillValue = int.Parse(form["valor-nova-nota"]);

            _billsService.Add(newBillValue);
        }

        public void Remove(int value)
        {
            _billsService.Remove(value);
        }
    }
}
