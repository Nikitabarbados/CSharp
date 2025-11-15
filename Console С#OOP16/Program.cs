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

    public List<int> Credits {get; private set;} = new List<int>();
    public List<int> CourseWorks {get; private set;} = new List<int>();
    public List<int> Exams {get; private set;} = new List<int>();

    public event Action LectureMissed;
    public event Action AutomatReceived;
    public event Action ScholarshipAwarded;

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
        if (grade == 100) 
            AutomatReceived?.Invoke();
    }

    public void AddCourseWork(int grade)
    {
        ValidateGrade(grade);
        CourseWorks.Add(grade);
        if (grade == 100) 
            AutomatReceived?.Invoke();
    }

    public void AddExam(int grade)
    {
        ValidateGrade(grade);
        Exams.Add(grade);
        if (grade == 100)
            AutomatReceived?.Invoke();
    }

    public void CheckTime()
    {
        TimeSpan lectureStart = new TimeSpan(16, 45, 0);
        if (DateTime.Now.TimeOfDay > lectureStart)
            LectureMissed?.Invoke();
    }

    public void CheckScholarship()
    {
        if (GetAverageGrade() >= 10)
            ScholarshipAwarded?.Invoke();
    }

    public double AverageGrade => Average();

    public double Average()
    {
        var allGrades = Credits.Concat(CourseWorks).Concat(Exams).ToList();
        return 
            allGrades.Count == 0 ? 0 : allGrades.Average();
    }

    public double GetAverageGrade() => Average();

    public void Show()
    {
        Console.WriteLine($"Студент: {lastName} {firstName} {middleName}");
        Console.WriteLine($"Середній бал: {Average():F2}\n");
    }

    public string Name => firstName;
    public string Lastname => lastName;


    public class AverageGradeComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            if (x == null || y == null)
                throw new ArgumentNullException("Студент не може бути нульовим");

            int avgCompare = x.AverageGrade.CompareTo(y.AverageGrade);
            if (avgCompare != 0)
                return avgCompare;

            return string.Compare(
                x.Lastname + x.Name,
                y.Lastname + y.Name,
                StringComparison.OrdinalIgnoreCase
            );
        }
    }

    public class FullNameComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            if (x == null || y == null)
                throw new ArgumentNullException("Студент не може бути нульовим");

            int nameCompare = string.Compare(
                x.Lastname + x.Name,
                y.Lastname + y.Name,
                StringComparison.OrdinalIgnoreCase
            );

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

    public event Action GroupPartyPlanned;
    public event Action SessionSurvived;

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

            throw new IndexOutOfRangeException("Недійсний індекс студента.");
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

    public List<Student> FilterStudents(StudentFilter filter)
    {
        List<Student> result = new List<Student>();

        foreach (var s in this)
            if (filter(s)) result.Add(s);

        return result;
    }

    public void CheckParty()
    {
        bool allExcellent = this.All(s => s.GetAverageGrade() >= 90);
        if (allExcellent)
            GroupPartyPlanned?.Invoke();
    }

    public void CheckSession()
    {
        bool everyonePassed = this.All(s => s.Exams.All(g => g >= 60));
        if (everyonePassed)
            SessionSurvived?.Invoke();
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
            return
                position < count;
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
            Student s2 = new Student("Петренко", "Петро", "Петрович", new DateTime(2004, 7, 22), "Львів", "987-654");
            Student s3 = new Student("Бондар", "Богдан", "Олегович", new DateTime(2002, 9, 17), "Одеса", "222-333");

            s1.LectureMissed += () => Console.WriteLine("Швидко вмикай онлайн-трансляцію!");
            s1.AutomatReceived += () => Console.WriteLine("Вітаємо з автоматом! Святкуємо кавою!");
            s1.ScholarshipAwarded += () => Console.WriteLine("Вітаємо! Ви отримуєте стипендію!");

            s2.LectureMissed += () => Console.WriteLine("Ти запізнився на пару!");
            s2.AutomatReceived += () => Console.WriteLine("Автомат отримано! Кава?");
            s2.ScholarshipAwarded += () => Console.WriteLine("Стипендія нарахована!");

            Group g1 = new Group("ІТ-21", "Інформатика", 2);

            g1.GroupPartyPlanned += () => Console.WriteLine("Свято групи! Піцца для всіх!");
            g1.SessionSurvived += () => Console.WriteLine("Ура! Всі здали сесію! Йдемо в парк!");

            s1.AddExam(100); 
            s1.AddCredit(85);
            s1.AddCourseWork(90);

            s2.AddExam(70);
            s2.AddCredit(75);

            s3.AddExam(95);
            s3.AddExam(60);

            g1.AddStudent(s1);
            g1.AddStudent(s2);
            g1.AddStudent(s3);

            Console.WriteLine("\n=== Перевірка подій STUDENT ===");
            s1.CheckTime();
            s1.CheckScholarship();

            Console.WriteLine("\n=== Перевірка подій GROUP ===");
            g1.CheckParty();
            g1.CheckSession();

        }
        catch (Exception ex)
        {
            Console.WriteLine("Помилка: " + ex.Message);
        }

        Console.WriteLine("\nПрограма завершила роботу.");
    }
}
