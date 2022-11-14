while(true)
{
    Console.Clear();
    Console.WriteLine("Pick a day: ");
    var day = Console.ReadLine();
    Console.Clear();

    await (day switch
    {
        "1" => AdventOfCode.Day01.Main(),
        _ => Task.CompletedTask
    });

    Console.ReadLine();
}