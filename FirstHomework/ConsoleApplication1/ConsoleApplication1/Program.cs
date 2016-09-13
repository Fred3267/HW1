using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Olympic Soccer Tournament

Draw a class diagram that represents a Soccer Tournament. You will need a Team parent class, a child soccer class, and a game class. Write a program that prompts the user to enter in the number of teams competing in an olympic soccer tournament. Then for the number of teams entered, prompt the user to enter the name of the team and the number of points the team has scored. Finally, display the results of the tournament. Make sure your console output matches the sample screenshot in the requirements below exactly.

Requirements

 Console output matches sample output completely (see screenshot below)
 First letter of each teams's name is capitalized
 Program uses a List object to store the list of teams
 Teams are sorted by the team's points in descending order
 Result table has column headers and separators for Position, Name, and Points
 Result table displays each team's position, name, and points
 Properly implements Team and SoccerTeam classes but you do NOT need to implement the Game class
 Use exception handling to make sure that the number of teams they enter is a valid integer (try/catch within a while loop).
 Adds comments to make code easier to understand
 Upload the project here and also upload the zipped project to the Learning Suite assignment (include the class diagram in your upload in the main root directory for your project so TAs can easily find it) and then schedule a time with the TAs for them to grade this assignment
 */
namespace ConsoleApplication1
{
    public class Team 
    {
        public string name;
        public int wins;
        public int loss;

        public Team(string Name)
        {
            this.name = Name;
        }

    }


    
    public class SoccerTeam : Team
    {
        public List<Game> SoccerGames = new List<Game>();
        public int draws;
        public int points;

        public SoccerTeam(string Name, int Points) : base(Name)
        {
            this.points = Points;
        }
    }





    public class Game 
    {
        //declare varibles
        public int goalsFor;
        public int goalsAgainst;
        public int differentail;

        // a Method i dont use, but may be helpful when we have two teams play in the future
        public void PlayGame(SoccerTeam T1, SoccerTeam T2)
        {

            int T1Score = 0;
            int T2Score = 0;

            //determine scores for both teams
            while(T1Score==T2Score)
            {
                Random R = new Random();
                T1Score = R.Next(1, 101);
                T2Score = R.Next(1, 101);
            }

            //assign score to correct attributes
            this.goalsFor = T1Score;
            this.goalsAgainst = T2Score;
            this.differentail = T1Score - T2Score;

            //determine winners and update correct attributes
            if(T1Score>=T2Score)
            {
                T1.wins++;
                T2.loss--;
            }

            else if(T1Score<=T2Score)
            {
                T2.wins++;
                T1.loss--;
            }

            else 
            {
                T1.draws++;
                T2.draws--;
            }
        }
    
    
    }


    class Program
    {
        static string UpperCaseFirstLetter(string s) 
        {
            if(string.IsNullOrEmpty(s))
            {   //check for empty string
                return  string.Empty;
            }
            //return char and concat substring
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        static void Main(string[] args)
        {   //declare varibles
            String sTeamName;
            int iNumGames;
            int iPoints;
            List<SoccerTeam> lTeamList = new List<SoccerTeam>();
            string sNumGames;
            string sPoints;

            Console.Write("How many teams? ");
            sNumGames = Console.ReadLine();

            //make sure the user entered an integer. I could have use try catch, but i wanted to show a different way of doing it. I also know that try catch will catch more variety of exception
            while(Int32.TryParse(sNumGames,out iNumGames)== false )
            {
                Console.WriteLine("You bozo! Enter a Integer!\n");

                Console.Write("How many teams? ");
                sNumGames = Console.ReadLine();
            }

            iNumGames = Convert.ToInt32(sNumGames);


            //load up team and points and add them to the list
            for(int iCount=1; iCount<=iNumGames;iCount++)
            {
                Console.Write("\n\nEnter Team " + iCount + "'s name: ");
                sTeamName = Console.ReadLine();
                sTeamName = Program.UpperCaseFirstLetter(sTeamName);

                Console.Write("\nEnter " + sTeamName + "'s points: ");
                sPoints = Console.ReadLine();

                //make sure the user entered an integer
                while (Int32.TryParse(sPoints, out iPoints) == false)
                {
                    Console.WriteLine("You bozo! Enter a Integer!\n");

                    Console.Write("\nEnter " + sTeamName + "'s points: ");
                    sPoints = Console.ReadLine();
                }

                iPoints = Convert.ToInt32(sPoints);

                lTeamList.Add(new SoccerTeam(sTeamName,iPoints));
            }

            //sort the list by point

            lTeamList.Sort((x, y) => y.points.CompareTo(x.points));



            Console.WriteLine("\n\nHere is the sorted list:\n\n");
            Console.WriteLine("Position".PadRight(13, ' ') + "Name".PadRight(20,' ')+"Points");
            Console.WriteLine("--------".PadRight(13, ' ') + "----".PadRight(20,' ') + "------");
            int iCounter = 0;

            //print results
            foreach (SoccerTeam i in lTeamList)
            {
            
                Console.Write(Convert.ToString(iCounter+1).PadRight(13,' ') + lTeamList[iCounter].name.PadRight(20,' ')+ lTeamList[iCounter].points + "\n");
                iCounter++;
               
            }

            Console.ReadLine();
        }
    }
}
