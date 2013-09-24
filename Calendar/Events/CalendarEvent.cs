using System;

namespace Calendar.Events
{
  [Serializable]
  public class CalendarEvent
  {
    private readonly DateSpan _schedule;
    private readonly string _title;

    public CalendarEvent(DateSpan schedule, string title)
    {
      _schedule = schedule;
      _title = title;
    }

    public override string ToString()
    {
      return "TODO '" + Title + "'" + Environment.NewLine
             + "start date: " + Schedule.StartTime + Environment.NewLine
             + "end date: " + Schedule.EndTime + Environment.NewLine;
    }

    public DateSpan Schedule { get { return _schedule; } }
    public string Title { get { return _title; } }
  }
}