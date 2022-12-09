while(true)
{
    Console.Clear();
    Console.Write("Pick a day: ");
    var day = Console.ReadLine();
    Console.Clear();

    await (day switch
    {
        "1" => AdventOfCode.Day01.Program.Main(),
        "2" => AdventOfCode.Day02.Program.Main(),
        "3" => AdventOfCode.Day03.Program.Main(),
        "4" => AdventOfCode.Day04.Program.Main(),
        "5" => AdventOfCode.Day05.Program.Main(),
        "6" => AdventOfCode.Day06.Program.Main(),
        "7" => AdventOfCode.Day07.Program.Main(),
        _ => Task.CompletedTask
    });

    Console.ReadLine();
}