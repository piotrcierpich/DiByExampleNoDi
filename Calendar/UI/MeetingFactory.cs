using Calendar.Events;

namespace Calendar.UI
{
  class MeetingFactory : IMeetingFactory
  {
    private readonly bool canShareTime;

    public MeetingFactory(bool canShareTime)
    {
      this.canShareTime = canShareTime;
    }

    public Meeting Create(DateSpan schedule, string title, string[] participants)
    {
      return new Meeting(schedule, title, participants) { CanShareTime = canShareTime };
    }
  }
}