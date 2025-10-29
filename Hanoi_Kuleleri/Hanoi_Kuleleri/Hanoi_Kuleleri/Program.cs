using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanoi_Kuleleri
{
    internal class Program
    {
        static void Hanoi(int n,char kaynak, char hedef, char yardimci)
        {
            if (n == 1)
            {
                Console.WriteLine($"Disk 1 {kaynak} çubuğundan {hedef} çubuğuna taşındı");
                return;
            }

            Hanoi(n-1, kaynak, yardimci, hedef);

            Console.WriteLine($"Disk {n} {kaynak} çubuğundan {hedef} çubuğuna taşındı");

            Hanoi(n - 1, yardimci, hedef, kaynak);
        }


        static void Main(string[] args)
        {
            Console.Write("Disk Sayısını Giriniz: ");
            int n =int.Parse(Console.ReadLine());

            Console.WriteLine("\nHanoi Kulelerinin Çözümü: \n");
            Hanoi(n, 'A', 'C', 'B');

            Console.WriteLine("İşlem Tamamlandı!");

            Console.ReadLine();
        }
    }
}
