using System;
using System.Collections.Generic;
using System.Text;

namespace TurnBasedBattler.Models.Entities.Heroes
{
    class Wizzard : Hero
    {
        private const int InitialWizzardHp = 75;
        private const int WizzardAttackModifier = 1;
        private const int WizzardDefenceModifier = -2;
        private const int WizzardMagicModifier = 8;
        private const decimal WizzardDodgeModifier = 0.02;



        public Wizzard(string name)
            : base(name, WizzardAttackModifier, WizzardDefenceModifier, WizzardMagicModifier, WizzardDodgeModifier, InitialWizzardHp)
        {
        }
    }
}
