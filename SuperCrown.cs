namespace testPA5
{
    public class SuperCrown : IAttack
    {
        public int CalculateDamage(Character attacker, Character defender)
            {
                float typeBonus = defender is DonkeyKong ? 1.2f : 1.0f;
                int damage = (int)((attacker.AttackStrength - defender.DefenseStrength) * typeBonus);
                return Math.Max(damage, 0); 
            }
    }
}