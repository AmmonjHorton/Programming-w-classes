using System;

class Program
{
    
        public void SaveGoal(Goals goal)
{
    string filePath = "goals.csv";
    using (StreamWriter writer = new StreamWriter(filePath, append: true))
    {
        writer.WriteLine(goal.ToCsv());
    }
}
}

 

