namespace Calendar.Events.AddPolicy
{
  class ShareableTimePolicy : IAddPolicy
  {
    private readonly IEventsRepository eventsRepository;

    public ShareableTimePolicy(IEventsRepository eventsRepository)
    {
      this.eventsRepository = eventsRepository;
    }

    public void TryAddToRepository(ICalendarEvent calendarEvent)
    {
      eventsRepository.AddEvent(calendarEvent);
    }
  }
}
