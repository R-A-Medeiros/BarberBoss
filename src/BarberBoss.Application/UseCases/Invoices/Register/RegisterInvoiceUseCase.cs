using AutoMapper;
using BarberBoss.Communication.Requests;
using BarberBoss.Communication.Responses;
using BarberBoss.Domain.Entities;
using BarberBoss.Domain.Repositories;
using BarberBoss.Domain.Repositories.Invoices;
using BarberBoss.Exception.ExceptionBase;

namespace BarberBoss.Application.UseCases.Invoices.Register;
public class RegisterInvoiceUseCase : IRegisterInvoiceUseCase
{
    private readonly IInvoicesRepository _invoicesRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RegisterInvoiceUseCase(IInvoicesRepository invoicesRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _invoicesRepository = invoicesRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<ResponseRegisteredInvoiceJson> Execute(RequestInvoiceJson request)
    {
        Validate(request);


        var entity = _mapper.Map<Invoice>(request);
        await _invoicesRepository.Add(entity);
        await _unitOfWork.Commit();

        return _mapper.Map<ResponseRegisteredInvoiceJson>(entity);
    }


    private void Validate(RequestInvoiceJson request)
    {
        var validator = new InvoiceValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
