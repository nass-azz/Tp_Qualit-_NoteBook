using System;

namespace Logic
{
    public abstract class EducationalElement
    {
        private string name;
        private float coef;

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name must be non-empty.");
                name = value.Trim();
            }
        }

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

        protected EducationalElement() { }

        protected EducationalElement(string name, float coef)
        {
            Name = name;
            Coef = coef;
        }

        public override string ToString() => $"{Name} ({Coef})";
    }
}
