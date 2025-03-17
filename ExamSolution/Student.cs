namespace ExamSolution;

public class Student : Person
{
    private int[,] gradesAndUnits;

    public Student(string name, int gradesNum) : base(name)
    {
        // 2d array to store the grades and units
        gradesAndUnits = new int[gradesNum, 2];
    }

    public Student(Student student) : base(student)
    {
        // copy the grades and units
        gradesAndUnits = new int[student.gradesAndUnits.GetLength(0), 2];
        for (int i = 0; i < student.gradesAndUnits.GetLength(0); i++)
        {
            gradesAndUnits[i, 0] = student.gradesAndUnits[i, 0];
            gradesAndUnits[i, 1] = student.gradesAndUnits[i, 1];
        }
    }

    public bool AddGrade(int grade, int unit, int index)
    {
        // check if the index is valid
        if (index < 0 || index >= gradesAndUnits.GetLength(0))
        {
            return false;
        }
        // check if the grade and unit are valid
        if (grade < 0 || grade > 100 || unit < 0)
        {
            return false;
        }
        // add the grade and unit
        gradesAndUnits[index, 0] = grade;
        gradesAndUnits[index, 1] = unit;
        return true;
    }

    public double GetAverage()
    {
        double sum = 0;
        for (int i = 0; i < gradesAndUnits.GetLength(0); i++)
        {
            sum += gradesAndUnits[i, 0];
            // add bonus points based on the unit
            switch (gradesAndUnits[i, 1])
            {
                case 5:
                    sum += 10;
                case 4:
                    sum += 10;
                    break;
            }
        }
        // return the average
        return sum / gradesAndUnits.GetLength(0);
    }
}
