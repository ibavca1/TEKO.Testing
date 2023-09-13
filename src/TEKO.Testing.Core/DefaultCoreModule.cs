using System.Net.Http;
using Autofac;
using TEKO.Testing.Core.Interfaces;
using TEKO.Testing.Core.Services;

namespace TEKO.Testing.Core;

/// <summary>
/// An Autofac module that is responsible for wiring up services defined in the Core project.
/// </summary>
public class DefaultCoreModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<DeleteContributorService>()
        .As<IDeleteContributorService>().InstancePerLifetimeScope();    
  }
}
