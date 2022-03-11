using System.Collections.Generic;
using System.Linq;

namespace mps360test
{
    public class Command
    {
        public List<char> Path { get; set; }

        public Command()
        {

        }

        public Command(string path)
        {
            Path = path.ToList();
        }
    }
}
