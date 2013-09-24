using System;

namespace Calendar.Events
{
  [Serializable]
  public abstract class CalendarEventBase : ICalendarEvent
  {
    private readonly DateSpan _schedule;
    private readonly string _title;

    protected CalendarEventBase(DateSpan schedule, string title)
    {
      _schedule = schedule;
      _title = title;
    }

    public DateSpan Schedule { get { return _schedule; } }
    public string Title { get { return _title; } }
    public bool CanShareTime { get;  set; }
  }
}