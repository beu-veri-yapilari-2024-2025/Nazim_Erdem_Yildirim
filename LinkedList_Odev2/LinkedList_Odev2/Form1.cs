using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Security;

namespace LinkedList_Odev2
{
    public class Node
    {
   
        public int StudentNo { get; set; }
        public string CourseCode { get; set; }
        public string LetterGrade { get; set; }

        // Ba�lant� Alanlar� (Pointers)
        public Node NextCourse { get; set; }     // Ayn� ��rencinin bir sonraki dersi (Ogrenci-Ders ba�lant�s�)
        public Node NextStudent { get; set; }    // Ayn� dersteki bir sonraki ��renci (Ders-Ogrenci ba�lant�s�)

        public Node(int studentNo, string courseCode, string letterGrade)
        {
            this.StudentNo = studentNo;
            this.CourseCode = courseCode;
            this.LetterGrade = letterGrade;
            this.NextCourse = null;
            this.NextStudent = null;
        }

        public override string ToString()
        {
            return $"[No: {StudentNo}, Ders: {CourseCode}, Not: {LetterGrade}]";
        }
    }

    public class LinkedListManager
    {
        // Anahtar olarak ��renci Numaras�, de�er olarak o ��rencinin ilk Node'u
        private Dictionary<int, Node> StudentHeads = new Dictionary<int, Node>();

        // Anahtar olarak Ders Kodu, de�er olarak o dersi alan ilk ��rencinin Node'u
        private Dictionary<string, Node> CourseHeads = new Dictionary<string, Node>();

        private bool Add(int studentNo, string courseCode, string letterGrade)
        {
            // Kontrol: Ayn� ��rencinin ayn� dersi var m�?
            if (StudentHeads.ContainsKey(studentNo))
            {
                Node current = StudentHeads[studentNo];
                while (current != null)
                {
                    if (current.CourseCode.Equals(courseCode, StringComparison.OrdinalIgnoreCase))
                    {
                        return false; // Kay�t zaten var
                    }
                    current = current.NextCourse;
                }
            }

            Node newNode = new Node(studentNo, courseCode.ToUpper(), letterGrade.ToUpper());

            // 1. ��renci Ba�lant�s� (NextCourse)
            if (!StudentHeads.ContainsKey(studentNo))
            {
                StudentHeads.Add(studentNo, newNode);
            }
            else
            {
                Node current = StudentHeads[studentNo];
                while (current.NextCourse != null)
                {
                    current = current.NextCourse;
                }
                current.NextCourse = newNode;
            }

            // 2. Ders Ba�lant�s� (NextStudent)
            if (!CourseHeads.ContainsKey(courseCode))
            {
                CourseHeads.Add(courseCode, newNode);
            }
            else
            {
                Node current = CourseHeads[courseCode];
                while (current.NextStudent != null)
                {
                    current = current.NextStudent;
                }
                current.NextStudent = newNode;
            }

            return true;
        }

        // Form Kodundaki Metotlar:
        public bool AddCourseToStudent(int studentNo, string courseCode, string letterGrade) => Add(studentNo, courseCode, letterGrade);
        public bool AddStudentToCourse(int studentNo, string courseCode, string letterGrade) => Add(studentNo, courseCode, letterGrade);

        public bool Remove(int studentNo, string courseCode)
        {
            courseCode = courseCode.ToUpper();
            bool removedFromStudentList = false;

            // 1. ��renci (Ders) Ba�lant�s�ndan Silme
            if (StudentHeads.ContainsKey(studentNo))
            {
                Node head = StudentHeads[studentNo];
                Node prev = null;
                Node current = head;

                while (current != null && !current.CourseCode.Equals(courseCode, StringComparison.OrdinalIgnoreCase))
                {
                    prev = current;
                    current = current.NextCourse;
                }
                if (current != null)
                {
                    if (prev == null)
                    {
                        if (current.NextCourse != null)
                            StudentHeads[studentNo] = current.NextCourse;
                        else
                            StudentHeads.Remove(studentNo);
                    }
                    else
                    {
                        prev.NextCourse = current.NextCourse;
                    }
                    removedFromStudentList = true;
                }
            }

            // 2. Ders (��renci) Ba�lant�s�ndan Silme
            if (CourseHeads.ContainsKey(courseCode))
            {
                Node head = CourseHeads[courseCode];
                Node prev = null;
                Node current = head;

                while (current != null && current.StudentNo != studentNo)
                {
                    prev = current;
                    current = current.NextStudent;
                }

                if (current != null)
                {
                    if (prev == null)
                    {
                        if (current.NextStudent != null)
                            CourseHeads[courseCode] = current.NextStudent;
                        else
                            CourseHeads.Remove(courseCode);
                    }
                    else
                    {
                        prev.NextStudent = current.NextStudent;
                    }
                }
            }

            return removedFromStudentList; // Sadece ��renci listesinden silinip silinmedi�ini kontrol etmek yeterli
        }

