using System.Collections.Generic;
using System.Linq;

namespace Acme.Library
{
    public class TrapFactory
    {
        public TrapFactory()
        {
            Traps = new List<Trap>
            {
                new Trap() {ChanceOfSuccess = 0, Type = TrapType.Anvil},
                new Trap() {ChanceOfSuccess = 0, Type = TrapType.FakeTunnel},
                new Trap() {ChanceOfSuccess = 0, Type = TrapType.BigRock}
            };
        }

        public List<Trap> Traps { get; }

        public Trap GetByType(TrapType type)
        {
            return Traps.FirstOrDefault(t => t.Type == type);
        }
    }
}