using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadPipe.Net.Slack.Tests
{
    public class SlackConfiguration : ISlackConfiguration
    {
        public string DefaultChannel { get; }

        public bool Enabled { get; }

        public string UrlWithAccessToken { get; }
    }
}
