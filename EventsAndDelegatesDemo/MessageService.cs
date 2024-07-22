using System;

namespace EventsAndDelegatesDemo
{
    public class MessageService
    {
        public void OnVideoPublished(object source, VideoEventArgs args)
        {
            Console.WriteLine($"Message Service: Sending a message...... {args.Video.Title}");
        }
    }
}
