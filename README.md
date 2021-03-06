# ALIEbot

### Author
Katherine "Kat" Harris - Microsoft Technical Evangelist (TE) - Twitter: @KatVHarris - http://twitter.com/katvharris

## Interact and Test
Web: http://aliebot.azurewebsites.net/

Facebook: https://www.facebook.com/ALIE-Bot-1179365098748917/

## Summary
ALIEbot was created using the Microsoft Bot Framework. It uses the Bot Connector (C#) for integration to the Web, Facebook and Slack. Each class has a different sample of how to implement messaging for your Bot. The Natural Language processing is done through Microsoft's LUIS Serivce: https://www.luis.ai/

The purpose of this project is to have detailed samples for people to learn about the Bot Framework. And eventually expand the demo into the 3D gaming engine, Unity3D. 

The post for how I got everything working will be up at: http://katvharris.azurewebsites.net/blog/

## Commands // Responses // LUIS intents
#### None
Catch all, generic response that is the default response for unknown intents that are returned in LUIS. 

#### Help
Gives hints as to what the user can do with the Bot. Help cahanges base on the version of ALIE. 

#### CoreCommand
States A.L.I.E.'s core command.

#### JoinCOL
Creates a ConfirmationDialog for the user to respond with affirmitive/negitive confirmation to "join" the city of light.

#### NameQuery
Queries information on X, where X is the name of the Person, Place, or Thing, in the world of the 100. 

Current Character Attachment Cards

* Clarke
* Lexa
* Raven
* Abby
* Kane
* Jaha
* Bellamy
* Jasper
* Monty
* Murphy
* Octavia
* Indra
* Roan
* Emori

PLACES

* Tondc
* Polis
* The Ark
* Arkadia
* Mount Weather

#### Greeting
Responds to users greeting with generic greetings.

#### Upgrade
Gives the user acess to all the hidden commands for querying data about the show instead of just elements inside the show. The user needs to know the command phrase "ascende superius" to upgrade. "Help" Command will also reveal list of hidden commands. 

#### LocateX
Gives the last known location of a character.

#### Sort Character
This command can only be used after upgrading. It tells users which house each character belongs to with attachement card of the house and a descrioption of why they are in that house. 

## Action Items
* Restablish FB connection
* Uncouple the Character Attchment cards from the LUIS_Integration Class. 
* Add more Character Cards

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


## Notes
With the new updates to the Bot Framework, I refactored all the code to reflect V3. Now interations are handled by Activites and the Web and Facebook interfaces are handled by the updated connection client. 01/24/17

Slack integration is working, however the bot responds to ever post in the channel. To avoid this, add alie to a seprate #alie_bot channel to interact. 

Unity integration may byspass certain callbacks in the bot framework since Unity runs on a different version of .Net/Mono. Direct calls to the LUIS framework will have to be integrated through a Node.js server. Elements to work on this part will happen this week - 06/27/16

## Coming Features:
* Asking about the creator (Becca and Kat)
* Returning Links relevant to the show




