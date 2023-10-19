namespace TranslatorApp
{
    class Translator
    {
        //Private member to hold the dictionary of words and their translations
        private Dictionary<string, List<string>> dictionary;
        
        // Constructor that initializes the dictionary from a file
        public Translator(string path) 
        {
            // Initialize the dictionary
            dictionary = new Dictionary<string, List<string>>();
            // Read all lines from the file
            var lines = File.ReadAllLines(path);
            // Iterate over each line
            foreach (var line in lines)
            {
                // If the line starts with a "#", it's a comment and should be skipped
                if (line.StartsWith("#")) continue;
                // Split the line on tab to separate the word from its translations
                var words = line.Split("\t");
                // If the word already exists in the dictionary
                if (dictionary.ContainsKey(words[0]))
                {
                    // Add the new translation to the existing list of translations
                    dictionary[words[0]].Add(words[1]);
                }
                else
                {
                    // If the word doesn't exist, create a new list for translations
                    var translations = new List<string>();
                    translations.Add(words[1]);

                    // Add the word and its translations to the dictionary
                    dictionary.Add(words[0], translations);
                }
            }
        }
        // Method to get the translations for a given word
        public List<string> Translate(string word)
        {
            // If the word exists in the dictionary, return its translations, otherwise return an empty list
            return dictionary.ContainsKey(word) ? dictionary[word] : new List<string>();
        }
    }
    // Entry point of the program
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new Translator object with the path to the dictionary file
                Translator translator = new Translator("C:\\Users\\bryan\\OneDrive\\Documents\\GitHub\\TranslatorApp\\TranslatorApp\\Spanish.txt");
                Console.Write("Please enter an English Word: ");
                var word = Console.ReadLine();
                // Get the translations for the entered word
                var translations = translator.Translate(word);
                // Display the translations
                Console.WriteLine("The translations are: ");
                foreach (var translation in translations)
                {
                    Console.WriteLine($"\t{translation}");
                }
            }
            // Handle the case where the dictionary file is not found
            catch (FileNotFoundException)
            {
                Console.WriteLine("Cannot find dictionary file");
            }
            
        }
    }
}