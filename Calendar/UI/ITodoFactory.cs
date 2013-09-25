using Calendar.Events;

namespace Calendar.UI
{
  public interface ITodoFactory
  {
    Todo Create(DateSpan schedule, string title);
  }
}