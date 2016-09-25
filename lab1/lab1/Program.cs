using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Program
    {
     
        public class Team//parent class team 
        {
            public string name;//holds general variable of all teams teamName
            public int wins;
            public int loss;
           
        }
        class Game
        {

        }
        public class SoccerTeam : Team//child class soccer team will inherit from team class
        {
            public int draw;
            public int goalsFor;
            public int goalsAgainst;
            public int differential;
            public int points;//points variable will is used to store user entered data
            //constructor for team class
            public SoccerTeam(string sName, int points)
            {
                this.name = sName;
                this.points = points;
            }
        }
        //function returns an upper case first letter of the string that is passed through the parameter
        static string UppercaseFirst(string sName)
        {
            // if sName that is passed through is empty
            if (string.IsNullOrEmpty(sName))
            {
                return string.Empty;
            }
            //if passed string will capatalize the first char and add the rest of the string to that
            return char.ToUpper(sName[0]) + sName.Substring(1);
        }
        static void Main(string[] args)
        {
            int teamNum = 1; //variable that is set to display correct team number in prompt to user in for loop
            int numOfTeams =0;//to store user input on number of teams
            string sName;//to store user input of the team name
            string userNameInput;//temp variable to hold name that user inputs
            int points =0;//to store user input on the points scored by the team
            bool isNumber= false;
            bool isNum = false;
            List<SoccerTeam> myTeams = new List<SoccerTeam>();//define the list of soccer team objects
            //while loop for reprompt until user enters an appropriate integer
            while (isNumber == false)
            {
                Console.Write("How many teams? ");//prompting for user input
                //try catch statement will prompt the user to enter valid integer if they don't do so the first time
                try
                    //should be greater than or equal to 2
                {
                    numOfTeams = Convert.ToInt16(Console.ReadLine());//reading the user input as converted int
                    isNumber = true;
                }
                //the for loop is for the prompts to the user for team names and points for the teams iterates based on how many teams there are
                catch
                {
                    Console.Write("Please enter a valid integer\n");
                }
                for (int i = 0; i < numOfTeams; i++)
                {
                    Console.Write("\n\n");
                    Console.Write("Enter Team " + teamNum + "'s name: ");
                    userNameInput = Console.ReadLine();//assigns the user input to temporary variable
                    sName = UppercaseFirst(userNameInput);//assigns sName to the return 
                    Console.Write("\n");
                    Console.Write("Enter " + sName + "'s points: ");
                    //while loop to make sure the user is reprompted until they enter the correct info
                    while (isNum == false)
                    {
                        //try catch statement to prompt the user to enter a valid integer if they don't do so
                        try
                        {
                            points = Convert.ToInt16(Console.ReadLine());//assigns user input to points
                            isNum = true;
                        }
                        catch
                        {
                            Console.Write("Please enter a valid integer(>=0)");
                        }
                    }
                    // stores the sName and points given by user into SoccerTeam object st
                    SoccerTeam st = new SoccerTeam(sName, points);
                    myTeams.Add(st);//adds that SoccerTeam object to the List of SoccerTeam objects
                    teamNum++;//to iterate the team number that the write line will display on the next iteration through the for loop
                    isNum = false;//reset this so that it can pass through the while loop correctly on the next iteration
                }
                
            }
            //will sort the teams list in descending order based on points and place them into sorted list
            List<SoccerTeam> sorted = myTeams.OrderByDescending(team => team.points).ToList();
            int position = 1; //variable to hold the position value for results printout, will iterate with each loop in the foreach
            //The following 3 lines are used to set my header for the output and then print them out to the console
            string header1 = "Postion".PadRight(25, ' ') + "Name".PadRight(20, ' ') + "Points".PadRight(10,' ');
            string header2 = "-------".PadRight(25, ' ') + "----".PadRight(20, ' ') + "------".PadRight(10, ' ');
            Console.Write(header1+"\n"+header2+"\n");
            //The foreach will go through each object in my sorted list and print the position, name, and points I use the same padright as my header
            foreach(SoccerTeam teams in sorted)
            {
                Console.Write(Convert.ToString(position).PadRight(25, ' '));
                Console.Write(Convert.ToString(teams.name).PadRight(20,' '));
                Console.Write(Convert.ToString(teams.points).PadRight(10, ' '));
                Console.Write("\n");
                position++;
            }
            Console.Read();
        }
    }
}
