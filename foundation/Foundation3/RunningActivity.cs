
public class RunningActivity : Activity
{
    private float _distance;

    public RunningActivity(string date, float length, float distance) : base(date, length)
    {
        _distance = distance;
    }

    public override float GetDistance()
    {
        return _distance;
    }

    public override float GetSpeed()
    {
        return 60 / GetPace();
    }

    public override float GetPace()
    {
        return GetLength() / _distance;
    }

    public override string GetName()
    {
        return "Running";
    }
}
