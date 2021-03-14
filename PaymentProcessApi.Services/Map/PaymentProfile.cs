using PaymentProcessApi.Entity.Dtos;
using PaymentProcessApi.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentProcessApi.Services.Map
{
    public class PaymentProfile : AutoMapper.Profile
    {
        public PaymentProfile()
        {
            CreateMap<PaymentRequestDto, Payment>()
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount))
                .ForMember(dest => dest.CardHolder, opt => opt.MapFrom(src => src.CardHolder))
                .ForMember(dest => dest.CreditCardNumber, opt => opt.MapFrom(src => src.CreditCardNumber))
                .ForMember(dest => dest.ExpirationDate, opt => opt.MapFrom(src => src.ExpirationDate))
                .ForMember(dest => dest.PaymentId, opt => opt.Ignore())
                .ForMember(dest => dest.PaymentStates, opt => opt.Ignore())
                .ForMember(dest => dest.SecurityCode, opt => opt.MapFrom(src => src.SecurityCode))
                .ReverseMap();
                
        }
    }
}
