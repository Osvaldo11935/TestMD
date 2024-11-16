namespace Test
{
    partial class SaleForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_finish_sale = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_customer_address = new System.Windows.Forms.TextBox();
            this.txt_customer_email = new System.Windows.Forms.TextBox();
            this.txt_customer_phone_number = new System.Windows.Forms.TextBox();
            this.txt_customer_name = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgv_cart = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_search_product_sale = new System.Windows.Forms.TextBox();
            this.dgv_list_product_sale = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produtosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarVendaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatoriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produtosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.vendasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label7 = new System.Windows.Forms.Label();
            this.lb_total_s = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cart)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_list_product_sale)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(12, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1495, 678);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.btn_finish_sale);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txt_customer_address);
            this.panel2.Controls.Add(this.txt_customer_email);
            this.panel2.Controls.Add(this.txt_customer_phone_number);
            this.panel2.Controls.Add(this.txt_customer_name);
            this.panel2.Location = new System.Drawing.Point(13, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(501, 662);
            this.panel2.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Bright", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 286);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(184, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "Endereço do cliente";
            // 
            // btn_finish_sale
            // 
            this.btn_finish_sale.Font = new System.Drawing.Font("Lucida Bright", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_finish_sale.Location = new System.Drawing.Point(107, 469);
            this.btn_finish_sale.Name = "btn_finish_sale";
            this.btn_finish_sale.Size = new System.Drawing.Size(247, 56);
            this.btn_finish_sale.TabIndex = 2;
            this.btn_finish_sale.Text = "Terminar venda";
            this.btn_finish_sale.UseVisualStyleBackColor = true;
            this.btn_finish_sale.Click += new System.EventHandler(this.btn_finish_sale_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Bright", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "E-mail";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Bright", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nº Telefone";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Bright", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nome do cliente";
            // 
            // txt_customer_address
            // 
            this.txt_customer_address.Location = new System.Drawing.Point(3, 308);
            this.txt_customer_address.Multiline = true;
            this.txt_customer_address.Name = "txt_customer_address";
            this.txt_customer_address.Size = new System.Drawing.Size(480, 151);
            this.txt_customer_address.TabIndex = 3;
            // 
            // txt_customer_email
            // 
            this.txt_customer_email.Location = new System.Drawing.Point(3, 194);
            this.txt_customer_email.Multiline = true;
            this.txt_customer_email.Name = "txt_customer_email";
            this.txt_customer_email.Size = new System.Drawing.Size(480, 44);
            this.txt_customer_email.TabIndex = 2;
            // 
            // txt_customer_phone_number
            // 
            this.txt_customer_phone_number.Location = new System.Drawing.Point(4, 112);
            this.txt_customer_phone_number.Multiline = true;
            this.txt_customer_phone_number.Name = "txt_customer_phone_number";
            this.txt_customer_phone_number.Size = new System.Drawing.Size(479, 44);
            this.txt_customer_phone_number.TabIndex = 1;
            this.txt_customer_phone_number.TextChanged += new System.EventHandler(this.txt_customer_phone_number_TextChanged);
            // 
            // txt_customer_name
            // 
            this.txt_customer_name.Location = new System.Drawing.Point(3, 31);
            this.txt_customer_name.Multiline = true;
            this.txt_customer_name.Name = "txt_customer_name";
            this.txt_customer_name.Size = new System.Drawing.Size(480, 44);
            this.txt_customer_name.TabIndex = 0;
            this.txt_customer_name.TextChanged += new System.EventHandler(this.txt_customer_name_TextChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel3.Controls.Add(this.lb_total_s);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(545, 13);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(947, 662);
            this.panel3.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Bright", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 323);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 19);
            this.label6.TabIndex = 8;
            this.label6.Text = "Carrinho";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dgv_cart);
            this.panel5.Location = new System.Drawing.Point(13, 345);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(928, 262);
            this.panel5.TabIndex = 3;
            // 
            // dgv_cart
            // 
            this.dgv_cart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_cart.Location = new System.Drawing.Point(3, 3);
            this.dgv_cart.Name = "dgv_cart";
            this.dgv_cart.RowHeadersWidth = 51;
            this.dgv_cart.RowTemplate.Height = 24;
            this.dgv_cart.Size = new System.Drawing.Size(922, 256);
            this.dgv_cart.TabIndex = 1;
            this.dgv_cart.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_cart_CellContentClick_1);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.txt_search_product_sale);
            this.panel4.Controls.Add(this.dgv_list_product_sale);
            this.panel4.Location = new System.Drawing.Point(13, 24);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(931, 287);
            this.panel4.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Bright", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(610, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "Buscar";
            // 
            // txt_search_product_sale
            // 
            this.txt_search_product_sale.Location = new System.Drawing.Point(684, 3);
            this.txt_search_product_sale.Multiline = true;
            this.txt_search_product_sale.Name = "txt_search_product_sale";
            this.txt_search_product_sale.Size = new System.Drawing.Size(241, 44);
            this.txt_search_product_sale.TabIndex = 8;
            this.txt_search_product_sale.TextChanged += new System.EventHandler(this.txt_search_product_sale_TextChanged);
            // 
            // dgv_list_product_sale
            // 
            this.dgv_list_product_sale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_list_product_sale.Location = new System.Drawing.Point(3, 58);
            this.dgv_list_product_sale.Name = "dgv_list_product_sale";
            this.dgv_list_product_sale.RowHeadersWidth = 51;
            this.dgv_list_product_sale.RowTemplate.Height = 24;
            this.dgv_list_product_sale.Size = new System.Drawing.Size(925, 226);
            this.dgv_list_product_sale.TabIndex = 1;
            this.dgv_list_product_sale.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_list_product_sale_CellContentClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Lucida Bright", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inicioToolStripMenuItem,
            this.produtosToolStripMenuItem,
            this.registrarVendaToolStripMenuItem,
            this.relatoriosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1519, 27);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // inicioToolStripMenuItem
            // 
            this.inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            this.inicioToolStripMenuItem.Size = new System.Drawing.Size(74, 23);
            this.inicioToolStripMenuItem.Text = "Inicio";
            this.inicioToolStripMenuItem.Click += new System.EventHandler(this.inicioToolStripMenuItem_Click);
            // 
            // produtosToolStripMenuItem
            // 
            this.produtosToolStripMenuItem.Name = "produtosToolStripMenuItem";
            this.produtosToolStripMenuItem.Size = new System.Drawing.Size(102, 23);
            this.produtosToolStripMenuItem.Text = "Produtos";
            this.produtosToolStripMenuItem.Click += new System.EventHandler(this.produtosToolStripMenuItem_Click);
            // 
            // registrarVendaToolStripMenuItem
            // 
            this.registrarVendaToolStripMenuItem.Name = "registrarVendaToolStripMenuItem";
            this.registrarVendaToolStripMenuItem.Size = new System.Drawing.Size(124, 23);
            this.registrarVendaToolStripMenuItem.Text = "Ver Vendas";
            this.registrarVendaToolStripMenuItem.Click += new System.EventHandler(this.registrarVendaToolStripMenuItem_Click);
            // 
            // relatoriosToolStripMenuItem
            // 
            this.relatoriosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.produtosToolStripMenuItem1,
            this.vendasToolStripMenuItem,
            this.clientesToolStripMenuItem1});
            this.relatoriosToolStripMenuItem.Name = "relatoriosToolStripMenuItem";
            this.relatoriosToolStripMenuItem.Size = new System.Drawing.Size(113, 23);
            this.relatoriosToolStripMenuItem.Text = "Relatorios";
            // 
            // produtosToolStripMenuItem1
            // 
            this.produtosToolStripMenuItem1.Name = "produtosToolStripMenuItem1";
            this.produtosToolStripMenuItem1.Size = new System.Drawing.Size(171, 26);
            this.produtosToolStripMenuItem1.Text = "Produtos";
            this.produtosToolStripMenuItem1.Click += new System.EventHandler(this.produtosToolStripMenuItem1_Click);
            // 
            // vendasToolStripMenuItem
            // 
            this.vendasToolStripMenuItem.Name = "vendasToolStripMenuItem";
            this.vendasToolStripMenuItem.Size = new System.Drawing.Size(171, 26);
            this.vendasToolStripMenuItem.Text = "Vendas";
            // 
            // clientesToolStripMenuItem1
            // 
            this.clientesToolStripMenuItem1.Name = "clientesToolStripMenuItem1";
            this.clientesToolStripMenuItem1.Size = new System.Drawing.Size(171, 26);
            this.clientesToolStripMenuItem1.Text = "Clientes";
            this.clientesToolStripMenuItem1.Click += new System.EventHandler(this.clientesToolStripMenuItem1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Lucida Bright", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(656, 630);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 19);
            this.label7.TabIndex = 9;
            this.label7.Text = "Total a pagar:";
            // 
            // lb_total_s
            // 
            this.lb_total_s.AutoSize = true;
            this.lb_total_s.Font = new System.Drawing.Font("Lucida Bright", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_total_s.Location = new System.Drawing.Point(791, 630);
            this.lb_total_s.Name = "lb_total_s";
            this.lb_total_s.Size = new System.Drawing.Size(86, 19);
            this.lb_total_s.TabIndex = 10;
            this.lb_total_s.Text = "R$ 00.00";
            // 
            // SaleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1519, 731);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.Name = "SaleForm";
            this.Text = "SaleForm";
            this.Load += new System.EventHandler(this.SaleForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cart)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_list_product_sale)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgv_list_product_sale;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_customer_address;
        private System.Windows.Forms.TextBox txt_customer_email;
        private System.Windows.Forms.TextBox txt_customer_phone_number;
        private System.Windows.Forms.TextBox txt_customer_name;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_search_product_sale;
        private System.Windows.Forms.Button btn_finish_sale;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgv_cart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem produtosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarVendaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatoriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produtosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem vendasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem inicioToolStripMenuItem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lb_total_s;
    }
}