using System.Text;

namespace SharkTaxonomy
{
    public class Classifier
    {
        public int Capacity { get; set; }
        public List<Shark> Species { get; set; }

        public Classifier(int capacity)
        {
            Capacity = capacity;
            Species = new List<Shark>();
        }
        public int GetCount
        {
            get { return Species.Count; }
        }

        public void AddShark(Shark shark)
        {
            try
            {
                if (Capacity > Species.Count)
                {
                    Shark sh = Species.FirstOrDefault(x => x.Kind == shark.Kind);
                    if (sh == default)
                    {
                        Species.Add(shark);
                    }
                }
            }
            catch (Exception eh)
            {

                Console.WriteLine("Grumna" + eh.Message); throw;
            }

        }
        public bool RemoveShark(string kind)
        {
            Shark shark = Species.FirstOrDefault(x => x.Kind == kind);
            if (shark == null)
            {
                return false;
            }
            Species.Remove(shark);
            return true;
        }
        public string GetLargestShark()
        {
            Shark shark = Species.OrderByDescending(x => x.Length).First();
            return shark.ToString();
        }
        public double GetAverageLength()
        {
            double average = 0;
            average = Species.Sum(x => x.Length);
            return average / Species.Count;
        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{Species.Count} sharks classified:");
            foreach (var item in Species)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
