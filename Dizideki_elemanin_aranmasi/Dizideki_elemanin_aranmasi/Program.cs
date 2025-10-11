using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dizideki_elemanin_aranmasi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Bu kodun Notasyonu O(n)'dir

            int[] Sayilar = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };

            //Aranacak sayının girilmesi
            Console.Write("Aranan Sayıyı giriniz: ");
            int aranan=Convert.ToInt32(Console.ReadLine());

            // Bulunup bulunmadığını kontrol edecek değişken
            bool bulundu = false;

            for(int i = 0; i < Sayilar.Length; i++)
            {
                if (Sayilar[i] == aranan)
                {
                    Console.Write($"Elemanın bulunduğu index {i}");
                    bulundu = true;
                    break;
                }
            }

            if(!bulundu)
            {
                Console.WriteLine("Eleman Dizide Bulunamadı");
            }
            Console.ReadLine();
        }
    }
}
