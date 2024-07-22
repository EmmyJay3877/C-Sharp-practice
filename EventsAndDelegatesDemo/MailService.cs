using System;

namespace EventsAndDelegatesDemo
{
    public class MailService
    {
        public void OnVideoPublished(object source, VideoEventArgs args)
        {
            Console.WriteLine($"Mail Service: Sending an email...... {args.Video.Title}");
        }
    }
}
