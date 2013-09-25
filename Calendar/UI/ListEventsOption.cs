using System;

using Calendar.Events;
using Calendar.Logging;

namespace Calendar.UI
{
  internal class ListEventsOption : IOption
  {
    internal const string ListEventsOptionString = "l";

    private readonly IEventsRepository eventsRepository;
    private readonly ILogger _logger;

    public ListEventsOption(IEventsRepository eventsRepository, ILogger logger)
    {
      this.eventsRepository = eventsRepository;
      _logger = logger;
    }

    public bool MatchesString(string chosenOptionAsString)
    {
      return StringComparer.InvariantCultureIgnoreCase.Equals(ListEventsOptionString, chosenOptionAsString);
    }

    public bool Run()
    {
      _logger.Log("Run");
      ICalendarEvent[] calendarEvents = eventsRepository.GetEvents(DateSpan.Max);
      foreach (var calendarEvent in calendarEvents)
      {
        if (calendarEvent != null)
          Console.WriteLine(calendarEvent);
      }
      _logger.Log("Run completed");
      return true;
    }

    public sealed override string ToString()
    {
      return ListEventsOptionString + " - list events";
    }
  }
}