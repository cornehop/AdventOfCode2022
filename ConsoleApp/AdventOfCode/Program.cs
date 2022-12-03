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
        _ => Task.CompletedTask
    });

    Console.ReadLine();
}