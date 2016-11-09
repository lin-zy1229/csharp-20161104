using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Collections;

namespace Pizza_La_Rosa
{
    public partial class frmMain : Form
    {
        #region Members & Constants
            private static string mDBPath = Application.StartupPath + "\\pizzadb.accdb";
            //private static string mDBPath = @"..\..\db\pizzadb.accdb";
        
            private List<string> mIngridients = null;
            private List<Variation> mVariations = null;
            private List<Order> mOrders = null;
            private BindingList<Order> ordersBindingList = null;
        
        private int m_currentPageIndex;
            private IList<Stream> m_streams;

            private List<string> mDeliverySectors = new List<string>(){ "FR-Zähringen", "Gundelfingen", "Wildtal", "FR-Herdern", "FR-Betzenhausen", 
                                                 "FR-Brühl", "Gewerbegebiet Hochdorf", "FR-Industriegebiet Nord", 
                                                 "FR-Mooswald", "FR-Stühlinger", "FR-Altstadt", "Hochdorf", "FR-Landwasser", 
                                                 "FR-Lehen", "FR-Gewerbgebiet Haid", "FR-Haslach", "FR-Rieselfeld", 
                                                 "FR-St. Georgen", "FR-Weingarten", "Denzlingen", "Benzhausen", "Buchheim", 
                                                 "Oberau", "Hugstetten", "FR-Opfingen", "Merzhausen", "Oberwiehre", 
                                                 "Unterwiehre", "FR-Vauban", "Au", "Günterstal", "Umkirch","Reute"};

            private Access.AccessSQL mDB = null;
        #endregion

        public frmMain()
        {
            InitializeComponent();
            txtDatabase.Text = mDBPath;
        }

        #region Functions

        // Display message box
        private static System.Windows.Forms.DialogResult displayMessage(string PMessage,
           MessageBoxButtons pButtons = MessageBoxButtons.OK, MessageBoxIcon pIcon = MessageBoxIcon.Error)
        {
            return MessageBox.Show(PMessage, Application.ProductName, pButtons, pIcon);
        }

