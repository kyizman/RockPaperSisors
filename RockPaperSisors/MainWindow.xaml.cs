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

namespace RockPaperSisors
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string playerchoice;
        private string aiselection;

        private int playerspicksslector = -1;
        private string[] playersPicks = new string[10];

        private double rockcount = 0.95;
        private double Papercount = 0.95;
        private double Sisorscount = 0.95;
        private double Lizzardcount = 0.95;
        private double Spockcount = 0.95;

        private int score1 = 0;
        private int score2 = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Rock_Click(object sender, RoutedEventArgs e)
        {
            playerchoice = "Rock";

            aiChoice();

            Winnercheck();

            Lizzardcount -= .1;
            Papercount += .1;
            Spockcount -= .1;
            Sisorscount -= .1;

        }



        public void Winnercheck()
        {
            enemy.Content = aiselection;
            Player.Content = playerchoice;
            playerspicksslector++;
            if(playerspicksslector >9)
            {
                playerspicksslector = 0;
            }

            playersPicks[playerspicksslector] = playerchoice;

            switch(playerchoice)
            {
                case "Rock":

                    if(aiselection == "Scissors" || aiselection == "Lizard")
                    {
                        score1 += 1;
                       player_score.Content=score1;
                    }
                    else if(aiselection=="Rock")
                    {
                        
                    }
                    else
                    {
                        score2 += 1;
                        EnemyScore.Content = score2;
                    }
                    break;


                case "Paper":

                    if (aiselection == "Rock" || aiselection == "Spock")
                    {
                        score1 += 1;
                        player_score.Content = score1;
                    }
                    else if (aiselection == "Paper")
                    {
                        
                    }
                    else
                    {
                        score2 += 1;
                        EnemyScore.Content = score2; ;
                    }
                    break;


                case "Scissors":

                    if (aiselection == "Paper" || aiselection == "Lizard")
                    {
                        score1 += 1;
                        player_score.Content = score1; ;
                    }
                    else if (aiselection == "Scissors")
                    {
                       
                    }
                    else
                    {
                        score2 += 1;
                        EnemyScore.Content = score2;
                    }
                    break;


                case "Lizard":

                    if (aiselection == "Paper" || aiselection == "Spock")
                    {
                        score1 += 1;
                        player_score.Content = score1; ;
                    }
                    else if (aiselection == "Lizard")
                    {

                    }
                    else
                    {
                        score2 += 1;
                        EnemyScore.Content = score2;
                    }
                    break;


                case "Spock":

                    if (aiselection == "Rock" || aiselection == "Scissors")
                    {
                        score1 += 1;
                        player_score.Content = score1;
                    }
                    else if (aiselection == "Spock")
                    {
                       
                    }
                    else
                    {
                        score2 += 1;
                        EnemyScore.Content = score2;
                    }

                    break;


            }

        


        }

        public void aiChoice()
        {
            if(Spockcount <0)
            {
                Spockcount = 0;
            }
            if (rockcount < 0)
            {
                rockcount = 0;
            }

            if (Lizzardcount < 0)
            {
                Lizzardcount = 0;
            }

            if (Papercount < 0)
            {
             Papercount = 0;
            }
            if (Sisorscount < 0)
            {
                Sisorscount = 0;
            }


            double randnumber = new double();
            Random random = new Random();
            randnumber = random.NextDouble() * (Math.Exp(rockcount) + Math.Exp(Sisorscount) + Math.Exp(Papercount) + Math.Exp(Spockcount) + Math.Exp(Lizzardcount));


            if(randnumber <Math.Exp(rockcount))
            {
                aiselection = "Rock";
            }


            else if(randnumber< Math.Exp(rockcount) + Math.Exp(Papercount))
            {
                aiselection = "Paper";
            }

            else if(randnumber < Math.Exp(rockcount) + Math.Exp(Papercount)+ Math.Exp(Sisorscount))
            {
                aiselection = "Scissors";
            }
            else if (randnumber < Math.Exp(rockcount) + Math.Exp(Papercount) + Math.Exp(Sisorscount)+Math.Exp(Lizzardcount))
            {
                aiselection = "Lizard";
            }
            else
            {
                aiselection = "Spock";
            }

           // if(rockcount>Papercount && rockcount >Sisorscount && rockcount > Lizzardcount && rockcount > Spockcount)
           // {
           //     aiselection = "Paper";
           // }

                //else if (Papercount > rockcount && Papercount > Sisorscount && Papercount > Lizzardcount && Papercount > Spockcount)
                // {
                //     aiselection = "Sissors";
                // }

                // else if (Sisorscount > Papercount && Sisorscount > rockcount && Sisorscount > Lizzardcount && Sisorscount > Spockcount)
                // {
                //     aiselection = "Rock";
                // }
                // else if (Lizzardcount > Papercount && Lizzardcount > Sisorscount && Lizzardcount > rockcount && Lizzardcount > Spockcount)
                // {
                //     aiselection = "Rock";
                // }

                // else
                // {
                //     aiselection = "Paper";
                // }








                //string[] aichoicelist = new string[] {"Rock","Paper", "Scissors","Lizard","Spock" } ;

                //Random randomselect = new Random();

                //randomselect.Next(1, 5);

                //aiselection = aichoicelist[randomselect.Next(0, 4)];


        }

        private void paper_Click(object sender, RoutedEventArgs e)
        {

            playerchoice = "Paper";

            aiChoice();

            Winnercheck();

            rockcount -= .1;
            Spockcount -= .1;

            Lizzardcount += .1;
            Sisorscount += .1;
        }

        private void Sisors_Click(object sender, RoutedEventArgs e)
        {
            playerchoice = "Scissors";

            aiChoice();

            Winnercheck();

            Papercount -= .1;
            Lizzardcount -= .1;
            rockcount += .1;
            Spockcount += .1;
        }

        private void Lizard_Click(object sender, RoutedEventArgs e)
        {
            playerchoice = "Lizard";

            aiChoice();

            Winnercheck();

            Spockcount -= .1;
            Papercount -= .1;
            rockcount += .1;
            Sisorscount += .1;

        }

        private void Spock_Click(object sender, RoutedEventArgs e)
        {
            playerchoice = "Spock";

            aiChoice();

            Winnercheck();

            Lizzardcount += .1;
            Papercount += .1;
            rockcount -= .1;
            Sisorscount -= .1;
        }
    }


}
