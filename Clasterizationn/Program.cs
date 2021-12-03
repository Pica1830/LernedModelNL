using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clasterizationn
{
    public class Rrr
    {
        public string Segment { get; set; }
        public string gamecategory { get; set; }
        public string subgamecategory { get; set; }
        public string bundle { get; set; }
        public string created { get; set; }
        public string shift { get; set; }
        public string oblast { get; set; }
        public string city { get; set; }
        public string os { get; set; }
        public string osv { get; set; }
    }

    public class Ooo
    {
        public string OblastSegment { get; set; }
        public string Dolya { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader(@"Y:\2019пк1\GG wp\RealData1000.csv"))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    using (var writer = new StreamWriter($@"C:\Users\gazimov.ii0794\Report.csv", false, System.Text.Encoding.UTF8))
                    {
                        using (var cc = new CsvWriter(writer, CultureInfo.InvariantCulture))
                        {
                            List<Ooo> ooos = new List<Ooo>();
                            var records = csv.GetRecords<Rrr>();
                            //int l = records.Count();
                            List<Rrr> f = records.ToList();
                            double l = f.Count();
                            List<string> obl = new List<string>();
                            foreach (var rec in f)
                            {
                                if (obl.Contains(rec.oblast))
                                {
                                    continue;
                                }
                                else
                                {
                                    obl.Add(rec.oblast);
                                }
                            }
                            foreach (var rec in obl)
                            {
                                double i = f.Where(p => p.oblast == rec && p.Segment == "1").Count();
                                double i2 = f.Where(p => p.oblast == rec && p.Segment == "2").Count();
                                double i3 = f.Where(p => p.oblast == rec && p.Segment == "3").Count();
                                double i4 = f.Where(p => p.oblast == rec && p.Segment == "4").Count();
                                double i5 = f.Where(p => p.oblast == rec && p.Segment == "5").Count();
                                if (i != 0)
                                {
                                    ooos.Add(new Ooo { OblastSegment = rec + " Сегмент 1", Dolya = (i * 100 / l).ToString() + "%" });
                                }
                                else
                                {
                                    ooos.Add(new Ooo { OblastSegment = rec + " Сегмент 1", Dolya = (0).ToString() + "%" });
                                }
                                if (i2 != 0)

                                    ooos.Add(new Ooo { OblastSegment = rec + " Сегмент 2", Dolya = (i2 * 100 / l).ToString() + "%" });
                                else
                                    ooos.Add(new Ooo { OblastSegment = rec + " Сегмент 2", Dolya = (0).ToString() + "%" });

                                if (i3 != 0)
                                    ooos.Add(new Ooo { OblastSegment = rec + " Сегмент 3", Dolya = (i3 * 100 / l).ToString() + "%" });
                                else
                                    ooos.Add(new Ooo { OblastSegment = rec + " Сегмент 3", Dolya = (0).ToString() + "%" });
                                if (i4 != 0)
                                    ooos.Add(new Ooo { OblastSegment = rec + " Сегмент 4", Dolya = (i4 * 100 / l).ToString() + "%" });
                                else
                                    ooos.Add(new Ooo { OblastSegment = rec + " Сегмент 4", Dolya = (0).ToString() + "%" });

                                if (i5 != 0)
                                    ooos.Add(new Ooo { OblastSegment = rec + " Сегмент 5", Dolya = (i5 * 100 / l).ToString() + "%" });
                                else
                                    ooos.Add(new Ooo { OblastSegment = rec + " Сегмент 5", Dolya = (0).ToString() + "%" });


                            }
                            IEnumerable<Ooo> ooos1 = ooos;
                            cc.WriteRecords(ooos1);

                        }
                    }
                }
            }
        }
    }
}
