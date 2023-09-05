using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            //HeroThatOnlyUsesSwords hero1 = new HeroThatOnlyUsesSwords("Ultraman");
            //hero1.Attack();
            //Console.WriteLine();

            //HeroThatCanUseAnyWeapon hero2 = new HeroThatCanUseAnyWeapon("Eregon", new Sword("brisinger"));
            //hero2.Attack();
            //Console.WriteLine();

            //HeroThatCanUseAnyWeapon hero3 = new HeroThatCanUseAnyWeapon("The Joker", new Grenade("The Pineapple"));
            //hero3.Attack();
            //Console.WriteLine();

            //HeroThatCanUseAnyWeapon hero4 = new HeroThatCanUseAnyWeapon("GI Joe", new Gun("Six Shooter",
            //    new List<Bullet>
            //    {
            //        new Bullet("Silver Slug", 10),
            //        new Bullet("Lead Ball", 20),
            //        new Bullet("Rusty Nail", 3),
            //        new Bullet("Hollow Point", 5)
            //    }));

            //hero4.Attack();
            //hero4.Attack();
            //hero4.Attack();
            //hero4.Attack();
            //hero4.Attack();
            //hero4.Attack();
            //hero4.Attack();
            //hero4.Attack();

            ServiceCollection services = new ServiceCollection();

            services.AddTransient<IWWeapon, Gun>(Gun => new Gun("Six Shooter",
                new List<Bullet>
                {
                    new Bullet("Silver Slug", 10),
                    new Bullet("Lead Ball", 20),
                    new Bullet("Rusty Nail", 3),
                    new Bullet("Hollow Point", 5)

                }));

            services.AddTransient<IHero, HeroThatCanUseAnyWeapon>(
                hero => new HeroThatCanUseAnyWeapon("Jonny English", hero.GetService<IWWeapon>())
            );

            ServiceProvider provider = services.BuildServiceProvider();

            var hero5 = provider.GetService<IHero>();

            hero5.Attack();
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}