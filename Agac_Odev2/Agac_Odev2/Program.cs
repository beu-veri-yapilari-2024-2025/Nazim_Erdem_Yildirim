using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agac_Odev2
{
    class Node
    {
        public int Data;
        public Node Left;
        public Node Right;

        public Node(int data)
        {
            Data= data;
            Left= null;
            Right= null;
        }
    }

    class İkiliAgac
    {
        public Node Root;

        public void Insert(int value)
        {
            Root = InsertRecursive(Root, value);
        }

        private Node InsertRecursive(Node node, int value)
        {
            if(node == null)
            {
                return new Node(value);
            }
            if(value<node.Data)
            {
                node.Left = InsertRecursive(node.Left, value);
            }
            else
            {
                node.Right = InsertRecursive(node.Right, value);
            }

            return node;
        }

        // PREORDER (Root - Left - Right)
        public void Preorder(Node node)
        {
            if (node == null) return;

            Console.Write(node.Data + " ");
            Preorder(node.Left);
            Preorder(node.Right);
        }

        // INORDER (Left - Root - Right)
        public void Inorder(Node node)
        {
            if (node == null) return;

            Inorder(node.Left);
            Console.Write(node.Data+" ");
            Inorder(node.Right);
        }

        // POSTORDER (Left - Right - Root)
        public void Postorder(Node node)
        {
            if (node == null) return;

            Postorder(node.Left);
            Postorder(node.Right);
            Console.Write(node.Data+" ");
        }

        // LEVEL-ORDER
        public void LevelOrder()
        {
            if(Root == null) return;

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                Node temp = queue.Dequeue();
                Console.Write(temp.Data+" ");

                if(temp.Left != null) queue.Enqueue(temp.Left);
                if(temp.Right != null) queue.Enqueue(temp.Right);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            İkiliAgac ikl = new İkiliAgac();

            Console.Write("Kaç Adet Sayı Girilecek: ");
            int n=int.Parse(Console.ReadLine());

            Console.WriteLine("Sayıları Giriniz: ");
            for (int i = 0; i < n; i++)
            {
                int value = int.Parse(Console.ReadLine());
                ikl.Insert(value);
            }

                Console.WriteLine("\nPreorder: ");
                ikl.Preorder(ikl.Root);

                Console.WriteLine("\nInorder: ");
                ikl.Inorder(ikl.Root);

                Console.WriteLine("\nPostorder: ");
                ikl.Postorder(ikl.Root);

                Console.WriteLine("\nLevel-Order: ");
                ikl.LevelOrder();

                Console.WriteLine();
                Console.ReadLine();
        }
    }
}
