using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps;
using MahApps.Metro.Controls;

namespace RockPaperSisors
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        //The Choices of both ai and player for comparison 
        private string playerchoice;
        private string aiselection;
        //Win quotes for the front end
        private string[] aitrashtalk = new string[] {"Your Next Line Is","Yawn...","Infant","Go watch More rick and morty befor playing me again","Be glad tiny brain can Doge","Ai got Hands Huh..."
             ,"Bronzie","I know your better than this","Im 3 parralell Universis Ahed of you!","Why?"   };
        private string[] aicopieum = new string[] { "Wait You WON?!", "My little Brother Was Playing", "Hmmmm...", "My controller Got Unplugged", "Who Plays That?" };
         

        //Starting Values for the Ai probability 
        private double RockChances = 0.95;
        private double paperChances = 0.95;
        private double sisorsChances = 0.95;
        private double lizzardChances = 0.95;
        private double spockChances = 0.95;
        //set scores for front end to 0 at the begining 
        private int score1 = 0;
        private int score2 = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

     
        private void Rock_Click(object sender, RoutedEventArgs e)
        {
            //changes the players selection to rock
            playerchoice = "Rock";
//loads respective image to the player image entitiy
            PlayerImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/rock.jpg"));
           
            //calls the ai method to select an answer
            aiChoice();
            //check who won the round
            Winnercheck();

            //increase the winning selections decrease loosing selections for the ai after the round
           lizzardChances -= .1;
            paperChances += .1;
            spockChances += .1;
            sisorsChances -= .1;

        }



        public void Winnercheck()
        {
            //random to select new quote
            Random aitalknum = new();
            //enemy.Content = aiselection;
            //Player.Content = playerchoice;
          
            //switch based on the players selection
            //each one will check if the ai chose the loosing hand, then check if they selected a tie, or the ai won
            //with this if the player wins it will incroment the score and vice versa if the ai wins
            switch(playerchoice)
            {
                case "Rock":

                    if(aiselection == "Scissors" || aiselection == "Lizard")
                    {
                        score1 += 1;
                       player_score.Content=score1;


                        aitalk.Text = aicopieum[aitalknum.Next(0, aicopieum.Length - 1)];
                    }
                    else if(aiselection=="Rock")
                    {
                        aitalk.Text = "Evenly Matched I See";
                    }
                    else
                    {
                        score2 += 1;
                        EnemyScore.Content = score2;

                        aitalk.Text = aitrashtalk[aitalknum.Next(0, aitrashtalk.Length - 1)];
                    }
                    break;


                case "Paper":

                    if (aiselection == "Rock" || aiselection == "Spock")
                    {
                        score1 += 1;
                        player_score.Content = score1;
                        aitalk.Text = aicopieum[aitalknum.Next(0, aicopieum.Length - 1)];
                    }
                    else if (aiselection == "Paper")
                    {
                        aitalk.Text = "Evenly Matched I See";
                    }
                    else
                    {
                        score2 += 1;
                        EnemyScore.Content = score2; ;
                        aitalk.Text = aitrashtalk[aitalknum.Next(0, aitrashtalk.Length - 1)];
                    }
                    break;


                case "Scissors":

                    if (aiselection == "Paper" || aiselection == "Lizard")
                    {
                        score1 += 1;
                        player_score.Content = score1; ; 
                        aitalk.Text = aicopieum[aitalknum.Next(0, aicopieum.Length - 1)];
                    }
                    else if (aiselection == "Scissors")
                    {
                        aitalk.Text = "Evenly Matched I See";
                    }
                    else
                    {
                        score2 += 1;
                        EnemyScore.Content = score2;
                        aitalk.Text = aitrashtalk[aitalknum.Next(0, aitrashtalk.Length - 1)];
                    }
                    break;


                case "Lizard":

                    if (aiselection == "Paper" || aiselection == "Spock")
                    {
                        score1 += 1;
                        player_score.Content = score1; ;
                        aitalk.Text = aicopieum[aitalknum.Next(0, aicopieum.Length - 1)];
                    }
                    else if (aiselection == "Lizard")
                    {
                        aitalk.Text = "Evenly Matched I See";
                    }
                    else
                    {
                        score2 += 1;
                        EnemyScore.Content = score2;
                        aitalk.Text = aitrashtalk[aitalknum.Next(0, aitrashtalk.Length - 1)];
                    }
                    break;


                case "Spock":

                    if (aiselection == "Rock" || aiselection == "Scissors")
                    {
                        score1 += 1;
                        player_score.Content = score1;
                        aitalk.Text = aicopieum[aitalknum.Next(0, aicopieum.Length - 1)];
                    }
                    else if (aiselection == "Spock")
                    {
                        aitalk.Text = "Evenly Matched I See";

                    }
                    else
                    {
                        score2 += 1;
                        EnemyScore.Content = score2;
                        aitalk.Text = aitrashtalk[aitalknum.Next(0, aitrashtalk.Length - 1)];
                    }

                    break;


            }

        


        }

        //This is to use the weights of each selection to allow the ai to attempt to win more
        public void aiChoice()
        {
            //these if statments are to check wether the 
            if(spockChances <0)
            {
                spockChances = 0;
            }
            if (RockChances < 0)
            {
                RockChances = 0;
            }

            if (lizzardChances < 0)
            {
               lizzardChances = 0;
            }

            if (paperChances < 0)
            {
             paperChances = 0;
            }
            if (sisorsChances < 0)
            {
                sisorsChances = 0;
            }


            double randnumber = new double();
            Random random = new Random();
            randnumber = random.NextDouble() * (Math.Exp(RockChances) + Math.Exp(sisorsChances) + Math.Exp(paperChances) + Math.Exp(spockChances) + Math.Exp(lizzardChances));


            if(randnumber <Math.Exp(RockChances))
            {
                aiselection = "Rock";

                AIIMAGE.Source = new BitmapImage(new Uri("pack://application:,,,/Images/rock.jpg"));
            }


            else if(randnumber< Math.Exp(RockChances) + Math.Exp(paperChances))
            {
                aiselection = "Paper";
                AIIMAGE.Source = new BitmapImage(new Uri("pack://application:,,,/Images/Paper.jpg"));
            }

            else if(randnumber < Math.Exp(RockChances) + Math.Exp(paperChances)+ Math.Exp(sisorsChances))
            {
                AIIMAGE.Source = new BitmapImage(new Uri("pack://application:,,,/Images/sissors.jpg"));

                aiselection = "Scissors";
            }
            else if (randnumber < Math.Exp(RockChances) + Math.Exp(paperChances) + Math.Exp(sisorsChances)+Math.Exp(lizzardChances))
            {
                aiselection = "Lizard";
                AIIMAGE.Source = new BitmapImage(new Uri("pack://application:,,,/Images/lizzard.jpg"));
            }
            else
            {
                aiselection = "Spock";
                AIIMAGE.Source = new BitmapImage(new Uri("pack://application:,,,/Images/spock.jpg"));
            }

         






        }

        private void paper_Click(object sender, RoutedEventArgs e)
        {

            playerchoice = "Paper";
            PlayerImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/Paper.jpg"));
            aiChoice();

            Winnercheck();

            RockChances -= .1;
            spockChances -= .1;

           lizzardChances += .1;
            sisorsChances += .1;
        }

        private void Sisors_Click(object sender, RoutedEventArgs e)
        {
            playerchoice = "Scissors";
            PlayerImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/sissors.jpg"));
            aiChoice();

            Winnercheck();

            paperChances -= .1;
           lizzardChances -= .1;
            RockChances += .1;
            spockChances += .1;
        }

        private void Lizard_Click(object sender, RoutedEventArgs e)
        {
            playerchoice = "Lizard";
            PlayerImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/lizzard.jpg"));
            aiChoice();

            Winnercheck();

            spockChances -= .1;
            paperChances -= .1;
            RockChances += .1;
            sisorsChances += .1;

        }

        private void Spock_Click(object sender, RoutedEventArgs e)
        {
            playerchoice = "Spock";
            PlayerImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/spock.jpg"));
            aiChoice();

            Winnercheck();

           lizzardChances += .1;
            paperChances += .1;
            RockChances -= .1;
            sisorsChances -= .1;
        }

        private void rules_Click(object sender, RoutedEventArgs e)
        {
            RockPaperSisors.rules rules = new();

            rules.Show();
        }
    }


}
