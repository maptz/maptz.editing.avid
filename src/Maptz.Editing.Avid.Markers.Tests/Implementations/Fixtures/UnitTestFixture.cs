using System;
using Xunit;
using Maptz.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace Maptz.Editing.Avid.Markers.Tests
{


    public class UnitTestFixture : InjectedServicesFixture
    {
        /* #region Public Constructors */
        
          protected override void AddServices(ServiceCollection servicesCollection)
        {
            base.AddServices(servicesCollection);
            //servicesCollection.AddTransient<ITempDirectoryWorkspace, TempDirectoryWorkspace>();
        }
        public UnitTestFixture()
        {
            //var workspace = this.ServiceProvider.GetService<ITempDirectoryWorkspace>();   
        }
        /* #endregion Public Constructors */
    }
}