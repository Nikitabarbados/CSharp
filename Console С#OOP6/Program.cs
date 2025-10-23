using System;
class StudentManagementException : ApplicationException
{
    public StudentManagementException(string message) : base(message) {}
}

class InvalidGradeException : StudentManagementException
{
    public int InvalidValue { 
        get; set;
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
        get; set;
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
        get; set;
    }

    public GroupFullException(string message, int maxSize) : base(message)
    {
        MaxSize = maxSize;
    }
}

class InvalidGroupDataException : GroupManagementException
{
    public string FieldName { 
        get; set; 
    }

    public InvalidGroupDataException(string message, string field) : base(message)
    {
        FieldName = field;
    }
}

class TransferFailedException : GroupManagementException
{
    public string StudentName { 
        get; set; 
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

    private int[] credits;
    private int[] courseWorks;
    private int[] exams;

    public Student(string ln, string fn, string mn, DateTime bd, string addr, string ph)
    {
        if (ln == "" || fn == "")
            throw new InvalidStudentDataException("Невірні дані студента", "Ім’я або Прізвище");

        lastName = ln;
        firstName = fn;
        middleName = mn;
        birthDate = bd;
        address = addr;
        phone = ph;
        credits = new int[3];
        courseWorks = new int[2];
        exams = new int[3];
    }

    public void SetCredits(int a, int b, int c)
    {
        ValidateGrade(a);
        ValidateGrade(b);
        ValidateGrade(c);
        credits[0] = a; 
        credits[1] = b; 
        credits[2] = c;
    }

    public void SetCourseWorks(int a, int b)
    {
        ValidateGrade(a);
        ValidateGrade(b);
        courseWorks[0] = a;
        courseWorks[1] = b;
    }

    public void SetExams(int a, int b, int c)
    {
        ValidateGrade(a);
        ValidateGrade(b);
        ValidateGrade(c);
        exams[0] = a;
        exams[1] = b; 
        exams[2] = c;
    }

    private void ValidateGrade(int grade)
    {
        if (grade < 0 || grade > 100)
            throw new InvalidGradeException("Недопустима оцінка: " + grade, grade);
    }

    public double Average()
    {
        int sum = 0;
        int count = credits.Length + courseWorks.Length + exams.Length;

        for (int i = 0; i < credits.Length; i++) 
            sum += credits[i];
        for (int i = 0; i < courseWorks.Length; i++)
            sum += courseWorks[i];
        for (int i = 0; i < exams.Length; i++) 
            sum += exams[i];

        return (double)sum / count;
    }

    public void Show()
    {
        Console.WriteLine("Студент: " + lastName + " " + firstName + " " + middleName);
        Console.WriteLine("Середній бал: " + Average());
        Console.WriteLine();
    }

    public string LastName { 
        get { 
            return lastName; 
        }
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
        if (name == "" || spec == "")
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
        Console.WriteLine("Група: " + groupName + " (" + specialization + "), Курс: " + course);
        for (int i = 0; i < count; i++)
        {
            students[i].Show();
        }
    }

    public void TransferStudent(string lastName, Group otherGroup)
    {
        int index = -1;
        for (int i = 0; i < count; i++)
        {
            if (students[i].LastName == lastName)
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
}

class Program
{
    static void Main()
    {
        try
        {
            Student s1 = new Student("Іваненко", "Іван", "Іванович", new DateTime(2003, 5, 12), "Київ", "123-456");
            s1.SetExams(80, 90, 110);

            Student s2 = new Student("Петренко", "Петро", "Петрович", new DateTime(2004, 7, 22), "Львів", "987-654");
            s2.SetExams(50, 60, 70);

            Group g1 = new Group("ІТ-21", "Інформатика", 2);
            Group g2 = new Group("ІТ-22", "Інформатика", 2);

            g1.AddStudent(s1);
            g1.AddStudent(s2);

            g1.TransferStudent("Сидоренко", g2);
        }
        catch (InvalidGradeException ex)
        {
            Console.WriteLine("Помилка оцінки: " + ex.Message + " (значення: " + ex.InvalidValue + ")");
        }
        catch (StudentNotFoundException ex)
        {
            Console.WriteLine("Помилка: студент не знайдений — " + ex.StudentName);
        }
        catch (GroupFullException ex)
        {
            Console.WriteLine("Група переповнена (макс: " + ex.MaxSize + ")");
        }
        catch (ApplicationException ex)
        {
            Console.WriteLine("Сталася помилка: " + ex.Message);
        }

        Console.WriteLine("\nПрограма завершила роботу.");
    }
}
