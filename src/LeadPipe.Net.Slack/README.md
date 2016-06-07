# LeadPipe.Net.Slack

LeadPipe.Net.Slack provides a fluent interface to make sending Slack messages quick and easy.

Simple messages are as quick and easy as this:

```csharp
Slack.Build.Message("Hello world!").SendNow();
```

The fun begins when you start formatting your message with attachments and fields! Like this:

```csharp
Slack.Build.Message("Oh-no! There's been an error!")
     .WithMessageLevel(SlackMessageLevel.Error)
     .WithAttachment
         .WithPriority(SlackMessagePriority.High)
         .WithTitle(ex.Message)
         .WithTitleLink(myApplicationUrl)
         .IncludingField("Gizmo Id", gizmoId)
         .Attach()
     .SendNow();
```
