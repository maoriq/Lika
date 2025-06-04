namespace ShopApp
{
    partial class ShopForm
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
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.lstCart = new System.Windows.Forms.ListBox();
            this.btnAddToCart = new System.Windows.Forms.Button();
            this.btnWeighProduct = new System.Windows.Forms.Button();
            this.btnRemoveFromCart = new System.Windows.Forms.Button();
            this.btnProceedToPayment = new System.Windows.Forms.Button();
            this.btnClearCart = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblCustomerInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProducts
            // 
            this.dgvProducts.BackgroundColor = System.Drawing.Color.MistyRose;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Location = new System.Drawing.Point(38, 44);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.RowHeadersWidth = 51;
            this.dgvProducts.RowTemplate.Height = 24;
            this.dgvProducts.Size = new System.Drawing.Size(747, 260);
            this.dgvProducts.TabIndex = 0;
            // 
            // lstCart
            // 
            this.lstCart.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstCart.FormattingEnabled = true;
            this.lstCart.ItemHeight = 18;
            this.lstCart.Location = new System.Drawing.Point(38, 318);
            this.lstCart.Name = "lstCart";
            this.lstCart.Size = new System.Drawing.Size(520, 202);
            this.lstCart.TabIndex = 1;
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddToCart.Location = new System.Drawing.Point(564, 377);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(221, 29);
            this.btnAddToCart.TabIndex = 2;
            this.btnAddToCart.Text = "Добавить";
            this.btnAddToCart.UseVisualStyleBackColor = true;
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);
            // 
            // btnWeighProduct
            // 
            this.btnWeighProduct.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnWeighProduct.Location = new System.Drawing.Point(564, 342);
            this.btnWeighProduct.Name = "btnWeighProduct";
            this.btnWeighProduct.Size = new System.Drawing.Size(221, 29);
            this.btnWeighProduct.TabIndex = 3;
            this.btnWeighProduct.Text = "Взвесить";
            this.btnWeighProduct.UseVisualStyleBackColor = true;
            this.btnWeighProduct.Click += new System.EventHandler(this.btnWeighProduct_Click);
            // 
            // btnRemoveFromCart
            // 
            this.btnRemoveFromCart.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRemoveFromCart.Location = new System.Drawing.Point(564, 412);
            this.btnRemoveFromCart.Name = "btnRemoveFromCart";
            this.btnRemoveFromCart.Size = new System.Drawing.Size(221, 29);
            this.btnRemoveFromCart.TabIndex = 4;
            this.btnRemoveFromCart.Text = "Удалить продукт";
            this.btnRemoveFromCart.UseVisualStyleBackColor = true;
            this.btnRemoveFromCart.Click += new System.EventHandler(this.btnRemoveFromCart_Click);
            // 
            // btnProceedToPayment
            // 
            this.btnProceedToPayment.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnProceedToPayment.Location = new System.Drawing.Point(564, 482);
            this.btnProceedToPayment.Name = "btnProceedToPayment";
            this.btnProceedToPayment.Size = new System.Drawing.Size(221, 29);
            this.btnProceedToPayment.TabIndex = 5;
            this.btnProceedToPayment.Text = "Оплатить";
            this.btnProceedToPayment.UseVisualStyleBackColor = true;
            this.btnProceedToPayment.Click += new System.EventHandler(this.btnProceedToPayment_Click);
            // 
            // btnClearCart
            // 
            this.btnClearCart.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClearCart.Location = new System.Drawing.Point(564, 447);
            this.btnClearCart.Name = "btnClearCart";
            this.btnClearCart.Size = new System.Drawing.Size(221, 29);
            this.btnClearCart.TabIndex = 6;
            this.btnClearCart.Text = "Очистить";
            this.btnClearCart.UseVisualStyleBackColor = true;
            this.btnClearCart.Click += new System.EventHandler(this.btnClearCart_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Montserrat", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTotal.Location = new System.Drawing.Point(563, 307);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(68, 32);
            this.lblTotal.TabIndex = 7;
            this.lblTotal.Text = "епта";
            // 
            // lblCustomerInfo
            // 
            this.lblCustomerInfo.AutoSize = true;
            this.lblCustomerInfo.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCustomerInfo.Location = new System.Drawing.Point(33, 16);
            this.lblCustomerInfo.Name = "lblCustomerInfo";
            this.lblCustomerInfo.Size = new System.Drawing.Size(72, 21);
            this.lblCustomerInfo.TabIndex = 8;
            this.lblCustomerInfo.Text = "с в а г а ";
            // 
            // ShopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(841, 532);
            this.Controls.Add(this.lblCustomerInfo);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnClearCart);
            this.Controls.Add(this.btnProceedToPayment);
            this.Controls.Add(this.btnRemoveFromCart);
            this.Controls.Add(this.btnWeighProduct);
            this.Controls.Add(this.btnAddToCart);
            this.Controls.Add(this.lstCart);
            this.Controls.Add(this.dgvProducts);
            this.Name = "ShopForm";
            this.Text = "ShopForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.ListBox lstCart;
        private System.Windows.Forms.Button btnAddToCart;
        private System.Windows.Forms.Button btnWeighProduct;
        private System.Windows.Forms.Button btnRemoveFromCart;
        private System.Windows.Forms.Button btnProceedToPayment;
        private System.Windows.Forms.Button btnClearCart;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblCustomerInfo;
    }
}