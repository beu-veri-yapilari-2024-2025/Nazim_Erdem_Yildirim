using System;

namespace LinkedList_Odev
{
    internal class Program
    {
        // NODE SINIFI
        public class Node
        {
            public string Ad;
            public string Soyad;
            public int Numara;
            public Node Next;

            public Node(string ad, string soyad, int numara)
            {
                Ad = ad;
                Soyad = soyad;
                Numara = numara;
                Next = null;
            }
        }

        // LİST SINIFI
        public class OgrenciListesi
        {
            private Node head;

            public OgrenciListesi()
            {
                head = null;
            }

            // Başa Ekleme
            public void BasaEkle(string ad, string soyad, int numara)
            {
                Node yeni = new Node(ad, soyad, numara);
                yeni.Next = head;
                head = yeni;
                Console.WriteLine($"{ad} {soyad} (No:{numara}) başa eklendi.");
            }

            // Sona Ekleme
            public void SonaEkle(string ad, string soyad, int numara)
            {
                Node yeni = new Node(ad, soyad, numara);
                if (head == null)
                {
                    head = yeni;
                    Console.WriteLine($"{ad} {soyad} (No:{numara}) listeye eklendi (ilk eleman).");
                    return;
                }

                Node temp = head;
                while (temp.Next != null)
                {
                    temp = temp.Next;
                }

                temp.Next = yeni;
                Console.WriteLine($"{ad} {soyad} (No:{numara}) sona eklendi.");
            }

            //  Belirli Numaradan Sonrasına Ekleme
            public void SonrasinaEkle(int hedefNumara, string ad, string soyad, int numara)
            {
                Node temp = head;
                while (temp != null)
                {
                    if (temp.Numara == hedefNumara)
                    {
                        Node yeni = new Node(ad, soyad, numara);
                        yeni.Next = temp.Next;
                        temp.Next = yeni;
                        Console.WriteLine($"{hedefNumara} numaralı öğrenciden sonra {numara} eklendi.");
                        return;
                    }
                    temp = temp.Next;
                }
                Console.WriteLine($"{hedefNumara} numaralı öğrenci bulunamadı!");
            }

            // Belirli Numaradan Öncesine Ekleme
            public void OncesineEkle(int hedefNumara, string ad, string soyad, int numara)
            {
                if (head == null)
                {
                    Console.WriteLine("Liste boş!");
                    return;
                }

                if (head.Numara == hedefNumara)
                {
                    BasaEkle(ad, soyad, numara);
                    return;
                }

                Node temp = head;
                while (temp.Next != null && temp.Next.Numara != hedefNumara)
                {
                    temp = temp.Next;
                }

                if (temp.Next == null)
                {
                    Console.WriteLine($"{hedefNumara} numaralı öğrenci bulunamadı!");
                    return;
                }

                Node yeni = new Node(ad, soyad, numara);
                yeni.Next = temp.Next;
                temp.Next = yeni;
                Console.WriteLine($"{hedefNumara} numaralı öğrenciden önce {numara} eklendi.");
            }

            // Baştan Silme
            public void BastanSil()
            {
                if (head == null)
                {
                    Console.WriteLine("Liste zaten boş!");
                    return;
                }
                Console.WriteLine($"{head.Ad} {head.Soyad} (No:{head.Numara}) silindi.");
                head = head.Next;
            }

            // Sondan Silme
            public void SondanSil()
            {
                if (head == null)
                {
                    Console.WriteLine("Liste boş!");
                    return;
                }

                if (head.Next == null)
                {
                    Console.WriteLine($"{head.Ad} {head.Soyad} (No:{head.Numara}) silindi.");
                    head = null;
                    return;
                }

                Node temp = head;
                while (temp.Next.Next != null)
                {
                    temp = temp.Next;
                }

                Console.WriteLine($"{temp.Next.Ad} {temp.Next.Soyad} (No:{temp.Next.Numara}) silindi.");
                temp.Next = null;
            }

            // Belirli Numarayı Silme
            public void DegerSil(int hedefNumara)
            {
                if (head == null)
                {
                    Console.WriteLine("Liste boş!");
                    return;
                }

                if (head.Numara == hedefNumara)
                {
                    BastanSil();
                    return;
                }

                Node temp = head;
                while (temp.Next != null && temp.Next.Numara != hedefNumara)
                {
                    temp = temp.Next;
                }

                if (temp.Next == null)
                {
                    Console.WriteLine($"{hedefNumara} numaralı öğrenci bulunamadı!");
                    return;
                }

                Console.WriteLine($"{temp.Next.Ad} {temp.Next.Soyad} (No:{temp.Next.Numara}) silindi.");
                temp.Next = temp.Next.Next;
            }

