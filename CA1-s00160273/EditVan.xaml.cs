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
    public partial class EditVan : Window
    {
        public Van tempVan = new Van();

        public EditVan()
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

        private void btnEditVan_Click(object sender, RoutedEventArgs e)
        {
            try
            {
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

                    tempVan.Description = txDescription.Text;
                    tempVan.imagePath = txImgPath.Text;


                    //get link to main window
                    MainWindow main = this.Owner as MainWindow;

                    //add Car
                    main.VanList.Remove(tempVan);
                    main.AllList.Remove(tempVan);

                    main.VanList.AddLast(tempVan);
                    main.AllList.AddLast(tempVan);

                    //close window
                    this.Close();
                    main.UpdateListbox();
                }
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
                tempVan = main.lbxCars.SelectedItem as Van;
            }


            txMake.Text = tempVan.Make;
            txModel.Text = tempVan.Model;
            txPrice.Text = tempVan.Price.ToString();
            txYear.Text = tempVan.Year.ToString();
            txMileage.Text = tempVan.Mileage.ToString();
            txColour.Text = tempVan.Colour.ToString();
            txDescription.Text = tempVan.Description;
            txImgPath.Text = tempVan.imagePath;
            cbxVanType.SelectedItem = tempVan.VanType;
            cbxWheelbase.SelectedItem = tempVan.Wheelbase;

        }
    }
}
