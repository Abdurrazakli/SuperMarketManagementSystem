namespace demoMarketManagementSystem
{
    partial class DatamanPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatamanPage));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSales = new System.Windows.Forms.Button();
            this.btnOrders = new System.Windows.Forms.Button();
            this.btnProducts = new System.Windows.Forms.Button();
            this.btnReception = new System.Windows.Forms.Button();
            this.btnTypes = new System.Windows.Forms.Button();
            this.btnSuppliers = new System.Windows.Forms.Button();
            this.btnCategories = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Categories";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Suppliers";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(389, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Types";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(82, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Reception";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(233, 256);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Products";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(371, 256);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Ordered items";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(241, 387);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Sales";
            // 
            // btnSales
            // 
            this.btnSales.BackgroundImage = global::demoMarketManagementSystem.Properties.Resources.sales;
            this.btnSales.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSales.Location = new System.Drawing.Point(198, 272);
            this.btnSales.Name = "btnSales";
            this.btnSales.Size = new System.Drawing.Size(119, 112);
            this.btnSales.TabIndex = 13;
            this.btnSales.UseVisualStyleBackColor = true;
            // 
            // btnOrders
            // 
            this.btnOrders.BackgroundImage = global::demoMarketManagementSystem.Properties.Resources.orders;
            this.btnOrders.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOrders.Location = new System.Drawing.Point(348, 140);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Size = new System.Drawing.Size(119, 112);
            this.btnOrders.TabIndex = 6;
            this.btnOrders.UseVisualStyleBackColor = true;
            this.btnOrders.Click += new System.EventHandler(this.BtnOrders_Click);
            // 
            // btnProducts
            // 
            this.btnProducts.BackgroundImage = global::demoMarketManagementSystem.Properties.Resources.products;
            this.btnProducts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnProducts.Location = new System.Drawing.Point(198, 142);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(119, 112);
            this.btnProducts.TabIndex = 5;
            this.btnProducts.UseVisualStyleBackColor = true;
            this.btnProducts.Click += new System.EventHandler(this.BtnProducts_Click);
            // 
            // btnReception
            // 
            this.btnReception.BackgroundImage = global::demoMarketManagementSystem.Properties.Resources.reception;
            this.btnReception.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReception.Location = new System.Drawing.Point(51, 142);
            this.btnReception.Name = "btnReception";
            this.btnReception.Size = new System.Drawing.Size(119, 112);
            this.btnReception.TabIndex = 4;
            this.btnReception.UseVisualStyleBackColor = true;
            this.btnReception.Click += new System.EventHandler(this.BtnReception_Click);
            // 
            // btnTypes
            // 
            this.btnTypes.BackgroundImage = global::demoMarketManagementSystem.Properties.Resources.types_general;
            this.btnTypes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTypes.Location = new System.Drawing.Point(348, 12);
            this.btnTypes.Name = "btnTypes";
            this.btnTypes.Size = new System.Drawing.Size(119, 112);
            this.btnTypes.TabIndex = 3;
            this.btnTypes.UseVisualStyleBackColor = true;
            this.btnTypes.Click += new System.EventHandler(this.BtnTypes_Click);
            // 
            // btnSuppliers
            // 
            this.btnSuppliers.BackgroundImage = global::demoMarketManagementSystem.Properties.Resources.supplier;
            this.btnSuppliers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSuppliers.Location = new System.Drawing.Point(198, 12);
            this.btnSuppliers.Name = "btnSuppliers";
            this.btnSuppliers.Size = new System.Drawing.Size(119, 112);
            this.btnSuppliers.TabIndex = 2;
            this.btnSuppliers.UseVisualStyleBackColor = true;
            this.btnSuppliers.Click += new System.EventHandler(this.BtnSuppliers_Click);
            // 
            // btnCategories
            // 
            this.btnCategories.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCategories.BackgroundImage")));
            this.btnCategories.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategories.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCategories.Location = new System.Drawing.Point(51, 12);
            this.btnCategories.Name = "btnCategories";
            this.btnCategories.Size = new System.Drawing.Size(119, 112);
            this.btnCategories.TabIndex = 0;
            this.btnCategories.UseVisualStyleBackColor = true;
            this.btnCategories.Click += new System.EventHandler(this.BtnCategories_Click);
            // 
            // DatamanPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(514, 450);
            this.Controls.Add(this.btnSales);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOrders);
            this.Controls.Add(this.btnProducts);
            this.Controls.Add(this.btnReception);
            this.Controls.Add(this.btnTypes);
            this.Controls.Add(this.btnSuppliers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCategories);
            this.Name = "DatamanPage";
            this.Text = "DatamanPage";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DatamanPage_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCategories;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSuppliers;
        private System.Windows.Forms.Button btnTypes;
        private System.Windows.Forms.Button btnReception;
        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSales;
    }
}