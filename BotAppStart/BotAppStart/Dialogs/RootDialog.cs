using System;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Dialogs;

namespace BotAppStart.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            // calculate something for us to return
            int length = (activity.Text ?? string.Empty).Length;

            // return our reply to the user
            
            if (activity.Text.Contains("ChatBot Demo"))
            {
                await context.PostAsync("Para mayor detalle consulte el sitio web https://vicenteguzman.mx/");
            }
            else if (activity.Text.Contains("morning"))
            {
                await context.PostAsync("¡Hola! Buenos dias, ¿en que puedo ayudarte?");
            }
            
            else if (activity.Text.Contains("night"))
            {
                await context.PostAsync("Buenas noches, sueña con Applications Bots.");
            }
            else if (activity.Text.Contains("date"))
            {
                await context.PostAsync(DateTime.Now.ToString());
            }
            else
            {
                await context.PostAsync($"You sent {activity.Text} which was {length} characters");
            }

            context.Wait(MessageReceivedAsync);
        }
    }
}