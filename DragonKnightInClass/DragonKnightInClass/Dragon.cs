namespace DragonKnightInClass
{
    public class Dragon : AttackingUnit
    {
        private string type;

        public int Hp { get => base.hp; set => base.hp = value; }
        public int Def { get => base.def; }
        public string Type { get => type; }

        public Dragon(int hp, int atk, int def, int crit, int multiplier = 1000, int dodge = 0) : base(hp, atk, def, crit, multiplier, dodge)
        {
            int val = r.Next(1, 5);
            switch (val)
            {
                case 1: type = "Fire Dragon";
                    break;
                case 2:
                    type = "Water Dragon";
                    break;
                case 3:
                    type = "Wind Dragon";
                    break;
                case 4:
                    type = "Earth Dragon";
                    break;
            }

        }
    }
}
