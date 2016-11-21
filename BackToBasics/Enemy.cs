using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Xml.Serialization;
using System.IO;

namespace BackToBasics
{
    class Enemy
    {
        private static int idCount;
        public int id { get; private set; }
        public string name { get; private set; }
        public int strength { get; set; }
        public int intelligence { get; set; }
        public int speed { get; set; }
        public string type { get; private set; }
        public int level { get; set; }
        public string[] skills { get; set; }
        //public bool inBattle { get; set; }
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
                if (type == "magic")
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

        private static List<Enemy> enemiesLevel1 = new List<Enemy>();
        private static List<Enemy> enemiesLevel2 = new List<Enemy>();
        private static List<Enemy> enemiesLevel3 = new List<Enemy>();
        private static List<Enemy> enemiesLevel4 = new List<Enemy>();
        private static List<Enemy> enemiesBoss = new List<Enemy>();


        public static void SheetConnection()
        {
            var fileName = string.Format("{0}\\Monsters.xls", Directory.GetCurrentDirectory());
            OleDbConnection monsterlink;
            monsterlink = new OleDbConnection(string.Format("Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties='Excel 8.0;HDR=Yes;';", fileName));
            monsterlink.Open();

            DataTable dt = monsterlink.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            if (dt == null || dt.Rows.Count == 0) return;

            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string sheet = dt.Rows[i]["TABLE_NAME"].ToString();

                switch (sheet)
                {
                    case "Level1":
                        break;
                    default:
                        break;
                }
            }
            monsterlink.Close();
                
                //WORKS dunno how to get table list
            //var fileName = string.Format("{0}\\Monsters.xls", Directory.GetCurrentDirectory());
            //var connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties='Excel 8.0;HDR=Yes;';", fileName);

            //using (OleDbConnection conn = new OleDbConnection(connectionString))
            //{
            //    conn.Open();
            //    var table = "Level 1";
            //    OleDbCommand command = new OleDbCommand("select * from [" + table + "$]", conn);
            //    using (OleDbDataReader dr = command.ExecuteReader())
            //    {
                    
            //        while (dr.Read())
            //        {
            //            try
            //            {
                            
            //            string ename = dr[0].ToString();
            //            string etype = dr[1].ToString();
            //            int estrength = Convert.ToInt32(dr[2]);
            //            int eintelligence = Convert.ToInt32(dr[3]);
            //            int espeed = Convert.ToInt32(dr[4]);
            //            Console.WriteLine("{0} {1} {2} {3} {4}", ename, etype, estrength, eintelligence, espeed); ;
            //            }
            //            catch (Exception)
            //            {
            //                break;
            //            }
            //        }
            //    }
            //}
        }

