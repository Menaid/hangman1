string[] lines = { "banan", "bajskorv", "Hunden", "Kaka", "Bumbibjörn", "Gosig" };
var r = new Random();

Console.WriteLine("Vill du välja ord eller låta datorn välja åt dig?");
Console.WriteLine("Skriv Yes för att välja själv");

string useRandom = Console.ReadLine().ToLower();
int selected;


if (useRandom == "yes")
{
    selected = r.Next(0, lines.Length - 1);
}
else
{
    Console.WriteLine("Du har valt att välja själv");
    Console.WriteLine("Välj en siffra mellan 1-6 ");

    for (int i = 0; i < lines.Length; i++)
    {
        var lista = lines[i].ToLower();
        Console.WriteLine(i + 1 + ". längd på ordet är: " + new string('_', lista.Length));
    }

    string? input = string.Empty;
    while (!int.TryParse(input, out selected)) // loops until we input a number
    {
        // Console.WriteLine("Choose a number and not a letter ");
        input = Console.ReadLine(); // reads the input
    }
    selected--;
}

var word = lines[selected].ToLower();

var currentGuess = string.Empty;

while (currentGuess.Length < word.Length)
{

    currentGuess = currentGuess + "_";
}

var lives = 10;
var hasWon = false;

while (lives > 0 && !hasWon)
{
    Console.Clear();
    Console.WriteLine("Gissa vilket ord eller vilka bokstäver");
    Console.WriteLine();
    Console.WriteLine(currentGuess);
    Console.WriteLine("current lives: " + lives);
    Console.Write("Please enter a letter as a guess: ");
    var guess = Console.ReadLine().ToLower();
    var guessWasRight = false;

    if (guess == word)
    {
        hasWon = true;
        Console.WriteLine("You have won!");
        // om gissningen är samma som ordet så har vi vunnit (ändra så att while loopen avbryts genom att "hasWon" ska bli true.
        // annars går vi ner till "else" och kör loopen för att hitta bokstäver

    }
    else
    {
        for (int i = 0; i < word.Length; i++)
        {
            if (guess == word[i].ToString())
            {
                currentGuess = currentGuess.Remove(i, 1).Insert(i, guess);
                guessWasRight = true;
            }
        }
        if (!guessWasRight)
        {
            lives--;
            if (lives == 0)
            {
                Console.WriteLine("You have lost!");
            }
        }
        if (currentGuess == word)
        {
            hasWon = true; // om vi har börjat fylla på med bokstäver men sen gissar hela ordet så ska loopen avbrytas genom hasWon blir true
            Console.WriteLine(word);
            Console.WriteLine("You have won!");
        }

    }
}

Console.WriteLine("Press ENTER to exit");
Console.ReadKey();