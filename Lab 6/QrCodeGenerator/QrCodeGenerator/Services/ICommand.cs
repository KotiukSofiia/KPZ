namespace QrCodeGenerator.Services
{
    public interface ICommand<TInput, TResult>
    {
        TResult Execute(TInput input);
    }
}
