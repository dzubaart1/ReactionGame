namespace Models
{
    public class LevelItem
    {
        public string Name;
        public float TimeStart;
        public float TimePause;

        public LevelItem(string name, float timeStart, float timePause)
        {
            Name = name;
            TimeStart = timeStart;
            TimePause = timePause;
        }
    }
}