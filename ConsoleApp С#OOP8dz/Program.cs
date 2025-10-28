using System;

class StudentManagementException : ApplicationException
{
    public StudentManagementException(string message) : base(message) { }
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
        get; set;
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
    public GroupManagementException(string message) : base(message) { }
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

    private List<int> credits = new List<int>();
    private List<int> courseWorks = new List<int>();
    private List<int> exams = new List<int>();

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
        credits.Add(grade);
    }

    public void AddCourseWork(int grade)
    {
        ValidateGrade(grade);
        courseWorks.Add(grade);
    }

    public void AddExam(int grade)
    {
        ValidateGrade(grade);
        exams.Add(grade);
    }

    public double Average()
    {
        var allGrades = credits.Concat(courseWorks).Concat(exams).ToList();
        if (allGrades.Count == 0) 
            return 0;

        return allGrades.Average();
    }

    public void Show()
    {
        Console.WriteLine($"Студент: {lastName} {firstName} {middleName}");
        Console.WriteLine($"Середній бал: {Average():F2}");
        Console.WriteLine();
    }

    public string Name
    {
        get => firstName;
        set => firstName = value;
    }

    public string Lastname
    {
        get => lastName;
        set => lastName = value;
    }

    public int Age => DateTime.Now.Year - birthDate.Year;

    public double AverageGrade => Average();

    public static bool operator == (Student s1, Student s2)
    {
        if (ReferenceEquals(s1, s2))
            return true;
        if (ReferenceEquals(s1, null) || ReferenceEquals(s2, null))
            return false;
        return s1.Average() == s2.Average();
    }

    public static bool operator != (Student s1, Student s2)
    {
        return !(s1 == s2);
    }

    public static bool operator > (Student s1, Student s2)
    {
        return s1.Average() > s2.Average();
    }

    public static bool operator < (Student s1, Student s2)
    {
        return s1.Average() < s2.Average();
    }

    public static bool operator true(Student s)
    {
        return s != null && s.Average() >= 70;
    }

    public static bool operator false(Student s)
    {
        return !(s != null && s.Average() >= 70);
    }

    public override bool Equals(object obj)
    {
        if (obj is Student other)
            return this == other;
        return false;
    }

    public override int GetHashCode()
    {
        return Average().GetHashCode();
    }
}

class Group
{
    private string groupName;
    private string specialization;
    private int course;
    private Student[] students;
    private int count;

    public Group(string name, string spec, int c)
    {
        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(spec))
            throw new InvalidGroupDataException("Некоректні дані групи.", "Назва або спеціальність");

        groupName = name;
        specialization = spec;
        course = c;
        students = new Student[5];
        count = 0;
    }

    public void AddStudent(Student s)
    {
        if (count >= students.Length)
            throw new GroupFullException("Група переповнена!", students.Length);

        students[count] = s;
        count++;
    }

    public void ShowGroup()
    {
        Console.WriteLine($"Група: {groupName} ({specialization}), Курс: {course}");
        for (int i = 0; i < count; i++)
            students[i].Show();
    }

    public void TransferStudent(string lastName, Group otherGroup)
    {
        int index = -1;
        for (int i = 0; i < count; i++)
        {
            if (students[i].Lastname == lastName)
            {
                index = i;
                break;
            }
        }

        if (index == -1)
            throw new StudentNotFoundException("Студента не знайдено: " + lastName, lastName);

        try
        {
            otherGroup.AddStudent(students[index]);
        }
        catch (GroupFullException)
        {
            throw new TransferFailedException("Не вдалося перевести студента", lastName);
        }

        for (int j = index; j < count - 1; j++)
            students[j] = students[j + 1];

        count--;
    }

    public Student this[int index]
    {
        get
        {
            if (index >= 0 && index < count)
                return students[index];
            throw new IndexOutOfRangeException("Невірний індекс студента.");
        }
    }

    public Student this[string lastName]
    {
        get
        {
            for (int i = 0; i < count; i++)
            {
                if (students[i].Lastname == lastName)
                    return students[i];
            }
            throw new StudentNotFoundException("Студента не знайдено", lastName);
        }
    }

    public int Count => count;
    public string Specialization => specialization;
    public int Course => course;

    public static bool operator == (Group g1, Group g2)
    {
        if (ReferenceEquals(g1, g2))
            return true;
        if (ReferenceEquals(g1, null) || ReferenceEquals(g2, null))
            return false;
        return g1.count == g2.count;
    }

    public static bool operator != (Group g1, Group g2)
    {
        return !(g1 == g2);
    }

    public static bool operator > (Group g1, Group g2)
    {
        return g1.count > g2.count;
    }

    public static bool operator < (Group g1, Group g2)
    {
        return g1.count < g2.count;
    }

    public override bool Equals(object obj)
    {
        if (obj is Group other)
            return this == other;
        return false;
    }

    public override int GetHashCode()
    {
        return count.GetHashCode();
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Student s1 = new Student("Іваненко", "Іван", "Іванович", new DateTime(2003, 5, 12), "Київ", "123-456");
            s1.AddExam(85);
            s1.AddExam(90);
            s1.AddExam(75);
            s1.AddCredit(95);
            s1.AddCourseWork(88);

            Student s2 = new Student("Петренко", "Петро", "Петрович", new DateTime(2004, 7, 22), "Львів", "987-654");
            s2.AddExam(60);
            s2.AddExam(70);
            s2.AddCredit(65);
            s2.AddCourseWork(75);

            Group g1 = new Group("ІТ-21", "Інформатика", 2);
            Group g2 = new Group("ІТ-22", "Інформатика", 2);

            g1.AddStudent(s1);
            g1.AddStudent(s2);

            g2.AddStudent(new Student("Сидоренко", "Олег", "Іванович", new DateTime(2003, 1, 20), "Одеса", "555-111"));

            Console.WriteLine("=== Перевірка операторів ===");
            Console.WriteLine($"s1 > s2 ? {(s1 > s2)}");
            Console.WriteLine($"g1 > g2 ? {(g1 > g2)}");

            Console.WriteLine("\n=== Перевірка властивостей ===");
            Console.WriteLine($"Ім’я s1: {s1.Name}, Прізвище: {s1.Lastname}, Вік: {s1.Age}, Середній бал: {s1.AverageGrade:F2}");
            Console.WriteLine($"Кількість студентів у g1: {g1.Count}, Спеціальність: {g1.Specialization}, Курс: {g1.Course}");

            Console.WriteLine("\n=== Перевірка індексаторів ===");
            Console.WriteLine($"Перший студент у g1: {g1[0].Lastname}");
            Console.WriteLine($"Пошук студента 'Петренко': {g1["Петренко"].Name}");

            Console.WriteLine("\n=== Список групи ІТ-21 ===");
            g1.ShowGroup();
        }
        catch (ApplicationException ex)
        {
            Console.WriteLine("Помилка: " + ex.Message);
        }

        Console.WriteLine("\nПрограма завершила роботу.");
    }
}