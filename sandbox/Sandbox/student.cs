public class Student
{
    public string _firstName;
    public string _lastName;
    public string _id;
    public void DisplayName()
    {
        Console.WriteLine($"Student name: {_firstName} {_lastName}");
    }
    public void DisplayInfo()
    {
        Console.WriteLine($"Student name:  {_firstName} {_lastName},\n ID: {_id}");
    }
}