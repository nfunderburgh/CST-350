using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    internal class Sword : IWWeapon
    {

        public String SwordName { get; set; }

        public Sword(string swordName)
        {
            SwordName = swordName;
        }

        public Sword()
        {
            SwordName = "Lame name sword";
        }

        public void AttackWithMe()
        {
            System.Console.WriteLine(SwordName + " slices through the air, devestating all enemies");
        }
    }
}
