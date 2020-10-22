using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace ConsoleApp2.Config
{
    public class EnvironmentConfiguration : IEnvironmentConfiguration
    {
        public string DirectoryToMonitor => ConfigurationManager.AppSettings["DirectoryToMonitor"];

        public string FeedFileName => ConfigurationManager.AppSettings["FeedFileName"];

        public string FeedFileAbsolutePath => ConfigurationManager.AppSettings["FeedFileAbsolutePath"];

        public int IntervalInSecondsToPollDirectory => Convert.ToInt32(ConfigurationManager.AppSettings["IntervalInSecondsToPollDirectory"]);

        public string BaseUrl => ConfigurationManager.AppSettings["BaseUrl"];

        //public string DirectoryToMonitor { get; set; }

        //public string FeedFileName { get; set; }

        //public string FeedFileAbsolutePath { get; set; }

        //public int IntervalInSecondsToPollDirectory { get; set; }

        //public string BaseUrl { get; set; }
    }
}
