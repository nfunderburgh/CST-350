using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    class Grenade : IWWeapon
    {

        public string WeaponName { get; set; }

        public Grenade(string weaponName)
        {
            WeaponName = weaponName;
        }

        public Grenade()
        {
            WeaponName = "Pathetic grenade. No name provided";
        }

        public void AttackWithMe()
        {
            Console.WriteLine(WeaponName + " sizzles for a moment and then explods into a shower of deadly metal fragments");
        }
    }
}
