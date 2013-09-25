using System;

using Calendar.Events;
using Calendar.Logging;

namespace Calendar.UI
{
  public class AddTodoOption : IOption
  {
    internal const string AddToDoOptionString = "a";

    private readonly IPlanner planner;
    private readonly Func<DateSpan, string, Todo> _todoFactory;
    private readonly ILogger _logger;

    public AddTodoOption(IPlanner planner, Func<DateSpan, string, Todo> todoFactory, ILogger logger)
    {
      this.planner = planner;
      _todoFactory = todoFactory;
      _logger = logger;
    }

    public bool MatchesString(string chosenOptionAsString)
    {
      bool result = StringComparer.InvariantCultureIgnoreCase.Equals(chosenOptionAsString, AddToDoOptionString);
      return result;
    }

    public sealed override string ToString()
    {
      return AddToDoOptionString + " - todo";
    }

    public bool Run()
    {
      _logger.Log("Run");
      DateSpan schedule = DateSpanReader.PromptForDateSpan();
      Console.Write("Title: ");
      string title = Console.ReadLine();
      Todo calendarEvent = _todoFactory(schedule, title);
      planner.AddEvent(calendarEvent);
      _logger.Log("Run completed");
      return true;
    }
  }
}