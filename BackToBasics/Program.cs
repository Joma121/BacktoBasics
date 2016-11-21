using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BackToBasics
{

    class Program
    {
        public static Player player = new Player();
        public static Enemy enemy = new Enemy();

        static void Main()
        {
            Edokan.KaiZen.Colors.EscapeSequencer.Install();
            Console.WindowHeight = 40;
            Prompt.Introduction();
            Enemy.BuildLeveledLists();
            Game.Init();

            Console.WriteLine("-<To continue your adventure to the next scene enter \"go\">-");
            //Console.WriteLine("-<To return to previous scene enter \"back\">-");
            Console.WriteLine("-<You can assess your character by entering \"report\" or \"rep\">-");
            Console.WriteLine("\nYou awaken from your nap. A myriad of leaves sways gently above you. \nAn old dirt road is to your left and you're surrounded by trees otherwise.");
            Console.WriteLine("There is a scuffling sound to the north, \"go\" to investigate.\n\n");
            Prompt.DisplayPrompt();

           // Enemy currentEnemy = Enemy.RandomEnemy();
           // Console.WriteLine("The {0} looks up from its small kill, a toothy grin as its greating.", currentEnemy.name);
           // Prompt.DisplayPrompt();

            //command = Console.ReadLine();
            //Prompt.CommandHandler(command);
            //Prompt.DisplayPrompt();
           // Console.ReadLine();
        }
        public static void End()
        {
            Console.WriteLine("Do you wish to try again?");
            string restart = Console.ReadLine();
            switch (restart)
            {
                case "y":
                case "yes":
                    Main();
                    player = null;
                    enemy = null;
                    break;
                default:
                    Environment.Exit(1);
                    break;
            }
        }
        
    }
}