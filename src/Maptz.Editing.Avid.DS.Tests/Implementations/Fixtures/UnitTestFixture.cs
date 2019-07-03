using System;
using Xunit;
using Maptz.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace Maptz.Editing.Avid.DS.Tests
{
    public class UnitTestFixture : InjectedServicesFixture
    {
        public ITempDirectoryWorkspace Workspace { get; }

        /* #region Public Constructors */
        public UnitTestFixture(Action<IServiceCollection> sc) : base(sc)
        {
            
        }

        public UnitTestFixture(): base()
        {
            this.Workspace = this.ServiceProvider.GetService<ITempDirectoryWorkspace>();       
            
        }
        /* #endregion Public Constructors */

        /* #region Protected Methods */
        protected override void AddServices(ServiceCollection servicesCollection)
        {
            base.AddServices(servicesCollection);
            servicesCollection.AddTransient<ITempDirectoryWorkspace, TempDirectoryWorkspace>();
        }
        /* #endregion Public Constructors */
    }
}