namespace testPA5
{
    public class FireFlower : IAttack
    {
        public int CalculateDamage(Character attacker, Character defender)
            {
                float typeBonus = defender is Bowser ? 1.2f : 1.0f;
                int damage = (int)((attacker.AttackStrength - defender.DefenseStrength) * typeBonus);
                return Math.Max(damage, 0); 
            }
    }
}