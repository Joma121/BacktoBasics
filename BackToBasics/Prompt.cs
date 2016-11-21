using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
//using DocumentFormat.OpenXml.Packaging;
//using DocumentFormat.OpenXml.Spreadsheet;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Edokan.KaiZen.Colors;

namespace BackToBasics
{
    class Prompt
    {
        //public delegate PlayerPrompt();
        public static void Introduction()
        {
            Console.WriteLine("Hello! \n Welcome back to basics!");
            Console.WriteLine("");
            Console.WriteLine("");
            bool unchosen = true;
            do
            {
                Console.WriteLine("Gaven The Warrior, Kris The Rogue, Jenna The Sorcerer ");
                Console.Write("Please, Choose a Character:");
                string charChoice = Console.ReadLine();

                string gavenCheck = @"^g(aven|ave|av|a)?$";
                string krisCheck = @"^k(ris|ri|r)?$";
                string jennaCheck = @"^j(enna|enn|en|e)?$";

                if (charChoice == "edomdog")
                {
                    unchosen = false;
                    Program.player.character = "Odin";
                    Program.player.strength = 9999;
                    Program.player.intelligence = 9999;
                    Program.player.speed = 9999;
                    Program.player.experience = 9999;
                    Program.player.level = 1;
                    Program.player.health = Program.player.maxHp;
                    Program.player.skillPoints = Program.player.maxSp;
                    Program.player.battleSkills = new string[7] { "Quickdraw", "Cleave", "Parry", "Dualstrike", "Thrust", "Hide", "Trip" };
                }
                else if (Regex.IsMatch(charChoice, gavenCheck, RegexOptions.IgnoreCase))
                {
                    unchosen = false;
                    Program.player.character = "Gaven";
                    Program.player.strength = 3;
                    Program.player.intelligence = 1;
                    Program.player.speed = 2;
                    Program.player.experience = 0;
                    Program.player.level = 1;
                    Program.player.health = Program.player.maxHp;
                    Program.player.skillPoints = Program.player.maxSp;
                    Program.player.battleSkills = new string[5] { "quickdraw", "Cleave", "Parry", "Dualstrike", "Thrust" };
                }
                else if (Regex.IsMatch(charChoice, krisCheck, RegexOptions.IgnoreCase))
                {
                    unchosen = false;
                    Program.player.character = "Kris";
                    Program.player.strength = 2;
                    Program.player.intelligence = 1;
                    Program.player.speed = 3;
                    Program.player.experience = 0;
                    Program.player.level = 1;
                    Program.player.health = Program.player.maxHp;
                    Program.player.skillPoints = Program.player.maxSp;
                    Program.player.battleSkills = new string[2] { "hide", "trip" };
                    Program.player.nonBattleSkills = new string[1] { "hide" };
                }
                else if (Regex.IsMatch(charChoice, jennaCheck, RegexOptions.IgnoreCase))
                {
                    unchosen = false;
                    Program.player.character = "Jenna";
                    Program.player.strength = 1;
                    Program.player.intelligence = 3;
                    Program.player.speed = 2;
                    Program.player.experience = 0;
                    Program.player.level = 1;
                    Program.player.health = Program.player.maxHp;
                    Program.player.skillPoints = Program.player.maxSp;
                    Program.player.battleSkills = new string[5] { "Shield", "Firebolt", "Frost Ray", "Invisible", "Death" };
                }
                else
                {
                    Console.WriteLine("That is not a valid choice, please try again");
                    unchosen = true;
                }
            } while (unchosen);
        }
        public static void CommandHandler(string input)
        {
            input = input.ToLower();
            string value;
            if(Game.CurrentCommands.TryGetValue(input, out value))
            {
                    switch (value)
                    {
                        case "attack":
                            Skill.Attack();
                            break;
                        case "cmd":
                            Commands(input);
                            break;
                        case "skill":
                            SkillCmds(input);
                            break;
                        default:
                            Invalid();
                            break;
                    }
                }
            
            DisplayPrompt();
                //if (Game.InBattle)
                //{
                //    CommandInBattle(input);

                //}
                //else
                //{
                //    CommandOutOfBattle(input);
                //}
        }

