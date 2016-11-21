using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackToBasics.States;

namespace BackToBasics
{
    class Skill
    {        
        public static void Attack()
        {
            double atk = Math.Round(Program.player.strength * (.5 * Program.player.speed));
            Program.enemy.health -= Convert.ToInt32(atk);
            Console.WriteLine("You strike out for {0} damage.", atk);
            
                Combat.AttackEnd(Program.player);
            
        }
        //Kris skills
        public static void Hide()
        {
            States.Hidden playerHide = new States.Hidden();
        }
        public static int Backstab()
        {
            return 0;
        }
        public static void Envenom()
        {

        }
        public static int Trip()
        {
            return 0;
        }
        public static void PLACEHOLDER()
        {

        }

        //Gaven Skills
        public static void BattleCry()
        {
            //Random r = new Random();
            //int number = r.Next(2);
            //if (number = 1)
            //{
            //    while (Combat = true)
            //    {   
            //        Program.player.strength + 1
            //    }
            //}
        }
        public static int Cleave()
        {
            return 5;
        }
        public static int Parry()
        {
            return 1;
        }
        public static int Takedown()
        {
            return 0;
        }
        //public static void PLACEHOLDER()
        //{

        //}

        ////Jenna skills
        //public static void PLACEHOLDER()
        //{

        //}
        //public static void PLACEHOLDER()
        //{

        //}
        //public static void PLACEHOLDER()
        //{

        //}
        //public static void PLACEHOLDER()
        //{

        //}
        //public static void PLACEHOLDER()
        //{

        //}
       
    }
}
