namespace Stats
{
    public class StatsBuff : IBuff
    {
        private StatType _type;
        private float _value;
        private BuffData _data;
        private float _elapsed;

        public BuffData BuffData => _data;
        public float Elapsed { get => _elapsed; set => _elapsed = value; }
        public StatType Type => _type;
        public float Value => _value;

        public StatsBuff(StatType type, float value, BuffData data)
        {
            _type = type;
            _value = value;
            _data = data;
        }
    }
}