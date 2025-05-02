namespace Characteristics
{
    public struct CharacteristicsModifier
    {
        public float Increment;
        public float Multiplier;

        public CharacteristicsModifier(float increment = 0, float multiplier = 1)
        {
            Increment = increment;
            Multiplier = multiplier;
        }

        public static CharacteristicsModifier operator +(CharacteristicsModifier a, CharacteristicsModifier b) 
        {
            return new CharacteristicsModifier(a.Increment + b.Increment, a.Multiplier + b.Multiplier);
        }

        public static CharacteristicsModifier operator -(CharacteristicsModifier a, CharacteristicsModifier b) 
        {
            return new CharacteristicsModifier(a.Increment - b.Increment, a.Multiplier - b.Multiplier);
        }
    }
}