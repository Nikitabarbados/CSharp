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
        set { 
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
        set 
        {
            middleName = value;
        }
    }
    public string Address {

        get { 
            return address; 
        } 
        set { 
            address = value; 
        }
    }
    public string Phone { 

        get { 
            return phone; 
        }
        set { 
            phone = value; 
        } 
    }
    public DateTime BirthDate { 
        get {
            return birthDate; 
        } 
        set {
            birthDate = value;
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
