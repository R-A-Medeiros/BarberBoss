using AutoMapper;
using BarberBoss.Communication.Requests;
using BarberBoss.Communication.Responses;
using BarberBoss.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss.Application.Mapper;
public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();
    }


    private void RequestToEntity()
    {
        CreateMap<RequestInvoiceJson, Invoice>();
    }

    private void EntityToResponse()
    {
        CreateMap<Invoice, ResponseInvoiceJson>();
        CreateMap<Invoice, ResponseShortInvoice>();
        CreateMap<Invoice, ResponseRegisteredInvoiceJson>();
    }
}
