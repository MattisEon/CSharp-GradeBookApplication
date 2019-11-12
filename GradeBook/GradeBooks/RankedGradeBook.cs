using System;
using System.Collections;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            this.Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            double studentsInEachPercentile = Students.Count/5;
            studentsInEachPercentile = Math.Floor(studentsInEachPercentile);

            // Create a list of sorted grades.
            ArrayList averageGrades = new ArrayList();
            foreach (Student student in Students)
            {
                averageGrades.Add(student.AverageGrade);
            }
            averageGrades.Sort();

            var higherGrades = 0;
            foreach (double grade in averageGrades)
            {
                if (averageGrade < grade)
                {
                    higherGrades++;
                }
            }

            var gradeValue = 5 - (Math.Floor(higherGrades/studentsInEachPercentile));

            switch (gradeValue)
            {
                case 5:
                    return 'A';
                case 4:
                    return 'B';
                case 3:
                    return 'C';
                case 2:
                    return 'D';
            }
            
            return 'F';
        }

    }
}