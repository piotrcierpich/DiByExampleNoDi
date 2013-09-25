using System;
using Calendar.Logging;

namespace Calendar.UI
{
  internal class EndApplicationOption : IOption
  {
    private readonly ILogger _logger;

    public EndApplicationOption(ILogger logger)
    {
      _logger = logger;
    }

    private const string ApplicationEndsString = "e";

    public bool MatchesString(string chosenOptionAsString)
    {
      return StringComparer.InvariantCulture.Equals(chosenOptionAsString, ApplicationEndsString);
    }

    public bool Run()
    {
      return false;
    }

    public override string ToString()
    {
      return ApplicationEndsString + " - application terminates";
    }
  }
}