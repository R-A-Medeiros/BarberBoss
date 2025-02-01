using AutoMapper;
using BarberBoss.Communication.Responses;
using BarberBoss.Domain.Repositories.Invoices;

namespace BarberBoss.Application.UseCases.Invoices.GetAll;
public class GetAllInvoiceUseCase : IGetAllInvoiceUseCase
{
    private readonly IInvoicesRepository _invoicesRepository;
    private readonly IMapper _mapper;
    public GetAllInvoiceUseCase(IInvoicesRepository repository, IMapper mapper)
    {
        _invoicesRepository = repository;
        _mapper = mapper;
    }
    public async Task<ResponseInvoicesJson> Execute()
    {
        var result = await _invoicesRepository.GetAll();

        return new ResponseInvoicesJson
        {
            Invoice = _mapper.Map<List<ResponseShortInvoice>>(result)
        };
    }
}
