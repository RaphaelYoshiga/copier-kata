using CoperKata.UnitTests;

namespace CopierKata
{
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
}