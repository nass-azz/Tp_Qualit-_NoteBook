using System;
using System.Collections.Generic;

namespace Logic
{
    public class Unit : EducationalElement
    {
        private readonly List<Module> modules = new();

        public Unit() { }

        public Unit(string name, float coef) : base(name, coef) { }

        public void AddModule(Module module)
        {
            if (module == null)
                throw new ArgumentNullException(nameof(module));
            if (modules.Contains(module))
                throw new InvalidOperationException("This module is already in the unit.");
            modules.Add(module);
        }

        public void RemoveModule(Module module)
        {
            if (!modules.Remove(module))
                throw new InvalidOperationException("The module does not exist in this unit.");
        }

        public Module[] ListModules() => modules.ToArray();
    }
}