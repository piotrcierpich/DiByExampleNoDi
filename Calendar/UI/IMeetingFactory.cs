using Calendar.Events;

namespace Calendar.UI
{
  internal interface IMeetingFactory
  {
    Meeting Create(DateSpan schedule, string title, string[] participants);
  }
}