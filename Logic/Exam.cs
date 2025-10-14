using System;

namespace Logic
{
    public class Exam
    {
        private string teacher;
        private float coef;
        private float note;

        public string Teacher
        {
            get => teacher;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Teacher name must be non-empty.");
                teacher = value.Trim();
            }
        }

        public DateTime Date { get; set; }

        public float Coef
        {
            get => coef;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Coefficient must be > 0.");
                coef = value;
            }
        }

        public float Note
        {
            get => isAbsent ? 0 : note;
            set
            {
                if (value < 0 || value > 20)
                    throw new ArgumentException("Note must be between 0 and 20.");
                note = value;
            }
        }

        private bool isAbsent;
        public bool IsAbsent
        {
            get => isAbsent;
            set
            {
                isAbsent = value;
                if (isAbsent) note = 0; // Absence => note = 0
            }
        }

        public Exam() { }

        public Exam(string teacher, DateTime date, float coef, float note, bool isAbsent = false)
        {
            Teacher = teacher;
            Date = date;
            Coef = coef;
            IsAbsent = isAbsent;
            Note = note;
        }

        public override string ToString() =>
            $"{Teacher} - {Date:d} : {(IsAbsent ? "Absent (0)" : $"{Note}/20")} (coef {Coef})";
    }
}
