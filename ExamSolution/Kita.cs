namespace ExamSolution;

public class Kita
{
    private Person[] people;

    public Kita(Teacher teacher, int studentsNum)
    {
        // create an array to store the teacher and students
        people = new Person[studentsNum + 1];
        people[0] = new Teacher(teacher);
    }

    public bool AddStudent(Student student)
    {
        // find the first empty slot in the array
        for (int i = 0; i < people.Length; i++)
        {
            if (people[i] == null)
            {
                // add the student to the array
                people[i] = new Student(student);
                return true;
            }
        }
        return false;
    }

    public bool IsInKita(string name)
    {
        for (int i = 0; i < people.Length; i++)
        {
            // check if the person is a student and has the same name
            if (people[i] != null &&people[i].GetName() == name)
            {
                return true;
            }
        }
        return false;
    }

    public bool RemoveStudent(string name)
    {
        for (int i = 0; i < people.Length; i++)
        {
            // check if the person is a student and has the same name
            if (people[i] != null && people[i].GetName() == name)
            {
                // remove the student from the array
                people[i] = null;
                return true;
            }
        }
        return false;
    }

    public string GetHighestAvgStudent()
    {
        double maxAvg = 0;
        string name = "";
        for (int i = 1; i < people.Length; i++)
        {
            // check if the person is a student
            if (people[i] is Student)
            {
                // get the average of the student
                double avg = ((Student)people[i]).GetAverage();
                // update the maxAvg and name
                if (avg > maxAvg)
                {
                    maxAvg = avg;
                    name = people[i].GetName();
                }
            }
        }
        return name;
    }

    public static Kita CreateGoodOnlyStudentsKita(Kita old)
    {
        // create a new kita with the same teacher and only good students
        Kita newKita = new Kita((Teacher)old.people[0], old.people.Length - 1);
        for (int i = 1; i < old.people.Length; i++)
        {
            // check if the person is a student
            if (old.people[i] is Student)
            {
                // get the average of the student
                double avg = ((Student)old.people[i]).GetAverage();
                // add the student to the new kita if the average is greater than 80
                if (avg > 90)
                {
                    newKita.AddStudent((Student)old.people[i]);
                }
            }
        }
        return newKita;
    }
}