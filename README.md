# ALIEbot

### Author
Katherine "Kat" Harris - Microsoft Technical Evangelist (TE) - Twitter: @KatVHarris

## Interact and Test
Web: http://aliebot.azurewebsites.net/

Facebook: https://www.facebook.com/ALIE-Bot-1179365098748917/

## Summary
ALIEbot was created using the Microsoft Bot Framework. It uses the Bot Connector (C#) for integration to the Web, Facebook and Slack. Each class has a different sample of how to implement messaging for your Bot. The Natural Language processing is done through Microsoft's LUIS Serivce: https://www.luis.ai/

The purpose of this project is to have detailed samples for people to learn about the Bot Framework. And eventually expand the demo into the 3D gaming engine, Unity3D. 

The post for how I got everything working will be up at: http://katvharris.azurewebsites.net/blog/microsoft-bot-framework/

## Coding Todo's
Uncouple the Character Attchment cards from the LUIS_Integration Class. 
Add more Character Cards

### Adding Character Bot.Builder Attachment Cards
The format for adding Character Cards is as follows: 
```csharp
    case "CHARACTER_NAME":
        reply.Text = "DESCRIPTION OF CHARACTER FROM ALIE'S POV. INCULDE STATUS, AGE, LIVING FAMILY";
        // EXAMPLE: Clarke is strong and determined. Her friends and family are her weakness. She is not as clever as Raven though she is resrouceful.";
        reply.Attachments = new List<Attachment>();
        reply.Attachments.Add(new Attachment
        {
            Title = "Name: CHARACTER_NAME - CHARACTER_TITLE //EXAMPLE: Clarke Griffin - aka WanHeda - the commander of Death.",
            ContentType = "image/jpeg",
            ContentUrl = $"THE100 WIKI PHOTO URL OF CHARACTER",
            Text = "COL STATUS/ AGE / FAMILY /" //EXAMPLE:"Status: Not in City of Light \n >Age: 19 \n  >Living Family: Abby Griffin \n "
        });
        break;
```     
Syntax for reply.Text should follow the Microsoft Bot Frameowrk Markdown text. 
Examples of the text for Facebook and the Web are here: http://bit.ly/botMarkdown

## Coming Features:
Sorting Characters
Asking Character Current Location
Returning Links relevant to the show


