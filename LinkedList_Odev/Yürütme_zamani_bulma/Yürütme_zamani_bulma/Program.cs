using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yürütme_zamani_bulma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Bu algoritmanın notasyonu O(n)'dir

            int[] Sayilar = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
            // Zaman ölçmeyi başlatma
            Stopwatch zamanlayici = Stopwatch.StartNew();
            zamanlayici.Start();

            // Dizideki sayıların toplamı
            int toplam = 0;
            foreach (int sayi in Sayilar)
            {
                toplam += sayi;
            }

            // Zaman ölçmeyi durdurma
            zamanlayici.Stop();
            
            //Sonuçları yazdırma
            Console.WriteLine("Sayıların Toplamı: " + toplam);
            Console.WriteLine("Yürütme Süresi: " + zamanlayici.Elapsed.TotalMilliseconds + " milisaniye");
            Console.ReadLine();
        }
    }
}
