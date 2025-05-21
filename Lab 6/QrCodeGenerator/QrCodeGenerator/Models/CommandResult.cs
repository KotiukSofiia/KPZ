namespace QrCodeGenerator.Models
{
    public class CommandResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public static CommandResult Ok(object data) => new() { Success = true, Data = data };
        public static CommandResult Fail(string message) => new() { Success = false, Message = message };
    }
}
