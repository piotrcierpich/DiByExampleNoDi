using System;

namespace Calendar.UI
{
  internal class EndApplicationOption : IOption
  {
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