using System;
using System.Threading;

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            Video video = new Video { Title = "Gladiator" };
            VideoEncoder videoEncoder = new VideoEncoder();

            MailService mailService = new MailService();
            MessagingService messagingService = new MessagingService();

            videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
            videoEncoder.VideoEncoded += messagingService.OnVideoEncoded;

            videoEncoder.Encode(video);
        }

        public class Video
        {
            public string Title { get; set; }

        }

        public class VideoEventArgs : EventArgs
        {
            public Video Video { get; set; }
        }

        public class VideoEncoder
        {
            // 1. Define a Delegate (eventhandler)
            // 2. Define an Event based on that Delegate
            // 3. Raise the event
            public delegate void VideoEncodeEventHandler(object sender, VideoEventArgs e);
            public event VideoEncodeEventHandler VideoEncoded;

            public void Encode(Video video)
            {
                Console.WriteLine("Encoding video...");
                Thread.Sleep(5000);

                OnVideoEncoded(video);
                Console.Read();
            }

            public void OnVideoEncoded(Video video)
            {
                if (VideoEncoded != null)
                    VideoEncoded(this, new VideoEventArgs { Video = video });
            }
        }

        public class MailService
        {
            public void OnVideoEncoded(object sender, VideoEventArgs e)
            {
                Console.WriteLine("MAILSERVICE: sending an email..." + e.Video.Title);
            }
        }

        public class MessagingService
        {
            public void OnVideoEncoded(object sender, VideoEventArgs e)
            {
                Console.WriteLine("MESSAGING-SERVICE: sending a text message..." + e.Video.Title);
            }
        }
    }
}
