using System;
using Logic;
using Xunit;

namespace TestLogic
{
    public class TestNotebook
    {
        [Fact]
        public void ListUnits_EmptyAtStart()
        {
            var nb = new Notebook();
            var list = nb.ListUnits();
            Assert.NotNull(list);
            Assert.Empty(list);
        }

        [Fact]
        public void AddUnit_AddsIt()
        {
            var nb = new Notebook();
            var u = new Unit { Name = "UE Info", Coef = 2f };
            nb.AddUnit(u);
            var list = nb.ListUnits();
            Assert.Single(list);
            Assert.Equal(u, list[0]);
        }

        [Fact]
        public void AddUnit_DuplicateName_Throws()
        {
            var nb = new Notebook();
            var u1 = new Unit { Name = "UE Info", Coef = 2f };
            var u2 = new Unit { Name = "ue info", Coef = 3f };
            nb.AddUnit(u1);
            Assert.Throws<InvalidOperationException>(() => nb.AddUnit(u2));
        }

        [Fact]
        public void RemoveUnit_RemovesIt()
        {
            var nb = new Notebook();
            var u = new Unit { Name = "UE Info", Coef = 2f };
            nb.AddUnit(u);
            nb.RemoveUnit(u);
            Assert.Empty(nb.ListUnits());
        }

        [Fact]
        public void RemoveUnit_NotPresent_Throws()
        {
            var nb = new Notebook();
            var u = new Unit { Name = "UE Info", Coef = 2f };
            Assert.Throws<InvalidOperationException>(() => nb.RemoveUnit(u));
        }
    }
}
