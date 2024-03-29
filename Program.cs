

string filePath = fileCreate();
List<string> moodData = readMoodData(filePath);
bool quit = false;


System.Console.WriteLine("-----Welcome-----");
Console.ReadKey();
Console.Clear();
while (quit == false)
{
    int userInput;
    while(true)
    {
        System.Console.WriteLine("-----What do you wish to do-----\n\n1. Add mood\n2. View tracking data\n3. Quit");
        string ?userInputString = Console.ReadLine();
       
        if(int.TryParse(userInputString, out userInput) && userInput <= 3 && userInput >=1)
        {
            Console.Clear();
            break;
        }
        else
        {
            System.Console.WriteLine("Input unreadable please try again");
        }

        

        }

    switch(userInput)
    {
        case 1:
        moodData = addMood(filePath, moodData);
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
        Console.Clear();
        break;
        
        case 2:
        displayProgression(moodData);
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
        Console.Clear();
        break;
    
        case 3:
        quit = true;
        Console.Clear();
        break;
    }


}




static void displayProgression(List<string> moodData)
{
    System.Console.WriteLine(" ");
    System.Console.WriteLine("-----Your mood over time-----");
    foreach (string a in moodData)
    {
        System.Console.WriteLine(a);
    }

}


//List retrieves data from path.
static List<string> readMoodData(string path)
{
    List<string> moodData = new List<string>();

    try
    {
        using (StreamReader sr = new StreamReader(path))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                moodData.Add(line); // Add each line to moodData
            }
        }
    }
    catch (IOException e)
    {

        Console.WriteLine("Error reading mood data: " + e.Message);
    }
    return moodData;
}



static List<string> addMood(string filePath, List<string> moodData)
{
    string currentTime = DateTime.Now.ToString("yyyy-MM-dd");
    string moodEntry = $"{currentTime}: {todaysMood()}";
    using (StreamWriter sw = File.AppendText(filePath))
    {
        sw.WriteLine(moodEntry);
    }
    // Read the newly added line from the file
    string newestLine = File.ReadLines(filePath).Last();
    
    // Add the newest line to the moodData list
    moodData.Add(newestLine);
    return moodData;
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

    }

    return filePath;
}



static int todaysMood()
{
    string? userInputString;
    int userInput;
    while (true)
    {
        Console.WriteLine("How are you feeling from a scale from 1-10");
        userInputString = Console.ReadLine();
        if (int.TryParse(userInputString, out userInput))
        {
            if (userInput <= 10 && userInput >= 1)
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
