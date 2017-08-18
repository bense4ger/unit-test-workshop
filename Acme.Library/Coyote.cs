using System;
using Acme.Library.Interfaces;

namespace Acme.Library
{
    public class Coyote
    {
        public Coyote(ITrapTypeSelector typeSelector, ITrapFactory trapFactory, ITrapProcessor processor)
        {
            TypeSelector = typeSelector;
            TrapFactory = trapFactory;
            TrapProcessor = processor;
        }

        private ITrapProcessor TrapProcessor { get; }

        private ITrapTypeSelector TypeSelector { get; }
        private ITrapFactory TrapFactory { get; }

        public TrapResult TryCatchRoadrunner()
        {
            var rnd = new Random();
            var trapType = TypeSelector.Select(rnd.Next(0,2));
            var trap = TrapFactory.Create(trapType);
            var result = TrapProcessor.Process(trap);

            return result;
        }

        public TrapResult TryCatchRoadrunner(TrapType trapType)
        {
            var trap = TrapFactory.Create(trapType);
            var result = TrapProcessor.Process(trap);

            return result;
        }
    }
}