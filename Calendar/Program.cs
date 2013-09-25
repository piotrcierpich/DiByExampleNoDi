using System;
using System.Collections.Generic;
using System.IO;
using Autofac;
using Autofac.Configuration;
using Autofac.Extras.DynamicProxy2;
using Calendar.DataAccess;
using Calendar.Events;
using Calendar.Events.AddPolicy;
using Calendar.Logging;
using Calendar.UI;
using System.Reflection;

namespace Calendar
{
  class Program
  {
    static void Main()
    {

      ContainerBuilder containerBuilder = new ContainerBuilder();

      containerBuilder.RegisterType<ShareableTimePolicy>();
      containerBuilder.RegisterType<ExclusiveSchedulePolicy>();

      containerBuilder.Register(c => new Planner(c.Resolve<ExclusiveSchedulePolicy>(), c.Resolve<ShareableTimePolicy>()))
                      .As<IPlanner>();

      containerBuilder.RegisterModule(new ConfigurationSettingsReader("customXmlConfigurationSection"));

      containerBuilder.RegisterType<Logger>()
                      .AsImplementedInterfaces()
                      .SingleInstance();

      containerBuilder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                      .Where(type => type.IsAssignableTo<IOption>())
                      .AsImplementedInterfaces();
      
      containerBuilder.RegisterType<OptionsDispatcher>()
                      .EnableClassInterceptors()
                      .InterceptedBy(typeof(LoggingInterceptor));
      containerBuilder.RegisterType<LoggingInterceptor>();

      containerBuilder.RegisterInstance(Console.In);

      using (IContainer container = containerBuilder.Build())
      {
        OptionsDispatcher optionsDispatcher = container.Resolve<OptionsDispatcher>();

        bool continueRunning = true;
        while (continueRunning)
        {
          continueRunning = optionsDispatcher.ChooseOptionAndRun();
        }
      }
    }
  }
}