        public bool RemoveCourseFromStudent(int studentNo, string courseCode) => Remove(studentNo, courseCode);
        public bool RemoveStudentFromCourse(int studentNo, string courseCode) => Remove(studentNo, courseCode);

       

        // Bir ��rencinin ald��� t�m dersleri ders koduna g�re s�ral� listeleme
        public List<Node> GetCoursesOfStudent(int studentNo)
        {
            List<Node> list = new List<Node>();
            if (StudentHeads.ContainsKey(studentNo))
            {
                Node current = StudentHeads[studentNo];
                while (current != null)
                {
                    list.Add(current);
                    current = current.NextCourse;
                }
            }
            return list.OrderBy(n => n.CourseCode).ToList(); // Ders koduna g�re s�ralama
        }

        // Bir dersteki t�m ��rencileri numara s�ras�na g�re s�ral� listeleme
        public List<Node> GetStudentsInCourse(string courseCode)
        {
            courseCode = courseCode.ToUpper();
            List<Node> list = new List<Node>();
            if (CourseHeads.ContainsKey(courseCode))
            {
                Node current = CourseHeads[courseCode];
                while (current != null)
                {
                    list.Add(current);
                    current = current.NextStudent;
                }
            }
            return list.OrderBy(n => n.StudentNo).ToList(); // ��renci numaras�na g�re s�ralama
        }
    }
    public partial class Form1 : Form
    {
        // LinkedListManager art�k tan�mland��� i�in hata vermeyecektir
        LinkedListManager manager = new LinkedListManager();

        public Form1()
        {
            InitializeComponent();
            InitializeData(); // Ba�lang�� verisi eklemek i�in
        }

        private void InitializeData()
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Y�kleme i�lemleri
        }

        //Bir ��renciye yeni ders ekleme
        private void BtnDersEkle_Click(object sender, EventArgs e)
        {
            // Kullan�c�dan al�nan verilerde hata kontrol� yap�lmas� �nerilir (TryGetInputs gibi)
            int no = int.Parse(TxtOgrNo.Text);
            string kod = TxtDersKodu.Text;
            string not = TxtHarfNotu.Text;

            if (manager.AddCourseToStudent(no, kod, not))
                MessageBox.Show("��renciye Ders Eklendi :) ");
            else
                MessageBox.Show("HATA: Kay�t zaten mevcut veya giri� hatal�.");
        }

        // Derse ��renci Ekleme
        private void BtnOgrenciEkle_Click(object sender, EventArgs e)
        {
            int no = int.Parse(TxtOgrNo.Text);
            string kod = TxtDersKodu.Text;
            string not = TxtHarfNotu.Text;

            if (manager.AddStudentToCourse(no, kod, not))
                MessageBox.Show("��renci Ba�ar�yla Eklendi :)");
            else
                MessageBox.Show("HATA: Kay�t zaten mevcut veya giri� hatal�.");
        }

        //Bir ��rencinin Bir Dersini Silme
        private void BtnDersSil_Click(object sender, EventArgs e)
        {
            int no = int.Parse(TxtOgrNo.Text);
            string kod = TxtDersKodu.Text;

            if (manager.RemoveCourseFromStudent(no, kod))
                MessageBox.Show("��rencinin Dersi Ba�ar�yla Silindi !");
            else
                MessageBox.Show("HATA: Silinecek kay�t bulunamad�.");
        }

        //Bir Dersteki bir ��renciyi Silme
        private void BtnOgrenciSil_Click(object sender, EventArgs e)
        {
            int no = int.Parse(TxtOgrNo.Text);
            string kod = TxtDersKodu.Text;

            if (manager.RemoveStudentFromCourse(no, kod))
                MessageBox.Show("Dersteki ��renci Silindi !");
            else
                MessageBox.Show("HATA: Silinecek kay�t bulunamad�.");
        }

        // Bir ��rencinin ald��� t�m dersleri ders koduna g�re listeleme (Buton 6)
        private void BtnOgrList_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            int no = int.Parse(TxtOgrNo.Text);
            var list = manager.GetCoursesOfStudent(no);

            listBox1.Items.Add($"��renci No {no}'nun Ald��� Dersler");

            foreach (var item in list)
            {
                // Form kodunuzda 'item.StudentNo' olarak ge�en �zellikler art�k Node s�n�f�nda mevcut
                listBox1.Items.Add($"No: {item.StudentNo} | Ders: {item.CourseCode} | Not: {item.LetterGrade}");
            }
        }

        // Bir dersteki t�m ��rencileri numara s�ras�na g�re s�ral� listeleme (Buton 5)
        private void BtnDersListele_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string kod = TxtDersKodu.Text;
            var list = manager.GetStudentsInCourse(kod);

            listBox1.Items.Add($"{kod} Dersindeki ��renciler");

            foreach (var item in list)
            {
                listBox1.Items.Add($"No: {item.StudentNo} | Ders: {item.CourseCode} | Not: {item.LetterGrade}");
            }
        }
    }
}