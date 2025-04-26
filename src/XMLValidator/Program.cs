using XMLValidator;

if (args.Length == 0)
{
    Console.WriteLine("Please, provide input string as argument.");
    return;
}

if (args.Length > 1)
{
    Console.WriteLine("Please, provide only one argument.");
    return;
}

var xml = args[0];

if (xml.IsXML())
    Console.WriteLine("Valid");
else
    Console.WriteLine("Invalid");