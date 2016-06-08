# LeadPipe.Net.Slack

LeadPipe.Net.Slack provides a fluent interface to make sending Slack messages quick and easy.

## Overview

Simple messages are as quick and easy as this:

```csharp
slack.Send.Message("Hey everybody!").ToDefaultChannel();
```

They can include emoji and other goodies, too. Like this:

```csharp
slack.Send.Message("Hey everybody!")
          .AsUserName("Buddy Tables")
          .WithIconEmoji(":thumbsup:")
          .ToDefaultChannel();
```

You can also get fancy with [Slack message attachments](https://api.slack.com/docs/attachments). Like this:

```csharp
slack.Send.MessageWithAttachment
          .WithFallbackText("Required plain-text summary of the attachment.")
          .WithColor("#36a64f")
          .WithPretext("Optional text that appears above the attachment block")
          .WithAuthorName("Bobby Tables")
          .WithAuthorLink("http://flickr.com/bobby/")
          .WithAuthorIcon("http://flickr.com/icons/bobby.jpg")
          .WithTitle("Slack API Documentation")
          .WithTitleLink("https://api.slack.com/")
          .WithText("Optional text that appears within the attachment")
          .IncludingField("Priority", "High", false)
          .WithImageUrl("http://my-website.com/path/to/image.jpg")
          .WithThumbUrl("http://example.com/path/to/thumb.png")
          .WithFooter("Slack API")
          .WithFooterIcon("https://platform.slack-edge.com/img/default_application_icon.png")
          .WithTimestamp(123456789)
          .Attach()
          .ToDefaultChannel();
```

### Notes

* To create a link in your text, enclose the URL in `<>` angle brackets.
* Message text _can_ be multi-line using `\n` as the line break.
* A channel usually means what you think it does, but it can also be a direct message between two users, a private channel, or it could be the instance of a conversation between one or more users.
* Specify channels with the hashtag prefix (`#somechannel`) and users with the ampersand prefix (`@someuser`).
* Follow Slack's [Message Formatting](https://api.slack.com/docs/formatting).

## Configuration

To get started you will need to [set up a new Web Hook in Slack](https://api.slack.com/incoming-webhooks). Put the URL including the authorization token in your ISlackConfiguration instance along with the name of the default channel and you're ready to go! You can wire up with your favorite IoC solution or simply new up a `Slack` object and start sending!

## Error Handling

The result of the last Slack request can be found by looking at the `slack.Result` property. Generally speaking, you should see `HTTP 200 OK` there. If something went wrong then you'll get whatever Slack sent back.
