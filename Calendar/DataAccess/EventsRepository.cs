using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

using Calendar.Events;

namespace Calendar.DataAccess
{
  class EventsRepository : IEventsRepository
  {
    private readonly BinaryFormatter _binaryFormatter = new BinaryFormatter();
    private const string FileName = "calendarData.dat";

    public ICalendarEvent[] GetEvents(DateSpan schedule)
    {
      try
      {
        IEnumerable<ICalendarEvent> allEvents = TryReadingCalendarEvents();
        return allEvents.Where(e => e.Schedule.IntersectWith(schedule))
                        .ToArray();
      }
      catch (Exception)
      {
        return new ICalendarEvent[0];
      }
    }

    private IEnumerable<ICalendarEvent> TryReadingCalendarEvents()
    {
      using (Stream s = File.OpenRead(FileName))
      {
        return (ICalendarEvent[])_binaryFormatter.Deserialize(s);
      }
    }

    public void AddEvent(ICalendarEvent eventToAdd)
    {
      IList<ICalendarEvent> allEvents = GetEvents(DateSpan.Max).ToList();
      allEvents.Add(eventToAdd);

      using (Stream s = File.OpenWrite(FileName))
      {
        _binaryFormatter.Serialize(s, allEvents.ToArray());
      }
    }
  }
}
