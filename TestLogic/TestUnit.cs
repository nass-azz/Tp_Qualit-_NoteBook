using System;
using Logic;
using Xunit;

namespace TestLogic
{
    public class TestUnit
    {
        [Fact]
        public void AddModule_Works_And_ListModulesContainsIt()
        {
            var unit = new Unit { Name = "UE1", Coef = 2.0f };
            var mod = new Module { Name = "Algo", Coef = 1.5f };

            unit.AddModule(mod);
            var list = unit.ListModules();

            Assert.Single(list);
            Assert.Equal(mod, list[0]);
        }

        [Fact]
        public void AddModule_Duplicate_Throws()
        {
            var unit = new Unit { Name = "UE1", Coef = 2.0f };
            var mod = new Module { Name = "Algo", Coef = 1.5f };
            unit.AddModule(mod);
            Assert.Throws<InvalidOperationException>(() => unit.AddModule(mod));
        }

        [Fact]
        public void RemoveModule_RemovesIt()
        {
            var unit = new Unit { Name = "UE1", Coef = 2.0f };
            var mod = new Module { Name = "Algo", Coef = 1.5f };
            unit.AddModule(mod);
            unit.RemoveModule(mod);
            Assert.Empty(unit.ListModules());
        }

        [Fact]
        public void RemoveModule_NotExisting_Throws()
        {
            var unit = new Unit { Name = "UE1", Coef = 2.0f };
            var mod = new Module { Name = "Algo", Coef = 1.5f };
            Assert.Throws<InvalidOperationException>(() => unit.RemoveModule(mod));
        }
    }
}