        // Initializes connection with db and adds data for autocomplete and suggest fields
        private bool performInit()
        {
            try
            {
                // init db connection
                mDB = new Access.AccessSQL(mDBPath);
                if (!mDB.isConnectionExist())
                    throw new Exception("Can't connect to database!");

                mIngridients = new List<string>();
                mVariations = new List<Variation>();
                mOrders = new List<Order>();
                ordersBindingList = new BindingList<Order>();

                //
                prepareAutoCompleteSources();
                loadIngridients();

                dgvOrders.AutoGenerateColumns = false;
                //Gert commented
                //mDeliverySectors.Sort();
                //this.cmbDeliverySector.DataSource = mDeliverySectors;

                dtpDailyTimePicker.Value = DateTime.Now;
                lblRealPrice_1.Text = "";

                return true;
            }
            catch (Exception ex)
            {
                displayMessage("Error occured during initialization - " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Fill's autocomplete sources with data from database
        /// </summary>
        private void prepareAutoCompleteSources()
        {
            txtTelephone.AutoCompleteCustomSource.Clear();
            txtName.AutoCompleteCustomSource.Clear();
            txtClientNo.AutoCompleteCustomSource.Clear();

            // filling...
            List<string> resPhone = mDB.SelectSingleColumn<string>("Select `c_PhoneNumber` from `Clients`");
            List<string> resName = mDB.SelectSingleColumn<string>("Select `c_Name` from `Clients`");
            List<string> resReferenceNo = mDB.SelectSingleColumn<string>("Select `c_Number` from `Clients`");

            txtTelephone.AutoCompleteCustomSource.AddRange(resPhone.ToArray());
            txtName.AutoCompleteCustomSource.AddRange(resName.ToArray());
            txtClientNo.AutoCompleteCustomSource.AddRange(resReferenceNo.ToArray());

            resPhone.Clear();
            resName.Clear();
            resReferenceNo.Clear();
        }

        /// <summary>
        /// Loading ingridients from grid
        /// </summary>
        private void loadIngridients()
        {
            mIngridients = mDB.SelectSingleColumn<string>("Select `ing_Name` from `Pizza_Ingridients` order by `ing_Name`");

            chcmbIngridients.Items.Clear();
            foreach (string ing in mIngridients)
                chcmbIngridients.Items.Add(ing);
        }

        /// <summary>
        /// Perform search and fill client related fields
        /// </summary>
        /// <param name="pSearchValue"></param>
        /// <param name="pName"></param>
        private void performSearch(string pSearchValue, string pName)
        {
            if (string.IsNullOrEmpty(pSearchValue))
                return;

            DataTable res = mDB.Select("Select * from `Clients` Where `"+pName+"`=" + pSearchValue);
            // always take first found client....
            if (res.Rows.Count != 0)
            {
                // fill fields...
                txtTelephone.Text = Access.AccessSQL.getString(res.Rows[0]["c_PhoneNumber"]);
                txtName.Text = Access.AccessSQL.getString(res.Rows[0]["c_Name"]);
                txtStrasse.Text = Access.AccessSQL.getString(res.Rows[0]["c_Street"]);
                this.txtHouseNo.Text = Access.AccessSQL.getString(res.Rows[0]["c_HouseNumber"]);
                this.txtPostalCode.Text = Access.AccessSQL.getString(res.Rows[0]["c_PostalCode"]);
                this.txtCity.Text = Access.AccessSQL.getString(res.Rows[0]["c_City"]);
                //this.cmbDeliverySector.SelectedItem = Access.AccessSQL.getString(res.Rows[0]["c_DeliverySector"]); //Gert commented
                this.txtClientNo.Text = Access.AccessSQL.getString(res.Rows[0]["c_Number"]);
                
                //gert
                this.chkHardcoded.Checked = Access.AccessSQL.getInt(res.Rows[0]["c_Hard"]) == 1;
                if (this.chkHardcoded.Checked)
                {
                    txtTelephone.Enabled = false;
                    txtName.Enabled = false;
                    txtStrasse.Enabled = false;
                    txtHouseNo.Enabled = false;
                    txtPostalCode.Enabled = false;
                    txtCity.Enabled = false;
                }
                else
                {
                    txtTelephone.Enabled = true;
                    txtName.Enabled = true;
                    txtStrasse.Enabled = true;
                    txtHouseNo.Enabled = true;
                    txtPostalCode.Enabled = true;
                    txtCity.Enabled = true;
                }
            }
            else
            {
                txtTelephone.Text = "";
                txtTelephone.Enabled = true;
                txtName.Enabled = true;
                txtName.Text = "";
                txtStrasse.Enabled = true;
                txtStrasse.Text = "";
                txtHouseNo.Enabled = true;
                txtHouseNo.Text = "";
                txtPostalCode.Enabled = true;
                txtPostalCode.Text = "";
                txtCity.Enabled = true;
                txtCity.Text = "";

                displayMessage("No client found that matches provided criteria.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Perform's search when user presses on Enter key
        /// </summary>
        private void searchOnEnterKey(KeyEventArgs pKeyPressed, string pName, string pValue)
        {
            if (pKeyPressed.KeyData == Keys.Enter)
            {
                performSearch(pValue, pName);
            }
        }

        /// <summary>
        /// Clear order details fields
        /// </summary>
        private void clearOrderDetails()
        {
            //

            foreach (Variation vrt in mVariations)
            {
                vrt.RadVariation.Checked = false;
            }
          
            lblPrice.Text = "";
            lblRealPrice_1.Text = "";

            chkBaked.Checked = false;
            chkBaked.Visible = false;
            
            grpVariations.Text = "";

            for(int i= 0;i <chcmbIngridients.Items.Count; i++ ){
                chcmbIngridients.SetItemChecked(i, false);
            }

            //gert
            lblComment.Visible = true;
            txtComment.Clear();
            txtComment.Visible = true;

            chkDelivery.Visible = true;
            chkDelivery.Checked = false;
            cmbDrivers.Enabled = false;
            cmbDrivers.Visible = true;
        }


        private void variation_CheckedChanged(object sender, EventArgs e)
        {
            lblRealPrice_1.Text = ((RadioButton)sender).Tag.ToString();
        }

        /// <summary>
        /// Add variations into combobox
        /// </summary>
        /// <param name="pProductID">Reference id of product</param>
        private void addVariations(long pProductReference)
        {
            //cmbVariations.DataSource = null;
            DataTable dtb = mDB.Select("SELECT v.v_ID, v.v_Name, e1.p_ID AS prddid, e1.Price, IngredientPrice " +
                        "FROM ((Variations as v) LEFT JOIN Product_Variations AS e1 ON v.v_ID = e1.var_ID) " +
                        "left join Products as p on (e1.p_ID=p.p_ID) WHERE p.[p_Ref_No]=" + pProductReference.ToString() +
                        " order by v_Name");
            int startx = 4;
            int starty = 5;

            foreach (DataRow dr in dtb.Rows)
            {
                Variation vr = new Variation(pnlVariations, startx, starty);
                vr.ProductID = Access.AccessSQL.getLong(dr["prddid"]);
                vr.VariationID = Access.AccessSQL.getLong(dr["v_ID"]);
                vr.VariationName = Access.AccessSQL.getString(dr["v_Name"]);
                vr.VariationPrice = Access.AccessSQL.getDouble(dr["Price"]);
                vr.IngredientPrice = Access.AccessSQL.getDouble(dr["IngredientPrice"]);
                vr.addVariationRadio();
                vr.RadVariation.CheckedChanged += variation_CheckedChanged;

                starty += 20;
                mVariations.Add(vr);
            }
        }

        /// <summary>
        /// Clearing old variations
        /// </summary>
        private void clearOldVariations()
        {
            foreach (Variation vrn in mVariations)
            {
                vrn.RadVariation.CheckedChanged -= variation_CheckedChanged;
                pnlVariations.Controls.Remove(vrn.RadVariation);
                vrn.RadVariation.Dispose();
            }

            mVariations.Clear();
        }

        /// <summary>
        /// Attaching to orders grid
        /// </summary>
        private void attachToOrdersGrid()
        {
            ordersBindingList = new BindingList<Order>(mOrders);

            dgvOrders.DataSource = ordersBindingList;
        }

        /// <summary>
        /// Calculate total 
        /// </summary>
        private double calcTotalGesamt(ref double pDiscAmount)
        {
            double sum = (mOrders.Sum(x => x.TotalPrice));
            double discount = (mOrders.Sum(x => x.Discount*x.Quantity));
           
            // add 19%
            //sum += sum*19/100; 
            lblTotalSumPrice.Text = (sum-discount).ToString("C2");
            lblRabbat.Text = discount.ToString("C2");
            pDiscAmount = discount;

            return sum;
        }

        private DataTable ToDataTable(IList<Order> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(Order));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (Order item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        private DataTable ToDataTable(IList<CompeltedOrder> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(CompeltedOrder));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (CompeltedOrder item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        #region "Invoice Related"
        
        // Routine to provide to the report renderer, in order to
        //    save an image for each page of the report.
        private Stream CreateStream(string name,
          string fileNameExtension, Encoding encoding,
          string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }
        // Export the given report as an EMF (Enhanced Metafile) file.
        private void Export(LocalReport report)
        {
            string deviceInfo =
              @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>7.81in</PageWidth>
                <PageHeight>11.69in</PageHeight>
                <MarginTop>0.00in</MarginTop>
                <MarginLeft>0.00in</MarginLeft>
                <MarginRight>0.00in</MarginRight>
                <MarginBottom>0.00in</MarginBottom>
            </DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image" , deviceInfo, CreateStream,
               out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;
        }

        // Handler for PrintPageEvents
        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new
               Metafile(m_streams[m_currentPageIndex]);

            // Adjust rectangular area with printer margins.
            Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);

            // Draw a white background for the report
            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            // Draw the report content
            ev.Graphics.DrawImage(pageImage, adjustedRect);

            // Prepare for the next page. Make sure we haven't hit the end.
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        private void Print()
        {
            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
            PrintDocument printDoc = new PrintDocument();
            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }
            else
            {
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                m_currentPageIndex = 0;
                printDoc.Print();
            }
        }

        #endregion

        private string getFormattedClientDataForReport(long pClID )
        {
            string outData = "";
            DataTable clData = mDB.Select("Select * from `Clients` where c_ID=" + pClID.ToString());
            if (clData.Rows.Count > 0)
            {
                outData += Access.AccessSQL.getString(clData.Rows[0]["c_Name"]) + Environment.NewLine;
                outData += Access.AccessSQL.getString(clData.Rows[0]["c_Street"]) + " " + 
                    Access.AccessSQL.getString(clData.Rows[0]["c_HouseNumber"]) + Environment.NewLine;
                outData += Access.AccessSQL.getString(clData.Rows[0]["c_PostalCode"]) + " " +
                    Access.AccessSQL.getString(clData.Rows[0]["c_City"]) + Environment.NewLine;
                //gert comment outData += Access.AccessSQL.getString(clData.Rows[0]["c_DeliverySector"]) + Environment.NewLine;
                outData += "Tel: " + Access.AccessSQL.getString(clData.Rows[0]["c_PhoneNumber"]) + Environment.NewLine;
            }

            return outData;
        }

        /// <summary>
        /// Start printing of invoice...
        /// </summary>
        private void generateInvoiceAndPrint(string pOrderNum, string pDate, 
            string pClientInfo, double discount, double orderTotal)
        {
            LocalReport report = new LocalReport();
            report.ReportPath = Application.StartupPath + "\\repInvoice.rdlc";

            DataTable ord = ToDataTable(mOrders);
            
            report.DataSources.Add(
               new ReportDataSource("DataSetOrders", ord));


            ReportParameter[] parms = new ReportParameter[5];
            parms[0] = new  ReportParameter("repOrderNum",pOrderNum);
            parms[1] = new  ReportParameter("repOrderDate",pDate);
            parms[2] = new ReportParameter("clientInfo", pClientInfo);
            parms[3] = new ReportParameter("repDiscount", discount.ToString());
            parms[4] = new ReportParameter("repTotal", orderTotal.ToString());


            try
            {
                report.SetParameters(parms);

                Export(report);
                Print();
            }
            catch (Exception ex)
            {
                throw ex;
            }
 
        }

        #endregion

        #region Event Handlers

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (!performInit())
                Application.Exit();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtTelephone_KeyDown(object sender, KeyEventArgs e)
        {
            searchOnEnterKey(e, "c_PhoneNumber", "\"" + txtTelephone.Text + "\"");
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            searchOnEnterKey(e, "c_Name", "\"" + txtName.Text + "\"");
        }

        private void txtClientNo_KeyDown(object sender, KeyEventArgs e)
        {
            searchOnEnterKey(e, "c_Number", txtClientNo.Text);
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            txtTelephone.Clear();
            txtName.Clear();
            txtStrasse.Clear();
            txtHouseNo.Clear();
            txtPostalCode.Clear();
            txtCity.Clear();
            //gert comment cmbDeliverySector.SelectedIndex = -1;
            txtClientNo.Clear();
            txtTelephone.Focus();

            nudQuantity.Value = 1;
            txtReferenceNo.Clear();
            clearOrderDetails();

            clearOldVariations();

            chkPicksOrder.Checked = false;
            grpVariations.Text = "";
            lblTotalSumPrice.Text = "";
            lblRabbat.Text = "";
            pnlIngredients.Visible = false;

            //gert
            lblComment.Visible = false;
            txtComment.Visible = false;
            txtComment.Clear();
            chkDelivery.Checked = false;
            chkDelivery.Visible = false;
            cmbDrivers.Visible = false;
            cmbDrivers.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int clntNo = -1;
            if(txtName.Enabled == false && chkHardcoded.Checked == true)
            {
                displayMessage("Stable client.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            if (string.IsNullOrEmpty(txtName.Text))
            {
                displayMessage("Client name can't be blank!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int.TryParse(txtClientNo.Text, out clntNo);

            try
            {
                long clID = Access.AccessSQL.getLong( mDB.selectSingleObject("Select `c_ID` from `Clients`" +
                                                    " where c_Number=" + clntNo.ToString()));
                bool actionPerformed = false;

                Dictionary<string, string> AddUpdateVals = new Dictionary<string, string>();

                AddUpdateVals.Add("c_PhoneNumber", txtTelephone.Text);
                AddUpdateVals.Add("c_Name", txtName.Text);
                AddUpdateVals.Add("c_Street", this.txtStrasse.Text);
                AddUpdateVals.Add("c_HouseNumber", this.txtHouseNo.Text);
                AddUpdateVals.Add("c_PostalCode", this.txtPostalCode.Text);
                AddUpdateVals.Add("c_City", this.txtCity.Text);
                //AddUpdateVals.Add("c_DeliverySector", this.cmbDeliverySector.SelectedItem.ToString()); //Gert commented
                
                //gert added
                AddUpdateVals.Add("c_Hard", this.chkHardcoded.Checked ? "1" : "0"); ;

                // adding!!
                if (clID == 0 || clntNo == -1)
                {
                    long currMaxID = Access.AccessSQL.getLong(mDB.selectSingleObject("Select Max(`c_ID`) from `Clients`"));
                    
                    AddUpdateVals.Add("c_Number", (currMaxID + 1).ToString());

                    mDB.Insert("Clients", AddUpdateVals);

                    txtClientNo.Text = AddUpdateVals["c_Number"];
                    displayMessage("New client added successfully!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    actionPerformed = true;
                }
                else
                { // editing...
                    if (displayMessage("Client already exists, do you want to update information ?",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Dictionary<string, string> updTerms = new Dictionary<string, string>();
                        updTerms.Add("c_ID", clID.ToString());

                        mDB.Update("Clients", updTerms, AddUpdateVals);

                        displayMessage("Client details updated successfully!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        actionPerformed = true;
                    }
                }
                //gert
                if (chkHardcoded.Checked == false)
                {
                    txtTelephone.Enabled = true;
                    txtName.Enabled = true;
                    txtStrasse.Enabled = true;
                    txtHouseNo.Enabled = true;
                    txtPostalCode.Enabled = true;
                    txtCity.Enabled = true;
                }else
                {
                    txtTelephone.Enabled = false;
                    txtName.Enabled = false;
                    txtStrasse.Enabled = false;
                    txtHouseNo.Enabled = false;
                    txtPostalCode.Enabled = false;
                    txtCity.Enabled = false;
                }
                if (actionPerformed)
                    prepareAutoCompleteSources();
            }
            catch (Exception ex)
            {
                displayMessage("Error while adding/updating client - " + ex.Message);
            }
        }

        private void txtReferenceNo_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyData == Keys.Enter)
            {
                clearOldVariations();
                clearOrderDetails();

                if (string.IsNullOrEmpty(txtReferenceNo.Text))
                    return;
                
                long referenceID = -1;
                long.TryParse(txtReferenceNo.Text, out referenceID);

                if (referenceID==-1)
                    return;

                // search for variations
                DataTable prDetails = mDB.Select("Select `p_Name`,`p_Price`,`has_variations`,`cat_Name` from `Products` as pr" +
                    " LEFT JOIN `Product_Categories` as pc ON pc.cat_ID=pr.p_Cat where p_Ref_No=" + referenceID.ToString());

                if (Access.AccessSQL.getBool(prDetails.Rows[0]["has_variations"]))
                {
                    addVariations(referenceID);
                }

                string catlower=  Access.AccessSQL.getString(prDetails.Rows[0]["cat_Name"]).ToLower();

                pnlIngredients.Visible = (catlower == "pizza");

                chkBaked.Checked = false;
                chkBaked.Visible = (catlower == "nudelgerichte");

                grpVariations.Text = Access.AccessSQL.getString(prDetails.Rows[0]["p_Name"]);
                lblRealPrice_1.Text = Access.AccessSQL.getDouble(prDetails.Rows[0]["p_Price"]).ToString("C2");
                //
                //gert
                // read driver table
                prDetails = mDB.Select("Select `id`,`d_Name` from `Drivers`");
                foreach(DataRow obj in  prDetails.Rows){
                    cmbDrivers.Items.Add("[" + obj.ItemArray[0] + "] " + obj.ItemArray[1]);
                }
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtClientNo.Text))
            {
                displayMessage("Please select client!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrEmpty(this.txtReferenceNo.Text))
            {
                displayMessage("Please select artikel!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

           // search for variations
            DataTable prDetails = mDB.Select("Select `p_ID`,`p_Name`,`has_variations`,`p_Price`,`cat_Name` from `Products` as pr" +
                    " LEFT JOIN `Product_Categories` as pc ON pc.cat_ID=pr.p_Cat" + 
                                    " where p_Ref_No=" + txtReferenceNo.Text.ToString());

           if (prDetails.Rows.Count > 0)
           {
               Order newOrder = new Order();
               newOrder.Name = Access.AccessSQL.getString(prDetails.Rows[0]["p_Name"]);
               newOrder.ProductID = Access.AccessSQL.getLong(prDetails.Rows[0]["p_ID"]);

               string prCatName = Access.AccessSQL.getString(prDetails.Rows[0]["cat_Name"]).ToLower();

                double ingrPrice = 0;
                double Price = 0;

                Price = Access.AccessSQL.getDouble(prDetails.Rows[0]["p_Price"]);

               Variation selVariation = null;
               foreach (Variation avVariation in mVariations)
               {
                   if (avVariation.RadVariation.Checked)
                   {
                       selVariation = avVariation;
                       break;
                   }
               }

               if (selVariation != null){
                   newOrder.Name += " (" + selVariation.VariationName + ")";
                   newOrder.ItemVariation = selVariation;
                   Price = selVariation.VariationPrice;
                   ingrPrice = selVariation.IngredientPrice;
               }

               // adding ingredients
               int ingrCount = chcmbIngridients.CheckedItems.Count;

               newOrder.PricePerItem = Price + ingrPrice * ingrCount + (chkBaked.Checked ? 1 : 0);
            
               newOrder.Discount = 0;
               //
               if (chkPicksOrder.Checked)
               {
                   // add 20% discount
                   // hardcoding :(
                   if (prCatName != "dessert" && prCatName != "getränke" && prCatName != "menüs")
                   {
                       newOrder.Discount = newOrder.PricePerItem * 20 / 100;
                   }
               }



               //
               newOrder.Quantity = (int)nudQuantity.Value;
               newOrder.ReferenceNo = long.Parse(txtReferenceNo.Text);
               
               //gert added
               newOrder.Comment = txtComment.Text;
               if (chkDelivery.Checked)
                   newOrder.DriverID = cmbDrivers.Text;

               mOrders.Add(newOrder);
               attachToOrdersGrid();

               double disc = 0;
               calcTotalGesamt(ref disc);
           }

        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedCells.Count > 0)
            {
                if (displayMessage("Are you sure you want to remove selected order(s) ?",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    List<Order> removeOrders = new List<Order>();
                   
                        for (int i = dgvOrders.SelectedCells.Count - 1; i >= 0; i--)
                        {
                            Order rOrder = (Order)dgvOrders.SelectedCells[i].OwningRow.DataBoundItem;
                            removeOrders.Add(rOrder);

                        }

                        foreach (Order orde in removeOrders)
                            mOrders.Remove(orde);
                        attachToOrdersGrid();
                        double disc = 0;
                        calcTotalGesamt(ref disc);
                }
            }
            else
                displayMessage("Please select row(s) to remove.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnConfirmOrder_Click(object sender, EventArgs e)
        {
            try
            {
                int clntNo = -1;
                int.TryParse(txtClientNo.Text, out clntNo);

                // get clientID
                long clID = Access.AccessSQL.getLong(mDB.selectSingleObject("Select `c_ID` from `Clients`" +
                                                       " where c_Number=" + clntNo.ToString()));

                if (clID == 0 || clntNo == -1)
                {
                    displayMessage("Please select valid client!");
                    return;
                }

                if (mOrders.Count <= 0)
                {
                    displayMessage("There is no order to confirm.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                // get the order total amount!
                double discAmount = 0;
                double ordertotal = calcTotalGesamt(ref discAmount);

                // get new orderID
                long ordNum = Access.AccessSQL.getLong(mDB.selectSingleObject("Select MAX(`O_ID`) from Orders")) + 1;

                // generate order number
                string orderNumber = DateTime.Now.ToString("ddMMyyyy" + ordNum.ToString("D4"));

               

                // add to confirm table!
                Dictionary<string, string> AddVals = new Dictionary<string, string>();

                AddVals.Add("o_No", orderNumber);
                AddVals.Add("c_ID", clID.ToString());
                AddVals.Add("o_Date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                AddVals.Add("o_Sum", ordertotal.ToString());
                //gert
                AddVals.Add("o_Comment", txtComment.Text);
                if (chkDelivery.Checked)
                {
                    AddVals.Add("d_ID", Order.getDriverID(cmbDrivers.Text));
                }

                mDB.Insert("Orders", AddVals);
                
                foreach (Order oOrder in mOrders)
                {
                    // now let's add to order details table...
                    AddVals.Clear();

                    AddVals.Add("o_ID", ordNum.ToString());
                    AddVals.Add("p_ID", oOrder.ProductID.ToString());
                    AddVals.Add("v_ID", oOrder.getVariationID().ToString());
                    AddVals.Add("p_Price", oOrder.TotalPrice.ToString());
                    //gert 11/07/2016
                    //AddVals.Add("o_Comment", oOrder.Comment);
                    AddVals.Add("d_ID", oOrder.DriverID);

                    mDB.Insert("Order_Details", AddVals);
                }

                string clData = getFormattedClientDataForReport(clID);

                double ordTotalMinDiscount = ordertotal - discAmount;

                generateInvoiceAndPrint(orderNumber, DateTime.Now.ToString("yyyy.MM.dd"), clData, discAmount, ordTotalMinDiscount);  

                displayMessage("Confirmation succeeded!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnClearAll.PerformClick();
                mOrders.Clear();
                attachToOrdersGrid();
            }
            catch (Exception ex)
            {
                displayMessage("Error confirming order - " + ex.Message);

            }


            // clearing...
            //mOrders.Clear();

        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            List<CompeltedOrder> cords = new List<CompeltedOrder>();
            string vFDate, vTdate;
            int reportType = 0; // 0 - daily, 1-monthly, 2-yearly

            int year = dtpDailyTimePicker.Value.Year;
            int month = dtpDailyTimePicker.Value.Month;
            int day = dtpDailyTimePicker.Value.Day;

            if (sender == btnDaily)
            {
                reportType = 0;
                vFDate = dtpDailyTimePicker.Value.ToString("MM/d/yyyy 00:00:00").Replace(".", "/");
                vTdate = dtpDailyTimePicker.Value.ToString("MM/d/yyyy 23:59:59").Replace(".", "/");
            }
            else if (sender == btnMonthly)
            {
                reportType = 1;
                vFDate = dtpDailyTimePicker.Value.ToString("MM/01/yyyy 00:00:00").Replace(".", "/");
                vTdate = dtpDailyTimePicker.Value.ToString("MM/" + DateTime.DaysInMonth(year, month) + "/yyyy 23:59:59").Replace(".", "/");
            }
            else if (sender == btnYearly)
            {
                reportType = 2;
                vFDate = dtpDailyTimePicker.Value.ToString("01/01/yyyy 00:00:00").Replace(".", "/");
                vTdate = dtpDailyTimePicker.Value.ToString("12/31/yyyy 23:59:59").Replace(".", "/");
            }
            else
            {
                return;
            }

            // get orders that match seleted day...
            // gert added o_Date;
            DataTable orders = mDB.Select(@"Select o_No,c_Number,o_Sum,c_Name,o_Date from Orders " +
                "left join Clients as cltbl1 on (cltbl1.c_ID = Orders.c_ID) where o_Date between #" + vFDate + "# And #" + vTdate + "#");

            List<List<int>> a = new List<List<int>>();
            a.Add(new List<int>(new int[] { 1, 2, 3, 4, 5 }));
            a.Add(new List<int>(new int[] { 6, 7 }));
            a.Add(new List<int>(new int[] { 8, 9, 10 }));
            int b = a.Sum(x => x.Sum(y => y));


            //
            // Gert
            // e.g. total[2016][10][18]
            Dictionary<int, List<List<double>>> total = new Dictionary<int, List<List<double>>>();
            DateTime prevDate = new DateTime(1, 1, 1);
            foreach (DataRow dr in orders.Rows)
            {
                CompeltedOrder ord = new CompeltedOrder();
                ord.clientName = Access.AccessSQL.getString(dr["c_Name"]);
                ord.clientNum = Access.AccessSQL.getString(dr["c_Number"]);
                ord.orderNum = Access.AccessSQL.getString(dr["o_No"]);
                ord.orderSum = Access.AccessSQL.getDouble(dr["o_Sum"]);

                DateTime date = Access.AccessSQL.getDateTime(dr["o_Date"]);

                if (!(prevDate.Month == 1 && prevDate.Day == 1 && prevDate.Year == 1))
                {
                    // new day
                    //
                    // subtotal day
                    //
                    if(reportType == 1)
                    if (prevDate.Month == date.Month && prevDate.Day != date.Day && prevDate.Year == date.Year)
                    {
                        CompeltedOrder ordSub = new CompeltedOrder();
                        ordSub.orderNum = prevDate.ToShortDateString();
                        ordSub.orderSum = total[prevDate.Year][prevDate.Month - 1][prevDate.Day - 1];
                        cords.Add(ordSub);
                    }
                    //new month
                    //
                    // subtotal month
                    //
                    if (reportType == 2)
                    if (prevDate.Month != date.Month && prevDate.Year == date.Year)
                    {
                        //
                        //day
                        //
                        //CompeltedOrder ordSub = new CompeltedOrder();
                        //ordSub.orderNum = prevDate.ToShortDateString();
                        //ordSub.orderSum = total[prevDate.Year][prevDate.Month - 1][prevDate.Day - 1];
                        //cords.Add(ordSub);
                        //
                        //month
                        //
                        CompeltedOrder ordSub2 = new CompeltedOrder();
                        ordSub2.orderNum = prevDate.Month + "/" + prevDate.Year;
                        ordSub2.orderSum = total[prevDate.Year][prevDate.Month - 1].Sum(x => x);
                        cords.Add(ordSub2);
                    }
                    //new year
                    //
                    // subtotal year
                    //
                    if (reportType > 2)
                    if (prevDate.Year != date.Year)
                    {
                        //
                        //day
                        //
                        //CompeltedOrder ordSub = new CompeltedOrder();
                        //ordSub.orderNum = prevDate.ToShortDateString();
                        //ordSub.orderSum = total[prevDate.Year][prevDate.Month - 1][prevDate.Day - 1];
                        //cords.Add(ordSub);
                        //
                        //month
                        //
                        //CompeltedOrder ordSub2 = new CompeltedOrder();
                        //ordSub2.orderNum = prevDate.Month + "/" + prevDate.Year;
                        //ordSub2.orderSum = total[prevDate.Year][prevDate.Month - 1].Sum(x => x);
                        //cords.Add(ordSub2);
                        //
                        //year
                        //
                        CompeltedOrder ordSub3 = new CompeltedOrder();
                        ordSub3.orderNum = prevDate.Year.ToString();
                        ordSub3.orderSum = total[prevDate.Year].Sum(x => x.Sum(y => y));
                        cords.Add(ordSub3);
                    }
                }

                prevDate = date;
                if(reportType==0)
                cords.Add(ord);
                //
                // calculate sub totals. Gert
                //
                if (!total.ContainsKey(date.Year))
                {
                    List<List<double>> monthlist = new List<List<double>>(12);
                    for (int m = 0; m < 12; m++)
                    {
                        List<double> daylist = new List<double>(31);
                        daylist.AddRange(new double[30]);
                        monthlist.Add(daylist);
                    }
                    total.Add(date.Year, monthlist);
                }
                total[date.Year][date.Month - 1][date.Day - 1] += ord.orderSum;


                //
                // If end row
                //
                if (dr == orders.Rows[orders.Rows.Count - 1])
                {
                    //if (prevDate.Month == date.Month && prevDate.Day != date.Day && prevDate.Year == date.Year)
                    // subtotal day
                    if (reportType == 0 || reportType ==1)
                    {
                        CompeltedOrder ordSub = new CompeltedOrder();
                        ordSub.orderNum = date.ToShortDateString();
                        ordSub.orderSum = total[date.Year][date.Month - 1][date.Day - 1];
                        cords.Add(ordSub);
                    }
                    //
                    // subtotal month
                    //
                    if (reportType == 1 || reportType == 2)
                    //if (prevDate.Month != date.Month && prevDate.Year == date.Year)
                    {
                        CompeltedOrder ordSub = new CompeltedOrder();
                        ordSub.orderNum = date.Month + "/" + date.Year;
                        ordSub.orderSum = total[date.Year][date.Month - 1].Sum(x => x);
                        cords.Add(ordSub);
                    }
                    //
                    // subtotal year
                    //
                    //if (prevDate.Year != date.Year)
                    if (reportType == 2)
                    {
                        CompeltedOrder ordSub = new CompeltedOrder();
                        ordSub.orderNum = date.Year.ToString();
                        ordSub.orderSum = total[date.Year].Sum(x => x.Sum(y => y));
                        cords.Add(ordSub);
                    }
                }

            }


            DataTable dsComplOrders = ToDataTable(cords);

            // attach to reportviewer
            frmReportViewer frView = new frmReportViewer();

            //gert added 04.11.2016
            if (cords.Count > 0)
                frView.prepareDailyReport(dsComplOrders, dtpDailyTimePicker.Value, reportType);

            frView.ShowDialog();
        }
        class CompeltedOrderComparer : IComparer<CompeltedOrder>
        {

            public int Compare(CompeltedOrder x, CompeltedOrder y)
            {
                return String.Compare(x.orderNum, y.orderNum);
            }
        }
        #endregion

        private void chkDelivery_CheckedChanged(object sender, EventArgs e)
        {
            cmbDrivers.Enabled = chkDelivery.Checked;
            if (cmbDrivers.Items.Count > 0)
                cmbDrivers.SelectedIndex = 0;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            mDBPath = txtDatabase.Text;
            if(!performInit())
            {
                MessageBox.Show("Failed in connecting database.");
            }
        }
    }
}
