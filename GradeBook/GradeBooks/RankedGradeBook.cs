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

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override double GetGPA(char letterGrade, StudentType studentType)
        {
            return base.GetGPA(letterGrade, studentType);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
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

        public override string ToString()
        {
            return base.ToString();
        }
    }
}