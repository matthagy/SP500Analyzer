using System;
using System.Collections.Generic;

namespace SP500Analyzer
{

    struct Date
    {
        public int year, month, day;

        public Date(int year, int month, int day)
        {
            this.year = year;
            this.month = month;
            this.day = day;
        }
    }

    struct Entry
    {
        public Date date;
        public decimal open, high, low, close, volume;
    }

    class Column : IEnumerable<decimal>
    {
        public readonly string name;
        public readonly decimal[] values;

        public Column(string name, List<Entry> entries, Func<Entry, decimal> get)
        {
            this.name = name;
            this.values = new decimal[entries.Count];
            for (int i = 0; i < this.values.Length; i++)
            {
                this.values[i] = get(entries[i]);
            }
        }

        public IEnumerator<decimal> GetEnumerator()
        {
            foreach (var v in values)
            {
                yield return v;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private static S MeanFunc<S, T>(IEnumerable<T> elements, Func<T, S> func)
        {
            int count = 0;
            dynamic acc = 0;
            foreach (var el in elements)
            {
                acc = acc + func(el);
                count++;
            }
            return (S)(acc / count);
        }

        public decimal Mean()
        {
            return MeanFunc(values, d => d);
        }

        public decimal Variance()
        {
            var mean = Mean();
            return MeanFunc(values, d => (d - mean) * (d - mean));
        }

        public decimal StandardDeviation()
        {
            return (decimal)Math.Sqrt((double)Variance());
        }
    }

    struct Ticker
    {
        public string symbol;
        public List<Entry> entries;

        public Ticker(string symbol)
        {
            this.symbol = symbol;
            entries = new List<Entry>();
        }

        public Column Open
        {
            get
            {
                return new Column("open", entries, e => e.open);
            }
        }
    }

}