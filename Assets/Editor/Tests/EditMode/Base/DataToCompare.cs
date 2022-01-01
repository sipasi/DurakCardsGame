namespace ProjectCard.Editor.TestModule.TestData
{
    public static class DataToCompare
    {
        public static readonly int length = 10;

        public static readonly SaveData data = new SaveData(dataLength: length);

        public static bool Compare(SaveData saveData) => data.Compare(saveData);
    }
}