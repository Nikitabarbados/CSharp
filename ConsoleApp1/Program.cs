using System;


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

    public Student()
    {
        lastName = "";
        firstName = "";
        middleName = "";
        birthDate = DateTime.MinValue;
        address = "";
        phone = "";
        credits = new int[3];
        courseWorks = new int[2];
        exams = new int[3];
    }

    public Student(string ln, string fn, string mn, DateTime bd, string addr, string ph)
    {
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

    public string LastName {
        get {
            return lastName;
        } 
        set 
        { 
            lastName = value; 
        } 
    }
    public string FirstName { 
        get { 
            return firstName;
        } 
        set { 
            firstName = value;
        } 
    }
    public string MiddleName {
        get {
            return middleName;
        }
        set {
            middleName = value;
        }
    }

    public void SetCredits(int a, int b, int c)
    {
        credits[0] = a;
        credits[1] = b;
        credits[2] = c;
    }

    public void SetCourseWorks(int a, int b)
    {
        courseWorks[0] = a;
        courseWorks[1] = b;
    }

    public void SetExams(int a, int b, int c)
    {
        exams[0] = a;
        exams[1] = b;
        exams[2] = c;
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
        Console.WriteLine("Дата народження: " + birthDate.ToShortDateString());
        Console.WriteLine("Адреса: " + address);
        Console.WriteLine("Телефон: " + phone);
        Console.WriteLine("Середній бал: " + Average());
        Console.WriteLine();
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
        groupName = name;
        specialization = spec;
        course = c;
        students = new Student[10];
        count = 0;
    }

    public void AddStudent(Student s)
    {
        if (count < students.Length)
        {
            students[count] = s;
            count++;
        }
    }

    public void ShowGroup()
    {
        Console.WriteLine("Група: " + groupName);
        Console.WriteLine("Спеціальність: " + specialization);
        Console.WriteLine("Курс: " + course);
        for (int i = 0; i < count; i++)
        {
            students[i].Show();
        }
    }

    public void RemoveFailed()
    {
        for (int i = 0; i < count; i++)
        {
            if (students[i].Average() < 60)
            {
                for (int j = i; j < count - 1; j++)
                    students[j] = students[j + 1];
                count--;
                i--;
            }
        }
    }

    public void RemoveWorst()
    {
        if (count == 0) 
            return;
        int worstIndex = 0;
        double worst = students[0].Average();

        for (int i = 1; i < count; i++)
        {
            if (students[i].Average() < worst)
            {
                worst = students[i].Average();
                worstIndex = i;
            }
        }

        for (int j = worstIndex; j < count - 1; j++)
            students[j] = students[j + 1];

        count--;
    }
}

class Program
{
    static void Main()
    {

        Student s1 = new Student("Іваненко", "Іван", "Іванович", new DateTime(2003, 5, 12), "Київ", "123-456");
        s1.SetCredits(80, 75, 90);
        s1.SetCourseWorks(85, 88);
        s1.SetExams(70, 90, 95);

        Student s2 = new Student("Петренко", "Петро", "Петрович", new DateTime(2004, 7, 22), "Львів", "987-654");
        s2.SetCredits(50, 55, 60);
        s2.SetCourseWorks(40, 45);
        s2.SetExams(50, 50, 55);

        Group g = new Group("ІТ-21", "Інформатика", 2);
        g.AddStudent(s1);
        g.AddStudent(s2);

        Console.WriteLine("=== Усі студенти ===");
        g.ShowGroup();

        Console.WriteLine("=== Відрахування тих, хто не склав сесію ===");
        g.RemoveFailed();
        g.ShowGroup();

        Console.ReadLine();
    }
}
