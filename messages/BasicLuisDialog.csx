using System;
using System.Threading.Tasks;

using Microsoft.Bot.Builder.Azure;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;

// For more information about this template visit http://aka.ms/azurebots-csharp-luis
[Serializable]
public class BasicLuisDialog : LuisDialog<object>
{
    public BasicLuisDialog() : base(new LuisService(new LuisModelAttribute(Utils.GetAppSetting("LuisAppId"), Utils.GetAppSetting("LuisAPIKey"))))
    {
    }
    
    public List<String> conversation_history = new List<String>();
    [LuisIntent("None")]
    public async Task NoneIntent(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"cvcb la la la Ne diyon lan . You said: {result.Query}"); //
        context.Wait(MessageReceived);
    }

    // Go to https://luis.ai and create a new intent, then train/publish your luis app.
    // Finally replace "MyIntent" with the name of your newly created intent in the following handler
    [LuisIntent("MyIntent")]
    public async Task MyIntent(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"You have reached the MyIntent intent. You said: {result.Query}"); //
        conversation_history.Add("myIntent");
        context.Wait(MessageReceived);
    }
    [LuisIntent("YarroIntent")]
    public async Task YarroIdsfsdftent(IDialogContext context, LuisResult result)
    {
        
        if (conversation_history.Exists("YARRO"))
        {
            await context.PostAsync($"Yine mi geldin lan YARRO!");
        } else
        {
            await context.PostAsync($"Sensin lan YARRO!"); //
            conversation_history.Add("YARRO");
        }
        context.Wait(MessageReceived);
    }
}