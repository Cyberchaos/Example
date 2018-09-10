using System;

namespace DragonKnightInClass
{
    public class GameEngine{
        AttackingUnit[] units;
        private int dragonWins = 0;
        private int knightsWins = 0;

        public GameEngine()
        {
            units = new AttackingUnit[2];
            units[0] = new Knight(300, 80, 30, 33, 3, 90, "Steve");
            units[1] = new Dragon(1500, 120, 60, 25);
        }

        public int DragonWins { get => dragonWins;}
        public int KnightsWins { get => knightsWins;  }

        public void playGame()
        {
            int turnCounter = 1;
            bool playing = true;
            Random r = new Random();

            while (playing == true)
            {
               // Console.WriteLine("Turn " + turnCounter);

                int turn = r.Next(0, 2);

                if (turn == 0)
                {
                    //dragon start
                    if (DragonAttack() != true)
                    {
                        if (KnightAttack() == true)
                        {
                            playing = false;
                            Knight k = (Knight)units[0];
                            Dragon d = (Dragon)units[1];
                            //Console.WriteLine("The " + d.Type + " has fallen." + k.Name  + " the Knight has won this fight!");
                            knightsWins++;
                        }
                    }
                    else
                    {
                        playing = false;
                        Knight k = (Knight)units[0];
                        Dragon d = (Dragon)units[1];
                       // Console.WriteLine(k.Name + " The Knight has fallen. The " + d.Type + " has won this fight!");
                        dragonWins++;
                    }
                }
                else if (turn == 1)
                {
                    //knight start
                    if (KnightAttack() != true)
                    {
                        if (DragonAttack() == true)
                        {
                            playing = false;
                            Knight k = (Knight)units[0];
                            Dragon d = (Dragon)units[1];
                           // Console.WriteLine(k.Name + " The Knight has fallen. The " + d.Type + " has won this fight!");
                            dragonWins++;
                        }
                    }
                    else
                    {
                        playing = false;
                        Knight k = (Knight)units[0];
                        Dragon d = (Dragon)units[1];
                       // Console.WriteLine("The " + d.Type + " has fallen." + k.Name + " the Knight has won this fight!");
                        knightsWins++;
                    }
                }

                turnCounter++;
            }

            units[0] = new Knight(300, 80, 30, 33, 3, 90, "Steve");
            units[1] = new Dragon(1500, 120, 60, 25);

        }

        private bool DragonAttack()
        {
            units[1].Attack(units[0]);

            if (units[0].isDead())
                return true;
            else return false;
        }

        private bool KnightAttack()
        {
            units[0].Attack(units[1]);

            if (units[1].isDead())
                return true;
            else return false;
        }
    }
}
