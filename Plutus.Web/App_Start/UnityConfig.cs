using System;
using System.Diagnostics;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace Plutus.Web.App_Start {
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() => {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer() {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container) {
            // Load from web.config
            container.LoadConfiguration();

            // TODO: Register your types here
            // container.RegisterType<IProductRepository, ProductRepository>();
        }
    }


    public class MyUnityContainer : IUnityContainer {
        private IUnityContainer _container = new UnityContainer();

        #region IUnityContainer Members

        public IUnityContainer AddExtension(UnityContainerExtension extension) {
            throw new NotImplementedException();
        }

        public object BuildUp(Type t, object existing, string name, params ResolverOverride[] resolverOverrides) {
            throw new NotImplementedException();
        }

        public object Configure(Type configurationInterface) {
            throw new NotImplementedException();
        }

        public IUnityContainer CreateChildContainer() {
            throw new NotImplementedException();
        }

        public IUnityContainer Parent {
            get { throw new NotImplementedException(); }
        }

        public IUnityContainer RegisterInstance(Type t, string name, object instance, LifetimeManager lifetime) {
            throw new NotImplementedException();
        }

        public IUnityContainer RegisterType(Type from, Type to, string name, LifetimeManager lifetimeManager, params InjectionMember[] injectionMembers) {
            return _container.RegisterType(from, to, name, lifetimeManager, injectionMembers);
        }

        public System.Collections.Generic.IEnumerable<ContainerRegistration> Registrations {
            get { throw new NotImplementedException(); }
        }

        public IUnityContainer RemoveAllExtensions() {
            throw new NotImplementedException();
        }

        public object Resolve(Type t, string name, params ResolverOverride[] resolverOverrides) {
            Trace.TraceInformation(t.GetType().Name);

            return _container.Resolve(t, name, resolverOverrides);
        }

        public System.Collections.Generic.IEnumerable<object> ResolveAll(Type t, params ResolverOverride[] resolverOverrides) {
            throw new NotImplementedException();
        }

        public void Teardown(object o) {
            throw new NotImplementedException();
        }

        #endregion

        #region IDisposable Members

        public void Dispose() {
            throw new NotImplementedException();
        }

        #endregion
    }
}
