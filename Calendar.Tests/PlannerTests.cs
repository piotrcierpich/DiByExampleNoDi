using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Calendar.Events;
using Calendar.Events.AddPolicy;

using NSubstitute;

using NUnit.Framework;

namespace Calendar.Tests
{
  [TestFixture]
  class PlannerTests
  {
    [Test]
    public void ShouldUseExclusiveSchedulePolicyWhenEventCannotShareTime()
    {
      ICalendarEvent calendarEvent = Substitute.For<ICalendarEvent>();
      calendarEvent.CanShareTime.Returns(false);

      IAddPolicy exclusiveScheduleAddPolicy = Substitute.For<IAddPolicy>();
      IAddPolicy shareableTimeAddPolicy = Substitute.For<IAddPolicy>();

      Planner planner = new Planner(exclusiveScheduleAddPolicy, shareableTimeAddPolicy);
      planner.AddEvent(calendarEvent);

      exclusiveScheduleAddPolicy.Received(1).TryAddToRepository(calendarEvent);
    }

    [Test]
    public void ShoulduseShareableSchedulePolicyWhenEventCanShareTime()
    {
      ICalendarEvent calendarEvent = Substitute.For<ICalendarEvent>();
      calendarEvent.CanShareTime.Returns(true);

      IAddPolicy exclusiveScheduleAddPolicy = Substitute.For<IAddPolicy>();
      IAddPolicy shareableTimeAddPolicy = Substitute.For<IAddPolicy>();

      Planner planner = new Planner(exclusiveScheduleAddPolicy, shareableTimeAddPolicy);
      planner.AddEvent(calendarEvent);

      shareableTimeAddPolicy.Received(1).TryAddToRepository(calendarEvent);
    }
  }
}
