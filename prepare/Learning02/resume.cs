public class Resume
{
    public string _name;
    public List<Job> _jobs = new List<Job>();
    public void Display()
    {
        Console.WriteLine($"{_name}:");
        foreach (Job job in _jobs)
            Console.WriteLine($"{job._jobTitle} at {job._company} {job._startYear}-{job._endYear}");
    }
}