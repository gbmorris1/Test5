using testPA5;

    int userChoice = GetUserChoice();
    while(userChoice!=3) {//condition check
        RouteEm(userChoice);
        userChoice = GetUserChoice();
    }
    Console.WriteLine("Thank you for playing!");
    //End Main
    static int GetUserChoice() {
        DisplayMenu();
        string userChoice=Console.ReadLine();
        if(IsValidChoice(userChoice)) {
            return int.Parse(userChoice);
        }
        else return 0;
    }
    
    static void DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine("Super Mario Battle Game");
        Console.WriteLine("1. Start New Game");
        System.Console.WriteLine("2. View Rules");
        System.Console.WriteLine("3. Exit");
    }

    static bool IsValidChoice(string userInput) {
        if(userInput=="1" || userInput=="2" || userInput=="3") {
            return true;
        }
        return false;
    }

    static void RouteEm(int menuChoice) {
        if(menuChoice==1) {
            StartGame();
        }
        else if(menuChoice==2) {
            ShowRules();
        }
        else{
            SayInvalid();
        }

        }
        static void SayInvalid() {
        System.Console.WriteLine("Invalid!");
        PauseAction();
        }
    static void PauseAction() {
        System.Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    static void StartGame()
    {
        System.Console.WriteLine("Player 1, enter your name:");
        string player1Name = Console.ReadLine();
        Console.Clear();
        Character player1 = ChooseCharacter(player1Name);
        
        Console.WriteLine("Player 2, enter your name:");
        string player2Name = Console.ReadLine();
        Console.Clear();
        Character player2 = ChooseCharacter(player2Name);

        Random rnd = new Random();
        bool isPlayer1Turn = rnd.Next(0, 2) == 0;

        // Game loop
        while (player1.Health > 0 && player2.Health > 0)
        {
            Console.Clear();
            Character activePlayer = isPlayer1Turn ? player1 : player2;
            Character opponent = isPlayer1Turn ? player2 : player1;

            Console.WriteLine($"{activePlayer.Name}'s Turn. Choose an action:");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. View Stats");
            Console.WriteLine("Enter the number of your choice:");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    activePlayer.ResetAttackAndDefense();
                    activePlayer.Attack(opponent);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    System.Console.WriteLine("Press any key to end turn");
                    Console.ResetColor();
                    Console.ReadKey();
                    break;
                case "2":
                    activePlayer.DisplayStats();
                    continue; 
                default:
                    Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                    continue; 
            }

            if (opponent.Health <= 0)
            {
                Console.WriteLine($"{opponent.Name} has been defeated! {activePlayer.Name} wins!");
                break;
            }

            isPlayer1Turn = !isPlayer1Turn;
        }
    }

    static Character ChooseCharacter(string playerName) {
        System.Console.WriteLine($"{playerName}, choose your character:" );
        System.Console.WriteLine("1. Mario");
        System.Console.WriteLine("2. Donkey Kong");
        System.Console.WriteLine("3. Bowser");
        while (true)
        {
            string choice = Console.ReadLine();
            Character character = null;
            switch (choice)
            {
                case "1":
                    character = new Mario(playerName);
                    break;
                case "2":
                    character = new DonkeyKong(playerName);
                    break;
                case "3":
                    character = new Bowser(playerName);
                    break;
                default:
                    Console.WriteLine("Invalid selection. Please choose 1, 2, or 3.");
                    break;
            }
            DisplayCharacter(character);
            return character;
        }
    }
    static void DisplayCharacter(Character character) {
        Console.ForegroundColor = ConsoleColor.Cyan;
        System.Console.WriteLine($"[{character.Name}]");
        Console.ResetColor();
    }
    

static void ShowRules() {
    Console.Clear();
    Console.WriteLine("=== Super Mario Battle Game Rules ===\n");
    Console.WriteLine("1. Each player chooses a character from the Mario universe.");
    Console.WriteLine("2. Characters take turns attacking each other.");
    Console.WriteLine("3. On your turn, choose to either Attack or View Stats.");
    Console.WriteLine("4. Viewing your stats does not consume your turn.");
    Console.WriteLine("5. Each attack's strength is determined randomly, up to your character's Max Power.");
    Console.WriteLine("6. Each defense's effectiveness is also determined randomly each turn.");
    Console.WriteLine("7. Characters have type advantages that may affect the attack's strength:");
    Console.WriteLine("   - Mario has an advantage over Bowser.");
    Console.WriteLine("   - Donkey Kong has an advantage over Mario.");
    Console.WriteLine("   - Bowser has an advantage over Donkey Kong.");
    Console.WriteLine("8. The battle continues until one character's health drops to zero.");
    Console.WriteLine("9. The first player to reduce their opponent's health to zero wins the game.");
    Console.WriteLine("\nPress any key to return to the main menu...");
    Console.ReadKey();
}
