using System;
using System.Collections.Generic;
using System.Text;

namespace TurnBasedBattler.Models.Entities.Heroes
{
    class Ranger : Hero
    {
        private const int InitialRangerHp = 100;
        private const int RangerAttackModifier = 3;
        private const int RangerDeffenceModifier = 1;
        private const int RangerMagicModifier = 2;
        private const double RangerDodgeModifier = 0.1;

        public Ranger(string name)
            : base(name, RangerAttackModifier, RangerDeffenceModifier, RangerMagicModifier, RangerDodgeModifier, InitialRangerHp)
        {
        }


    }
}
