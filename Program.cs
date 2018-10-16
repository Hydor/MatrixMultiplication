using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Project2_3
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter the max size of matrix:");
            int N = int.Parse(Console.ReadLine());

            var results = new List<Results>();
            var start = DateTime.Now;

            for (int i = 1; i <= N; i *= 2)
            {
                Results r = new Results(i.ToString());

                Console.WriteLine("Testing; Matrix size = {0}...√", i);

                var a = Matrix.Generate(i);
                var b = Matrix.Generate(i);

                Stopwatch t1 = Stopwatch.StartNew();
                var normal = Matrix.NormalMultiply(a, b);
                t1.Stop();

                Stopwatch t2 = Stopwatch.StartNew();
                var strassen = Matrix.StrassenMultiply(a, b);
                t2.Stop();

                r.Times.Add(t1.Elapsed.TotalSeconds);

                results.Add(r);
            }

            string consoleFormat = "{0}\t{1:N6}s\t ";
            WriteResults(Console.Out, results, consoleFormat, "Size \t Time");

            Console.ReadKey();
        }


        static void WriteResults(TextWriter output, IEnumerable<Results> results, string format, string header = null)
        {
            if (header != null)
                output.WriteLine(header);

            foreach (var r in results)
            {
                double avg1 = r.Times.Average();
                output.WriteLine(format, r.TestName, avg1);
            }
        }
    }

    class Results
    {
        public String TestName { get; set; }
        public IList<double> Times { get; set; }
        public Results(String name)
        {
            TestName = name;
            Times = new List<double>();
        }
    }

}
