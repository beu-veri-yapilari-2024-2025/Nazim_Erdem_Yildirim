using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matris_Çarpımı
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] A = { { 3, 5, 7 }, { 4, 9, 8 } }; //1. Matris
            int[,] B = { { 2, 4, 6 }, { 1, 5, 3 } }; //2. Matris

            int aSatir = A.GetLength(0);
            int bSutun = B.GetLength(1);
            int aSutun = A.GetLength(1);

            int[,] C = new int[aSatir, bSutun];

            for(int i=0; i<aSatir; i++)       // A'nın satırlarını dolaş
            {
                for(int j=0; j<bSutun; j++)       // B'nin sütunlarını dolaş
                {
                    int toplam = 0;
                    for(int k=0; k<aSatir; k++)     // Ortak elemanları çarp ve topla
                    {
                        toplam += A[i, k] * B[k, j];
                    }
                    C[i, j] = toplam;   // Sonucu C matrisine yaz
                }
            }
            //Sonucu ekrana yazdır
            Console.WriteLine("Sonuç Matrisi: ");
            for(int i=0;i<aSatir; i++)
            {
                for(int j=0;j<bSutun; j++)
                {
                    Console.Write(C[i, j]+"\t");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