        public static void BuildLeveledLists()
        {
            enemiesLevel1.Add(new Enemy() { name = "Goblin", type = "physical", strength = 2, intelligence = 1, speed = 1, level = 1 });
            enemiesLevel1.Add(new Enemy() { name = "Kobold", type = "physical", strength = 2, intelligence = 1, speed = 2, level = 1 });
            enemiesLevel1.Add(new Enemy() { name = "Giant Rat", type = "physical", strength = 1, intelligence = 1, speed = 1, level = 1 });
            enemiesLevel1.Add(new Enemy() { name = "Carnivore Vine", type = "physical", strength = 1, intelligence = 1, speed = 1, level = 1 });

            enemiesLevel2.Add(new Enemy() { name = "Goblin", type = "physical", strength = 2, intelligence = 1, speed = 1, level = 2 });
            enemiesLevel2.Add(new Enemy() { name = "Kobold", type = "physical", strength = 2, intelligence = 1, speed = 2, level = 2 });
            enemiesLevel2.Add(new Enemy() { name = "Giant Rat", type = "physical", strength = 1, intelligence = 1, speed = 1, level = 2 });
            enemiesLevel2.Add(new Enemy() { name = "Carnivore Vine", type = "physical", strength = 1, intelligence = 1, speed = 1, level = 2 });
            enemiesLevel2.Add(new Enemy() { name = "Goblin Mage", type = "magic", strength = 1, intelligence = 2, speed = 1, level = 2 });
            enemiesLevel2.Add(new Enemy() { name = "Kobold Shaman", type = "magic", strength = 2, intelligence = 2, speed = 2, level = 2 });
            enemiesLevel2.Add(new Enemy() { name = "Ghost", type = "magic", strength = 1, intelligence = 3, speed = 1, level = 2 });

            enemiesLevel3.Add(new Enemy() { name = "Goblin Mage", type = "magic", strength = 1, intelligence = 2, speed = 1, level = 3 });
            enemiesLevel3.Add(new Enemy() { name = "Kobold Shaman", type = "magic", strength = 2, intelligence = 2, speed = 2, level = 3 });
            enemiesLevel3.Add(new Enemy() { name = "Ghost", type = "magic", strength = 1, intelligence = 3, speed = 1, level = 3 });
            enemiesLevel3.Add(new Enemy() { name = "Wolf", type = "physical", strength = 4, intelligence = 1, speed = 3, level = 3 });
            enemiesLevel3.Add(new Enemy() { name = "Spectre", type = "magic", strength = 1, intelligence = 4, speed = 3, level = 3 });
            enemiesLevel3.Add(new Enemy() { name = "Carnivore Vine", type = "physical", strength = 4, intelligence = 1, speed = 1, level = 3 });
            enemiesLevel3.Add(new Enemy() { name = "Goblin Warrior", type = "physical", strength = 5, intelligence = 1, speed = 3, level = 3 });

            enemiesLevel4.Add(new Enemy() { name = "Goblin Wizad", type = "magic", strength = 2, intelligence = 6, speed = 3, level = 4 });
            enemiesLevel4.Add(new Enemy() { name = "Shade", type = "magic", strength = 1, intelligence = 5, speed = 3, level = 4 });
            enemiesLevel4.Add(new Enemy() { name = "Wolf", type = "physical", strength = 4, intelligence = 1, speed = 3, level = 4 });
            enemiesLevel4.Add(new Enemy() { name = "Spectre", type = "magic", strength = 1, intelligence = 4, speed = 3, level = 4 });
            enemiesLevel4.Add(new Enemy() { name = "Goblin Warrior", type = "physical", strength = 5, intelligence = 1, speed = 3, level = 4 });
            enemiesLevel4.Add(new Enemy() { name = "Rogue Mage", type = "magic", strength = 3, intelligence = 7, speed = 5, level = 4 });
            enemiesLevel4.Add(new Enemy() { name = "Bandit", type = "physical", strength = 7, intelligence = 3, speed = 5, level = 4 });

        }
        public static Enemy RandomEnemy()
        {
            Random r = new Random();
            Enemy e = new Enemy();
            switch (Program.player.level)
            {
                case 1:
                    e = enemiesLevel1.ElementAtOrDefault(r.Next(enemiesLevel1.Count));
                    break;
                case 2:
                    e = enemiesLevel2.ElementAtOrDefault(r.Next(enemiesLevel1.Count));
                    break;
                case 3:
                    e = enemiesLevel3.ElementAtOrDefault(r.Next(enemiesLevel1.Count));
                    break;
                case 4:
                    e = enemiesLevel4.ElementAtOrDefault(r.Next(enemiesLevel1.Count));
                    break;
                case 5:
                    e = new Enemy() { name = "Basilisk", type = "magic", strength = 10, intelligence = 10, speed = 10, level = 5 };
                    break;
                default:
                    break;
            }
            int strMod;
            int intMod;
            if (e.type == "physical")
            {
                strMod = Program.player.level * 2;
                intMod = Program.player.level;
            }
            else
            {
                intMod = Program.player.level * 2;
                strMod = Program.player.level;
            }
            int spdMod = Program.player.level;

            e.id = getId();
            e.strength = e.strength + r.Next(strMod);
            e.speed = e.speed + r.Next(spdMod);
            e.intelligence = e.intelligence + r.Next(intMod);
            e.health = e.maxHp;
            e.skillPoints = e.maxSp;

            return e;
        }

        private static int getId()
        {
            idCount++;
            return idCount;
        }
        public static void Death()
        {
            Console.WriteLine("The {0} drops dead from it's wounds", Program.enemy.name);
            Program.enemy = null;
            int expGain;
            if (Program.player.character == "Jenna")
            {
                expGain = 4 * Program.player.level;
                expGain += Program.player.intelligence;
            }
            else if (Program.player.character == "Kris")
            {
                expGain = 4 * Program.player.level;
                expGain += Program.player.speed;
            }
            else
            {
                expGain = 4 * Program.player.level;
                expGain += Program.player.strength;
            }
            Program.player.experience += expGain;
            Console.WriteLine("You gain {0} experience from the fight",expGain);
            Player.CheckLevelUp(Program.player.level, Program.player.experience);
        }
    }
}
