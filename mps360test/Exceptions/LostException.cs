using System;

namespace mps360test.Exceptions
{
    public class LostException : Exception
    {
        public LostException() : base()
        {

        }

        public override string ToString()
        {
            return "LOST";
        }
    }
}
