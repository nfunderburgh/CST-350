using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    class HeroThatCanUseAnyWeapon : IHero
    {

        public string Name { get; set; }
        public IWWeapon MyWeapon { get; set; }

        public HeroThatCanUseAnyWeapon(string name, IWWeapon myWeapon)
        {
            Name = name;
            MyWeapon = myWeapon;
        }

        public HeroThatCanUseAnyWeapon()
        {
            Name = "Mr. Nobody. No name provided";
            MyWeapon = null;
        }

        public void Attack()
        {
            Console.WriteLine(Name + " prepares to attack");
            MyWeapon.AttackWithMe();
        }
    }
}
