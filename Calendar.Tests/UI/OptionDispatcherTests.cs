using System.IO;
using Calendar.Logging;
using NSubstitute;

using NUnit.Framework;

namespace Calendar.Tests.UI
{
  [TestFixture]
  class OptionDispatcherTests
  {
    [Test]
    public void ShouldPickOption2AndRunIt()
    {
      const string option1String = "option1";
      IOption option1 = Substitute.For<IOption>();
      option1.MatchesString(option1String).Returns(true);

      const string option2String = "option 2";
      IOption option2 = Substitute.For<IOption>();
      option2.MatchesString(option2String).Returns(true);

      TextReader textReader = Substitute.For<TextReader>();
      textReader.ReadLine().Returns(option2String);

      ILogger logger = Substitute.For<ILogger>();

      OptionsDispatcher optionsDispatcher = new OptionsDispatcher(new[] { option1, option2 }, textReader, logger);
      optionsDispatcher.ChooseOptionAndRun();

      option2.Received(1).Run();
      option1.DidNotReceive().Run();
    }
  }
}
