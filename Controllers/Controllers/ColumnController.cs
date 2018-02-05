using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts;
using LiveCharts.Wpf;
using SaveIt;

namespace Controllers
{
    public class ColumnController : ObservableObject
    {
        private double[] daysOfWeek = { 0, 0, 0, 0, 0, 0, 0 };
        private double[] thisWeek = { 0, 0, 0, 0, 0, 0, 0 };
        private int Avg;
        private const int DAYS_IN_WEEK = 7;
        private TimeSpan numberOfDays;
        private TimeSpan numberOfWeeks;
#pragma warning restore CS0168 // The variable 'numberOfWeeks' is declared but never used

        public ColumnController()
        {
            InitializeGraphData();
        }

        private void InitializeGraphData()
        {
            using (var context = new EntitySaveItContext())
            {
                var MinDate = (from emp in context.Expenses
                               select emp.TransactionDate).Min();

                var MaxDate = (from emp in context.Expenses
                               select emp.TransactionDate).Max();

                numberOfDays = DateTime.Now.Subtract(MinDate);

                var exAll = from exp in context.Expenses
                            group exp by exp.TransactionDate into exg
                            select new
                            {
                                Day = exg.Key,
                                Amounts = exg.Sum(x => x.Amount)
                            };

                DateTime dt = StartOfWeek(DateTime.Now, DayOfWeek.Monday);

                var exWeek = from exp in context.Expenses
                             where exp.TransactionDate >= dt
                             group exp by exp.TransactionDate into exg
                             select new
                             {
                                 Day = exg.Key,
                                 Amounts = exg.Sum(x => x.Amount)
                             };

                foreach (var item in exWeek)
                {
                    if (item.Day.DayOfWeek == DayOfWeek.Monday)
                        thisWeek[1] += item.Amounts;
                    if (item.Day.DayOfWeek == DayOfWeek.Tuesday)
                        thisWeek[2] += item.Amounts;
                    if (item.Day.DayOfWeek == DayOfWeek.Wednesday)
                        thisWeek[3] += item.Amounts;
                    if (item.Day.DayOfWeek == DayOfWeek.Thursday)
                        thisWeek[4] += item.Amounts;
                    if (item.Day.DayOfWeek == DayOfWeek.Friday)
                        thisWeek[5] += item.Amounts;
                    if (item.Day.DayOfWeek == DayOfWeek.Saturday)
                        thisWeek[6] += item.Amounts;
                    if (item.Day.DayOfWeek == DayOfWeek.Sunday)
                        thisWeek[0] += item.Amounts;
                }

                Avg = numberOfDays.Days / DAYS_IN_WEEK;
                Avg += 1;

                foreach (var item in exAll)
                {
                    switch (item.Day.DayOfWeek)
                    {
                        case DayOfWeek.Monday:
                            daysOfWeek[1] += item.Amounts;
                            break;
                        case DayOfWeek.Tuesday:
                            daysOfWeek[2] += item.Amounts;
                            break;
                        case DayOfWeek.Wednesday:
                            daysOfWeek[3] += item.Amounts;
                            break;
                        case DayOfWeek.Thursday:
                            daysOfWeek[4] += item.Amounts;
                            break;
                        case DayOfWeek.Friday:
                            daysOfWeek[5] += item.Amounts;
                            break;
                        case DayOfWeek.Saturday:
                            daysOfWeek[6] += item.Amounts;
                            break;
                        case DayOfWeek.Sunday:
                            daysOfWeek[0] += item.Amounts;
                            break;
                    }
                }
            }

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Average",
                    Values = new ChartValues<double>
                    {
                        daysOfWeek[1] / Avg,
                        daysOfWeek[2] / Avg,
                        daysOfWeek[3] / Avg,
                        daysOfWeek[4] / Avg,
                        daysOfWeek[5] / Avg,
                        daysOfWeek[6] / Avg,
                        daysOfWeek[0] / Avg
                    }
                }
            };

            //adding series will update and animate the chart automatically
            SeriesCollection.Add(new ColumnSeries
            {
                Title = "This Week",
                Values = new ChartValues<double>
                {
                    thisWeek[1],
                    thisWeek[2],
                    thisWeek[3],
                    thisWeek[4],
                    thisWeek[5],
                    thisWeek[6],
                    thisWeek[0]
                }
            });

            Labels = new[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            Formatter = value => value.ToString("N");
        }

        public DateTime StartOfWeek(DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = dt.DayOfWeek - startOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }
            return dt.AddDays(-1 * diff).Date;
        }

        private SeriesCollection _seriesCollection;
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }


        public void UpdateValues()
        {
            SeriesCollection.Add(new ColumnSeries
            {
                Title = "This Week",
                Values = new ChartValues<double>
                {
                    thisWeek[1],
                    thisWeek[2],
                    thisWeek[3],
                    thisWeek[4],
                    thisWeek[5],
                    thisWeek[6],
                    thisWeek[0]
                }
            });

            Console.WriteLine(SeriesCollection.IsSynchronized);
        }
    }
}
