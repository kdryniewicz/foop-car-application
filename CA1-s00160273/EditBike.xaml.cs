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

namespace CA1_s00160273
{
    /// <summary>
    /// Interaction logic for EditCar.xaml
    /// </summary>
    public partial class EditBike : Window
    {
        public Bike tempBike = new Bike();

        public EditBike()
        {
            InitializeComponent();
            string[] biketypes = { "Scooter", "Trail Bike", "Sports", "Commuter", "Tourer", "Unlisted" };
            cbxBikeType.ItemsSource = biketypes;
            cbxBikeType.SelectedIndex = 0; //Set index to All

            
        }

        private void btnLocateImg_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|JPEG Files (*.jpeg)|*.jpeg|GIF Files (*.gif)|*.gif";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.SafeFileName;
                txImgPath.Text = "/IMG/" + filename;
            }

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tempBike.Make = txMake.Text;
                tempBike.Model = txModel.Text;
                tempBike.Price = Convert.ToInt32(txPrice.Text);
                tempBike.Year = Convert.ToInt32(txYear.Text);
                tempBike.Mileage = Convert.ToInt32(txMileage.Text);
                tempBike.Colour = txColour.Text;
                string selection = cbxBikeType.SelectedItem.ToString();
                tempBike.imagePath = txImgPath.Text;

                foreach (var type in tempBike.possibleBikeTypes)
                {
                    if (selection == type)
                    {
                        tempBike.BikeType = selection;
                        break;
                    }
                    else
                    {
                        tempBike.BikeType = tempBike.possibleBikeTypes[5];
                    }
                }

                tempBike.Description = txDescription.Text;
                tempBike.imagePath = txImgPath.Text;


                //get link to main window
                MainWindow main = this.Owner as MainWindow;

                //add Car
                main.BikeList.Remove(tempBike);
                main.AllList.Remove(tempBike);
                
                main.BikeList.AddLast(tempBike);
                main.AllList.AddLast(tempBike);

                //close window
                this.Close();
                main.UpdateListbox();
            }
            catch (FormatException formatEx)
            {
                MessageBox.Show("Error in input, Probably a string in a number field (Price, Year or Mileage) -->" + formatEx.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //get link to main window
            MainWindow main = this.Owner as MainWindow;

            if (main.lbxCars.SelectedItem != null)
            {
                tempBike = main.lbxCars.SelectedItem as Bike;
            }


            txMake.Text = tempBike.Make;
            txModel.Text = tempBike.Model;
            txPrice.Text = tempBike.Price.ToString();
            txYear.Text = tempBike.Year.ToString();
            txMileage.Text = tempBike.Mileage.ToString();
            txColour.Text = tempBike.Colour.ToString();
            txDescription.Text = tempBike.Description;
            txImgPath.Text = tempBike.imagePath;
            cbxBikeType.SelectedItem = tempBike.BikeType;

        }
    }
}
