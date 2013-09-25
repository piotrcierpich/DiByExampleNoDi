using Calendar.Events;

namespace Calendar.UI
{
  class TodoFactory : ITodoFactory
  {
    private bool canShareTime;

    public TodoFactory(bool canShareTime)
    {
      this.canShareTime = canShareTime;
    }

    public Todo Create(DateSpan schedule, string title)
    {
      return new Todo(schedule, title) { CanShareTime = canShareTime };
    }
  }
}