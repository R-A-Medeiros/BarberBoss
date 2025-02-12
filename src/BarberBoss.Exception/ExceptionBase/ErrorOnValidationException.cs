using System.Net;

namespace BarberBoss.Exception.ExceptionBase;
public class ErrorOnValidationException : BarberBossException
{
    private List<string> Errors { get; set; }

    public override int StatusCode => (int)HttpStatusCode.BadRequest;

    public ErrorOnValidationException(List<string> errorMessages) :base(string.Empty)
    {
        Errors = errorMessages;
    }

    public override List<string> GetErros()
    {
        return Errors;
    }
}
