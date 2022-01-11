
namespace Framework.Shared.Collections.Extensions
{
    public static class BoardExtension
    {
        public static T Last<T>(this IReadonlyBoard<T> board)
        {
            return board.All.Last();
        }
    }
}