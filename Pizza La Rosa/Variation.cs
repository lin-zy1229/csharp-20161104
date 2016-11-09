using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_La_Rosa
{
    public class Variation
    {
        #region Members
        private System.Windows.Forms.Panel mContainer;
        private int mX;
        private int mY;

        #endregion

        #region Properties

        public string VariationName { get; set; }
        public double VariationPrice { get; set; }
        public double IngredientPrice { get; set; }
        public long ProductID { get; set; }
        public long VariationID { get; set; }

        public System.Windows.Forms.RadioButton RadVariation = null;

        #endregion

        public Variation(System.Windows.Forms.Panel pContainer, int pX, int pY)
        {
            mContainer = pContainer;
            mX = pX;
            mY = pY;
        }
        
        public void addVariationRadio()
        {
            this.RadVariation = new System.Windows.Forms.RadioButton();
            this.RadVariation.AutoSize = true;
            this.RadVariation.Location = new System.Drawing.Point(mX, mY);
            this.RadVariation.Name = "radVariation" + VariationID.ToString();
            //this.radMittel.TabIndex = 1;
            //this.radMittel.Tag = "0.8";
            this.RadVariation.Checked = false;
            this.RadVariation.Text = VariationName;
            this.RadVariation.Tag = VariationPrice.ToString("C2");
            this.RadVariation.UseVisualStyleBackColor = true; 

            //
            mContainer.Controls.Add(this.RadVariation);
        }

    }
}
