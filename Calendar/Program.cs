using System;
using Calendar.DataAccess;
using Calendar.Events;

namespace Calendar
{
  class Program
  {
    static void Main()
    {
      EventsRepository eventsRepository = new EventsRepository();
      while (true)
      {
        Console.WriteLine("Pick option:");
        string[] options = new[] { "a - todo", "l - list events" };
        foreach (var option in options)
        {
          Console.WriteLine(option);
        }

        string chosenOption = Console.ReadLine();
        if (chosenOption == "a")
        {
          DateSpan schedule = DateSpanReader.PromptForDateSpan();
          Console.Write("Title: ");
          string title = Console.ReadLine();
          CalendarEvent calendarEvent = new CalendarEvent(schedule, title);
          eventsRepository.AddEvent(calendarEvent);
        }
        else if (chosenOption == "l")
        {
          CalendarEvent[] calendarEvents = eventsRepository.GetEvents(DateSpan.Max);
          foreach (var calendarEvent in calendarEvents)
          {
            Console.WriteLine(calendarEvent);
          }
        }
      }
    }
  }
}
