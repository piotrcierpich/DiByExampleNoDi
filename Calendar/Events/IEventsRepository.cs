namespace Calendar.Events
{
  public interface IEventsRepository
  {
    ICalendarEvent[] GetEvents(DateSpan schedule);
    void AddEvent(ICalendarEvent eventToAdd);
  }
}