using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;

namespace BackToBasics
{
    class Combat
    {

        private static System.Timers.Timer attackTimer;
        public static int CounterToken = 1;

        public static void StartCombat()
        {
            Game.InBattle = true;
            attackTimer = new System.Timers.Timer(10000);
            attackTimer.Elapsed += new System.Timers.ElapsedEventHandler(TimerEvent);
            attackTimer.AutoReset = true;
            attackTimer.Enabled = true;
        }

        public static void AttackEnd(object role)
        {
            if (role == Program.player)
            {
                if (Combat.CheckDeath(Program.enemy.health))
                {
                    Enemy.Death();
                }
                else
                {
                    EnemyAttack();
                    attackTimer.Stop();
                    attackTimer.Close();
                    attackTimer.Start();
                }
            }
            
            
        }
        private static void TimerEvent(object source, ElapsedEventArgs e)
        {
            EnemyAttack();
        }
        private static void EnemyAttack()
        {
            if (Game.InBattle)
            {
                double atk = Math.Round(Program.enemy.strength * (.5 * Program.enemy.speed));
                Program.player.health -= Convert.ToInt32(atk);
                Console.WriteLine("{1} strikes out for {0} damage.", atk, Program.enemy.name);
                //Console.WriteLine("{0}", Program.player.health);
                if (CheckDeath(Program.player.health))
                {
                    Player.Death();
                }
            }
        }
        public static bool CheckDeath(int health)
        {
            if (health <= 0)
            {
                Game.InBattle = false;
                StopTimer();
                return true;
            }
            else
            {
                return false;
            }
        }


        internal static void StopTimer()
        {
            attackTimer.Stop();
            attackTimer.Dispose();
        }
    }
}
