namespace SistemaCliente.Application.Validation;

public class ValidationBehavior<TRequisicao, TResposta> : IPipelineBehavior<TRequisicao, TResposta> where TRequisicao : IRequest<TResposta>
{
    private readonly IEnumerable<IValidator<TRequisicao>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequisicao>> validators) => _validators = validators;

    public async Task<TResposta> Handle(TRequisicao requisicao, RequestHandlerDelegate<TResposta> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequisicao>(requisicao);

            var validationResults = await Task.WhenAll(_validators.Select(v =>
            v.ValidateAsync(context, cancellationToken)));

            var failures = validationResults
            .SelectMany(r => r.Errors)
            .Where(f => f != null).ToList();

            if (failures.Count != 0)
                throw new ValidationException(failures);
        }
        return await next();
    }
}