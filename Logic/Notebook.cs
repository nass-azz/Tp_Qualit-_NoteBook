using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class Notebook
    {
        private readonly List<Unit> units = new();

        public Unit[] ListUnits() => units.ToArray();

        public void AddUnit(Unit u)
        {
            if (u == null) throw new ArgumentNullException(nameof(u));
            if (units.Any(x => x.Name.Equals(u.Name, StringComparison.OrdinalIgnoreCase)))
                throw new InvalidOperationException($"A unit named '{u.Name}' already exists.");
            units.Add(u);
        }

        public void RemoveUnit(Unit u)
        {
            if (u == null) throw new ArgumentNullException(nameof(u));
            if (!units.Remove(u))
                throw new InvalidOperationException("This unit does not exist.");
        }

        public Module[] ListModules() =>
            units.SelectMany(u => u.ListModules()).ToArray();
    }
}
