namespace DX9OverlayAPIWrapper
{
    /// <summary>
    /// The base class of all entities drawn to the overlay (e.g. texts, images...)
    /// </summary>
    public abstract class OverlayEntity
    {
        /// <summary>
        /// The identity registered with the actual overlay
        /// </summary>
        public int Id { get; protected set; } = -1;

        public virtual bool IsVisible { get; set; }

        public abstract void Destroy();

        public override string ToString()
        {
            return $"{GetType().Name} {Id}";
        }
    }
}
