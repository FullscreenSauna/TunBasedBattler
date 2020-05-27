using System;
using System.Collections.Generic;
using System.Text;

namespace TurnBasedBattler.Models.Entities.Heroes
{
    class Ranger : Hero
    {
        private const int InitialRangerHp = 100;
        private const int RangerAttackModifier = 3;
        private const int RangerDefenceModifier = 1;
        private const int RangerMagicModifier = 2;
        private const decimal RangerDodgeModifier = 0.1M;

        public Ranger(string name)
            : base(name, RangerAttackModifier, RangerDefenceModifier, RangerMagicModifier, RangerDodgeModifier, InitialRangerHp)
        {
        }


    }
}
