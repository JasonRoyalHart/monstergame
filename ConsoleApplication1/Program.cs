using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterGame
{
    class Program
    {
        static int Add(int x, int y)
        {
            return x + y;
        }
        static void Main(string[] args)
        {
            bool alive = true;
            bool monster = false;
            bool quit = false;
            int health = 20;
            int damage = 5;
            int monsterhealth = 20;
            int monsterdamage = 3;
            int level = 1;
            int xp = 0;
            Random random = new Random();
            while (alive)
            {
                Console.WriteLine("Health {0}. Enter a command:", health);
                string command = Console.ReadLine();
                switch (command)
                {
                    case "l":
                        Console.WriteLine("There is a thick fog. You can't see anything.");
                        if (monster)
                        {
                            Console.WriteLine("You see a monster!");
                        }
                        break;
                    case "n":
                        Console.WriteLine("You move north.");
                        if (monster)
                        {
                            Console.WriteLine("The monster follows you!");
                        }
                        break;
                    case "e":
                        Console.WriteLine("You move east.");
                        if (monster)
                        {
                            Console.WriteLine("The monster follows you!");
                        }
                        break;
                    case "w":
                        Console.WriteLine("You move west.");
                        if (monster)
                        {
                            Console.WriteLine("The monster follows you!");
                        }
                        break;
                    case "s":
                        Console.WriteLine("You move south.");
                        if (monster)
                        {
                            Console.WriteLine("The monster follows you!");
                        }
                        break;
                    case "list":
                        Console.WriteLine("Available commands: n,e,w,s,l,hit,list,quit");
                        break;
                    case "hit":
                        if (monster)
                        {
                            int randomNumber = random.Next(0, 100);
                            if (randomNumber < 50)
                            {
                                Console.WriteLine("You slice the monster with your sword!");
                                Console.WriteLine("You do {0} damage.", damage);
                                monsterhealth -= damage;
                                if (monsterhealth < 1)
                                {
                                    Console.WriteLine("You have slain the monster!");
                                    xp += 10;
                                    Console.WriteLine("You gained 10 experience points.");
                                    if (xp >= (level*level) * 10)
                                    {
                                        level += 1;
                                        health = 10 + (level * 10);
                                        damage += 1;
                                        Console.WriteLine("You have gained enough experience to reach level {0}", level);
                                    }
                                    monster = false;
                                }
                            }
                            else
                            {
                                Console.WriteLine("You swing your sword at the monster, but miss.");
                            }
                        }
                        break;
                    case "quit":
                        Console.WriteLine("You quit.");
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Unrecognized command. Type 'list' for command list.");
                        break;
                }
                if (quit)
                {
                    break;
                }
                if (monster)
                {
                    int randomNumber = random.Next(0, 100);
                    if (randomNumber < 50)
                    {
                        Console.WriteLine("The monster bites you!");
                        health -= monsterdamage;
                        Console.WriteLine("You take {0} damage.", monsterdamage);
                        if (health < 1)
                        {
                            Console.WriteLine("You die.");
                            alive = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("The monster tries to bite you, but misses!");
                    }
                }
                if (!monster)
                {
                    int randomNumber = random.Next(0, 100);
                    if (randomNumber < 30)
                    {
                        Console.WriteLine("A monster has appeared!");
                        monster = true;
                        monsterhealth = 20;
                    }
                }
            }
            Console.WriteLine("You have died.");
        }
    }
}