        private static void Invalid()
        {
            Console.WriteLine("That is not a valid command");
        }

        private static void Commands(string input)
        {
            switch(input){
                case "go":
                    NextScene();
                    break;
                case "rep":
                case "report":
                    ReportCard();
                    break;
                case "test":
                    Test();
                    break;
                default:
                    break;
            }
        }

        private static void SkillCmds(string input)
        {
            switch (input)
            {
                case "hide":
                    Skill.Hide();
                    break;
                //case "rep":
                //case "report":
                //    ReportCard();
                //    break;
                //case "test":
                //    Test();
                //    break;
                default:
                    break;
            }
        }
        //private static void CommandInBattle(string input)
        //{
        //    if (Program.player.character == "Jenna")
        //    {// Jenna battle skills
        //        switch (input)
        //        {
        //            default:
        //                break;
        //        }
        //    }
        //    else if (Program.player.character == "Kris")
        //    {// Kris battle skills
        //        switch (input)
        //        {
        //            case "trip":
        //                if (Program.player.level >= 4)
        //                {
        //                    Skill.Trip();
        //                }
        //                else
        //                {
        //                    Console.WriteLine("You don't know that skill.");
        //                }
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    else
        //    {// Gaven battle skills
        //        switch (input)
        //        {
        //            case "bc":
        //            case "battlecry":
        //            case "battle cry":
        //                Console.WriteLine("You shout at the enemy with murderous intent!");
        //                Skill.BattleCry();
        //                break;
        //            case "cl":
        //            case "cleave":
        //                if (Program.player.level >= 2)
        //                {
        //                    Skill.Cleave();
        //                }
        //                else
        //                {
        //                    Console.WriteLine("You don't know that skill.");
        //                }
        //                break;
        //            case "td":
        //            case "takedown":
        //                if (Program.player.level >= 4)
        //                {
        //                    Skill.Takedown();
        //                }
        //                else
        //                {
        //                    Console.WriteLine("You don't know that skill.");
        //                }
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    switch (input)
        //    {
        //        case "a":
        //        case "atk":
        //        case "attack":
        //            Combat.Attack(Program.player);
        //            break;
        //        case "":
        //            break;
        //        default:
        //            Console.WriteLine("That is not a valid command");
        //            break;
        //    }
        //    Prompt.DisplayPrompt();
        //}

        //private static void CommandOutOfBattle(string input)
        //{
        //    if (Program.player.character == "Jenna")
        //    {// Jenna out of battle skills
        //        switch (input)
        //        {
        //            default:
        //                break;
        //        }
        //    }
        //    else if (Program.player.character == "Kris")
        //    {// Kris out of battle skills
        //        switch (input)
        //        {
        //            case "stealth":
        //                break;
        //            case "bs":
        //            case "backstab":
        //                if (Program.player.level >= 2)
        //                {
        //                    //run check on presence of enemy
        //                }
        //                else
        //                {
        //                    Console.WriteLine("You don't know that skill.");
        //                }
        //                break;
        //            case "en":
        //            case "envenom":
        //                if (Program.player.level >= 3)
        //                {
        //                    Console.WriteLine("You cover your blade with poison.");
        //                    //Set envenomed flag to player
        //                }
        //                else
        //                {
        //                    Console.WriteLine("You don't know that skill.");
        //                }
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    else
        //    {// Gaven out of battle skills
        //        switch (input)
        //        {
        //            default:
        //                break;
        //        }
        //    }
        //    switch (input)
        //    {// Out of Battle, non skill commands
        //        case "test":
        //            Test();
        //            break;
        //        case "go":
        //            NextScene();
        //            break;
        //        case "report":
        //        case "rep":
        //            ReportCard();
        //            break;
        //        case "":
        //            break;
        //        default:
        //            Console.WriteLine("That is not a valid command");
        //            break;
        //    }
        //    DisplayPrompt();
        //}

