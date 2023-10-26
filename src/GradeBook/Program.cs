// See https://aka.ms/new-console-template for more information

IBook book = new DiskBook("Ryan's Grade Book");
book.GradeAdded += OnGradeAdded;

EnterGrades(book);

var stats = book.GetStatistics();

Console.WriteLine($"For the book named {book.Name}");
Console.WriteLine($"The Lowest grade is {stats.Low}");
Console.WriteLine($"The Highest grade is {stats.High}");
Console.WriteLine($"The Average grade is {stats.Average}");
Console.WriteLine($"The Letter grade is {stats.Letter}");

static void OnGradeAdded(object sender, EventArgs e)
{
  Console.WriteLine("A grade was added");
}

static void EnterGrades(IBook book)
{
  while (true)
  {
    Console.WriteLine("Enter a grade or 'q' to quit");
    var input = Console.ReadLine();
    if (input == "q")
    {
      break;
    }
    try
    {
      var grade = double.Parse(input);
      book.AddGrade(grade);
    }
    catch (ArgumentException ex)
    {
      Console.WriteLine(ex.Message);
    }
    catch (FormatException ex)
    {
      Console.WriteLine(ex.Message);
    }
    finally
    {
      Console.WriteLine("**");
    }
  }
}