            // Arama
            public void Ara(int numara)
            {
                Node temp = head;
                while (temp != null)
                {
                    if (temp.Numara == numara)
                    {
                        Console.WriteLine($"Öğrenci bulundu: {temp.Ad} {temp.Soyad} (No:{temp.Numara})");
                        return;
                    }
                    temp = temp.Next;
                }
                Console.WriteLine($"{numara} numaralı öğrenci bulunamadı!");
            }

            // Listeleme
            public void Listele()
            {
                if (head == null)
                {
                    Console.WriteLine("Liste boş!");
                    return;
                }

                Node temp = head;
                Console.WriteLine("\n--- Öğrenci Listesi ---");
                while (temp != null)
                {
                    Console.WriteLine($"Ad: {temp.Ad}, Soyad: {temp.Soyad}, No: {temp.Numara}");
                    temp = temp.Next;
                }
                Console.WriteLine("------------------------\n");
            }
        }

        
        static void Main(string[] args)
        {
            OgrenciListesi liste = new OgrenciListesi();
            bool devam = true;

            while (devam)
            {
                Console.WriteLine("\n<-- ÖĞRENCİ LİSTESİ MENÜSÜ -->");
                Console.WriteLine("1. Listeyi Göster");
                Console.WriteLine("2. Başa Ekle");
                Console.WriteLine("3. Sona Ekle");
                Console.WriteLine("4. Belirli Numaradan Sonrasına Ekle");
                Console.WriteLine("5. Belirli Numaradan Öncesine Ekle");
                Console.WriteLine("6. Baştan Sil");
                Console.WriteLine("7. Sondan Sil");
                Console.WriteLine("8. Belirli Numarayı Sil");
                Console.WriteLine("9. Arama Yap");
                Console.WriteLine("0. Çıkış");
                Console.Write("Seçiminiz: ");
                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        liste.Listele();
                        break;

                    case "2":
                        OgrenciGir("Başa Ekle", out string ad1, out string soyad1, out int no1);
                        liste.BasaEkle(ad1, soyad1, no1);
                        break;

                    case "3":
                        OgrenciGir("Sona Ekle", out string ad2, out string soyad2, out int no2);
                        liste.SonaEkle(ad2, soyad2, no2);
                        break;

                    case "4":
                        Console.Write("Sonrasına eklenecek öğrencinin numarasını gir: ");
                        int hedefNo1 = Convert.ToInt32(Console.ReadLine());
                        OgrenciGir("Yeni Öğrenci", out string ad3, out string soyad3, out int no3);
                        liste.SonrasinaEkle(hedefNo1, ad3, soyad3, no3);
                        break;

                    case "5":
                        Console.Write("Öncesine eklenecek öğrencinin numarasını gir: ");
                        int hedefNo2 = Convert.ToInt32(Console.ReadLine());
                        OgrenciGir("Yeni Öğrenci", out string ad4, out string soyad4, out int no4);
                        liste.OncesineEkle(hedefNo2, ad4, soyad4, no4);
                        break;

                    case "6":
                        liste.BastanSil();
                        break;

                    case "7":
                        liste.SondanSil();
                        break;

                    case "8":
                        Console.Write("Silinecek öğrencinin numarasını gir: ");
                        int silNo = Convert.ToInt32(Console.ReadLine());
                        liste.DegerSil(silNo);
                        break;

                    case "9":
                        Console.Write("Aranacak öğrencinin numarasını gir: ");
                        int araNo = Convert.ToInt32(Console.ReadLine());
                        liste.Ara(araNo);
                        break;

                    case "0":
                        devam = false;
                        Console.WriteLine("Programdan çıkılıyor...");
                        break;

                    default:
                        Console.WriteLine("Geçersiz seçim!");
                        break;
                }
            }
        }

        // Öğrenci Bilgisi Girişi Yardımcı Fonksiyon
        static void OgrenciGir(string islem, out string ad, out string soyad, out int numara)
        {
            Console.WriteLine($"\n{islem} için öğrenci bilgilerini girin:");
            Console.Write("Ad: ");
            ad = Console.ReadLine();
            Console.Write("Soyad: ");
            soyad = Console.ReadLine();
            Console.Write("Numara: ");
            numara = Convert.ToInt32(Console.ReadLine());
            Console.ReadLine();
        }

    }
}
