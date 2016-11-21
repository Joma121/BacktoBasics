using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edokan.KaiZen.Colors;

namespace BackToBasics
{
    class Player
    {
        public int strength { get; set; }
        public int intelligence { get; set; }
        public int speed { get; set; }
        public string character { get; set; }
        public int experience { get; set; }
        public int[] toNextLevel = new int[5] { 0, 25, 50, 100, 200 };
        public int level { get; set; }
        public string[] battleSkills { get; set; }
        public string[] nonBattleSkills { get; set; }
        public bool inBattle { get; set; }
        private string art { get; set; }
        //private string skillType { get; set; }
        public Dictionary<string, int> States {get;set;}


        public int maxHp 
        { 
            get 
            { 
                return 2 * strength;
            }
        }
        public int maxSp
        {
            get
            {
                if (character == "Jenna")
                {
                    return 2 * intelligence;
                }
                else
                {
                    return strength + speed;
                }
            }
        }
        public int health { get; set; }
        public int skillPoints { get; set; }

        public static void IncreaseHp(int num)
        {
            Program.player.health += num;
            if (Program.player.health >= Program.player.maxHp)
            {
                Program.player.health = Program.player.maxHp;
            }
        }

        public static void IncreaseSp(int num)
        {
            Program.player.health += num;
            if (Program.player.skillPoints >= Program.player.maxSp)
            {
                Program.player.skillPoints = Program.player.maxSp;
            }
        }

        public static void CheckLevelUp(int level, int exp)
        {
            if (level == 5)
            {
                Program.End();
            }
            if (exp >= Program.player.toNextLevel[level])
            {
                if (Program.player.character == "Jenna")
                {
                    if (IsOdd(level))
                    {

                        Program.player.strength++;
                        Program.player.intelligence += 2;
                        Program.player.speed++;
                        Program.player.level++;
                    }
                    else
                    {
                        Program.player.strength++;
                        Program.player.intelligence += 2;
                        Program.player.speed += 2;
                        Program.player.level++;
                    }
                }
                else if (Program.player.character == "Gaven")
                {
                    if (IsOdd(level))
                    {

                        Program.player.strength += 2;
                        Program.player.intelligence++;
                        Program.player.speed++;
                        Program.player.level++;
                    }
                    else
                    {
                        Program.player.strength += 2;
                        Program.player.intelligence++;
                        Program.player.speed += 2;
                        Program.player.level++;
                    }
                }
                else
                {
                    if (IsOdd(level))
                    {

                        Program.player.strength++;
                        Program.player.intelligence++;
                        Program.player.speed += 2;
                        Program.player.level++;
                    }
                    else
                    {
                        Program.player.strength += 2;
                        Program.player.intelligence++;
                        Program.player.speed += 2;
                        Program.player.level++;
                    }
                }
            }
        }
        public static void Death()
        {
            Combat.StopTimer();
            Console.WriteLine(@"
       ██               ██
     ████▄   ▄▄▄▄▄▄▄   ▄████
        ▀▀█▄█████████▄█▀▀
          █████████████ 
          ██▀▀▀███▀▀▀██
          ██   ███   ██
          █████▀▄▀█████
           ███████████
       ▄▄▄██  █▀█▀█  ██▄▄▄
       ▀▀██           ██▀▀
         ▀▀           ▀▀
  ▄████  ▄▄▄       ███▄ ▄███▓▓█████ 
 ██▒ ▀█▒▒████▄    ▓██▒▀█▀ ██▒▓█   ▀ 
▒██░▄▄▄░▒██  ▀█▄  ▓██    ▓██░▒███   
░▓█  ██▓░██▄▄▄▄██ ▒██    ▒██ ▒▓█  ▄ 
░▒▓███▀▒ ▓█   ▓██▒▒██▒   ░██▒░▒████▒
 ░▒   ▒  ▒▒   ▓▒█░░ ▒░   ░  ░░░ ▒░ ░
  ░   ░   ▒   ▒▒ ░░  ░      ░ ░ ░  ░
░ ░   ░   ░   ▒   ░      ░      ░   
      ░       ░  ░       ░      ░  ░
 ▒█████   ██▒   █▓▓█████  ██▀███    
▒██▒  ██▒▓██░   █▒▓█   ▀ ▓██ ▒ ██▒  
▒██░  ██▒ ▓██  █▒░▒███   ▓██ ░▄█ ▒  
▒██   ██░  ▒██ █░░▒▓█  ▄ ▒██▀▀█▄    
░ ████▓▒░   ▒▀█░  ░▒████▒░██▓ ▒██▒  
░ ▒░▒░▒░    ░ ▐░  ░░ ▒░ ░░ ▒▓ ░▒▓░  
  ░ ▒ ▒░    ░ ░░   ░ ░  ░  ░▒ ░ ▒░  
░ ░ ░ ▒       ░░     ░     ░░   ░   
    ░ ░        ░     ░  ░   ░       
              ░                     
".Red());
            Console.ReadLine();
            Program.End();
        }

        public static bool IsOdd(int value)
        {
            return value % 2 != 0;
        }

    }
}
