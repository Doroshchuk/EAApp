﻿using EATestFramework.Driver;

namespace EATestFramework.Settings
{
    public enum ExecutionType
    {
        Local,
        Remote
    }

    public class TestSettings
    {
        public BrowserType BrowserType { get; set; }
        public Uri ApplicationUrl { get; set; }
        public int TimeoutInterval { get; set; }
        public Uri SeleniumGridUrl { get; set; }
        public ExecutionType ExecutionType { get; set;}
    }
}
