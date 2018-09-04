using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
	class RankedGradeBook : BaseGradeBook
	{
		public RankedGradeBook(string name) : base(name)
		{
			Type = Enums.GradeBookType.Ranked;
		}

		public override char GetLetterGrade(double averageGrade)
		{
			if (Students.Count < 5) //Case: less than 5 students in a class
				throw new InvalidOperationException("Ranked grading requires 5 or more students.");

			//Determines 20% of students
			double studentIncrement = (double)Students.Count / 5;

			//Populate list of student grades and sort by average grades (descending)
			List<double> gradeList = new List<double>();
			foreach (Student s in Students)
				gradeList.Add(s.AverageGrade);
			gradeList.Sort();
			gradeList.Reverse();

			//Use an if-else if-else statement to determine what to return
			if (averageGrade >= gradeList[((int)Math.Ceiling(studentIncrement))-1])
			{
				return 'A';
			}
			else if (averageGrade >= gradeList[((int)Math.Ceiling(studentIncrement * 2)) -1])
			{
				return 'B';
			}
			else if (averageGrade >= gradeList[((int)Math.Ceiling(studentIncrement * 3)) -1])
			{
				return 'C';
			}
			else if (averageGrade >= gradeList[((int)Math.Ceiling(studentIncrement * 4)) -1])
			{
				return 'D';
			}
			else
				return 'F';
	
		}

		public override void CalculateStatistics()
		{
			if(Students.Count < 5)
				Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
			else
				base.CalculateStatistics();
		}

		public override void CalculateStudentStatistics(string name)
		{
			if (Students.Count < 5)
				Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
			else
				base.CalculateStudentStatistics(name);
		}
	}
}
