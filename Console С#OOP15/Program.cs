using System;
using System.Collections;
using System.Collections.Generic;
class StudentManagementException : ApplicationException
{
    public StudentManagementException(string message) : base(message) {}
}

class InvalidGradeException : StudentManagementException
{
    public int InvalidValue {
        get;
        set; 
    }
    public InvalidGradeException(string message, int value) : base(message)
    {
        InvalidValue = value;
    }
}

class StudentNotFoundException : StudentManagementException
{
    public string StudentName {
        get;
        set;
    }
    public StudentNotFoundException(string message, string name) : base(message)
    {
        StudentName = name;
    }
}

class InvalidStudentDataException : StudentManagementException
{
    public string FieldName { 
        get;
        set;
    }
    public InvalidStudentDataException(string message, string field) : base(message)
    {
        FieldName = field;
    }
}

class GroupManagementException : ApplicationException
{
    public GroupManagementException(string message) : base(message) {}
}

class GroupFullException : GroupManagementException
{
    public int MaxSize { 
        get;
        set;
    }
    public GroupFullException(string message, int maxSize) : base(message)
    {
        MaxSize = maxSize;
    }
}

class InvalidGroupDataException : GroupManagementException
{
    public string FieldName {
        get;
        set; 
    }
    public InvalidGroupDataException(string message, string field) : base(message)
    {
        FieldName = field;
    }
}

class TransferFailedException : GroupManagementException
{
    public string StudentName {
        get;
        set; 
    }
    public TransferFailedException(string message, string name) : base(message)
    {
        StudentName = name;
    }
}

class Student
{
    private string lastName;
    private string firstName;
    private string middleName;
    private DateTime birthDate;
    private string address;
    private string phone;

    public List<int> Credits { get; private set; } = new List<int>();
    public List<int> CourseWorks { get; private set; } = new List<int>();
    public List<int> Exams { get; private set; } = new List<int>();

    public Student(string ln, string fn, string mn, DateTime bd, string addr, string ph)
    {
        if (string.IsNullOrWhiteSpace(ln) || string.IsNullOrWhiteSpace(fn))
            throw new InvalidStudentDataException("Невірні дані студента", "Ім’я або Прізвище");

        lastName = ln;
        firstName = fn;
        middleName = mn;
        birthDate = bd;
        address = addr;
        phone = ph;
    }

    private void ValidateGrade(int grade)
    {
        if (grade < 0 || grade > 100)
            throw new InvalidGradeException($"Недопустима оцінка: {grade}", grade);
    }

    public void AddCredit(int grade)
    {
        ValidateGrade(grade);
        Credits.Add(grade);
    }

    public void AddCourseWork(int grade)
    {
        ValidateGrade(grade);
        CourseWorks.Add(grade);
    }

    public void AddExam(int grade)
    {
        ValidateGrade(grade);
        Exams.Add(grade);
    }

    public double Average()
    {
        var allGrades = Credits.Concat(CourseWorks).Concat(Exams).ToList();
        return allGrades.Count == 0 ? 0 : allGrades.Average();
    }

    public double GetAverageGrade() => Average();

    public void Show()
    {
        Console.WriteLine($"Студент: {lastName} {firstName} {middleName}");
        Console.WriteLine($"Середній бал: {Average():F2}");
        Console.WriteLine();
    }

    public string Name => firstName;
    public string Lastname => lastName;
    public int Age => DateTime.Now.Year - birthDate.Year;
    public double AverageGrade => Average();

    public static bool operator > (Student s1, Student s2) => s1.Average() > s2.Average();
    public static bool operator < (Student s1, Student s2) => s1.Average() < s2.Average();
    public static bool operator == (Student s1, Student s2)
    {
        if (ReferenceEquals(s1, s2)) 
            return true;
        if (ReferenceEquals(s1, null) || ReferenceEquals(s2, null))
            return false;

        return s1.Average() == s2.Average();
    }
    public static bool operator != (Student s1, Student s2) => !(s1 == s2);

    public override bool Equals(object obj) => obj is Student s && this == s;
    public override int GetHashCode() => Average().GetHashCode();

    public static bool operator true(Student s) => s != null && s.Average() >= 70;
    public static bool operator false(Student s) => !(s != null && s.Average() >= 70);

    public class AverageGradeComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            if (x == null || y == null)
                throw new ArgumentNullException("Student cannot be null");

            int avgCompare = x.AverageGrade.CompareTo(y.AverageGrade);
            if (avgCompare != 0)
                return avgCompare;

            return string.Compare(x.Lastname + x.Name, y.Lastname + y.Name, StringComparison.OrdinalIgnoreCase);
        }
    }

    public class FullNameComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            if (x == null || y == null)
                throw new ArgumentNullException("Студент не може бути нульовим");

            int nameCompare = string.Compare(x.Lastname + x.Name, y.Lastname + y.Name, StringComparison.OrdinalIgnoreCase);
            if (nameCompare != 0)
                return nameCompare;

            return y.AverageGrade.CompareTo(x.AverageGrade);
        }
    }
}
class Group : IEnumerable<Student>
{
    private string groupName;
    private string specialization;
    private int course;
    private Student[] students;
    private int count;

    public delegate bool StudentFilter(Student student);

    public Group(string name, string spec, int c)
    {
        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(spec))
            throw new InvalidGroupDataException("Некоректні дані групи.", "Назва або спеціальність");

