using KHSave.Lib1;
using KHSave.Lib1.Types;
using System.IO;
using Xunit;

namespace KHSave.Tests
{
    public class Kh1Tests
    {
        private static readonly string FilePath = "Saves/BISLPS-25198-05";
        private SaveKh1.SaveFinalMix save;

        public Kh1Tests()
        {
            using (var stream = File.OpenRead(FilePath))
            {
                save = Xe.BinaryMapper.BinaryMapping.ReadObject<SaveKh1.SaveFinalMix>(stream);
            }
        }

        [Theory]
        [InlineData(0x05, true)]
        [InlineData(0x04, true)]
        [InlineData(0x03, false)]
        public void TestIsValid(uint header, bool expected)
        {
            var stream = new MemoryStream(4);
            new BinaryWriter(stream).Write(header);
            stream.Position = 0;

            Assert.Equal(expected, SaveKh1.IsValid(stream));
        }

        [Fact]
        public void TestRead()
        {
            var characterIndex = (int)PlayableCharacterType.Sora;

            Assert.Equal(EquipmentType.KingdomKey, save.Characters[characterIndex].Weapon);
            Assert.Equal(100, save.Characters[characterIndex].Level);

            Assert.Equal(PlayableCharacterType.Empty, save.CompanionCharacter3);
            Assert.Equal((uint)45359, save.Munny);

            Assert.Equal(WorldType.Endoftheworld, save.World);
            Assert.Equal((uint)0x1D, save.Room);
            Assert.Equal((uint)0x48, save.SpawnLocation);
        }

        [Fact]
        public void TestWriteBackTheSameExactFile() =>
        File.OpenRead(FilePath).Using(stream => Helpers.AssertStream(stream, inStream =>
        {
            var outStream = new MemoryStream();
            SaveKh1.Read(inStream).Write(outStream);

            return outStream;
        }));
    }
}
