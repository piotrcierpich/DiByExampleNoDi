using Calendar.Events.AddPolicy;

namespace Calendar.Events
{
  internal class Planner : IPlanner
  {
    private readonly IAddPolicy _exclusiveScheduleAddPolicy;
    private readonly IAddPolicy _shareableTimeAddPolicy;

    public Planner(IAddPolicy exclusiveScheduleAddPolicy, IAddPolicy shareableTimeAddPolicy)
    {
      _exclusiveScheduleAddPolicy = exclusiveScheduleAddPolicy;
      _shareableTimeAddPolicy = shareableTimeAddPolicy;
    }

    public void AddEvent(ICalendarEvent calendarEvent)
    {
      if (calendarEvent.CanShareTime)
        _shareableTimeAddPolicy.TryAddToRepository(calendarEvent);
      else
        _exclusiveScheduleAddPolicy.TryAddToRepository(calendarEvent);
    }
  }
}