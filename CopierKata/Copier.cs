namespace CopierKata
{
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
}