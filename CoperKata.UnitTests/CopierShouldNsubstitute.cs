using CopierKata;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace CoperKata.UnitTests
{
    [TestFixture]
    public class CopierShouldNSubstitute
    {
        private Copier _copier;
        private ISource _source;
        private IDestination _destination;

        [SetUp]
        public void BeforeEachTest()
        {
            _destination = Substitute.For<IDestination>();
            _source = Substitute.For<ISource>();
            _copier = new Copier(_source, _destination);
        }

        [TestCase("A\n", "A")]
        [TestCase("B\n", "B")]
        public void SetCharOnTheDestination_WhenCopying_GivenSourceProvidesChar(string character, string expectedResult)
        {
            SetSourceToReturnChars(character);

            _copier.Copy();

            _destination.Received().SetChar(character[0]);
        }

        [Test]
        public void SetStringOnTheDestination_WhenCopying_GivenSourceProvidesString()
        {
            string character = "AB\n";
            SetSourceToReturnChars(character);

            _copier.Copy();

            _destination.Received().SetChar('A');
            _destination.Received().SetChar('B');
        }

        private void SetSourceToReturnChars(string character)
        {
            var theseChars = character.Substring(1, character.Length - 1).ToCharArray();
            _source.GetChar().Returns(character[0], theseChars);
        }
    }
}