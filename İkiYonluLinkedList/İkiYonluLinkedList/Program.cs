using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace İkiYonluLinkedList
{
    internal class Program
    {

        //Node Sınıfı

        public class Node<T>
        {
            public T Value { get; set; }
            public Node<T> Prev { get; set; }
            public Node<T> Next { get; set; }

            public Node (T value)
            {
                Value=value;
                Prev = null;
                Next = null;
            }
        }

        // İki Yönlü Linked List Sınıfı
        public class ikiyonlulinkedlist<T>
        {
            public Node<T> Head { get; private set; }
            public Node<T> Tail { get; private set; }
            public int Count { get; private set; }

            public ikiyonlulinkedlist()
                {
                Head = null;
                Tail=null; 
                Count=0;
                }

            public void BasaEkle(T value)
            {
                var newNode= new Node<T>(value);
                if(Head==null)
                {
                    Head= Tail = newNode;
                }
                else
                {
                    newNode.Next= Head;
                    Head.Prev = newNode;
                    Head = newNode;
                }
                Count++;
            }

            //Sona Ekleme
            public void SonaEkle(T value)
            {
                var newNode = new Node<T>(value);
                if (Tail == null) // liste boşsa
                {
                    Head = Tail = newNode;
                }
                else
                {
                    Tail.Next = newNode; // son node artık yeni node'a bağlanacak
                    newNode.Prev = Tail;
                    Tail = newNode; // yeni node artık son node
                }
                Count++;
            }

            //Belirli bir değerden sonra ekleme
            public bool SonraEkle(T targetvalue, T newvalue)
            {
                var node = FindNode(targetvalue);
                if (node == null) return false;

                var newNode = new Node<T>(newvalue);

                newNode.Prev = node;
                newNode.Next = node.Next;

                if (node.Next != null)
                    node.Next.Prev = newNode;
                else
                    Tail = newNode; // eğer node sondaysa yeni node artık Tail olur

                node.Next = newNode;

                Count++;
                return true;
            }

            //Belirli Bir Değerden Önce Ekleme

            public bool OnceEkle(T targetvalue, T newvalue)
            {
                var node = FindNode(targetvalue);
                if(node==null) return false;

                var newNode=new Node<T>(newvalue);
                newNode.Next = node;
                newNode.Prev= node.Prev;

                if (node.Prev != null)
                {
                    node.Prev.Next= newNode;
                }
                node.Prev = newNode;

                if(node == Head)
                {
                    Head = newNode;
                }

                Count++;
                return true;
            }

            //Baştan Silme
            public bool BastanSil()
            {
                if(Head==null) return false;

                if(Head == Tail)
                {
                    Head = Tail = null;
                }

                else
                {
                    Head = Head.Next;
                    Head.Prev = null;
                }
                Count--;
                return true;
            }

            //Sondan Sil
            public bool SondanSil()
            {
                if(Tail==null) return false;

                if(Tail == Head)
                {
                    Head = Tail = null;
                }

                else
                {
                    Tail = Tail.Prev;
                    Tail.Next = null;
                }
                Count--;
                return true;
            }

            // Belirli Değeri Silme
            public bool Silme(T value)
            {
                var node = FindNode(value);
                if(node==null) return false;
                if(Head==null) return BastanSil();
                if (Tail == null) return SondanSil();

                node.Prev.Next = node.Next;
                node.Next.Prev = node.Prev;

                Count--;
                return true;
            }

            //Arama
            public bool Arama(T value)
            {
                return FindNode(value) != null;
            }

            //Node Bulucu
            private Node<T> FindNode(T value)
            {
                var current = Head;
                EqualityComparer<T> comparer = EqualityComparer<T>.Default;
                while (current != null)
                {
                    if (comparer.Equals(current.Value, value))
                    {
                        return current;
                    }
                    current = current.Next;
                }
                return null;
            }

            //Listeleme
            public void List()
            {
                var current = Head;
                Console.Write("Head -> ");
                while (current != null)
                {
                    Console.Write(current.Value);
                    if(current.Next != null)
                    {
                        Console.Write("<->");
                    }
                    current = current.Next;
                }
                Console.WriteLine("<- Tail");
            }

            //Tümünü Silme
            public void TumunuSil()
            {
                var current = Head;
                while (current != null)
                {
                    var next = current.Next;
                    current.Prev = null;
                    current.Next = null;
                    current = next;
                }
                Head = Tail = null;
                Count = 0;
            }

            //Diziye Atma
            public T[] ToArray()
            {
                var arr = new T[Count];
                int i = 0;
                var current = Head;
                while (current != null)
                {
                    arr[i++] = current.Value;
                    current = current.Next;
                }
                return arr;
            }

        }
        static void Main(string[] args)
        {
            var dll = new ikiyonlulinkedlist<int>();

            //başa ekleme
            dll.BasaEkle(10);
            dll.BasaEkle(5);

            //Sona Ekle
            dll.SonaEkle(20);
            dll.SonaEkle(25);

            Console.WriteLine("Başlangıç Listesi: ");
            dll.List();

            //Araya Ekleme
            dll.SonraEkle(10, 15);
            Console.WriteLine("10'dan sonra 15 eklendi");
            dll.List();

            //Araya Ekleme
            dll.OnceEkle(20, 18);
            Console.WriteLine("20'den önce 18 eklendi");
            dll.List();

            //Arama
            Console.WriteLine("Liste 15 ekleniyor mu? " + dll.Arama(15));
            Console.WriteLine("Liste 99 içeriyor mu? " + dll.Arama(99));

            //Aradan Silme
            dll.Silme(15);
            Console.WriteLine("15 Silindikten sonra: ");
            dll.List();

            //Baştan Silme
            dll.BastanSil();
            Console.WriteLine("Baştan Silindikten Sonra: ");
            dll.List();

            //Sondan Silme
            dll.SondanSil();
            Console.WriteLine("Sondan Silindikten Sonra: ");
            dll.List();

            //Tümünü diziye atama
            var arr= dll.ToArray();
            Console.WriteLine("Diziye Altarılmış Hali: ["+ string.Join(", ", arr)+"]");

            //Tümünü Silme
            dll.TumunuSil();
            Console.WriteLine("Liste Temizlendikten Sonra: ");
            dll.List();
            Console.WriteLine("Eleman Sayısı: "+ dll.Count);

            Console.WriteLine("\nProgram Sonlandırıldı. Bir Tuşa Basınız...");
            Console.ReadLine();
        }
    }
}
