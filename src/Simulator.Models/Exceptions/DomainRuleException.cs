
namespace Simulator.Models.Exceptions;

public sealed class DomainRuleException(string message) : Exception(message) { }
