using System;

namespace Calendar.Events
{
  [Serializable]
  public class Todo : CalendarEventBase
  {
    public Todo(DateSpan schedule, string title)
      : base(schedule, title)
    {
    }

    public override string ToString()
    {
      return "TODO '" + Title + "'" + Environment.NewLine
             + "start date: " + Schedule.StartTime + Environment.NewLine
             + "end date: " + Schedule.EndTime + Environment.NewLine;
    }
  }
}