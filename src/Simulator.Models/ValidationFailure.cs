
namespace Simulator.Models;

public sealed class ValidationFailure(string message) : Result
{
    public string Message { get; } = message;
}
