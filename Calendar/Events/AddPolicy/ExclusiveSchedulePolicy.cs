using System.Linq;

namespace Calendar.Events.AddPolicy
{
  internal class ExclusiveSchedulePolicy : IAddPolicy
  {
    private readonly IEventsRepository eventsRepository;

    public ExclusiveSchedulePolicy(IEventsRepository eventsRepository)
    {
      this.eventsRepository = eventsRepository;
    }

    public void TryAddToRepository(ICalendarEvent eventToAdd)
    {
      ICalendarEvent[] intersectingEvents = eventsRepository.GetEvents(eventToAdd.Schedule);
      if (intersectingEvents.All(ie => ie.CanShareTime))
      {
        eventsRepository.AddEvent(eventToAdd);
      }
    }
  }
}