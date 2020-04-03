namespace Core.Data.Models
{
  public class QuestaoSPList
    {
        public QuestaoSPList(string name, string staticName, string displayName, int min, int max)
        {
            Name = name;
            this.staticName = staticName;
            this.displayName = displayName;
            Min = min;
            Max = max;
        }

        public string Name { get; set; }
        public string staticName { get; set; }
        public string displayName { get; set; }
        public  int Min { get; set; }
        public int Max { get; set; }

    }
}