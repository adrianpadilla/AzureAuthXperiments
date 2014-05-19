using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace FactsLibrary.Api
{
    public class UnityControllerFactory : DefaultControllerFactory
    {
        private readonly IUnityContainer _container;

        protected override System.Web.SessionState.SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, Type controllerType)
        {
            return base.GetControllerSessionBehavior(requestContext, controllerType);
        }

        public UnityControllerFactory(IUnityContainer container)
        {
            _container = container;
        }

        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            try
            {
                return (IController)_container.Resolve(GetControllerType(requestContext, controllerName));
            }
            catch
            {
                return base.CreateController(requestContext, controllerName);
            }
        }

        public override void ReleaseController(IController controller)
        {
            _container.Teardown(controller);

            base.ReleaseController(controller);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return base.GetControllerInstance(requestContext, controllerType);
        }

        protected override Type GetControllerType(RequestContext requestContext, string controllerName)
        {
            return base.GetControllerType(requestContext, controllerName);
        }
    }
}
