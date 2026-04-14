namespace IceFebruary
{
    public class Toggle : IToggle
    {
        public bool Enabled { get; set; }
        public Toggle(bool enabled = true)
        {
            Enabled = enabled;
        }
    }
}
