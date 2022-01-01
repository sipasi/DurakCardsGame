

using System.Collections.Generic;

using ProjectCard.Durak.CardModule.ExtensionModule;

namespace ProjectCard.Durak.CardModule.ToolModule
{
    public static class DataTool
    {
        public static bool TryGetSmallestTrump(IReadOnlyList<Data> datas, Data trump, out Data result)
        {
            result = default;
            Data? smallest = default;

            for (int i = 0; i < datas.Count; i++)
            {
                Data data = datas[i];

                if (!data.EqualSuit(trump))
                {
                    continue;
                }

                if (smallest == null || data.rank < result.rank)
                {
                    smallest = data;
                    result = data;
                    continue;
                }
            }

            return smallest != null;
        }
    }
}