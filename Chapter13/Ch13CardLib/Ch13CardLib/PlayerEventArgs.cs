using System;

namespace Ch13CardLib
{
    public class PlayerEventArgs : EventArgs
    {
        public Player Player { get; set; }
        public PlayerState State { get; set; }
    }

}
