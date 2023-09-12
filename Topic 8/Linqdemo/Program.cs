namespace Linqdemo{
    class Program
    {
        static void Main(string[] args)
        {
            int[] scores = new[] { 50, 66, 90, 81, 77, 45, 0, 100, 99, 72, 87, 85, 81, 80, 77, 74, 95, 97 };

            foreach(var indivialScore in scores)
            {
                Console.WriteLine("One of the scores was {0}", indivialScore);
            }

            Console.ReadLine();

            var theBestStudesnts =
                from indivialScore in scores
                where indivialScore > 90
                select indivialScore;

            foreach(var indivialScore in theBestStudesnts)
            {
                Console.WriteLine("One of the BEST scores was {0}", indivialScore);
            }

            Console.ReadLine();

            var sortedStudesnts =
                from indivialScore in scores
                orderby indivialScore
                select indivialScore;

            foreach (var indivialScore in sortedStudesnts)
            {
                Console.WriteLine("One of the scores was {0}", indivialScore);
            }

            Console.ReadLine();
        }
    }
}