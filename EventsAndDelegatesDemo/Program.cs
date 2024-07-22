using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegatesDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Video video = new Video();
            VideoPublisher publisher = new VideoPublisher();

            MailService mailService = new MailService();
            MessageService messageService = new MessageService();

            publisher.VideoPublished += mailService.OnVideoPublished;
            publisher.VideoPublished += messageService.OnVideoPublished;

            publisher.Publish(video);

            Console.ReadLine();
        }
    }
}
