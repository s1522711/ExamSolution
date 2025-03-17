namespace ExamSolution;

public class Kita
{
    private Person[] people;

    /*
     * the constuctor, gets the teacher object and the number of students in the class
     * input: the teacher object and int number of students in the class
     */
    public Kita(Teacher teacher, int studentsNum)
    {
        if teacher == null return;
        if studentsNum < 1 return;
        // create an array to store the teacher and students
        people = new Person[studentsNum + 1];
        people[0] = teacher;
    }

    /*
     * adds a new student to the classroom
     * input: the student's object
     * output: true if sucessful
     */
    public bool AddStudent(Student student)
    {
        if student = null return;
        // find the first empty slot in the array
        for (int i = 0; i < people.Length; i++)
        {
            if (people[i] == null)
            {
                // add the student to the array
                people[i] = student;
                return true;
            }
        }
        return false;
    }

    /*
     * checks if a student with a specific name is in the class
     * input: the name of the student
     * output: true if found
     */
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

    /*
     * removes a student with a specific name
     * input: the student name
     * output: true if sucsessful
     */
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

    /*
     * Returns the name of the student with the highest grade average
     * Output: a string, yes
     */
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

    /*
     * creates a new class that only contains students with an average grade score above 80
     * input: the original class
     * output: the new classroom with the good students
     */
    public static Kita CreateGoodOnlyStudentsKita(Kita old)
    {
        // cant be null
        if (old == null) return;
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
