using System;
using System.Collections.Generic;
using System.Text;
using Unity.Extension;

namespace ConsoleApp2.Ioc
{
    public class ScheduleFeedFileDependencies : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IScheduleFeedFileMonitoring, FeedFileJobScheduler>();
        }
        
    }
}
