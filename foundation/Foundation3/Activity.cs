public abstract class Activity
{
    private string _date;
    private float _length;

    public Activity(string date, float length)
    {
        _date = date;
        _length = length;
    }

    public abstract float GetDistance();

    public abstract float GetSpeed();

    public abstract float GetPace();

    public string GetSummary(string activity)
    {
        return $"{_date} {activity} ({_length} min) - Distance: {GetDistance()} miles, Speed: {GetSpeed()} mph, Pace: {GetPace()} min per mile";
    }

    public float GetLength()
    {
        return _length;
    }

    public abstract string GetName();
}