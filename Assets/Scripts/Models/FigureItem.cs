namespace Models
{
    public class FigureItem
    {
        public string KeyCode;
        public string SpriteName;
        public string SoundName = "None";
        public FigureItem(string keyCode, string spriteName, string soundName)
        {
            KeyCode = keyCode;
            SpriteName = spriteName;
            if (!string.IsNullOrWhiteSpace(soundName))
            {
                SoundName = soundName;
            }
        }
    }
}