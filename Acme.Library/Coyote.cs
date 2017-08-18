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

        public ITrapProcessor TrapProcessor { get; }

        private ITrapTypeSelector TypeSelector { get; }
        private ITrapFactory TrapFactory { get; }

        public TrapResult TryCatchRoadrunner()
        {
            var trapType = TypeSelector.Select();
            var trap = TrapFactory.Create(trapType);
            var result = TrapProcessor.Process(trap);

            return result;
        }
    }
}