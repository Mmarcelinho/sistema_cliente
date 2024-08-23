using SistemaCliente.Exceptions.Base;

namespace SistemaCliente.Exceptions;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var problemDetails = new ProblemDetails
        {
            Instance = httpContext.Request.Path
        };

        switch (exception)
        {
            case FluentValidation.ValidationException fluentException:
                problemDetails.Title = "Um ou mais erros de validação ocorreram.";
                problemDetails.Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1";
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                var validationErrors = fluentException.Errors.Select(e => e.ErrorMessage).ToList();
                problemDetails.Extensions.Add("errors", validationErrors);
                break;

            case NaoEncontradoException naoEncontradoException:
                problemDetails.Title = naoEncontradoException.Message;
                httpContext.Response.StatusCode = (int)naoEncontradoException.RecuperarStatusCode();
                break;

            case ClienteJaRegistradoException clienteJaRegistradoException:
                problemDetails.Title = clienteJaRegistradoException.Message;
                httpContext.Response.StatusCode = StatusCodes.Status409Conflict; 
                break;

            default:
                problemDetails.Title = "Ocorreu um erro inesperado.";
                problemDetails.Detail = exception.Message;
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                break;
        }

        _logger.LogError(exception, "Erro: {ProblemDetailsTitle}", problemDetails.Title);

        problemDetails.Status = httpContext.Response.StatusCode;
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken).ConfigureAwait(false);

        return true;
    }
}
