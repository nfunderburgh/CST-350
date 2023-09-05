using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    class HeroThatOnlyUsesSwords : IHero
    {

        public string Name { get; set; }

        public HeroThatOnlyUsesSwords(string name)
        {
            Name = name;
        }

        public HeroThatOnlyUsesSwords()
        {
            Name = "Generic Hero. No Name Given";
        }

        public void Attack()
        {
            Sword sword = new Sword("Excalibur");
            Console.WriteLine(Name + " prepares himself for the battle");
            sword.AttackWithMe();
        }
    }
}
