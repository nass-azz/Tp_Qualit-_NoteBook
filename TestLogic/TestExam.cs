using System;
using Logic;
using Xunit;

namespace TestLogic
{
    public class TestExam
    {
        [Fact]
        public void Teacher_MustNotBeEmpty()
        {
            var ex = new Exam();
            Assert.Throws<ArgumentException>(() => ex.Teacher = "");
            Assert.Throws<ArgumentException>(() => ex.Teacher = "  ");
        }

        [Fact]
        public void Coef_MustBePositive()
        {
            var ex = new Exam();
            Assert.Throws<ArgumentException>(() => ex.Coef = 0);
            Assert.Throws<ArgumentException>(() => ex.Coef = -5);
        }

        [Fact]
        public void Note_MustBeBetween0And20()
        {
            var ex = new Exam { Teacher = "Prof", Date = DateTime.Today, Coef = 1 };
            Assert.Throws<ArgumentException>(() => ex.Note = -1);
            Assert.Throws<ArgumentException>(() => ex.Note = 25);
        }

        [Fact]
        public void Absent_SetsNoteToZero()
        {
            var ex = new Exam("Prof", DateTime.Today, 2f, 15f, true);
            Assert.True(ex.IsAbsent);
            Assert.Equal(0, ex.Note);
        }

        [Fact]
        public void ToString_ContainsTeacherAndNote()
        {
            var ex = new Exam("Prof", DateTime.Today, 2f, 12f);
            string s = ex.ToString();
            Assert.Contains("Prof", s);
            Assert.Contains("12", s);
        }
    }
}
