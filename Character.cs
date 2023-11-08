namespace testPA5
{
    public class Character
    {
        public string Name { get; set; }
        public int MaxPower { get; private set; }
        public int AttackStrength { get; set; }
        public int DefenseStrength { get; set; }
        public int Health { get; set; }
        private IAttack attackBehavior;

        public Character(string name, IAttack attackBehavior)
        {
            Name = name;
            MaxPower = new Random().Next(1, 101);
            Health = 100;
            ResetAttackAndDefense();
            this.attackBehavior = attackBehavior;
        }

        public void ResetAttackAndDefense() {
            AttackStrength = new Random().Next(1, MaxPower);
            DefenseStrength = new Random().Next(1, MaxPower);
        }

        public void SetAttackBehavior(IAttack attackBehavior)
        {
            this.attackBehavior = attackBehavior;
        }

        public void Attack(Character opponent)
        {
            int damage = attackBehavior.CalculateDamage(this, opponent);
            opponent.ReceiveDamage(damage);
            Console.WriteLine($"{Name} attacks {opponent.Name} causing {damage} damage.");
        }

        public void ReceiveDamage(int damage)
        {
            Health = Math.Max(Health - damage, 0);
            Console.WriteLine($"{Name} receives {damage} damage and now has {Health} health left.");
        }

        public void DisplayStats()
        {
            Console.WriteLine($"{Name}'s Stats - Health: {Health}, Attack: {AttackStrength}, Defense: {DefenseStrength}");
            System.Console.WriteLine("Press any key to return to the fight");
            Console.ReadKey();
        }
    }
}
