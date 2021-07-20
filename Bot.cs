using System;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Events;

namespace AShittybot
{
    internal class Bot
    {
        ConnectionCredentials creds = new ConnectionCredentials(TwitchInfo.ChannelName, TwitchInfo.AcessToken);
        TwitchClient client;


        internal void Connect(bool isLogging)
        {
            client = new TwitchClient();
            client.Initialize(creds, TwitchInfo.ChannelName);

            Console.WriteLine("[BOT] : Connecting...");

            if (isLogging)
                client.OnLog += Client_OnLog;

            client.OnError += Client_OnError;
            client.OnMessageReceived += Client_OnMessageReceived;
            client.OnChatCommandReceived += Client_OnChatCommandReceived;

            client.Connect();
            client.OnConnected += Client_OnConnected;
        }

        private void Client_OnError(object sender, OnErrorEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            Console.WriteLine($"[{e.ChatMessage.DisplayName}] : {e.ChatMessage.Message} ");
        }

        private void Client_OnChatCommandReceived(object sender, OnChatCommandReceivedArgs e)
        {
            switch (e.Command.CommandText.ToLower())
            {
                case "benjam":
                    client.SendMessage(TwitchInfo.ChannelName, "Prejent");
                    break;
            }

            if (e.Command.ChatMessage.DisplayName == TwitchInfo.ChannelName)
            {
                switch (e.Command.CommandText.ToLower())
                {
                    case "julien" :
                        client.SendMessage(TwitchInfo.ChannelName, "Fuck You Julien ! ");
                        break;
                }
            }
        }

        private void Client_OnConnected(object sender, OnConnectedArgs e)
        {
            Console.WriteLine("[BOT] : Connected !");
        }

        private void Client_OnLog(object sender, OnLogArgs e)
        {
            Console.WriteLine(e.Data);
        }

        internal void Disconect()
        {
            client.Disconnect();
        }

    }
}