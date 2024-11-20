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
using System.Windows.Shapes;
using System.Xml.Serialization;
using System.IO;
using Ch13CardLib;

namespace BenCards.WPF
{
    /// <summary>
    /// Interaction logic for OptionsWindow.xaml
    /// </summary>
    public partial class OptionsWindow : Window
    {
        private GameOptions gameOptions;
        public OptionsWindow()
        {
            gameOptions = GameOptions.Create();
            DataContext = gameOptions;
            //if (gameOptions == null)
            //{
            //    if (File.Exists("GameOptions.xml"))
            //    {
            //        using (var stream = File.OpenRead("GameOptions.xml"))
            //        {
            //            var serializer = new XmlSerializer(typeof(GameOptions));
            //            gameOptions = serializer.Deserialize(stream) as GameOptions;
            //        }
            //    }
            //    else
            //    {
            //        gameOptions = new GameOptions();
            //    }
            //}
            //DataContext = gameOptions;
            InitializeComponent();
        }

        private void dumbAIRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            gameOptions.ComputerSkill = ComputerSkillLevel.Dumb;
        }

        private void goodAIRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            gameOptions.ComputerSkill = ComputerSkillLevel.Good;

        }

        private void cheatingAIRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            gameOptions.ComputerSkill = ComputerSkillLevel.Cheats;
        }

        private void oKButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            gameOptions.Save();
            Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            gameOptions = null;
            Close();
        }
    }
}
