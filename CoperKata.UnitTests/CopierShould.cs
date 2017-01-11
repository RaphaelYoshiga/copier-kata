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

    public class Copier
    {
        private readonly ISource _source;
        private readonly IDestination _destination;

        public Copier(ISource source, IDestination destination)
        {
            _destination = destination;
            _source = source;
        }

        public void Copy()
        {
            char character;
            while ((character = _source.GetChar()) != '\n')
            {
                _destination.SetChar(character);
            }

        }
    }

    public class SourceStub : ISource
    {
        private string _characters;

        public void SetupCharacters(string characters)
        {
            _characters = characters;
        }

        public char GetChar()
        {
            var character = _characters[0];
            if (_characters.Length > 1)
                _characters = _characters.Substring(1, _characters.Length - 1);

            return character;
        }
    }

    public interface ISource
    {
        char GetChar();
    }

    public interface IDestination
    {
        void SetChar(char character);
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