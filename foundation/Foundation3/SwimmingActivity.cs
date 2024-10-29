public class SwimmingActivity : Activity
{
    private int _laps;

    public SwimmingActivity(string date, float length, int laps) : base(date, length)
    {
        _laps = laps;
    }

    public override float GetDistance()
    {
        return _laps * 50 / (100 * 0.62f);
    }

    public override float GetSpeed()
    {
        return 60 / GetPace();
    }

    public override float GetPace()
    {
        return GetLength() / GetDistance();
    }

    public override string GetName()
    {
        return "Swimming";
    }
}