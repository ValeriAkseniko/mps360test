using System.Text.RegularExpressions;

namespace mps360test
{
    public class ValidationService
    {
        public bool ValidationCoordinate(string coordinate)
        {
            if (coordinate != null 
                && coordinate != string.Empty
                && Regex.IsMatch(coordinate, @"([0-7]){1}(\s){1}([0-7]){1}(\s){1}([NESW]$){1}"))
            {
                return true;
            }
            return false;
        }

        public bool ValidationPath(string path)
        {
            if (path != null 
                && path != string.Empty 
                && path.Length < 100
                && Regex.IsMatch(path, @"^[LRF]+$"))
            {
                return true;
            }
            return false;
        }
    }
}
