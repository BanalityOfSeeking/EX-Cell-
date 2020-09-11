
using SimpleInjector;

namespace Game
{
    public class ContainerFactory
    {
        private Container NewContainer() => new Container();

        public Container GetContainer()
        {
            return NewContainer();
        }
    }
}