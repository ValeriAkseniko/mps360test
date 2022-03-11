using System.Text.RegularExpressions;

namespace mps360test
{
    public class ValidationService
    {
        public bool ValidationCoordinate(string coordinate)
        {
            if (Regex.IsMatch(coordinate, @"([0-7]){1}(\s){1}([0-7]){1}(\s){1}([NESW]$){1}"))
            {
                return true;
            }
            return false;
        }

        public bool ValidationPath(string path)
        {
            if (Regex.IsMatch(path, @"[^\s][LRF]"))
            {
                return true;
            }
            return false;
        }
    }
}
