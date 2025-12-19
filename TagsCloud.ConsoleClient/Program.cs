using System.Reflection;
using Autofac;
using TagsCloud;
using TagsCloud.Modules;

var builder = new ContainerBuilder();


builder.RegisterType<ServiceResolver>().SingleInstance();
builder.RegisterType<ProgramOptionsMapper>().SingleInstance();
builder.RegisterType<ConsoleUi>().SingleInstance();
builder.RegisterAssemblyModules(Assembly.GetAssembly(typeof(AppModule))!);
var container = builder.Build();

var consoleUi = container.Resolve<ConsoleUi>();
consoleUi.Run(args);