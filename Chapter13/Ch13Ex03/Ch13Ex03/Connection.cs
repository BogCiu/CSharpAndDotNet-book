using System;
using System.Timers;

namespace Ch13Ex03
{
    public class Connection
    {
        public event EventHandler<MessageArrivedEventArgs> MessageArrived;
        public string Name { get; set; }
        private Timer pollTimer;
        public Connection()
        {
            pollTimer = new Timer(500);
            pollTimer.Elapsed += new ElapsedEventHandler(CheckForMessage);
            //pollTimer.Elapsed += new ElapsedEventHandler(ProcessEvents);

        }
        public void Connect() => pollTimer.Start();
        public void Disconnect() => pollTimer.Stop();
        private static Random random = new Random();
        private void CheckForMessage(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Checking for new messages.");
            if ((random.Next(9) == 0) && (MessageArrived != null))
            {
                MessageArrived(this, new MessageArrivedEventArgs("Hello Mami!"));
                //ProcessEvents(this, new MessageArrivedEventArgs("Exercise handler"));
            }
        }
        // Ch13ExExtra13.1

        //public void ProcessEvents(object source, EventArgs e)
        //{
        //    if (e is MessageArrivedEventArgs)
        //    {
        //        Console.WriteLine("Event handeled a on a MessageArrived event");
        //        Console.WriteLine($"Message: {(e as MessageArrivedEventArgs).Message}");
        //    }
        //    else if (e is ElapsedEventArgs)
        //    {
        //        Console.WriteLine("Event handeled a on a Elapsed event");
        //        Console.WriteLine($"Signal: {(e as ElapsedEventArgs).SignalTime}");
        //    }
        //}
    }
}
