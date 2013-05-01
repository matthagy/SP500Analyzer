using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace SP500Analyzer
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }

        Dictionary<string, Ticker> symbolMapping;
        List<Ticker> orderedTickers;
        private bool normalizeData = false;
        private bool shiftData = false;

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadStocks();
            priceChart.Series.Clear();

            orderedTickers = new List<Ticker>(symbolMapping.Values.OrderBy(sm => -sm.Open.Mean()));
            int count = 0;

            foreach (var ticker in orderedTickers)
            {
                count++;
                bool show = count <= 5;
                stockList.Items.Add(String.Format("{0} ({1:0.00})", ticker.symbol, ticker.Open.Mean()), show);
                if (show) AddStock(ticker);
            }
            priceChart.Invalidate();
            priceChart.ResetAutoValues();
        }

        private void AddStock(int index)
        {
            AddStock(orderedTickers[index]);
        }

        private void AddStock(string symbol)
        {
            AddStock(symbolMapping[symbol]);
        }

        private void AddStock(Ticker ticker)
        {
            var series = new Series
            {
                Name = ticker.symbol,
                ChartType = SeriesChartType.Line,
                IsVisibleInLegend = true,
                IsXValueIndexed = false
            };

            priceChart.Series.Add(series);
            int nValues = 0;
            double mean = (double)ticker.Open.Mean();
            double entry0 = 0;
            foreach (var entry in ticker.entries)
            {
                double year = (double)entry.date.year +
                              (double)entry.date.month / 12.0 +
                              (double)entry.date.day / 365.0;
                double y = (double)entry.open;
                if (normalizeData)
                    y /= mean;
                if (shiftData)
                {
                    if (nValues == 0)
                        entry0 = y;
                    y -= entry0;
                }
                series.Points.AddXY(year, y);
                nValues++;
            }
        }

        private void LoadStocks()
        {
            symbolMapping = new Dictionary<string, Ticker>();
            //"C:\\Users\\Hagy\\Documents\\sp500hst.txt"
            var assembly = Assembly.GetExecutingAssembly();
            //using (var file = new StreamReader(assembly.GetManifestResourceStream("WindowsFormsApplication4.SP500.txt")))
            string contents = SP500Analyzer.Properties.Resources.SP500;
            var lines = contents.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length != 7)
                    continue;

                var dateString = parts[0];
                var symbol = parts[1];
                var entry = new Entry(
                    date:  new Date(int.Parse(dateString.Substring(0, 4)),
                                    int.Parse(dateString.Substring(4, 2)),
                                    int.Parse(dateString.Substring(6, 2))),
                    open: Decimal.Parse(parts[2]),
                    high: Decimal.Parse(parts[3]),
                    low: Decimal.Parse(parts[4]),
                    close: Decimal.Parse(parts[5]),
                    volume: Decimal.Parse(parts[6]));

                if (!symbolMapping.ContainsKey(symbol))
                {
                    symbolMapping[symbol] = new Ticker(symbol);
                }
                symbolMapping[symbol].entries.Add(entry);
            }
        }

        private void stockList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = stockList.SelectedIndex;
            if (index == -1)
                return;
            Ticker ticker = orderedTickers[index];
            bool isChecked = stockList.GetItemChecked(index);
            if (isChecked == (priceChart.Series.FindByName(ticker.symbol) != null))
                return;
            if (isChecked)
            {
                AddStock(ticker);
            }
            else
            {
                priceChart.Series.Remove(priceChart.Series.FindByName(ticker.symbol));
            }
            priceChart.Invalidate();
            priceChart.ResetAutoValues();
        }

        private void RedoChart()
        {
            var tickers = new List<Ticker>();
            foreach (var series in priceChart.Series)
            {
                tickers.Add(symbolMapping[series.Name]);
            }
            priceChart.Series.Clear();

            foreach (var ticker in tickers)
            {
                AddStock(ticker);
            }
            priceChart.Invalidate();
            priceChart.ResetAutoValues();
        }

        private void checkNormalize_CheckedChanged(object sender, EventArgs e)
        {
            normalizeData = checkNormalize.Checked;
            RedoChart();
        }

        private void checkShift_CheckedChanged(object sender, EventArgs e)
        {
            shiftData = checkShift.Checked;
            RedoChart();
        }

    }
}
