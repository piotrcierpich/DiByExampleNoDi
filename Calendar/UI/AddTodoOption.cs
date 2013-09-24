using System;

using Calendar.Events;

namespace Calendar.UI
{
  public class AddTodoOption : IOption
  {
    internal const string AddToDoOptionString = "a";

    private readonly IPlanner planner;

    public AddTodoOption(IPlanner planner)
    {
      this.planner = planner;
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
      DateSpan schedule = DateSpanReader.PromptForDateSpan();
      Console.Write("Title: ");
      string title = Console.ReadLine();
      Todo calendarEvent = new Todo(schedule, title);
      planner.AddEvent(calendarEvent);
      return true;
    }
  }
}