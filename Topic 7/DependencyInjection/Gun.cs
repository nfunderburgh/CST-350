using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    internal class Gun : IWWeapon
    {
        public string Name { get; set; }

        public List<Bullet> Bullets { get; set; }

        public Gun(string name, List<Bullet> bullets)
        {
            Name = name;
            Bullets = bullets;
        }

        public void AttackWithMe()
        {
            if(Bullets.Count > 0)
            {
                System.Console.WriteLine(Name + " fires the round called " + Bullets[0].Name + ". The victim now has a deadly hole in him");
                Bullets.RemoveAt(0);
            }
            else
            {
                System.Console.WriteLine("The gun has no bullets. Nothing happens");
            }
        }
    }
}
