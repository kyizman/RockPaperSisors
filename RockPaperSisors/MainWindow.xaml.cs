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
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Rock_Click(object sender, RoutedEventArgs e)
        {
            playerchoice = "Rock";

            aiChoice();

            Winnercheck();
           
        }



        public int Winnercheck()
        {
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
                        return 1;
                    }
                    else if(aiselection=="Rock")
                    {
                        return 2;
                    }
                    else
                    {
                        return 3;
                    }
                    


                case "Paper":

                    if (aiselection == "Rock" || aiselection == "Spock")
                    {
                        return 1;
                    }
                    else if (aiselection == "Paper")
                    {
                        return 2;
                    }
                    else
                    {
                        return 3;
                    }
                    


                case "Scissors":

                    if (aiselection == "Paper" || aiselection == "Lizard")
                    {
                        return 1;
                    }
                    else if (aiselection == "Scissors")
                    {
                        return 2;
                    }
                    else
                    {
                        return 3;
                    }
                    


                case "Lizard":

                    if (aiselection == "Paper" || aiselection == "Spock")
                    {
                        return 1;
                    }
                    else if (aiselection == "Lizard")
                    {
                        return 2;
                    }
                    else
                    {
                        return 3;
                    }
                   


                case "Spock":

                    if (aiselection == "Rock" || aiselection == "Scissors")
                    {
                        return 1;
                    }
                    else if (aiselection == "Spock")
                    {
                        return 2;
                    }
                    else
                    {
                        return 3;
                    }
                 

                    

            }

            return 4;


        }

        public void aiChoice()
        {

            string[] aichoicelist = new string[] {"Rock","Paper", "Scissors","Lizard","Spock" } ;

            Random randomselect = new Random();

            randomselect.Next(1, 5);

            aiselection = aichoicelist[randomselect.Next(0, 4)];


        }

       
    }

}
