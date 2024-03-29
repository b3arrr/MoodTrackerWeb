
internal class Program
{
    private static void Main(string[] args)
    {
        string filePath = fileCreate();

        addMood(filePath);

        List<string> moodData = readMoodData(filePath);

        displayProgression(moodData);




     

        static void displayProgression(List<string> moodData)
        {
            foreach(string a in moodData)
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



        static void addMood(string filePath)
        {
                string currentTime = DateTime.Now.ToString("yyyy-MM-dd");
            string moodEntry = $"{currentTime}: {todaysMood()}";
            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine(moodEntry);
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
    }
}