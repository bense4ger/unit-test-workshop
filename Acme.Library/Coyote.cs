using System;

namespace Acme.Library
{
    public class Coyote
    {
        public TrapResult TryCatchRoadrunner()
        {
            var trapType = (TrapType) TrapTypeSelector();
            var trap = GetTrapFromFactory(trapType);
            var result = Process(trap);

            return result;
        }

        private int TrapTypeSelector()
        {
            var rnd = new Random();
            return rnd.Next(0, 2);
        }

        private Trap GetTrapFromFactory(TrapType trapType)
        {
            var factory = new TrapFactory();
            return factory.GetByType(trapType);
        }

        private TrapResult Process(Trap trap)
        {
            return new TrapResult();
        }
    }
}