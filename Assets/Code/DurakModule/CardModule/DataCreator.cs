
using ProjectCard.DurakModule.CardModule;

namespace ProjectCard.DurakModule.GameModule
{
    public static class DataCreator
    {
        public static Data[] Create(int suits, int ranks)
        {
            int total = suits * ranks;

            var datas = new Data[total];

            for (int suit = 0; suit < suits; suit++)
            {
                for (int rank = 0; rank < ranks; rank++)
                {
                    Data data = new Data(suit, rank);

                    int index = suit * ranks + rank;

                    datas[index] = data;
                }
            }

            return datas;
        }
    }
}