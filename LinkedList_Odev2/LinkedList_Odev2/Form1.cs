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

        // Baðlantý Alanlarý (Pointers)
        public Node NextCourse { get; set; }     // Ayný öðrencinin bir sonraki dersi (Ogrenci-Ders baðlantýsý)
        public Node NextStudent { get; set; }    // Ayný dersteki bir sonraki öðrenci (Ders-Ogrenci baðlantýsý)

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
        // Anahtar olarak Öðrenci Numarasý, deðer olarak o öðrencinin ilk Node'u
        private Dictionary<int, Node> StudentHeads = new Dictionary<int, Node>();

        // Anahtar olarak Ders Kodu, deðer olarak o dersi alan ilk öðrencinin Node'u
        private Dictionary<string, Node> CourseHeads = new Dictionary<string, Node>();

        private bool Add(int studentNo, string courseCode, string letterGrade)
        {
            // Kontrol: Ayný öðrencinin ayný dersi var mý?
            if (StudentHeads.ContainsKey(studentNo))
            {
                Node current = StudentHeads[studentNo];
                while (current != null)
                {
                    if (current.CourseCode.Equals(courseCode, StringComparison.OrdinalIgnoreCase))
                    {
                        return false; // Kayýt zaten var
                    }
                    current = current.NextCourse;
                }
            }

            Node newNode = new Node(studentNo, courseCode.ToUpper(), letterGrade.ToUpper());

            // 1. Öðrenci Baðlantýsý (NextCourse)
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

            // 2. Ders Baðlantýsý (NextStudent)
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

            // 1. Öðrenci (Ders) Baðlantýsýndan Silme
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

            // 2. Ders (Öðrenci) Baðlantýsýndan Silme
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

            return removedFromStudentList; // Sadece öðrenci listesinden silinip silinmediðini kontrol etmek yeterli
        }

        public bool RemoveCourseFromStudent(int studentNo, string courseCode) => Remove(studentNo, courseCode);
        public bool RemoveStudentFromCourse(int studentNo, string courseCode) => Remove(studentNo, courseCode);

       

        // Bir öðrencinin aldýðý tüm dersleri ders koduna göre sýralý listeleme
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
            return list.OrderBy(n => n.CourseCode).ToList(); // Ders koduna göre sýralama
        }

        // Bir dersteki tüm öðrencileri numara sýrasýna göre sýralý listeleme
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
            return list.OrderBy(n => n.StudentNo).ToList(); // Öðrenci numarasýna göre sýralama
        }
    }
    public partial class Form1 : Form
    {
        // LinkedListManager artýk tanýmlandýðý için hata vermeyecektir
        LinkedListManager manager = new LinkedListManager();

        public Form1()
        {
            InitializeComponent();
            InitializeData(); // Baþlangýç verisi eklemek için
        }

        private void InitializeData()
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Yükleme iþlemleri
        }

        //Bir öðrenciye yeni ders ekleme
        private void BtnDersEkle_Click(object sender, EventArgs e)
        {
            // Kullanýcýdan alýnan verilerde hata kontrolü yapýlmasý önerilir (TryGetInputs gibi)
            int no = int.Parse(TxtOgrNo.Text);
            string kod = TxtDersKodu.Text;
            string not = TxtHarfNotu.Text;

            if (manager.AddCourseToStudent(no, kod, not))
                MessageBox.Show("Öðrenciye Ders Eklendi :) ");
            else
                MessageBox.Show("HATA: Kayýt zaten mevcut veya giriþ hatalý.");
        }

        // Derse Öðrenci Ekleme
        private void BtnOgrenciEkle_Click(object sender, EventArgs e)
        {
            int no = int.Parse(TxtOgrNo.Text);
            string kod = TxtDersKodu.Text;
            string not = TxtHarfNotu.Text;

            if (manager.AddStudentToCourse(no, kod, not))
                MessageBox.Show("Öðrenci Baþarýyla Eklendi :)");
            else
                MessageBox.Show("HATA: Kayýt zaten mevcut veya giriþ hatalý.");
        }

        //Bir Öðrencinin Bir Dersini Silme
        private void BtnDersSil_Click(object sender, EventArgs e)
        {
            int no = int.Parse(TxtOgrNo.Text);
            string kod = TxtDersKodu.Text;

            if (manager.RemoveCourseFromStudent(no, kod))
                MessageBox.Show("Öðrencinin Dersi Baþarýyla Silindi !");
            else
                MessageBox.Show("HATA: Silinecek kayýt bulunamadý.");
        }

        //Bir Dersteki bir Öðrenciyi Silme
        private void BtnOgrenciSil_Click(object sender, EventArgs e)
        {
            int no = int.Parse(TxtOgrNo.Text);
            string kod = TxtDersKodu.Text;

            if (manager.RemoveStudentFromCourse(no, kod))
                MessageBox.Show("Dersteki Öðrenci Silindi !");
            else
                MessageBox.Show("HATA: Silinecek kayýt bulunamadý.");
        }

        // Bir öðrencinin aldýðý tüm dersleri ders koduna göre listeleme (Buton 6)
        private void BtnOgrList_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            int no = int.Parse(TxtOgrNo.Text);
            var list = manager.GetCoursesOfStudent(no);

            listBox1.Items.Add($"Öðrenci No {no}'nun Aldýðý Dersler");

            foreach (var item in list)
            {
                // Form kodunuzda 'item.StudentNo' olarak geçen özellikler artýk Node sýnýfýnda mevcut
                listBox1.Items.Add($"No: {item.StudentNo} | Ders: {item.CourseCode} | Not: {item.LetterGrade}");
            }
        }

        // Bir dersteki tüm öðrencileri numara sýrasýna göre sýralý listeleme (Buton 5)
        private void BtnDersListele_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string kod = TxtDersKodu.Text;
            var list = manager.GetStudentsInCourse(kod);

            listBox1.Items.Add($"{kod} Dersindeki Öðrenciler");

            foreach (var item in list)
            {
                listBox1.Items.Add($"No: {item.StudentNo} | Ders: {item.CourseCode} | Not: {item.LetterGrade}");
            }
        }
    }
}