using System;
using System.Collections.Generic;
using System.Text;

namespace TunBasedBattler.Models.Entities.Heroes
{
    class Paladin : Hero
    {
        private const int InitialPaladinHp = 125;
        private const int PaladinAttackModifier = 2;
        private const int PaladinDefenceModifier = 5;
        private const int PaladinMagicModifier = 1;
        private const decimal PaladinDodgeModifier = 0.01M;
        public Paladin(string name)
            : base(name, PaladinAttackModifier, PaladinDefenceModifier, PaladinMagicModifier, PaladinDodgeModifier, InitialPaladinHp)
        {
        }
    }
}