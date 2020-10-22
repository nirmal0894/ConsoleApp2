using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace ConsoleApp2.Config
{
    public interface IEnvironmentConfiguration
    {
        string DirectoryToMonitor { get; }

        string FeedFileName { get; }

        string FeedFileAbsolutePath { get; }

        int IntervalInSecondsToPollDirectory { get; }

        string BaseUrl { get; }
    }
}
