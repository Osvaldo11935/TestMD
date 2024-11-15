namespace Test
{
    partial class CustomerForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produtosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarVendaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatoriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produtosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.vendasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_customer_search = new System.Windows.Forms.TextBox();
            this.dgv_list_customer = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_customer_update = new System.Windows.Forms.Button();
            this.btn_customer_save = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_customer_address = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_customer_phone_number = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_customer_email = new System.Windows.Forms.TextBox();
            this.txt_customer_name = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_list_customer)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1538, 438);
            this.panel1.TabIndex = 1;
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
            this.menuStrip1.Size = new System.Drawing.Size(1538, 27);
            this.menuStrip1.TabIndex = 2;
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
            this.produtosToolStripMenuItem.Click += new System.EventHandler(this.produtosToolStripMenuItem_Click_1);
            // 
            // registrarVendaToolStripMenuItem
            // 
            this.registrarVendaToolStripMenuItem.Name = "registrarVendaToolStripMenuItem";
            this.registrarVendaToolStripMenuItem.Size = new System.Drawing.Size(167, 23);
            this.registrarVendaToolStripMenuItem.Text = "Registrar  venda";
            this.registrarVendaToolStripMenuItem.Click += new System.EventHandler(this.registrarVendaToolStripMenuItem_Click_1);
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
            this.produtosToolStripMenuItem1.Click += new System.EventHandler(this.produtosToolStripMenuItem1_Click_1);
            // 
            // vendasToolStripMenuItem
            // 
            this.vendasToolStripMenuItem.Name = "vendasToolStripMenuItem";
            this.vendasToolStripMenuItem.Size = new System.Drawing.Size(171, 26);
            this.vendasToolStripMenuItem.Text = "Vendas";
            this.vendasToolStripMenuItem.Click += new System.EventHandler(this.vendasToolStripMenuItem_Click_1);
            // 
            // clientesToolStripMenuItem1
            // 
            this.clientesToolStripMenuItem1.Name = "clientesToolStripMenuItem1";
            this.clientesToolStripMenuItem1.Size = new System.Drawing.Size(171, 26);
            this.clientesToolStripMenuItem1.Text = "Clientes";
            this.clientesToolStripMenuItem1.Click += new System.EventHandler(this.clientesToolStripMenuItem1_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel3.Controls.Add(this.dgv_list_customer);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txt_customer_search);
            this.panel3.Location = new System.Drawing.Point(525, 35);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1003, 400);
            this.panel3.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Bright", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(738, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 19);
            this.label5.TabIndex = 10;
            this.label5.Text = "Buscar";
            // 
            // txt_customer_search
            // 
            this.txt_customer_search.Location = new System.Drawing.Point(812, 18);
            this.txt_customer_search.Multiline = true;
            this.txt_customer_search.Name = "txt_customer_search";
            this.txt_customer_search.Size = new System.Drawing.Size(187, 37);
            this.txt_customer_search.TabIndex = 5;
            this.txt_customer_search.TextChanged += new System.EventHandler(this.txt_customer_search_TextChanged);
            // 
            // dgv_list_customer
            // 
            this.dgv_list_customer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_list_customer.Location = new System.Drawing.Point(3, 59);
            this.dgv_list_customer.Name = "dgv_list_customer";
            this.dgv_list_customer.RowHeadersWidth = 51;
            this.dgv_list_customer.RowTemplate.Height = 24;
            this.dgv_list_customer.Size = new System.Drawing.Size(996, 338);
            this.dgv_list_customer.TabIndex = 0;
            this.dgv_list_customer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_list_customer_CellContentClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.btn_customer_update);
            this.panel2.Controls.Add(this.btn_customer_save);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txt_customer_address);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txt_customer_phone_number);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txt_customer_email);
            this.panel2.Controls.Add(this.txt_customer_name);
            this.panel2.Location = new System.Drawing.Point(10, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(509, 397);
            this.panel2.TabIndex = 0;
            // 
            // btn_customer_update
            // 
            this.btn_customer_update.Font = new System.Drawing.Font("Lucida Bright", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_customer_update.Location = new System.Drawing.Point(148, 337);
            this.btn_customer_update.Name = "btn_customer_update";
            this.btn_customer_update.Size = new System.Drawing.Size(120, 45);
            this.btn_customer_update.TabIndex = 9;
            this.btn_customer_update.Text = "Alterar";
            this.btn_customer_update.UseVisualStyleBackColor = true;
            this.btn_customer_update.Click += new System.EventHandler(this.btn_customer_update_Click);
            // 
            // btn_customer_save
            // 
            this.btn_customer_save.Font = new System.Drawing.Font("Lucida Bright", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_customer_save.Location = new System.Drawing.Point(193, 301);
            this.btn_customer_save.Name = "btn_customer_save";
            this.btn_customer_save.Size = new System.Drawing.Size(75, 45);
            this.btn_customer_save.TabIndex = 8;
            this.btn_customer_save.Text = "Salvar";
            this.btn_customer_save.UseVisualStyleBackColor = true;
            this.btn_customer_save.Click += new System.EventHandler(this.btn_customer_save_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Bright", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "Endereço";
            // 
            // txt_customer_address
            // 
            this.txt_customer_address.Location = new System.Drawing.Point(7, 184);
            this.txt_customer_address.Multiline = true;
            this.txt_customer_address.Name = "txt_customer_address";
            this.txt_customer_address.Size = new System.Drawing.Size(488, 103);
            this.txt_customer_address.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Bright", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(289, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nº de telefone";
            // 
            // txt_customer_phone_number
            // 
            this.txt_customer_phone_number.Location = new System.Drawing.Point(293, 114);
            this.txt_customer_phone_number.Multiline = true;
            this.txt_customer_phone_number.Name = "txt_customer_phone_number";
            this.txt_customer_phone_number.Size = new System.Drawing.Size(202, 37);
            this.txt_customer_phone_number.TabIndex = 4;
            this.txt_customer_phone_number.TextChanged += new System.EventHandler(this.txt_customer_phone_number_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Bright", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Email";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Bright", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nome do cliente";
            // 
            // txt_customer_email
            // 
            this.txt_customer_email.Location = new System.Drawing.Point(7, 114);
            this.txt_customer_email.Multiline = true;
            this.txt_customer_email.Name = "txt_customer_email";
            this.txt_customer_email.Size = new System.Drawing.Size(232, 37);
            this.txt_customer_email.TabIndex = 1;
            // 
            // txt_customer_name
            // 
            this.txt_customer_name.Location = new System.Drawing.Point(7, 38);
            this.txt_customer_name.Multiline = true;
            this.txt_customer_name.Name = "txt_customer_name";
            this.txt_customer_name.Size = new System.Drawing.Size(488, 37);
            this.txt_customer_name.TabIndex = 0;
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1548, 450);
            this.Controls.Add(this.panel1);
            this.Name = "CustomerForm";
            this.Text = "CustomerForm";
            this.Load += new System.EventHandler(this.CustomerForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_list_customer)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_customer_search;
        private System.Windows.Forms.DataGridView dgv_list_customer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_customer_update;
        private System.Windows.Forms.Button btn_customer_save;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_customer_address;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_customer_phone_number;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_customer_email;
        private System.Windows.Forms.TextBox txt_customer_name;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem produtosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarVendaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatoriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produtosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem vendasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem inicioToolStripMenuItem;
    }
}