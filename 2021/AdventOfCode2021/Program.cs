using AdventOfCode2021.Day01;


using var reader = new StreamReader($"./{typeof(Day01).Name}/Input.txt");
var fileContent = reader.ReadToEnd();
Console.WriteLine(new Day01(fileContent.Split("\r\n")).ResolvePartTwo());

