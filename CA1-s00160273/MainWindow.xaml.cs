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

/*##############################################################################################################################
Assignment By: Konrad Dryniewicz
Student ID: s00160273
Group: Games Development
Year: 2nd Year - Semester 2
Assignment: CA 1
Due Date: Friday 3rd of March, 2017

Working: 
-Adding Vehicles by type
-Removing them
-Editing them
-Images are imported into IMG folder from any chosen path during Dialog Prompt
-Filtering by radio buttons
-User can add as many vehicles (Cars, bikes or vans) to the program as they want as I'm using dynamic LinkedLists Collections for storing them.
-Radio buttons icons

Not Working:
-Save & Load by file buttons
-Image is loaded but doesn't display for some reason. I checked the path that gets loaded and it should display the image as it's the same
one that I used when testing with hardcoded values, but for some reason it isn't just loading the images for any vehicle.
The image loading used to work before I added file copying so I'm assuming there's a problem there, I couldn't find out what it was.
-The colours and icons don't display in list, I haven't added that.
-Sort by not working.

 Hopefully my list of Working/Not working will help a little.
##############################################################################################################################*/

namespace CA1_s00160273
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public LinkedList<Car> CarList = new LinkedList<Car>();
        public LinkedList<Bike> BikeList = new LinkedList<Bike>();
        public LinkedList<Van> VanList = new LinkedList<Van>();
        public LinkedList<Vehicle> AllList = new LinkedList<Vehicle>();


        public MainWindow()
        {
            InitializeComponent();

            #region TestCode (IGNORE)
            //Car c1 = new Car("Ford", "Focus", 52000, 2010, 40000, "A very reliable car.", "Hatchback");
            //c1.imagePath = "/IMG/2010FordFocusHatchback.jpg";


            //Car c2 = new Car("Nissan", "Micra", 500, 2000, 240000, "Old Car. Great for starting drivers", "bkc");
            //Car c3 = new Car("BMW", "320i", 6, 2000, 40000, "A simple enough car.", "Saloon");

            //Bike b1 = new Bike("Yamaha", "2000", 15000, 2015, 2000, "One of the best bikes on market!", "Sports");
            //Bike b2 = new Bike("Chopper", "VeryNice", 1499, 2005, 250000, "Decent Bike.", "Commuter");
            //Bike b3 = new Bike("Honda", "SomeBike", 19500, 2017, 0, "Brand New Bike.", "asjdi");

            //Van v1 = new Van("Volkswagen", "Transit", 12000, 2010, 15568, "Reliable and efficient Van.", "Short", "Combi Van");
            //Van v2 = new Van("Opel", "Van", 15999, 2012, 12156, "Reliable and efficient Van.", "Medium", "Pickup");
            //Van v3 = new Van("Volkswagen", "Transit", 12000, 2010, 15568, "Reliable and efficient Van.", "something", "something");

            //CarList.AddLast(c1);
            //CarList.AddLast(c2);
            //CarList.AddLast(c3);

            //BikeList.AddLast(b1);
            //BikeList.AddLast(b2);
            //BikeList.AddLast(b3);

            //VanList.AddLast(v1);
            //VanList.AddLast(v2);
            //VanList.AddLast(v3);

            //AllList.AddLast(c1);
            //AllList.AddLast(c2);
            //AllList.AddLast(c3);
            //AllList.AddLast(b1);
            //AllList.AddLast(b2);
            //AllList.AddLast(b3);
            //AllList.AddLast(v1);
            //AllList.AddLast(v2);
            //AllList.AddLast(v3);
            #endregion

            radAll.IsChecked = true;

            img_all.Source = new BitmapImage(new Uri("/IMG/all-icon.png", UriKind.Relative));
            img_cars.Source = new BitmapImage(new Uri("/IMG/car-icon.png", UriKind.Relative));
            img_bikes.Source = new BitmapImage(new Uri("/IMG/motorcycle-icon.png", UriKind.Relative));
            img_vans.Source = new BitmapImage(new Uri("/IMG/van-icon.png", UriKind.Relative));

        }

        private void radCars_Checked(object sender, RoutedEventArgs e)
        {
            lbxCars.ItemsSource = CarList;
        }

        private void radAll_Checked(object sender, RoutedEventArgs e)
        {
            lbxCars.ItemsSource = AllList;
        }

        private void radBikes_Checked(object sender, RoutedEventArgs e)
        {
            lbxCars.ItemsSource = BikeList;
        }

        private void radVans_Checked(object sender, RoutedEventArgs e)
        {
            lbxCars.ItemsSource = VanList;
        }

        private void lbxCars_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lbxCars.SelectedItem != null)
            {
                if (lbxCars.SelectedItem.GetType().Name == "Car")
                {
                    Car selectedCar = lbxCars.SelectedItem as Car;
                    txCarDetails.Text = selectedCar.VehDisplayDetails();
                    imgCar.Source = new BitmapImage(new Uri(selectedCar.imagePath, UriKind.Relative));
                }
                else if (lbxCars.SelectedItem.GetType().Name == "Bike")
                {
                    Bike selectedBike = lbxCars.SelectedItem as Bike;
                    txCarDetails.Text = selectedBike.VehDisplayDetails();
                    imgCar.Source = new BitmapImage(new Uri(selectedBike.imagePath, UriKind.Relative));
                }
                else if (lbxCars.SelectedItem.GetType().Name == "Van")
                {
                    Van selectedVan = lbxCars.SelectedItem as Van;
                    txCarDetails.Text = selectedVan.VehDisplayDetails();
                    imgCar.Source = new BitmapImage(new Uri(selectedVan.imagePath, UriKind.Relative));
                }
            }
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (radAll.IsChecked == true)
            {
                MessageBox.Show("You cannot create 'All' Vehicle. Choose one from Car, Bike or Van to create in radio buttons!");
            }
            else if (radCars.IsChecked == true)
            {
                //Create new window object
                AddCar addCarWindow = new AddCar();

                //Create link between two
                addCarWindow.Owner = this;

                //Display
                addCarWindow.ShowDialog();
            }
            else if (radBikes.IsChecked == true)
            {
                //Create new window object
                AddBike addBikeWindow = new AddBike();

                //Create link between two
                addBikeWindow.Owner = this;

                //Display
                addBikeWindow.ShowDialog();
            }
            else if (radVans.IsChecked.Value == true)
            {
                //Create new window object
                AddVan addVanWindow = new AddVan();

                //Create link between two
                addVanWindow.Owner = this;

                //Display
                addVanWindow.ShowDialog();
            }
            UpdateListbox();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(lbxCars.SelectedItem != null)
            {
                txCarDetails.Text = "";
                if (lbxCars.SelectedItem.GetType().Name == "Car")
                {

                    Car selectedCar = lbxCars.SelectedItem as Car;
                    if (selectedCar != null)
                    {
                        AllList.Remove(selectedCar);
                        CarList.Remove(selectedCar);
                    }
                }
                else if (lbxCars.SelectedItem.GetType().Name == "Bike")
                {
                    Bike selectedBike = lbxCars.SelectedItem as Bike;
                    if (selectedBike != null)
                    {
                        AllList.Remove(selectedBike);
                        BikeList.Remove(selectedBike);
                    }
                }
                else if (lbxCars.SelectedItem.GetType().Name == "Van")
                {
                    Van selectedVan = lbxCars.SelectedItem as Van;
                    if (selectedVan != null)
                    {
                        AllList.Remove(selectedVan);
                        VanList.Remove(selectedVan);
                    }
                }

                UpdateListbox();
            }
        }

        public void UpdateListbox()
        {
            if (radAll.IsChecked == true)
            {
                lbxCars.ItemsSource = "";
                lbxCars.ItemsSource = AllList;
            }
            else if(radCars.IsChecked == true )
            {
                lbxCars.ItemsSource = "";
                lbxCars.ItemsSource = CarList;
            }
            else if (radBikes.IsChecked == true)
            {
                lbxCars.ItemsSource = "";
                lbxCars.ItemsSource = BikeList;
            }
            else if (radVans.IsChecked == true)
            {
                lbxCars.ItemsSource = "";
                lbxCars.ItemsSource = VanList;
            }
        }
        
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lbxCars.SelectedItem != null)
            {
                if (lbxCars.SelectedItem.GetType().Name == "Car")
                {
                    //Create new window object
                    EditCar EditCarWindow = new EditCar();

                    //Create link between two
                    EditCarWindow.Owner = this;

                    //Display
                    EditCarWindow.ShowDialog();

                }
                else if (lbxCars.SelectedItem.GetType().Name == "Bike")
                {
                    //Create new window object
                    EditBike EditBikeWindow = new EditBike();

                    //Create link between two
                    EditBikeWindow.Owner = this;

                    //Display
                    EditBikeWindow.ShowDialog();
                }
                else if (lbxCars.SelectedItem.GetType().Name == "Van")
                {
                    //Create new window object
                    EditVan EditVanWindow = new EditVan();

                    //Create link between two
                    EditVanWindow.Owner = this;

                    //Display
                    EditVanWindow.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Select something to edit first!");
            }
            
        }

        private void cmbSortBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string SortType = cmbSortBy.SelectedValue.ToString();

            if (SortType.Equals("All"))
            {
                lbxCars.ItemsSource = AllList;
            }
           else
            {
                FilterSort(SortType);
            }


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string[] SortBy = {"All", "Make", "Year", "Price"};
            cmbSortBy.ItemsSource = SortBy;
            cmbSortBy.SelectedIndex = 0; //Set index to All
            UpdateListbox();

        }

        public void FilterSort(string SortBy)
        {
           if(SortBy == "All")
            {
                lbxCars.ItemsSource = AllList;
            }
           else if(SortBy == "Make")
            {
                lbxCars.ItemsSource = "";
                AllList.OrderByDescending(p => p.Make);
                lbxCars.ItemsSource = AllList;
            }
            else if (SortBy == "Year")
            {
                lbxCars.ItemsSource = "";
                AllList.OrderByDescending(p => p.Year);
                lbxCars.ItemsSource = AllList;
            }
            else if (SortBy == "Price")
            {
                lbxCars.ItemsSource = "";
                AllList.OrderByDescending(p => p.Price);
                lbxCars.ItemsSource = AllList;
            }
        }
    }
}
