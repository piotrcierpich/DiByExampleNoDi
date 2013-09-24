namespace Calendar.Events
{
  public interface ICalendarEvent
  {
    DateSpan Schedule { get; }
    string Title { get; }
    bool CanShareTime { get;}
  }
}