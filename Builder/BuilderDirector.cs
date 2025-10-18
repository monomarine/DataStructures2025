﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    internal class BuilderDirector
    {
        private readonly ICharacterBuilder _characterBuilder;
        public BuilderDirector(ICharacterBuilder builder)
        {
            _characterBuilder = builder;
        }

        public ICharacterBuilder CreateWarrior(string name, int level)
        {
            return _characterBuilder.SetName(name)
                .SetLevel(level)
                .SetAppirance("обыччный воин из деревни")
                .AddSkill("сильный удар")
                .AddSkill("быстрый бег")
                .SetClass(CharacterClass.Warrior);
        }

        public ICharacterBuilder CreateCustomCharacter(string name, int level, int strenght, int mana, CharacterClass characterClass)
        {
            return _characterBuilder.SetName(name)
                .SetLevel(level)
                .SetClass(characterClass)
                .SetIntelligence(10)
                .SetMana(mana)
                .SetStrenght(strenght)
                .AddSkill("огненный взрыв")
                .AddSkill("ярость");
        }

        public ICharacterBuilder CreateNPC(string name, int level, CharacterClass characterClass, Equipment equipment = null)
        {
            var builder = _characterBuilder.SetName(name)
                .SetLevel(level)
                .SetClass(characterClass)
                .SetAppirance("NPC, обитатель деревни")
                .AddSkill("разговор")
                .AddSkill("торговля");

            if (equipment != null)
            {
                builder.SetEquipment(equipment);
            }
            else
            {
                builder.SetWeapon("Деревянный посох")
                       .SetArmor("Обычная одежда")
                       .SetHelmet("Нет")
                       .SetBoots("Сандалии")
                       .AddAccessory("Ожерелье");
            }

            return builder;
        }
    }
}