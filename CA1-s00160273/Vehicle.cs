using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CA1_s00160273
{
    public abstract class Vehicle : IComparable
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public string Description { get; set; }
        public string vehType { get; set; }
        public string imagePath { get;  set;}
        public string Colour { get; set; }
        public Image VehTypeIMG;

        public override string ToString()
        {
            return (String.Format("{0} {1} - {2}", Make, Model, vehType));
        }

        public int SortByMake(object obj)
        {
            Vehicle temp = (Vehicle)obj;

            return (this.Make.CompareTo(temp.Make));
        }
        public int SortByPrice(object obj)
        {
            Vehicle temp = (Vehicle)obj;

            return (this.Price.CompareTo(temp.Price));
        }
        public int SortByYear(object obj)
        {
            Vehicle temp = (Vehicle)obj;

            return (this.Year.CompareTo(temp.Year));
        }

        public int CompareTo(object obj)
        {
            Vehicle temp = (Vehicle)obj;


            return this.Make.CompareTo(temp.Make);
        }
    }

    public class Car : Vehicle
    {
        public string[] possibleBodyTypes = new string[8] { "Convertible" , "Hatchback" , "Coupe" , "Estate", "MPV", "SUV", "Saloon", "Unlisted" };
        public string BodyType { get; set; }
        public string EngineSize { get; set; }

        public Car()
        {
            VehTypeIMG = new Image();
            this.vehType = GetType().Name;
            this.VehTypeIMG.Source = new BitmapImage(new Uri("/IMG/car-icon.png", UriKind.Relative));
        }
        public Car(string make, string model, int price, int year, int mileage, string description, string bodyType)
        {
            this.Make = make;
            this.Model = model;
            this.Price = price;
            this.Year = year;
            this.Mileage = mileage;
            this.Description = description;
            this.vehType = GetType().Name;
            foreach (var body in possibleBodyTypes)
            {
                if(bodyType == body)
                {
                    this.BodyType = bodyType;
                    break;
                }
                else
                {
                    this.BodyType = possibleBodyTypes[7];
                }
            }
        }

        public string VehDisplayDetails()
        {
            return (String.Format("Make: {0}\nModel: {1}\nPrice: {2}\nYear: {3}\nMileage: {4}\nDescription: {5}\nBody Type: {6}", Make, Model, Price, Year, Mileage, Description, BodyType));
        }
    }

    public class Bike : Vehicle
    {
        public string[] possibleBikeTypes = new string[6] { "Scooter", "Trail Bike", "Sports", "Commuter", "Tourer", "Unlisted" };
        public string BikeType { get; set; }

        public Bike()
        {
            VehTypeIMG = new Image();
            this.vehType = GetType().Name;
            this.VehTypeIMG.Source = new BitmapImage(new Uri("/IMG/motorcycle-icon.png", UriKind.Relative));
        }
        public Bike(string make, string model, int price, int year, int mileage, string description,string bikeType)
        {
            this.Make = make;
            this.Model = model;
            this.Price = price;
            this.Year = year;
            this.Mileage = mileage;
            this.Description = description;
            this.vehType = GetType().Name;
            foreach (var bike in possibleBikeTypes)
            {
                if (bikeType == bike)
                {
                    this.BikeType = bikeType;
                    break;
                }
                else
                {
                    this.BikeType = possibleBikeTypes[5];
                }
            }

        }
        public string VehDisplayDetails()
        {
            return (String.Format("Make: {0}\nModel: {1}\nPrice: {2}\nYear: {3}\nMileage: {4}\nDescription: {5}\nBike Type: {6}", Make, Model, Price, Year, Mileage, Description, BikeType));
        }
    }
   public class Van : Vehicle
    {
        public string[] possibleWheelbase = new string[4] { "Short", "Medium", "Long", "Unlisted" };
        public string Wheelbase { get; set; }
        public string[] possibleVanTypes = new string[6] { "Combi Van", "Dropside", "Panel Van", "Pickup", "Tipper", "Unlisted" };
        public string VanType { get; set; }

        public Van()
        {
            VehTypeIMG = new Image();
            this.vehType = GetType().Name;
            this.VehTypeIMG.Source = new BitmapImage(new Uri("/IMG/van-icon.png", UriKind.Relative));
        }
        public Van(string make, string model, int price, int year, int mileage, string description, string wheelBase, string vanType)
        {
            this.Make = make;
            this.Model = model;
            this.Price = price;
            this.Year = year;
            this.Mileage = mileage;
            this.Description = description;
            this.vehType = GetType().Name;
            foreach (var wheel in possibleWheelbase)
            {
                if (wheelBase == wheel)
                {
                    this.Wheelbase = wheelBase;
                    break;
                }
                else
                {
                    this.Wheelbase = possibleWheelbase[3];
                }
            }
            foreach (var type in possibleVanTypes)
            {
                if (vanType == type)
                {
                    this.VanType = vanType;
                    break;
                }
                else
                {
                    this.VanType = possibleVanTypes[5];
                }
            }

        }
        public string VehDisplayDetails()
        {
            return (String.Format("Make: {0}\nModel: {1}\nPrice: {2}\nYear: {3}\nMileage: {4}\nDescription: {5}\nWheelbase: {6}\nType: {7}", Make, Model, Price, Year, Mileage, Description, Wheelbase, VanType));
        }
    }
}
