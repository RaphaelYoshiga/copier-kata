using CopierKata;
using FluentAssertions;
using NUnit.Framework;

namespace CoperKata.UnitTests
{
    [TestFixture]
    public class CopierShould
    {
        [TestCase("A\n", "A")]
        [TestCase("B\n", "B")]
        public void SetCharOnTheDestination_WhenCopying_GivenSourceProvidesChar(string character, string expectedResult)
        {
            var destination = new DestinationSpy();
            var source = new SourceStub();
            var copier = new Copier(source, destination);
            source.SetupCharacters(character);

            copier.Copy();

            destination.Characters.Should().Be(expectedResult);
        }


        [Test]
        public void SetStringOnTheDestination_WhenCopying_GivenSourceProvidesString()
        {
            var destination = new DestinationSpy();
            var source = new SourceStub();
            var copier = new Copier(source, destination);
            source.SetupCharacters("AB\n");

            copier.Copy();

            destination.Characters.Should().Be("AB");
        }
    }

    public class DestinationSpy : IDestination
    {
        public string Characters { get; set; }
        public void SetChar(char character)
        {
            Characters += character.ToString();
        }
    }
}