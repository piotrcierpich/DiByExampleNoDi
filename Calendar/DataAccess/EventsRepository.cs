using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

using Calendar.Events;

namespace Calendar.DataAccess
{
  class EventsRepository
  {
    private readonly BinaryFormatter _binaryFormatter = new BinaryFormatter();
    private const string FileName = "calendarData.dat";

    public CalendarEvent[] GetEvents(DateSpan schedule)
    {
      try
      {
        IEnumerable<CalendarEvent> allEvents = TryReadingCalendarEvents();
        return allEvents.Where(e => e.Schedule.IntersectWith(schedule))
                        .ToArray();
      }
      catch (Exception)
      {
        return new CalendarEvent[0];
      }
    }

    private IEnumerable<CalendarEvent> TryReadingCalendarEvents()
    {
      using (Stream s = File.OpenRead(FileName))
      {
        return (CalendarEvent[])_binaryFormatter.Deserialize(s);
      }
    }

    public void AddEvent(CalendarEvent eventToAdd)
    {
      IList<CalendarEvent> allEvents = GetEvents(DateSpan.Max).ToList();
      allEvents.Add(eventToAdd);

      using (Stream s = File.OpenWrite(FileName))
      {
        _binaryFormatter.Serialize(s, allEvents.ToArray());
      }
    }
  }
}
