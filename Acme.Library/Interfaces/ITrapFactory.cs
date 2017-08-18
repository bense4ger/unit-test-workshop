namespace Acme.Library
{
    public interface ITrapFactory
    {
        Trap Create(TrapType trapType);
    }
}