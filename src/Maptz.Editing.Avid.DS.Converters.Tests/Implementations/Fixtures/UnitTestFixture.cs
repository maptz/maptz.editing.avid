using System;
using Xunit;
using Maptz.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace Maptz.Editing.Avid.DS.Converters.Tests
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
            var workspace = this.ServiceProvider.GetService<ITempDirectoryWorkspace>();
            this.Workspace = workspace;
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