using System;
using System.Collections.Generic;
using System.Linq;

namespace лаба_6_норм
{
    internal class Director
    {
        public int FilmCount { get; set; } = 0;
        public List<double> Rates { get; } = new List<double>();

        public double AverageRate
        {
            get
            {
                if (FilmCount == 0 || Rates.Count == 0)
                    return 0;

                return Rates.Average();
            }
        }

        public string Name { get; set; }
        public int StartActivityYear { get; set; }
        public int EndActivityYear { get; set; }

        public void AddRate(double rate)
        {
            Rates.Add(rate);
            FilmCount = Rates.Count;
        }
    }
}