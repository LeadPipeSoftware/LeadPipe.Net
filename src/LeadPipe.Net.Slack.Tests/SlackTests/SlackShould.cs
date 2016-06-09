// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System.Linq;
using NUnit.Framework;

namespace LeadPipe.Net.Slack.Tests.SlackTests
{
    /// <summary>
    /// Slack tests.
    /// </summary>
    [TestFixture]
    public class SlackShould
    {
        /// <summary>
        /// Test to make sure that the built-up message includes all of the specified values.
        /// </summary>
        [Test]
        public void ReturnBuiltUpMessageWithOptionalValues()
        {
            // Arrange
            Bootstrapper.Start();
            var slack = Bootstrapper.Container.GetInstance<ISlack>();

            var expectedText = "Hey everybody!";
            var expectedUserName = "Bobby Tables";
            var expectedIconEmoji = ":thumbsup:";

            // Act
            var message = slack.Send.Message(expectedText)
                                    .AsUserName(expectedUserName)
                                    .WithIconEmoji(expectedIconEmoji)
                                    .ToSlackMessageObject();

            // Assert
            Assert.AreEqual(message.Text, expectedText);
            Assert.AreEqual(message.UserName, expectedUserName);
            Assert.AreEqual(message.IconEmoji, expectedIconEmoji);
        }

        /// <summary>
        /// Test to make sure that the built-up message with an attachment includes all of the specified values.
        /// </summary>
        [Test]
        public void ReturnBuiltUpMessageWithAttachment()
        {
            // Arrange
            Bootstrapper.Start();
            var slack = Bootstrapper.Container.GetInstance<ISlack>();

            var expectedFallback = "Required plain-text summary of the attachment.";
            var expectedColor = "#36a64f";
            var expectedPretext = "Optional text that appears above the attachment block";
            var expectedAuthorName = "Bobby Tables";
            var expectedAuthorLink = "http://flickr.com/bobby/";
            var expectedAuthorIcon = "http://flickr.com/icons/bobby.jpg";
            var expectedTitle = "Slack API Documentation";
            var expectedTitleLink = "https://api.slack.com/";
            var expectedText = "Optional text that appears within the attachment";
            var expectedImageUrl = "http://my-website.com/path/to/image.jpg";
            var expectedThumbUrl = "http://example.com/path/to/thumb.png";
            var expectedFooter = "Slack API";
            var expectedFooterIcon = "https://platform.slack-edge.com/img/default_application_icon.png";
            var expectedTimestamp = 123456789;

            // Act
            var message = slack.Send.MessageWithAttachment
                                        .WithFallbackText(expectedFallback)
                                        .WithColor(expectedColor)
                                        .WithPretext(expectedPretext)
                                        .WithAuthorName(expectedAuthorName)
                                        .WithAuthorLink(expectedAuthorLink)
                                        .WithAuthorIcon(expectedAuthorIcon)
                                        .WithTitle(expectedTitle)
                                        .WithTitleLink(expectedTitleLink)
                                        .WithText(expectedText)
                                        .IncludingField("Priority", "High", false)
                                        .WithImageUrl(expectedImageUrl)
                                        .WithThumbUrl(expectedThumbUrl)
                                        .WithFooter(expectedFooter)
                                        .WithFooterIcon(expectedFooterIcon)
                                        .WithTimestamp(expectedTimestamp)
                                        .Attach()
                                    .ToSlackMessageObject();

            // Assert
            Assert.AreEqual(message.Attachments.First().Fallback, expectedFallback);
            Assert.AreEqual(message.Attachments.First().Color, expectedColor);
            Assert.AreEqual(message.Attachments.First().Pretext, expectedPretext);
            Assert.AreEqual(message.Attachments.First().AuthorName, expectedAuthorName);
            Assert.AreEqual(message.Attachments.First().AuthorLink, expectedAuthorLink);
            Assert.AreEqual(message.Attachments.First().AuthorIcon, expectedAuthorIcon);
            Assert.AreEqual(message.Attachments.First().Title, expectedTitle);
            Assert.AreEqual(message.Attachments.First().TitleLink, expectedTitleLink);
            Assert.AreEqual(message.Attachments.First().Text, expectedText);
            Assert.AreEqual(message.Attachments.First().ImageUrl, expectedImageUrl);
            Assert.AreEqual(message.Attachments.First().ThumbUrl, expectedThumbUrl);
            Assert.AreEqual(message.Attachments.First().Footer, expectedFooter);
            Assert.AreEqual(message.Attachments.First().FooterIcon, expectedFooterIcon);
            Assert.AreEqual(message.Attachments.First().Timestamp, expectedTimestamp);
        }
    }
}