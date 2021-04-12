using AutoMapper;
using caixa_eletronico.Domain.DTO.WadOfBills;
using caixa_eletronico.Domain.ValueObjects;
using caixa_eletronico.Domain.Models;

namespace caixa_eletronico
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Bill, OutboundBillDTO>();

            CreateMap<WadOfBills, WadOfBillsDTO>();
            CreateMap<WadOfBillsDTO, WadOfBills>();
            CreateMap<WithdrawResult, OutboundWithdrawResultDTO>()
                .ForMember(x => x.WithdrewWads, y => y.MapFrom(z => z.WithdrewWads));
        }
    }
}
