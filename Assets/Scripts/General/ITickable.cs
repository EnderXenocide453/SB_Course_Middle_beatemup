namespace General
{
    public interface ITickable
    {
        float LifeTime { get; }
        float TimeElapsed { get; }

        void Tick(float deltaTime);
    }
}
