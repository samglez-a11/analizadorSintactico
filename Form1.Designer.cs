namespace analizadorSintactico
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textAnalizar = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textLexico = new System.Windows.Forms.TextBox();
            this.textErrores = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Pila = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Salida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textAnalizar
            // 
            this.textAnalizar.Location = new System.Drawing.Point(21, 27);
            this.textAnalizar.Multiline = true;
            this.textAnalizar.Name = "textAnalizar";
            this.textAnalizar.Size = new System.Drawing.Size(446, 163);
            this.textAnalizar.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(511, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 41);
            this.button1.TabIndex = 1;
            this.button1.Text = "Enviar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textLexico
            // 
            this.textLexico.Location = new System.Drawing.Point(21, 225);
            this.textLexico.Multiline = true;
            this.textLexico.Name = "textLexico";
            this.textLexico.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textLexico.Size = new System.Drawing.Size(316, 213);
            this.textLexico.TabIndex = 2;
            // 
            // textErrores
            // 
            this.textErrores.Location = new System.Drawing.Point(366, 225);
            this.textErrores.Multiline = true;
            this.textErrores.Name = "textErrores";
            this.textErrores.Size = new System.Drawing.Size(259, 213);
            this.textErrores.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Pila,
            this.Salida});
            this.dataGridView1.Location = new System.Drawing.Point(643, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(322, 418);
            this.dataGridView1.TabIndex = 4;
            // 
            // Pila
            // 
            this.Pila.HeaderText = "Pila";
            this.Pila.Name = "Pila";
            // 
            // Salida
            // 
            this.Salida.HeaderText = "Salida";
            this.Salida.Name = "Salida";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textErrores);
            this.Controls.Add(this.textLexico);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textAnalizar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Analizador ";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textAnalizar;
        private Button button1;
        private TextBox textLexico;
        private TextBox textErrores;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Pila;
        private DataGridViewTextBoxColumn Salida;
    }
}