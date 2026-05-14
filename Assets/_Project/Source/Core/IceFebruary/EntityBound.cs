namespace IceFebruary
{
    public sealed class EntityBound : BaseEntity
    {
        private readonly IBaseEntity[] _entities;
        public EntityBound(IBaseEntity[] entities) : base()
        {
            _entities = entities;
        }
        public override void Destroy()
        {
            base.Destroy();

            for (int index = 0; index < _entities.Length; index++)
                _entities[index].Destroy();
        }
    }
}
