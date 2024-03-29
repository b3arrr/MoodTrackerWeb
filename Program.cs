
string filePath = fileCreate();

addMood(filePath);

List<int> moodData = new List<int>(readMoodData(filePath));

foreach(int a in moodData)
{
    System.Console.WriteLine(a);
}



//Lis retrieves data from path.
static List<int> readMoodData (string path)
{
    List<int> moodData = new List<int>();

    try
    {
        using(StreamReader sr = new StreamReader(path))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                if(int.TryParse(line, out int moodRating))
                {
                    moodData.Add(moodRating);
                }
            }
        }
    }
    catch (IOException e)
    {

        System.Console.WriteLine("Error reading mood data: " + e.Message);
    }
    return moodData;
}


static void addMood(string filePath)
{
using (StreamWriter sw = File.AppendText(filePath))
{
    sw.WriteLine(todaysMood());
}
}




    static string fileCreate()
    {
        string currentDirectory = Directory.GetCurrentDirectory();

        string filePath = Path.Combine(currentDirectory, "mood", "file.txt");
        string pathDirectory = Path.Combine(currentDirectory, "mood");
        
        if (!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(pathDirectory);
        }

        if (!File.Exists(filePath))
        {
            
            File.CreateText(filePath);
           /*  // Create a file to write to.
            using (StreamWriter sw = File.CreateText(filePath))
            {
                sw.WriteLine("Hello");
                sw.WriteLine("And");
                sw.WriteLine("Welcome");
            } */
        }

        return filePath;
    }

static int todaysMood()
{


string ?userInputString;
int userInput;
while(true)
{
    Console.WriteLine("How are you feeling from a scale from 1-10");
    userInputString = Console.ReadLine();
    if(int.TryParse(userInputString, out userInput))
    {
        if(userInput <= 10 && userInput >= 1)
        {
            break;
        }
        else
        {
            Console.WriteLine("Incorrect input, please write a number between 1-10");
        }
    }
    else 
    {
        Console.WriteLine("Please enter a valid input");
    }
}

    return userInput;

}


