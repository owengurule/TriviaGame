﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //The logic for your trivia game happens here
            List<Trivia> AllQuestions = GetTriviaList();
        }


        //This functions gets the full list of trivia questions from the Trivia.txt document
        static List<Trivia> GetTriviaList()
        {
            bool playing = true;

            while (playing)
            {
                Random rng = new Random();

                int randomNum = rng.Next();
            }

                //Get Contents from the file.  Remove the special char "\r".  Split on each line.  Convert to a list.
                List<string> contents = File.ReadAllText("trivia.txt").Replace("\r", "").Split('\n').ToList();

                //Each item in list "contents" is now one line of the Trivia.txt document.

                //make a new list to return all trivia questions
                List<Trivia> returnList = new List<Trivia>();
                // TODO: go through each line in contents of the trivia file and make a trivia object.
                //       add it to our return list.
                // Example: Trivia newTrivia = new Trivia("what is my name?*question");
                //Return the full list of trivia questions
                return returnList;
            
        }
        static void AddHighScore(int playerScore)
        {
            Console.WriteLine("Your name");
            string playerName = Console.ReadLine();
            OwenEntities db = new OwenEntities();
            HighScore.newHighScore = new HighScore();
            newHighScore.DateCreated = DateTime.Now;
            newHighScore.Game = playerName;
            newHighScore.Score = playerScore;
            db.HighScores.Add(newHighScore);
            db.SaveChanges();

        }


        static void DisplayHighScores()
        {
            Console.Clear();
            Console.WriteLine("Trivia Game");
            Console.WriteLine("------------");
            OwenEntities db = new OwenEntities();
            List<HighScore> highScoreList = db.HighScores.Where(x => x.Game == "Trivia Game").OrderByDescending(x => x.Score).Take(10).ToList();
            foreach (HighScore highScore in highScoreList)
            {
                Console.WriteLine("{0},{1} - {2} on {3}", highScoreList.IndexOf(highScore) + 1, highScore.Name, highScore.Score);
            }
        }
    }
}
