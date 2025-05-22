using QrCodeGenerator.Models;
using QrCodeGenerator.Services;
using System.ComponentModel.DataAnnotations;

namespace QrCodeGenerator.Commands
{
  public class GenerateQrCodeCommand : ICommand<(QrInputModel input, string format), CommandResult>
  {
    private readonly IQrCodeMediator _mediator;

    public GenerateQrCodeCommand(IQrCodeMediator mediator)
    {
      _mediator = mediator;
    }

    public CommandResult Execute((QrInputModel input, string format) parameters)
    {
      return _mediator.GenerateAndStoreQrCode(parameters.input, parameters.format);
    }
  }
}
