namespace ExamSolution;

public class Teacher : Person
{
    private string subject;

    public Teacher(string name, string subject) : base(name)
    {
        this.subject = subject;
    }

    public Teacher(Teacher teacher) : base(teacher)
    {
        this.subject = teacher.GetSubject();
    }

    public string GetSubject()
    {
        return subject;
    }

    public void SetSubject(string subject)
    {
        this.subject = subject;
    }
}