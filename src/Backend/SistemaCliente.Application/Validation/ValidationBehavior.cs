namespace SistemaCliente.Application.Validation;

public class ValidationBehavior<TRequisicao, TResposta>(IEnumerable<IValidator<TRequisicao>> validators) : IPipelineBehavior<TRequisicao, TResposta> where TRequisicao : IRequest<TResposta>
{
    public async Task<TResposta> Handle(TRequisicao requisicao, RequestHandlerDelegate<TResposta> next, CancellationToken cancellationToken)
    {
        if (validators.Any())
        {
            var context = new ValidationContext<TRequisicao>(requisicao);

            var validationResults = await Task.WhenAll(validators.Select(v =>
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