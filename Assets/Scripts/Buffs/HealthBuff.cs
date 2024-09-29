namespace Stats
{
    public class HealthBuff : IBuff
    {
        private float _value;
        private float _elapsed;
        private BuffData _buffData;

        public BuffData BuffData => _buffData;
        public float Elapsed { get => _elapsed; set => _elapsed = value; }
        public float Value => _value;

        public HealthBuff(float value, BuffData data)
        {
            _value = value;
            _buffData = data;
        }
    }
}