        groupName = name;
        specialization = spec;
        course = c;
        students = new Student[50];
        count = 0;
    }

    public void AddStudent(Student s)
    {
        if (count >= students.Length)
            throw new GroupFullException("Група переповнена!", students.Length);

        students[count++] = s;
    }

    public void ShowGroup()
    {
        Console.WriteLine($"Група: {groupName} ({specialization}), Курс: {course}");
        foreach (var s in this)
            s.Show();
    }

    public void TransferStudent(string lastName, Group otherGroup)
    {
        int index = Array.FindIndex(students, 0, count, s => s.Lastname == lastName);
        if (index == -1)
            throw new StudentNotFoundException("Студента не знайдено: " + lastName, lastName);

        otherGroup.AddStudent(students[index]);

        for (int i = index; i < count - 1; i++)
            students[i] = students[i + 1];

        count--;
    }

    public Student this[int index]
    {
        get
        {
            if (index >= 0 && index < count)
                return students[index];

            throw new IndexOutOfRangeException("Invalid student index.");
        }
    }

    public Student this[string lastName]
    {
        get
        {
            for (int i = 0; i < count; i++)
                if (students[i].Lastname == lastName)
                    return students[i];

            throw new StudentNotFoundException("Студента не знайдено", lastName);
        }
    }

    public int Count => count;

    public List<Student> FilterStudents(StudentFilter filter)
    {
        List<Student> result = new List<Student>();

        foreach (var s in this)
            if (filter(s)) result.Add(s);

        return result;
    }
    public IEnumerator<Student> GetEnumerator() => new GroupEnumerator(students, count);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private class GroupEnumerator : IEnumerator<Student>
    {
        private Student[] students;
        private int count;
        private int position = -1;

        public GroupEnumerator(Student[] students, int count)
        {
            students = students;
            count = count;
        }

        public Student Current => students[position];
        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            position++;
            return position < count;
        }

        public void Reset() => position = -1;
        public void Dispose() {}
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Student s1 = new Student("Іваненко", "Іван", "Іванович", new DateTime(2003, 5, 12), "Київ", "123-456");
            s1.AddExam(90);
            s1.AddCredit(80);
            s1.AddCourseWork(85);

            Student s2 = new Student("Петренко", "Петро", "Петрович", new DateTime(2004, 7, 22), "Львів", "987-654");
            s2.AddExam(70);
            s2.AddCredit(75);
            s2.AddCourseWork(60);

            Student s3 = new Student("Бондар", "Богдан", "Олегович", new DateTime(2002, 9, 17), "Одеса", "222-333");
            s3.AddExam(95);
            s3.AddExam(2);
            s3.AddCredit(90);

            Group g1 = new Group("ІТ-21", "Інформатика", 2);
            g1.AddStudent(s1);
            g1.AddStudent(s2);
            g1.AddStudent(s3);

            Console.WriteLine("\n=== Всі студенти ===");
            g1.ShowGroup();

            Console.WriteLine("\n=== Відмінники (avg >= 10) ===");
            var excellent = g1.FilterStudents(s => s.GetAverageGrade() >= 10);
            foreach (var s in excellent) s.Show();

            Console.WriteLine("\n=== Імена починаються з 'Б' ===");
            var startsWithB = g1.FilterStudents(s => s.Name.StartsWith("Б", StringComparison.OrdinalIgnoreCase));
            foreach (var s in startsWithB) s.Show();

            Console.WriteLine("\n=== Має хоча б одну '2' за іспит ===");
            var hasTwo = g1.FilterStudents(s => s.Exams.Contains(2));
            foreach (var s in hasTwo) s.Show();

            Console.WriteLine("\n=== Немає оцінок за ДЗ ===");
            var noHW = g1.FilterStudents(s => s.CourseWorks.Count == 0);
            foreach (var s in noHW) s.Show();

            Console.WriteLine("\n=== Середній > середнього по групі ===");
            double groupAvg = g1.Average(st => st.GetAverageGrade());
            var betterThanAvg = g1.FilterStudents(s => s.GetAverageGrade() > groupAvg);
            foreach (var s in betterThanAvg) s.Show();

            Console.WriteLine("\n=== Довжина імені > 5 ===");
            var longNames = g1.FilterStudents(s => s.Name.Length > 5);
            foreach (var s in longNames) s.Show();

            Console.WriteLine("\n=== Однакові оцінки ДЗ з іншими студентами ===");
            var sameHW = g1.FilterStudents(s =>
            {
                return g1.Any(other => other != s &&
                    s.CourseWorks.OrderBy(x => x)
                    .SequenceEqual(other.CourseWorks.OrderBy(x => x)));
            });
            foreach (var s in sameHW) s.Show();

            Console.WriteLine("\n=== Парна кількість оцінок ===");
            var evenCount = g1.FilterStudents(s =>
                (s.Credits.Count + s.CourseWorks.Count + s.Exams.Count) % 2 == 0);
            foreach (var s in evenCount) s.Show();

            Console.WriteLine("\n=== Сума всіх оцінок > 50 ===");
            var sumOver50 = g1.FilterStudents(s =>
                s.Credits.Sum() + s.CourseWorks.Sum() + s.Exams.Sum() > 50);
            foreach (var s in sumOver50) s.Show();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Помилка: " + ex.Message);
        }

        Console.WriteLine("\nПрограма завершила роботу.");
    }
}
