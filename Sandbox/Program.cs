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
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            var yes = new Counter("yes",1);
            var no = new Counter("no",2);

            var manager = new CounterManager(yes, no);

            var yesPercent = yes.getPercent(manager.Total());
            var noPercent = no.getPercent(manager.Total());


            Console.WriteLine($"Yes counts : {yes.count}, percentage: {yesPercent}%");
            Console.WriteLine($"No counts : {no.count}, percentage: {noPercent}%");

            if (no.count > yes.count)
                Console.WriteLine("No won");
            else if(yes.count > no.count)
            {
                Console.WriteLine("Yes Won");

            }
            else
                Console.WriteLine("Draw");


        }
    }
}
