public class CyclingActivity : Activity
{
    private float _speed;

    public CyclingActivity(string date, float length, float speed) : base(date, length)
    {
        _speed = speed;
    }

    public override float GetDistance()
    {
        return GetLength() / _speed;
    }

    public override float GetSpeed()
    {
        return _speed;
    }

    public override float GetPace()
    {
        return GetLength() / GetDistance();
    }

    public override string GetName()
    {
        return "Cycling";
    }
}