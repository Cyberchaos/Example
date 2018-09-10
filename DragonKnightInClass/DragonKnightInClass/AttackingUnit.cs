using System;

namespace DragonKnightInClass
{
    public abstract class AttackingUnit {
        protected int hp;
        protected int atk;
        protected int def;
        protected int dodgeChance;
        protected int critChance;
        protected int critMultiplier;
        protected Random r;

        public AttackingUnit(int hp, int atk, int def, int crit, int multiplier, int dodge)
        {
            this.hp = hp;
            this.atk = atk;
            this.def = def;
            dodgeChance = dodge;
            critChance = crit;
            critMultiplier = multiplier;
            r = new Random();
        }

        public bool isDead() {
            if (hp <= 0)
            {
                return true;
            }
            else return false;
        }

        public bool Dodge()
        {
            int roll = r.Next(0, 101);
            if (roll < dodgeChance)
            {
                return true;
            }
            else return false;
        }

        protected int Crit()
        {
            int roll = r.Next(0, 101);
            if (roll < critChance)
            {
                return atk * critMultiplier;
            }
            else return atk;
        }

        protected int Damage(int atk, int enemyDef)
        {
             return atk - enemyDef;
        }

        public void Attack(AttackingUnit enemy)
        {
            Dragon dragon;
            Knight knight;

            string[] type = GetType().ToString().Split('.');
            string myType = type[type.Length - 1];
            string[] eType = enemy.GetType().ToString().Split('.');
            string enemyType = eType[eType.Length - 1];

            if (myType == "Dragon")
            {
                dragon = (Dragon)this;
                knight = (Knight)enemy;
            }
            else
            {
                knight = (Knight)this;
                dragon = (Dragon)enemy;
            }

            if (enemy.Dodge() != true)
            {
                int critDmg = Crit();
                int finalDmg = Damage(critDmg, enemy.def);
                enemy.hp -= finalDmg;
                if (enemy.hp < 0)
                {
                    enemy.hp = 0;
                }
                if (myType == "Dragon")
                {
                   // Console.WriteLine("The " + dragon.Type + " did " + finalDmg + " damage to " + knight.Name  + " the Knight. The Knight's HP is now " + enemy.hp + ".");
                }
                else
                {
                   // Console.WriteLine(knight.Name + " the Knight did " + finalDmg + " damage to the " + dragon.Type + ". The " + dragon.Type + "'s HP is now " + enemy.hp + ".");
                }

                
            }
            else
            {
                //Console output
                if (myType == "Dragon")
                {
                    //Console.WriteLine(knight.Name + " the Knight dodged!");
                }
                else
                {
                    //Console.WriteLine("The " + dragon.Type +" dodged!");
                }
            }
        }



        
    }
}
