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
    public partial class AddVan : Window
    {
        public AddVan()
        {
            InitializeComponent();
            string[] VanType = { "Combi Van", "Dropside", "Panel Van", "Pickup", "Tipper", "Unlisted" };
            cbxVanType.ItemsSource = VanType;
            cbxVanType.SelectedIndex = 0; //Set index to All
            string[] Wheelbase = { "Short", "Medium", "Long", "Unlisted" };
            cbxWheelbase.ItemsSource = Wheelbase;
            cbxWheelbase.SelectedIndex = 0; //Set index to All
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

        private void btnAddVan_Click(object sender, RoutedEventArgs e)
        {
            if(txImgPath.Text != null && txMake.Text != null && txModel.Text != null && txPrice.Text != null && txYear.Text != null && txMileage.Text != null && txColour.Text != null && txDescription.Text != null && txImgPath != null)
            {
                try
                {
                    Van tempVan = new Van();
                    tempVan.Make = txMake.Text;
                    tempVan.Model = txModel.Text;
                    tempVan.Price = Convert.ToInt32(txPrice.Text);
                    tempVan.Year = Convert.ToInt32(txYear.Text);
                    tempVan.Mileage = Convert.ToInt32(txMileage.Text);
                    tempVan.Colour = txColour.Text;
                    string selectionType = cbxVanType.SelectedItem.ToString();
                    string selectionWheels = cbxWheelbase.SelectedItem.ToString();
                    tempVan.imagePath = txImgPath.Text;

                    foreach (var type in tempVan.possibleVanTypes)
                    {
                        if (selectionType == type)
                        {
                            tempVan.VanType = selectionType;
                            break;
                        }
                        else
                        {
                            tempVan.VanType = tempVan.possibleVanTypes[5];
                        }
                    }
                    foreach (var wheel in tempVan.possibleWheelbase)
                    {
                        if (selectionWheels == wheel)
                        {
                            tempVan.Wheelbase = selectionWheels;
                            break;
                        }
                        else
                        {
                            tempVan.Wheelbase = tempVan.possibleWheelbase[3];
                        }
                    }
                    tempVan.Description = txDescription.Text;
                    tempVan.imagePath = txImgPath.Text;

                    //get link to main window
                    MainWindow main = this.Owner as MainWindow;

                    //add Car
                    main.VanList.AddLast(tempVan);
                    main.AllList.AddLast(tempVan);

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
