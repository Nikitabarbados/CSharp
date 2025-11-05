using System;
using System.Collections;

class Student
{
    private string lastName;
    private string firstName;
    private string middleName;
    private double averageGrade;

    public Student() { }

    public Student(string ln, string fn, string mn, double avg)
    {
        lastName = ln;
        firstName = fn;
        middleName = mn;
        averageGrade = avg;
    }

    public string LastName => lastName;
    public string FirstName => firstName;
    public string MiddleName => middleName;
    public double AverageGrade => averageGrade;

    public override string ToString()
    {
        return $"{lastName} {firstName} {middleName}, середній бал: {averageGrade}";
    }

    public class AverageGradeComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            if (x == null || y == null)
                throw new ArgumentNullException("Один з об’єктів Student дорівнює null!");

            int result = x.AverageGrade.CompareTo(y.AverageGrade);
            if (result == 0)
            {
                result = string.Compare(x.LastName, y.LastName, StringComparison.OrdinalIgnoreCase);
            }
            return result;
        }
    }

    public class FullNameComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            if (x == null || y == null)
                throw new ArgumentNullException("Один з об’єктів Student дорівнює null!");

            int result = string.Compare(
                x.LastName + x.FirstName,
                y.LastName + y.FirstName,
                StringComparison.OrdinalIgnoreCase
            );

            if (result == 0)
                result = y.AverageGrade.CompareTo(x.AverageGrade);

            return result;
        }
    }
}

class Group : IEnumerable<Student>
{
    private string name;
    private List<Student> students;

    public Group(string n)
    {
        name = n;
        students = new List<Student>();
    }

    public void AddStudent(Student s)
    {
        students.Add(s);
    }

    public void ShowGroup()
    {
        Console.WriteLine($"Група: {name}");
        foreach (Student s in students)
        {
            Console.WriteLine(s);
        }
        Console.WriteLine();
    }

    public IEnumerator<Student> GetEnumerator()
    {
        return new GroupEnumerator(students);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private class GroupEnumerator : IEnumerator<Student>
    {
        private List<Student> students;
        private int position = -1;

        public GroupEnumerator(List<Student> list)
        {
            students = list;
        }

        public Student Current
        {
            get
            {
                if (position < 0 || position >= students.Count)
                    throw new InvalidOperationException();
                return students[position];
            }
        }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            position++;
            return (position < students.Count);
        }

        public void Reset()
        {
            position = -1;
        }

        public void Dispose() { }
    }
}

class Program
{
    static void Main()
    {
        Group group = new Group("ІТ-21");

        group.AddStudent(new Student("Іваненко", "Іван", "Іванович", 80));
        group.AddStudent(new Student("Петренко", "Петро", "Петрович", 92));
        group.AddStudent(new Student("Сидоренко", "Сергій", "Олегович", 80));
        group.AddStudent(new Student("Антонюк", "Марія", "Ігорівна", 95));

        Console.WriteLine("=== Всі студенти ===");
        group.ShowGroup();

        List<Student> sortedByAvg = new List<Student>(group);
        sortedByAvg.Sort(new Student.AverageGradeComparer());

        Console.WriteLine("=== Сортування за середнім балом (зростання) ===");
        foreach (Student s in sortedByAvg)
            Console.WriteLine(s);

        List<Student> sortedByName = new List<Student>(group);
        sortedByName.Sort(new Student.FullNameComparer());

        Console.WriteLine("\n=== Сортування за ПІБ ===");
        foreach (Student s in sortedByName)
            Console.WriteLine(s);

        Console.WriteLine("\n=== Ітерація foreach по групі ===");
        foreach (Student s in group)
        {
            Console.WriteLine(s.LastName);
        }
    }
}
