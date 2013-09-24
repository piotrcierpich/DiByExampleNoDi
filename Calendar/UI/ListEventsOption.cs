using System;

using Calendar.Events;

namespace Calendar.UI
{
  internal class ListEventsOption : IOption
  {
    internal const string ListEventsOptionString = "l";

    private readonly IEventsRepository eventsRepository;

    public ListEventsOption(IEventsRepository eventsRepository)
    {
      this.eventsRepository = eventsRepository;
    }

    public bool MatchesString(string chosenOptionAsString)
    {
      return StringComparer.InvariantCultureIgnoreCase.Equals(ListEventsOptionString, chosenOptionAsString);
    }

    public bool Run()
    {
      ICalendarEvent[] calendarEvents = eventsRepository.GetEvents(DateSpan.Max);
      foreach (var calendarEvent in calendarEvents)
      {
        Console.WriteLine(calendarEvent);
      }
      return true;
    }

    public sealed override string ToString()
    {
      return ListEventsOptionString + " - list events";
    }
  }
}