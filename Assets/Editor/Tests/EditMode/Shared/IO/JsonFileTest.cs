using Framework.Shared.IO;
using Framework.Shared.Tests;

namespace ProjectCard.Editor.TestModule.IO
{
    public class BinaryFileTest : FileTest
    {
        protected override string LocalPath => "file.binary";

        protected override IFile<SaveData> GetFile() => new LocalBinaryFile<SaveData>(FullPath);
    }
}