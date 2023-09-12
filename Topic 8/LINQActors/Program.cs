using LINQActors;
using Newtonsoft.Json.Linq;

class Program
{
    static void Main(string[] args)
    {
        string data = @"[
        [""Harrison Ford"", 4871.7, 41, 118.8, ""Star Wars: The Force Awakens"", 936.7],
        [""Samuel L. Jackson"", 4772.8, 69, 69.2, ""The Avengers"", 623.4],
        [""Morgan Freeman"", 4468.3, 61, 73.3, ""The Dark Knight"", 534.9],
        [""Tom Hanks"", 4340.8, 44, 98.7, ""Toy Story 3"", 415],
        [""Robert Downey Jr."", 3947.3, 53, 74.5, ""The Avengers"", 623.4],
        [""Eddie Murphy"", 3810.4, 38, 100.3, ""Shrek 2"", 441.2],
        [""Tom Cruise"", 3587.2, 36, 99.6, ""War of the Worlds"", 234.3],
        [""Johnny Depp"", 3368.6, 45, 74.9, ""Dead Man's Chest"", 423.3],
        [""Michael Caine"", 3351.5, 58, 57.8, ""The Dark Knight"", 534.9],
        [""Scarlett Johansson"", 3341.2, 37, 90.3, ""The Avengers"", 623.4],
        [""Gary Oldman"", 3294, 38, 86.7, ""The Dark Knight"", 534.9],
        [""Robin Williams"", 3279.3, 49, 66.9, ""Night at the Museum"", 250.9],
        [""Bruce Willis"", 3189.4, 60, 53.2, ""Sixth Sense"", 293.5],
        [""Stellan Skarsgard"", 3175, 43, 73.8, ""The Avengers"", 623.4],
        [""Anthony Daniels"", 3162.9, 7, 451.8, ""Star Wars: The Force Awakens"", 936.7],
        [""Ian McKellen"", 3150.4, 31, 101.6, ""Return of the King"", 377.8],
        [""Will Smith"", 3149.1, 24, 131.2, ""Independence Day"", 306.2],
        [""Stanley Tucci"", 3123.9, 50, 62.5, ""Catching Fire"", 424.7],
        [""Matt Damon"", 3107.3, 39, 79.7, ""The Martian"", 228.4],
        [""Robert DeNiro"", 3081.3, 79, 39, ""Meet the Fockers"", 279.3],
        [""Cameron Diaz"", 3031.7, 34, 89.2, ""Shrek 2"", 441.2],
        [""Liam Neeson"", 2942.7, 63, 46.7, ""The Phantom Menace"", 474.5],
        [""Andy Serkis"", 2890.6, 23, 125.7, ""Star Wars: The Force Awakens"", 936.7],
        [""Don Cheadle"", 2885.4, 34, 84.9, ""Avengers: Age of Ultron"", 459],
        [""Ben Stiller"", 2827, 37, 76.4, ""Meet the Fockers"", 279.3],
        [""Helena Bonham Carter"", 2822, 36, 78.4, ""Harry Potter / Deathly Hallows(P2)"", 381],
        [""Orlando Bloom"", 2815.8, 17, 165.6, ""Dead Man's Chest"", 423.3],
        [""Woody Harrelson"", 2815.8, 50, 56.3, ""Catching Fire"", 424.7],
        [""Cate Blanchett"", 2802.6, 39, 71.9, ""Return of the King"", 377.8],
        [""Julia Roberts"", 2735.3, 42, 65.1, ""Ocean's Eleven"", 183.4],
        [""Elizabeth Banks"", 2726.3, 35, 77.9, ""Catching Fire"", 424.7],
        [""Ralph Fiennes"", 2715.3, 36, 75.4, ""Harry Potter / Deathly Hallows(P2)"", 381],
        [""Emma Watson"", 2681.9, 17, 157.8, ""Harry Potter / Deathly Hallows(P2)"", 381],
        [""Tommy Lee Jones"", 2681.3, 46, 58.3, ""Men in Black"", 250.7],
        [""Brad Pitt"", 2680.9, 40, 67, ""World War Z"", 202.4],
        [""Adam Sandler"", 2661, 32, 83.2, ""Hotel Transylvania 2"", 169.7],
        [""Daniel Radcliffe"", 2634.4, 17, 155, ""Harry Potter / Deathly Hallows(P2)"", 381],
        [""Jonah Hill"", 2605.1, 29, 89.8, ""The LEGO Movie"", 257.8],
        [""Owen Wilson"", 2602.3, 39, 66.7, ""Night at the Museum"", 250.9],
        [""Idris Elba"", 2580.6, 26, 99.3, ""Avengers: Age of Ultron"", 459],
        [""Bradley Cooper"", 2557.7, 25, 102.3, ""American Sniper"", 350.1],
        [""Mark Wahlberg"", 2549.8, 36, 70.8, ""Transformers 4"", 245.4],
        [""Jim Carrey"", 2545.2, 27, 94.3, ""The Grinch"", 260],
        [""Dustin Hoffman"", 2522.1, 43, 58.7, ""Meet the Fockers"", 279.3],
        [""Leonardo DiCaprio"", 2518.3, 25, 100.7, ""Titanic"", 658.7],
        [""Jeremy Renner"", 2500.3, 21, 119.1, ""The Avengers"", 623.4],
        [""Philip Seymour Hoffman"", 2463.7, 40, 61.6, ""Catching Fire"", 424.7],
        [""Sandra Bullock"", 2462.6, 35, 70.4, ""Minions"", 336],
        [""Chris Evans"", 2457.8, 23, 106.9, ""The Avengers"", 623.4],
        [""Anne Hathaway"", 2416.5, 25, 96.7, ""The Dark Knight Rises"", 448.1]
        ]";

        List<Actor> actorList = new List<Actor>();

        JArray a = JArray.Parse(data);

        foreach( var item in a)
        {
            Actor actor = new Actor
            {
                Name = (string)item[0],
                TotalGross = (decimal)item[1],
                MovieCount = (int)item[2],
                AvgPerMovie = (decimal)item[3],
                TopMovie = (string)item[4],
                TopMovieGross = (decimal)item[5]
            };
            actorList.Add(actor);
        }

        Console.WriteLine("Actors count = " + actorList.Count);
        Console.ReadLine();

        var richActors1 = new List<Actor>();
        Console.WriteLine("rich actors that make more than $400 million");

        foreach (Actor ac in actorList)
        {
            if (ac.TotalGross > 4000)
            {
                richActors1.Add(ac);
                Console.Write(ac);
            }
        }
        Console.ReadLine();

        var richActors2 = from actor in actorList
                          where actor.TotalGross > 4000
                          select actor;
        Console.WriteLine("Rich actors selected using LINQ");

        foreach (Actor ac in richActors2)
        {
            Console.Write(ac);
        }
        Console.ReadLine();

        var richActors3 = actorList.Where(a => a.TotalGross > 4000);
        Console.WriteLine("Rich actors selected using Lambda expressions");
        foreach (Actor ac in richActors3)
        {
            Console.Write(ac);
        }
        Console.ReadLine();

        var actorswithEvenNumber1 = new List<Actor>();

        foreach(Actor a2 in actorList)
        {
            if(a2.MovieCount % 2 == 0)
            {
                actorswithEvenNumber1.Add(
                    new Actor
                        {
                            Name = a2.Name,
                            MovieCount = a2.MovieCount
                        }
                    );
            }
        }
        Console.WriteLine("Even number actors = ");
        foreach (Actor ac in actorswithEvenNumber1)
        {
            Console.Write(ac);
        }
        Console.ReadLine();


        var actorswithEvenNumberOfFilms2 = from actor in actorList
                                           where actor.MovieCount % 2 == 0
                                           select new Actor
                                           {
                                               Name = actor.Name,
                                               MovieCount = actor.MovieCount
                                           };

        Console.WriteLine("Even number of films using LINQ: ");
        foreach (Actor ac in actorswithEvenNumberOfFilms2)
        {
            Console.Write(ac);
        }
        Console.ReadLine();


        var actorsWithEvenNumberOfFilms3 = actorList
            .Where(a => a.MovieCount % 2 == 0)
            .Select(x => new Actor
                {
                    Name = x.Name,
                    MovieCount = x.MovieCount
                }
            );
        Console.WriteLine("Even number of films using Lambda: ");
        foreach (Actor ac in actorsWithEvenNumberOfFilms3)
        {
            Console.Write(ac);
        }
        Console.ReadLine();

        var starWarsActors1 = new List<Actor>();

        foreach( Actor a3 in actorList)
        {
            if (a3.TopMovie.Contains("Star Wars"))
            {
                starWarsActors1.Add(new Actor { Name = a3.Name, TopMovie = a3.TopMovie});
            }
        }
        Console.WriteLine("Star Wars actors with for loop: ");
        foreach (Actor ac in starWarsActors1)
        {
            Console.Write(ac);
        }

        var starWarsActors2 = from actor in actorList
                              where actor.TopMovie.Contains("Star Wars")
                              select new Actor
                              {
                                  Name = actor.Name,
                                  TopMovie = actor.TopMovie
                              };

        Console.ReadLine();
        Console.WriteLine("Star wars actors made with LINQ : ");
        foreach (Actor ac in starWarsActors2)
        {
            Console.Write(ac);
        }

        var starWarsActors3 = actorList
           .Where(a => a.TopMovie.Contains("Star Wars"))
           .Select(x => new Actor
               {
                   Name = x.Name,
                   TopMovie = x.TopMovie
               }
           );

        Console.WriteLine("Star wars actors made with Lambda : ");
        foreach (Actor ac in starWarsActors3)
        {
            Console.Write(ac);
        }
        Console.ReadLine();

        //Example 3

        var groupedByMovies = from actor in actorList
                              group actor by actor.TopMovie into newGroup
                              orderby newGroup.Key
                              from actorinGroup in newGroup
                              select new Actor
                              {
                                  Name = actorinGroup.Name,
                                  TopMovie = actorinGroup.TopMovie
                              };
        Console.WriteLine("Grouped by Movie : ");
        foreach (Actor ac in groupedByMovies)
        {
            Console.Write(ac);
        }
        Console.ReadLine();


        var group2 = actorList.GroupBy(a => a.TopMovie)
            .OrderBy(b => b.Key)
            .SelectMany(c => c)
            .Select(d => new Actor
            {
                Name = d.Name,
                TopMovie = d.TopMovie
            });
        Console.WriteLine("Grouped by Movie with Lambda: ");
        foreach (Actor ac in group2)
        {
            Console.Write(ac);
        }
        Console.ReadLine();
    }
}
