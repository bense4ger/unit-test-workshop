using System;
using Acme.Library.Interfaces;

namespace Acme.Library
{
    public class TrapTypeSelector : ITrapTypeSelector
    {
        public TrapType Select(int typeSeed)
        {
            if (typeSeed <0 || typeSeed > 2) throw new ArgumentException("Invalid typeseed passed");

            return (TrapType) typeSeed;
        }
    }
}