using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza_La_Rosa
{
    public class Order
    {
        #region Properties
        public int Quantity { get; set; }
        public long ReferenceNo { get; set; }
        public long ProductID { get; set; }
        public string Name { get; set; }
        public double PricePerItem { get; set; }
        public double Discount { get; set; }
        public double TotalPrice { get { return PricePerItem * Quantity; } }

        public string Comment { get; set; } //Gert
        private string driverId = "0";
        public string DriverID //Gert
        {
            get { return driverId; }
            set
            {
                driverId = getDriverID(value);
            }
        }
        public static string getDriverID(string driver)
        {
            
            try
            {
                int firstId = driver.IndexOf("[");
                int secondId = driver.IndexOf("]");
                
                return int.Parse(driver.Substring(firstId + 1, secondId - firstId - 1)).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Driver ID");
            }
            return "0";
        }
        //Gert
        public Variation ItemVariation { get; set; }
        //public double IngredientPrice { get; set; }

       

        #endregion

        public long getVariationID()
        {
            if (ItemVariation == null)
                return 0;
            else
                return ItemVariation.VariationID;
        }

        public Order()
        { }
    }
}
