namespace DatabaseTermProject.Objects
{
    public class Nutrition
    {
        public string Name { get; set; }

        public string Calorie { get; set; }
        public string Carbohydrate { get; set; }
        public string Protein { get; set; }
        public string Oil { get; set; }
        public string Fiber { get; set; }
        public string Cholesterol { get; set; }
        public string Sodium { get; set; }
        public string Potassium { get; set; }
        public string VitaminA { get; set; }
        public string Calcium { get; set; }
        public string VitaminC { get; set; }
        public string Ferrous { get; set; }

        public Nutrition(string name)
        {
            Name = name;
        }
    }
}