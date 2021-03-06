﻿using BE;
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

namespace UI
{
    /// <summary>
    /// Interaction logic for UpdateSpecializationWindow.xaml
    /// </summary>
    public partial class UpdateSpecializationWindow : Window
    {
        BL.IBL bl;
        public UpdateSpecializationWindow()
        {
            InitializeComponent();
            bl = BL.Factory_BL.GetBL();
            InitializeComboBoxSpecField();
        }

        private void InitializeComboBoxSpecField()
        {
            comboBoxSpecField.Items.Add("Data structures");
            comboBoxSpecField.Items.Add("Computer communications");
            comboBoxSpecField.Items.Add("Information security");
            comboBoxSpecField.Items.Add("Server programming");
            comboBoxSpecField.Items.Add("Mobile programming");
            comboBoxSpecField.Items.Add("User interface designing");
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            
            if (boxSpecializationNumber.Text.Equals(""))
                MessageBox.Show("Please enter a specialization number", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (boxSpecializationName.Text.Equals(""))
                MessageBox.Show("Please enter a specialization name", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);

            else if (boxMinWage.Text.Equals(""))
                MessageBox.Show("Please enter a minimum wage", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);

            else if (boxMaxWage.Text.Equals(""))
                MessageBox.Show("Please enter a maximum wage", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);

            else if (comboBoxSpecField.SelectedValue == null)
                MessageBox.Show("Please choose a field", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);

            else
            {

                string spec = comboBoxSpecField.SelectedItem.ToString();
                switch (spec)
                {
                    case "Data structures":
                        spec = "dataStructures";
                        break;
                    case "Computer communications":
                        spec = "computerCommunications";
                        break;
                    case "Information security":
                        spec = "informationSecurity";
                        break;
                    case "Server programming":
                        spec = "serverProgramming";
                        break;
                    case "Mobile programming":
                        spec = "mobileProgramming";
                        break;
                    case "User interface designing":
                        spec = "userInterfaceDesigning";
                        break;

                }
                try
                {
                    bl.UpdateSpecialization(boxSpecializationName.Text, Double.Parse(boxMinWage.Text), Double.Parse(boxMaxWage.Text),
                        (Field)Enum.Parse(typeof(Field), spec), Int32.Parse(boxSpecializationNumber.Text));

                    MessageBox.Show("Specialization has been succesfully updated.");
                    boxSpecializationNumber.Clear();
                    boxSpecializationName.Clear();
                    boxMinWage.Clear();
                    boxMaxWage.Clear();
                    comboBoxSpecField.SelectedItem = null;
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void comboBoxSpecField_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button_Click2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

}