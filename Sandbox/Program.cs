using System;
using System.Collections.Generic;
using System.Linq;

namespace Sandbox
{
    public class Counter
    {
        public string name{ get; }
        public int count { get; }

        public Counter(string name, int count){
            this.name = name;
            this.count = count;
        }

        public double getPercent(int total){
            return Math.Round(count * 100.0 /total, 2);
        }

    }


    public class CounterManager
    {
        public List<Counter> counters { get; set; }

        public CounterManager(params Counter[] counters)
        {
            this.counters = new List<Counter>(counters);
        }

        public int Total() => counters.Sum(x => x.count);

        public void AnounceWinner()
        {
            var biggestAmountOfVotes = counters.Max(x => x.count);

            var winners = counters.Where(x => x.count == biggestAmountOfVotes).ToList();

            if (winners.Count == 1)
            {
                var winner = winners.First();
                Console.WriteLine($"{winner.name} won !");
            }
            else 
                string.Join("-Draw- ", winners.Select(x => x.name));
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            var yes = new Counter("yes",2);
            var no = new Counter("no",2);

            var manager = new CounterManager(yes, no);

            var yesPercent = yes.getPercent(manager.Total());
            var noPercent = no.getPercent(manager.Total());


            foreach(var c in manager.counters)
                Console.WriteLine($"{c.name} counts : {c.count}, percentage: {c.getPercent(manager.Total())}%");

            manager.AnounceWinner();

        }
    }
}
