namespace Models
{
    public class Answer
    {
        private string _keyCode;
        private double _time;

        public Answer(string keyCode, double time)
        {
            _keyCode = keyCode switch
            {
                null or "" => "Skip",
                " " => "Space",
                _ => keyCode
            };
            _time = time;
        }

        public string GetKeyCode()
        {
            return _keyCode;
        }

        public double GetTime()
        {
            return _time;
        }
    }
}