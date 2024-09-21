public class Person {
  public string Name { get; set; }
  public int Age { get; set; }
  public int Course { get; set; }
  public int Specialty { get; set; }

  public Person(IConfiguration config) {
    Name = config["Name"];
    Age = int.Parse(config["Age"]);
    Course = int.Parse(config["Course"]);
    Specialty = int.Parse(config["Specialty"]);
  }

    public override string ToString()
    {
        return $"Name: {Name}\nAge: {Age}\nCourse: {Course}\nSpecialty: {Specialty}\n";
    }
}
