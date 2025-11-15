namespace ProjetoFinal
{
    partial class PainelFinancas
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tb_servicos = new System.Windows.Forms.PictureBox();
            this.lbl_servicos = new System.Windows.Forms.Label();
            this.pb_clientes = new System.Windows.Forms.PictureBox();
            this.lbl_clientes = new System.Windows.Forms.Label();
            this.pb_home = new System.Windows.Forms.PictureBox();
            this.lbl_exit = new System.Windows.Forms.Label();
            this.pb_exit = new System.Windows.Forms.PictureBox();
            this.lbl_home = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pb_financas = new System.Windows.Forms.PictureBox();
            this.lbl_financas = new System.Windows.Forms.Label();
            this.chart_faturacao_mensal = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_welcome = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lb_detalhe_servicos = new System.Windows.Forms.ListBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbl_chart = new System.Windows.Forms.Label();
            this.dgv_analise_clientes = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_servicos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_clientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_home)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_exit)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_financas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_faturacao_mensal)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_analise_clientes)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.ForestGreen;
            this.panel1.Controls.Add(this.tb_servicos);
            this.panel1.Controls.Add(this.lbl_servicos);
            this.panel1.Controls.Add(this.pb_clientes);
            this.panel1.Controls.Add(this.lbl_clientes);
            this.panel1.Controls.Add(this.pb_home);
            this.panel1.Controls.Add(this.lbl_exit);
            this.panel1.Controls.Add(this.pb_exit);
            this.panel1.Controls.Add(this.lbl_home);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Location = new System.Drawing.Point(0, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 414);
            this.panel1.TabIndex = 0;
            // 
            // tb_servicos
            // 
            this.tb_servicos.BackColor = System.Drawing.Color.Transparent;
            this.tb_servicos.Image = global::ProjetoFinal.Properties.Resources.lawnmower_white;
            this.tb_servicos.Location = new System.Drawing.Point(12, 98);
            this.tb_servicos.Name = "tb_servicos";
            this.tb_servicos.Size = new System.Drawing.Size(25, 25);
            this.tb_servicos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.tb_servicos.TabIndex = 10;
            this.tb_servicos.TabStop = false;
            this.tb_servicos.Click += new System.EventHandler(this.tb_servicos_Click);
            // 
            // lbl_servicos
            // 
            this.lbl_servicos.AutoSize = true;
            this.lbl_servicos.BackColor = System.Drawing.Color.Transparent;
            this.lbl_servicos.Font = new System.Drawing.Font("Bahnschrift Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_servicos.ForeColor = System.Drawing.Color.White;
            this.lbl_servicos.Location = new System.Drawing.Point(43, 98);
            this.lbl_servicos.Name = "lbl_servicos";
            this.lbl_servicos.Size = new System.Drawing.Size(72, 25);
            this.lbl_servicos.TabIndex = 9;
            this.lbl_servicos.Text = "Serviços";
            this.lbl_servicos.Click += new System.EventHandler(this.lbl_servicos_Click);
            // 
            // pb_clientes
            // 
            this.pb_clientes.BackColor = System.Drawing.Color.Transparent;
            this.pb_clientes.Image = global::ProjetoFinal.Properties.Resources.user_white;
            this.pb_clientes.Location = new System.Drawing.Point(12, 58);
            this.pb_clientes.Name = "pb_clientes";
            this.pb_clientes.Size = new System.Drawing.Size(25, 25);
            this.pb_clientes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_clientes.TabIndex = 4;
            this.pb_clientes.TabStop = false;
            this.pb_clientes.Click += new System.EventHandler(this.pb_clientes_Click);
            // 
            // lbl_clientes
            // 
            this.lbl_clientes.AutoSize = true;
            this.lbl_clientes.BackColor = System.Drawing.Color.Transparent;
            this.lbl_clientes.Font = new System.Drawing.Font("Bahnschrift Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_clientes.ForeColor = System.Drawing.Color.White;
            this.lbl_clientes.Location = new System.Drawing.Point(43, 58);
            this.lbl_clientes.Name = "lbl_clientes";
            this.lbl_clientes.Size = new System.Drawing.Size(69, 25);
            this.lbl_clientes.TabIndex = 3;
            this.lbl_clientes.Text = "Clientes";
            this.lbl_clientes.Click += new System.EventHandler(this.lbl_clientes_Click);
            // 
            // pb_home
            // 
            this.pb_home.BackColor = System.Drawing.Color.Transparent;
            this.pb_home.Image = global::ProjetoFinal.Properties.Resources.icons8_home_100;
            this.pb_home.Location = new System.Drawing.Point(12, 22);
            this.pb_home.Name = "pb_home";
            this.pb_home.Size = new System.Drawing.Size(25, 25);
            this.pb_home.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_home.TabIndex = 4;
            this.pb_home.TabStop = false;
            this.pb_home.Click += new System.EventHandler(this.pb_home_Click);
            // 
            // lbl_exit
            // 
            this.lbl_exit.AutoSize = true;
            this.lbl_exit.BackColor = System.Drawing.Color.Transparent;
            this.lbl_exit.Font = new System.Drawing.Font("Bahnschrift Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_exit.ForeColor = System.Drawing.Color.White;
            this.lbl_exit.Location = new System.Drawing.Point(43, 375);
            this.lbl_exit.Name = "lbl_exit";
            this.lbl_exit.Size = new System.Drawing.Size(40, 25);
            this.lbl_exit.TabIndex = 3;
            this.lbl_exit.Text = "EXIT";
            this.lbl_exit.Click += new System.EventHandler(this.lbl_exit_Click);
            // 
            // pb_exit
            // 
            this.pb_exit.BackColor = System.Drawing.Color.Transparent;
            this.pb_exit.Image = global::ProjetoFinal.Properties.Resources.exit_white;
            this.pb_exit.Location = new System.Drawing.Point(12, 375);
            this.pb_exit.Name = "pb_exit";
            this.pb_exit.Size = new System.Drawing.Size(25, 25);
            this.pb_exit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_exit.TabIndex = 4;
            this.pb_exit.TabStop = false;
            // 
            // lbl_home
            // 
            this.lbl_home.AutoSize = true;
            this.lbl_home.BackColor = System.Drawing.Color.Transparent;
            this.lbl_home.Font = new System.Drawing.Font("Bahnschrift Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_home.ForeColor = System.Drawing.Color.White;
            this.lbl_home.Location = new System.Drawing.Point(43, 22);
            this.lbl_home.Name = "lbl_home";
            this.lbl_home.Size = new System.Drawing.Size(50, 25);
            this.lbl_home.TabIndex = 3;
            this.lbl_home.Text = "Home";
            this.lbl_home.Click += new System.EventHandler(this.lbl_home_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel4.Controls.Add(this.pb_financas);
            this.panel4.Controls.Add(this.lbl_financas);
            this.panel4.Location = new System.Drawing.Point(0, 135);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(150, 40);
            this.panel4.TabIndex = 5;
            // 
            // pb_financas
            // 
            this.pb_financas.BackColor = System.Drawing.Color.Transparent;
            this.pb_financas.Image = global::ProjetoFinal.Properties.Resources.financas_brown;
            this.pb_financas.Location = new System.Drawing.Point(12, 7);
            this.pb_financas.Name = "pb_financas";
            this.pb_financas.Size = new System.Drawing.Size(25, 25);
            this.pb_financas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_financas.TabIndex = 4;
            this.pb_financas.TabStop = false;
            // 
            // lbl_financas
            // 
            this.lbl_financas.AutoSize = true;
            this.lbl_financas.BackColor = System.Drawing.Color.Transparent;
            this.lbl_financas.Font = new System.Drawing.Font("Bahnschrift Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_financas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(83)))), ((int)(((byte)(66)))));
            this.lbl_financas.Location = new System.Drawing.Point(43, 7);
            this.lbl_financas.Name = "lbl_financas";
            this.lbl_financas.Size = new System.Drawing.Size(76, 25);
            this.lbl_financas.TabIndex = 3;
            this.lbl_financas.Text = "Finanças";
            // 
            // chart_faturacao_mensal
            // 
            this.chart_faturacao_mensal.BackColor = System.Drawing.Color.Transparent;
            this.chart_faturacao_mensal.BorderlineColor = System.Drawing.Color.Transparent;
            this.chart_faturacao_mensal.BorderlineWidth = 0;
            chartArea1.Name = "ChartArea1";
            this.chart_faturacao_mensal.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_faturacao_mensal.Legends.Add(legend1);
            this.chart_faturacao_mensal.Location = new System.Drawing.Point(-62, 27);
            this.chart_faturacao_mensal.Margin = new System.Windows.Forms.Padding(2);
            this.chart_faturacao_mensal.Name = "chart_faturacao_mensal";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart_faturacao_mensal.Series.Add(series1);
            this.chart_faturacao_mensal.Size = new System.Drawing.Size(666, 165);
            this.chart_faturacao_mensal.TabIndex = 12;
            this.chart_faturacao_mensal.Text = "Faturação Mensal";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(115)))), ((int)(((byte)(28)))));
            this.panel2.Controls.Add(this.lbl_welcome);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 50);
            this.panel2.TabIndex = 1;
            // 
            // lbl_welcome
            // 
            this.lbl_welcome.AutoSize = true;
            this.lbl_welcome.BackColor = System.Drawing.Color.Transparent;
            this.lbl_welcome.Font = new System.Drawing.Font("Bahnschrift Condensed", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_welcome.ForeColor = System.Drawing.Color.White;
            this.lbl_welcome.Location = new System.Drawing.Point(8, 11);
            this.lbl_welcome.Name = "lbl_welcome";
            this.lbl_welcome.Size = new System.Drawing.Size(95, 24);
            this.lbl_welcome.TabIndex = 2;
            this.lbl_welcome.Text = "lbl_welcome";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.Controls.Add(this.lb_detalhe_servicos);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.dgv_analise_clientes);
            this.panel3.Location = new System.Drawing.Point(166, 65);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(619, 398);
            this.panel3.TabIndex = 2;
            // 
            // lb_detalhe_servicos
            // 
            this.lb_detalhe_servicos.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lb_detalhe_servicos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_detalhe_servicos.ForeColor = System.Drawing.Color.Black;
            this.lb_detalhe_servicos.FormattingEnabled = true;
            this.lb_detalhe_servicos.ItemHeight = 16;
            this.lb_detalhe_servicos.Location = new System.Drawing.Point(13, 133);
            this.lb_detalhe_servicos.Name = "lb_detalhe_servicos";
            this.lb_detalhe_servicos.Size = new System.Drawing.Size(593, 52);
            this.lb_detalhe_servicos.TabIndex = 11;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.lbl_chart);
            this.panel5.Controls.Add(this.chart_faturacao_mensal);
            this.panel5.Location = new System.Drawing.Point(13, 205);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(593, 180);
            this.panel5.TabIndex = 20;
            // 
            // lbl_chart
            // 
            this.lbl_chart.AutoSize = true;
            this.lbl_chart.BackColor = System.Drawing.Color.Transparent;
            this.lbl_chart.Font = new System.Drawing.Font("Bahnschrift Condensed", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_chart.ForeColor = System.Drawing.Color.Black;
            this.lbl_chart.Location = new System.Drawing.Point(238, 1);
            this.lbl_chart.Name = "lbl_chart";
            this.lbl_chart.Size = new System.Drawing.Size(137, 24);
            this.lbl_chart.TabIndex = 2;
            this.lbl_chart.Text = "Faturação (Mensal)";
            // 
            // dgv_analise_clientes
            // 
            this.dgv_analise_clientes.BackgroundColor = System.Drawing.Color.White;
            this.dgv_analise_clientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_analise_clientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_analise_clientes.GridColor = System.Drawing.Color.ForestGreen;
            this.dgv_analise_clientes.Location = new System.Drawing.Point(13, 6);
            this.dgv_analise_clientes.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_analise_clientes.Name = "dgv_analise_clientes";
            this.dgv_analise_clientes.RowHeadersWidth = 51;
            this.dgv_analise_clientes.RowTemplate.Height = 24;
            this.dgv_analise_clientes.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_analise_clientes.Size = new System.Drawing.Size(593, 117);
            this.dgv_analise_clientes.TabIndex = 18;
            this.dgv_analise_clientes.SelectionChanged += new System.EventHandler(this.dgv_analise_clientes_SelectionChanged);
            // 
            // PainelFinancas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PainelFinancas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PainelAdmin";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_servicos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_clientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_home)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_exit)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_financas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_faturacao_mensal)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_analise_clientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_welcome;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbl_exit;
        private System.Windows.Forms.PictureBox pb_exit;
        private System.Windows.Forms.Label lbl_financas;
        private System.Windows.Forms.PictureBox pb_financas;
        private System.Windows.Forms.Label lbl_home;
        private System.Windows.Forms.PictureBox pb_home;
        private System.Windows.Forms.PictureBox pb_clientes;
        private System.Windows.Forms.Label lbl_clientes;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbl_servicos;
        private System.Windows.Forms.PictureBox tb_servicos;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_faturacao_mensal;
        private System.Windows.Forms.DataGridView dgv_analise_clientes;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ListBox lb_detalhe_servicos;
        private System.Windows.Forms.Label lbl_chart;
    }
}