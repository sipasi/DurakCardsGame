using ProjectCard.Shared.IO;

namespace ProjectCard.Editor.TestModule.IO
{
    public class BinaryFileTest : FileTest
    {
        protected override string LocalPath => "file.binary";

        protected override IFileAsync GetFile() => new BinaryFile(FullPath);
    }
}