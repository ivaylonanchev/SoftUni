using System.Text;

namespace SharkTaxonomy
{
    public class Shark
    {
        public string Kind { get; set; }
        public int Length { get; set; }
        public string Food { get; set; }
        public string Habitat { get; set; }

        public Shark(string kind, int lenght, string food, string habitat)
        {
            Kind = kind;
            Length = lenght;
            Food = food;
            Habitat = habitat;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{Kind} shark: {Length}m long.");
            sb.AppendLine($"Could be spotted in the {Habitat}, typical menu: {Food}");
            return sb.ToString().Trim();
        }
    }
}
