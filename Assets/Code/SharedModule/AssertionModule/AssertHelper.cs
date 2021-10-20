#nullable enable


namespace ProjectCard.Shared.AssertionModule
{
    public static class AssertHelper
    {
        public static string ReferenceNotSetMessage<T>(T? _) where T : class
        {
            var type = typeof(T);

            return $"You have forgotten set the {type.Name} reference";
        }
    }
}