        private static void Test()
        {
            StreamReader sr = new StreamReader("Test.txt");
            String line2 = sr.ReadLine();
            string art = "";
            string skillPoints = "";
            Console.Write("yolo", Program.player.character, Program.player.level, Program.player.experience, Program.player.toNextLevel[Program.player.level], Program.player.strength, Program.player.intelligence, Program.player.speed, Program.player.health, Program.player.maxHp, skillPoints, Program.player.skillPoints, Program.player.maxSp, art);

        }

        public static void EnemyHealth()
        {
            string healthMeter = "";
            int healthMinus;
            if (Game.InBattle)
            {
                for (int i = 0; i < Program.enemy.health; i++)
                {
                    healthMeter += "█".Red();
                }
                healthMinus = Program.enemy.maxHp - Program.enemy.health;
                for (int i = 0; i < healthMinus; i++)
                {
                    healthMeter += "█".Black().Bold();
                }
                Console.Write("\n[{0}]  {1}", healthMeter, Program.enemy.name);
            }
        }

        public static void DisplayPrompt()
        {
            EnemyHealth();
            PlayerPrompt();
            string command = Console.ReadLine();
            CommandHandler(command);
            
        }

        private static void PlayerPrompt(){
            if (Program.player.character == "Jenna")
                {
                    Console.Write("\n[Level: " + "{0}".Yellow().Bold() + " | " + "{1}".Red().Bold() + "/" + "{3}".Red() + "hp " + "{2}".Green().Bold() + "/" + "{4}".Green() + "mp => ", Program.player.level, Program.player.health, Program.player.skillPoints, Program.player.maxHp, Program.player.maxSp);
                }
                else
                {
                    Console.Write("\n[Level: " + "{0}".Yellow().Bold() + " | " + "{1}".Red().Bold() + "/" + "{3}".Red() + "hp " + "{2}".Green().Bold() + "/" + "{4}".Green() + "ap => ", Program.player.level, Program.player.health, Program.player.skillPoints, Program.player.maxHp, Program.player.maxSp);
                }
        }

        private static void ReportCard()
        {
            string art = "";
            string skillPoints = "";
            switch (Program.player.character)
            {
                case "Jenna":
                    art = "[==========+++++======+++++=====:<* ";
                    skillPoints = "Magic Points:  ";
                    break;
                case "Gaven":
                    art = "()======[{:::::::::::::::::::::::>";
                    skillPoints = "Action Points: ";
                    break;
                case "Kris":
                    art = "()===[;;;::::::>  <::::::;;;]===()";
                    skillPoints = "Action Points: ";
                    break;
                default:
                    break;
            }
            Console.Write(
"               -=<(" + "{0}".Yellow() + ")>=-\n" +
"    +---------------------------------\n" +
"    |" + "Level:         ".Grey() + "{1}     \n" +
"    |" + "Experience:    ".Grey() + "{2}".Blue().Bold() + "/".Grey() + "{3}\n".Blue() +
"    |\n" +
"    |" + "Health:        ".Grey() + "{7}".Red().Bold() + "/".Grey() + "{8}\n".Red() +
"    |" + "{9}".Grey() + "{10}".Green().Bold() + "/".Grey() + "{11}\n".Green() +
"    |\n" +
"    |" + "Strength:      ".Grey() + "{4}\n" +
"    |" + "Intelligence:  ".Grey() + "{5}\n" +
"    |".White() + "Speed:         ".Grey() + "{6}\n" +
"    {12} \n"
, Program.player.character, Program.player.level, Program.player.experience, Program.player.toNextLevel[Program.player.level], Program.player.strength, Program.player.intelligence, Program.player.speed, Program.player.health, Program.player.maxHp, skillPoints, Program.player.skillPoints, Program.player.maxSp, art);

        }

        public static void NextScene()
        {
            Enemy enemy = Enemy.RandomEnemy();
            Program.enemy = enemy;
            Console.WriteLine("A devilish look is on {0}'s face as it glares at you. \nReady for combat? I hope so.", enemy.name);
            Combat.StartCombat();

        }
    }
}
