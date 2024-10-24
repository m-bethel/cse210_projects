using System;
//initialize the program
class Program
{
    static void Main(string[] args)
    {

        //this was fun, setting up a boolean so I can do a while loop 
        bool exit = false;
        while (!exit)
        {
            //creating a menu to choose from and creating a vertical space because my terminal was having issues
            Console.WriteLine(" ");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
        
            string userInput=Console.ReadLine();
        
        switch (userInput)
        {
        
            case "1":
                //Write an entry to the journal
                Entry newEntry = new Entry();
                newEntry.Write();
                break;

            case "2":
                //Displaying the selected file
                Display filedisplay = new Display();
                filedisplay.DisplayEntries();
                break;
            
            case "3":
                //displaying the specified file
                Display loadfile = new Display();
                loadfile.Load();
                break;

            case "4":
                //saving the file as a new filename if desired
                Entry newSave = new Entry();
                newSave.Save();
                break;


            //Exeeding requirments section
            case "5":
                //Editing an entry
                

                break;





            case "6":
                //good ole exit program
                exit = true;
                break;

            default: //gotta make sure that someone doesnt put the wrong input in the program
                Console.WriteLine("Invalid Input");
                exit = true;
                break;
        }
        }
        
        
        
        
        
    }
    
        
        
        
        
    
   
}