namespace DragonKnightInClass
{
    public class Knight: AttackingUnit
    {

        private string name;
        public int Hp { get => base.hp; set => base.hp = value; }
        public int Def { get => base.def; }
        public string Name { get => name; }

        public Knight(int hp, int atk, int def, int crit, int multiplier, int dodge, string name) : base(hp, atk, def, crit, multiplier, dodge)
        {
            this.name = name;
        }
    }
}
