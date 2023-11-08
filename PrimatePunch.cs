namespace testPA5
{
    public class PrimatePunch : IAttack
    {
        public int CalculateDamage(Character attacker, Character defender)
        {
            float typeBonus = defender is Mario ? 1.2f : 1.0f;
            int damage = (int)((attacker.AttackStrength - defender.DefenseStrength) * typeBonus);
            return Math.Max(damage, 0); 
        }
    }
}