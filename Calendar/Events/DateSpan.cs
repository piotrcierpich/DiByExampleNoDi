using System;

namespace Calendar.Events
{
  [Serializable]
  public sealed class DateSpan
  {
    public static readonly DateSpan Max = new DateSpan(DateTime.MinValue, DateTime.MaxValue);
    private readonly DateTime _startTime;
    private readonly DateTime _endTime;

    public DateSpan(DateTime startTime, DateTime endTime)
    {
      if (endTime < startTime)
        throw new ArgumentException("End time cannot be lower than start time");

      _startTime = startTime;
      _endTime = endTime;
    }

    public bool IntersectWith(DateSpan other)
    {
      return _endTime > other._startTime && _startTime < other._endTime;
    }

    public DateTime StartTime
    {
      get { return _startTime; }
    }

    public DateTime EndTime
    {
      get { return _endTime; }
    }

    public override bool Equals(object obj)
    {
      if ((obj == null || (!(obj is DateSpan))))
      {
        return false;
      }

      DateSpan other = (DateSpan)obj;
      return _startTime.Equals(other._startTime) && _endTime.Equals(other._endTime);
    }

    public override int GetHashCode()
    {
      return _startTime.GetHashCode() | _startTime.GetHashCode();
    }
  }
}