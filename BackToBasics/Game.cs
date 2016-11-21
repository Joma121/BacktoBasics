using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;

namespace BackToBasics
{
    class Game
    {
        public static System.Timers.Timer tick;
        private static int tickCounter { get; set; }
        public static Dictionary<string, string> CurrentCommands = new Dictionary<string,string>();
        static bool _inBattle;
        public static bool InBattle 
        { 
            get 
            { 
                return _inBattle; 
            } 
            set 
            {
                _inBattle = value;
                UpdateCommands(); 
            } 
        }

        public static void Init()
        {
            InitWorldTime();
            UpdateCommands();
        }

        public static void InitWorldTime()
        {
            tick = new System.Timers.Timer(10000);
            tick.Elapsed += tick_Elapsed;
            tick.AutoReset = true;
            tick.Enabled = true;
        }

        static void tick_Elapsed(object sender, ElapsedEventArgs e)
        {
            tickCounter++;
            HealTime();
            stateUpdate();
            //throw new NotImplementedException();
            Console.Write("\n\nYou feel time pass by");
            Prompt.DisplayPrompt();
        }

        private static void stateUpdate()
        {
            //Program.player.stateUpdate();
            //Program.enemy.stateUpdate();
            //throw new NotImplementedException();
        }

        private static void HealTime()
        {
            if (tickCounter % 10 == 0)
            {
                Player.IncreaseHp(1);
            }
            if (tickCounter % 5 == 0)
            {
                Player.IncreaseSp(1);
            }
        }

        private static void UpdateCommands()
        {
            Game.CurrentCommands.Clear();
            if (Game.InBattle)
            {
                Game.CurrentCommands.Add("a", "attack");
                Game.CurrentCommands.Add("atk", "attack");
                Game.CurrentCommands.Add("attack", "attack");

                if (Program.player.character == "Jenna")
                {// Jenna battle skills
                     //Game.CurrentCommands.Add();
                }
                if (Program.player.character == "Kris")
                {// Kris battle skills
                    for (int i = 0; i < Program.player.battleSkills.Length; i++)
                    {
                        Game.CurrentCommands.Add(Program.player.battleSkills[i], "skill");

                    }
                }
                if (Program.player.character == "Gaven")
                {//Gaven battle skills
                    Game.CurrentCommands.Add("bc", "skill");
                    Game.CurrentCommands.Add("battlecry", "skill");
                    Game.CurrentCommands.Add("cl", "skill");
                    Game.CurrentCommands.Add("cleave", "skill");
                    Game.CurrentCommands.Add("td", "skill");
                    Game.CurrentCommands.Add("takedown", "skill");
                }
            }
            else
            {
                Game.CurrentCommands.Add("test", "cmd");
                Game.CurrentCommands.Add("go", "cmd");
                Game.CurrentCommands.Add("rep", "cmd");
                Game.CurrentCommands.Add("report", "cmd");

                if (Program.player.character == "Jenna")
                {// Jenna non battle skills
                    //Game.CurrentCommands.Add();
                }
                if (Program.player.character == "Kris")
                {// Kris non battle skills
                    for (int i = 0; i < Program.player.nonBattleSkills.Length; i++)
                    {
                        Game.CurrentCommands.Add(Program.player.nonBattleSkills[i], "skill");

                    }
                    Game.CurrentCommands.Add("stealth", "skill");
                    Game.CurrentCommands.Add("bs", "skill");
                    Game.CurrentCommands.Add("backstab", "skill");
                    Game.CurrentCommands.Add("en", "skill");
                    Game.CurrentCommands.Add("envenom", "skill");
                }
                if (Program.player.character == "Gaven")
                {//Gaven non battle skills
                    //Game.CurrentCommands.Add();
                }
            }
        }
       
        public static void Move()
        {

        }

        

    }
}
