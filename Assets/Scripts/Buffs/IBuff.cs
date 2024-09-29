namespace Stats
{
    public interface IBuff
    {
        public BuffData BuffData { get; }
        public float Elapsed { get; set; }
    }
}