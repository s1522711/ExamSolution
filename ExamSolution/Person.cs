namespace ExamSolution;

public class Person
{
    private string name;

    public Person(string name)
    {
        this.name = name;
    }

    public Person(Person person)
    {
        this.name = person.GetName();
    }

    public string GetName()
    {
        return name;
    }

    public void SetName(string name)
    {
        this.name = name;
    }
}