namespace S03_classes;

public class Character
{
    public string Name;
    public int HealthPoints;
    public int AttackStrength;
    public int DefenseStrength;

    public bool IsAlive()
    {
        return HealthPoints > 0;
    }

    public void Attack(Character otherCharacter)
    {
        int damage = Math.Max(0, AttackStrength - otherCharacter.DefenseStrength);
        otherCharacter.HealthPoints -= damage;
        Console.WriteLine($"{Name} attaque {otherCharacter.Name} et inflige {damage} points de perte .");
    }
}

class Program
{
    
    static void Main(string[] args)
    {
        Character playerOne = new Character
        {
            Name = "Player One",
            HealthPoints = 30,
            AttackStrength = 5,
            DefenseStrength = 5
        };

        Character playerTwo = new Character
        {
            Name = "Player Two",
            HealthPoints = 30,
            AttackStrength = 6,
            DefenseStrength = 4
        };

        while (playerOne.IsAlive() && playerTwo.IsAlive())
        {
            playerOne.Attack(playerTwo);
            if (playerTwo.IsAlive())
                playerTwo.Attack(playerOne);
        }

        Character winner; 
        if (playerOne.IsAlive())
        winner = playerOne;
        else
        winner = playerTwo;

        Console.WriteLine($"{winner.Name} a gagné!");
    }
}
