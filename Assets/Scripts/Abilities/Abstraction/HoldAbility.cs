namespace Abilities
{
    public abstract class HoldAbility : BaseAbility, IAbilityEnder
    {
        protected bool _isUse = false;

        public void EndExecution()
        {
            _isUse = false;
        }

        public override void Execute()
        {
            base.Execute();

            _isUse = true;
        }

        protected override void OnReady()
        {
            base.OnReady();

            if (_isUse)
                Execute();
        }

        protected override abstract void UseAbility();
    }
}

