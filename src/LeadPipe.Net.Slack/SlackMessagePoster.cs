using System.Collections.Specialized;
using System.Net;
using System.Text;
using LeadPipe.Net.Extensions;
using Newtonsoft.Json;

namespace LeadPipe.Net.Slack
{
    /// <summary>
    /// Posts messages to Slack.
    /// </summary>
    public class SlackMessagePoster : ISlackMessagePoster
    {
        private readonly ISlackConfiguration configuration;
        private readonly Encoding encoding = new UTF8Encoding();

        /// <summary>
        /// Initializes a new instance of the <see cref="SlackMessagePoster"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public SlackMessagePoster(ISlackConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// Posts the supplied message to Slack.
        /// </summary>
        /// <param name="message">The message.</param>
        public void PostMessage(SlackMessage message)
        {
            if (configuration.Enabled.IsFalse()) return;

            var payloadJson = JsonConvert.SerializeObject(message);

            using (var client = new WebClient())
            {
                var data = new NameValueCollection { ["payload"] = payloadJson };

                var response = client.UploadValues(configuration.UrlWithAccessToken, "POST", data);

                // The response text is usually "ok"
                var responseText = encoding.GetString(response);
            }
        }
    }
}