namespace IceFebruary.Animation
{
    using IceFebruary.Components;

    public static class AnimatorExtensions
    {
        public static AnimatorVariable<T> BindVariable<T>(this IAnimator animator, int hash) where T : struct => new(new(animator, hash));
        public static AnimatorTrigger BindTrigger(this IAnimator animator, int hash) => new(new(animator, hash));
    }
}
