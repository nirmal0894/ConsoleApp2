using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace ConsoleApp2.Ioc
{
    public static class ContainerFactory
    {
        public static IUnityContainer InitialiseContainer()
        {
            var unityContainer = new UnityContainer();
            unityContainer.AddExtension(new ScheduleFeedFileDependencies());
            return unityContainer;
        }
    }
}
