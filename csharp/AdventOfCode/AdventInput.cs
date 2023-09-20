using System.IO;

namespace AdventOfCode
{
    internal class AdventInput
    {
        public static string[] ReadFile<T>(int year, string split) where T : IAdventResolver
        {
            var path = $"./{year}/{typeof(T).Name.Replace("Resolver", string.Empty)}/Input.txt";
            using var reader = new StreamReader(path);
            return reader.ReadToEnd().Split(split);
        }
    }
}
