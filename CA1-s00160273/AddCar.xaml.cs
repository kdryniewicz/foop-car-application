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
using System.IO;
using System.Windows.Shapes;

namespace CA1_s00160273
{
    /// <summary>
    /// Interaction logic for AddVehicle.xaml
    /// </summary>
    public partial class AddCar : Window
    {
        public AddCar()
        {
            InitializeComponent();
            string[] bodytypes = { "Convertible", "Hatchback", "Coupe", "Estate", "MPV", "SUV", "Saloon", "Unlisted" };
            cbxBodyType.ItemsSource = bodytypes;
            cbxBodyType.SelectedIndex = 0; //Set index to All

        }

        private void btnLocateImg_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
           


            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".jpg";
            dlg.Filter = "JPG Files (*.jpg)|*.jpg|*.jpeg|PNG Files (*.png)|*.png|JPEG Files (*.jpeg)|GIF Files (*.gif)|*.gif";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();
            

            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                
                string filename = dlg.SafeFileName;
                txImgPath.Text = "/IMG/" + filename;
                
                string destPath = System.IO.Path.GetFullPath(Directory.GetCurrentDirectory() + @"\..\..\IMG\" + dlg.SafeFileName);
                File.Copy(dlg.FileName, destPath, true);
            }
            
        }

        private void btnAddCar_Click(object sender, RoutedEventArgs e)
        {
            if(txImgPath.Text != null && txMake.Text != null && txModel.Text != null && txPrice.Text != null && txYear.Text != null && txMileage.Text != null && txEngine.Text != null && txColour.Text != null && txDescription.Text != null && txImgPath != null)
            {
                try
                {
                    Car tempCar = new Car();
                    tempCar.Make = txMake.Text;
                    tempCar.Model = txModel.Text;
                    tempCar.Price = Convert.ToInt32(txPrice.Text);
                    tempCar.Year = Convert.ToInt32(txYear.Text);
                    tempCar.Mileage = Convert.ToInt32(txMileage.Text);
                    tempCar.EngineSize = txEngine.Text;
                    tempCar.Colour = txColour.Text;
                    string selection = cbxBodyType.SelectedItem.ToString();
                    tempCar.imagePath = txImgPath.Text;

                    foreach (var body in tempCar.possibleBodyTypes)
                    {
                        if (selection == body)
                        {
                            tempCar.BodyType = selection;
                            break;
                        }
                        else
                        {
                            tempCar.BodyType = tempCar.possibleBodyTypes[7];
                        }
                    }

                    tempCar.Description = txDescription.Text;
                    tempCar.imagePath = txImgPath.Text;

                    //get link to main window
                    MainWindow main = this.Owner as MainWindow;

                    //add Car
                    main.CarList.AddLast(tempCar);
                    main.AllList.AddLast(tempCar);

                    //close window
                    this.Close();
                    main.UpdateListbox();
                }
                catch(FormatException formatEx)
                {
                    MessageBox.Show("Error in input, Probably a string in a number field (Price, Year or Mileage) -->" + formatEx.Message);
                }
            }
           
        }
    }
}
