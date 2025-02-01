using BarberBoss.Application.UseCases.Invoices.GetAll;
using BarberBoss.Communication.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarberBoss.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class InvoicesController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(ResponseInvoiceJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAllInvoices([FromServices] IGetAllInvoiceUseCase useCase)
    {
        var response = await useCase.Execute();

        if (response.Invoice.Count > 0)
            return Ok(response);


        return  NoContent();
    }
}
