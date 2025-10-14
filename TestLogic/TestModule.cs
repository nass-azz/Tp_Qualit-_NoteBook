using System;
using Logic;
using Xunit;

namespace TestLogic
{
    public class TestModule
    {
        [Fact]
        public void AddExam_AddsIt()
        {
            var module = new Module { Name = "Maths", Coef = 1.0f };
            var exam = new Exam("ProfX", DateTime.Today, 2.0f, 15f);
            module.AddExam(exam);

            var exams = module.ListExams();
            Assert.Single(exams);
            Assert.Equal(exam, exams[0]);
        }

        [Fact]
        public void RemoveExam_RemovesIt()
        {
            var module = new Module { Name = "Maths", Coef = 1.0f };
            var exam = new Exam("ProfX", DateTime.Today, 2.0f, 15f);
            module.AddExam(exam);
            module.RemoveExam(exam);
            Assert.Empty(module.ListExams());
        }

        [Fact]
        public void RemoveExam_NotPresent_Throws()
        {
            var module = new Module { Name = "Maths", Coef = 1.0f };
            var exam = new Exam("ProfX", DateTime.Today, 2.0f, 15f);
            Assert.Throws<InvalidOperationException>(() => module.RemoveExam(exam));
        }
    }
}
