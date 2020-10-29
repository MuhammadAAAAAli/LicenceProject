namespace DataStructures
{
    public class InitialInfo
    {
        public InitialInfo(int d, bool p)
        {
            GameMode = d;
            PlayerStarts = p;
        }

        public int GameMode { get; private set; }
        public bool PlayerStarts { get; private set; }
    }
}