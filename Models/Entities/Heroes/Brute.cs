using System;
using System.Collections.Generic;
using System.Text;

namespace TurnBasedBattler.Models.Entities.Heroes
{
    class Brute : Hero
    {
        private const int InitialBruteHp = 150;
        private const int BruteAttackModifier = 5;
        private const int BruteDefenceModifier = 2;
        private const int BruteMagicModifier = 1;
        private const decimal BruteDodgeModifier = 0.02;


        public Brute(string name)
            : base(name, BruteAttackModifier, BruteDefenceModifier, BruteMagicModifier, BruteDodgeModifier, InitialBruteHp)
        {
        }
    }
}
