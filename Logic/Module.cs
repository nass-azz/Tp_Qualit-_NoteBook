using System;
using System.Collections.Generic;

namespace Logic
{
    public class Module : EducationalElement
    {
        public  List<Exam> exams = new();
        public Unit ParentUnit { get; set; }

        public Module() { }

        public Module(string name, float coef) : base(name, coef) { }

        public void AddExam(Exam exam)
        {
            if (exam == null)
                throw new ArgumentNullException(nameof(exam));
            exams.Add(exam);
        }

        public void RemoveExam(Exam exam)
        {
            if (!exams.Remove(exam))
                throw new InvalidOperationException("The exam does not exist in this module.");
        }

        public Exam[] ListExams() => exams.ToArray();
    }
}
