namespace ProjetoFinal
{
    partial class Login
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
            this.lbl_login = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_login = new System.Windows.Forms.Button();
            this.lbl_limpar = new System.Windows.Forms.Label();
            this.lbl_sair = new System.Windows.Forms.Label();
            this.tb_user = new System.Windows.Forms.TextBox();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.pb_pass = new System.Windows.Forms.PictureBox();
            this.pb_profile = new System.Windows.Forms.PictureBox();
            this.pb_logo = new System.Windows.Forms.PictureBox();
            this.cb_mostrar_password = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_pass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_profile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_login
            // 
            this.lbl_login.AutoSize = true;
            this.lbl_login.Font = new System.Drawing.Font("Bahnschrift", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_login.ForeColor = System.Drawing.Color.ForestGreen;
            this.lbl_login.Location = new System.Drawing.Point(100, 185);
            this.lbl_login.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_login.Name = "lbl_login";
            this.lbl_login.Size = new System.Drawing.Size(106, 39);
            this.lbl_login.TabIndex = 1;
            this.lbl_login.Text = "LOGIN";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.ForestGreen;
            this.panel1.Location = new System.Drawing.Point(62, 272);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(177, 1);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.ForestGreen;
            this.panel2.Location = new System.Drawing.Point(62, 332);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(177, 1);
            this.panel2.TabIndex = 3;
            // 
            // btn_login
            // 
            this.btn_login.BackColor = System.Drawing.Color.ForestGreen;
            this.btn_login.FlatAppearance.BorderSize = 0;
            this.btn_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_login.Font = new System.Drawing.Font("Bahnschrift", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_login.ForeColor = System.Drawing.Color.White;
            this.btn_login.Location = new System.Drawing.Point(62, 393);
            this.btn_login.Margin = new System.Windows.Forms.Padding(2);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(177, 31);
            this.btn_login.TabIndex = 4;
            this.btn_login.Text = "LOGIN";
            this.btn_login.UseVisualStyleBackColor = false;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // lbl_limpar
            // 
            this.lbl_limpar.AutoSize = true;
            this.lbl_limpar.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_limpar.ForeColor = System.Drawing.Color.ForestGreen;
            this.lbl_limpar.Location = new System.Drawing.Point(184, 347);
            this.lbl_limpar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_limpar.Name = "lbl_limpar";
            this.lbl_limpar.Size = new System.Drawing.Size(55, 23);
            this.lbl_limpar.TabIndex = 5;
            this.lbl_limpar.Text = "Limpar";
            this.lbl_limpar.Click += new System.EventHandler(this.lbl_limpar_Click);
            // 
            // lbl_sair
            // 
            this.lbl_sair.AutoSize = true;
            this.lbl_sair.Font = new System.Drawing.Font("Bahnschrift Condensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_sair.ForeColor = System.Drawing.Color.ForestGreen;
            this.lbl_sair.Location = new System.Drawing.Point(127, 430);
            this.lbl_sair.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_sair.Name = "lbl_sair";
            this.lbl_sair.Size = new System.Drawing.Size(41, 25);
            this.lbl_sair.TabIndex = 5;
            this.lbl_sair.Text = "Sair";
            this.lbl_sair.Click += new System.EventHandler(this.lbl_sair_Click);
            // 
            // tb_user
            // 
            this.tb_user.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_user.Font = new System.Drawing.Font("Bahnschrift Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_user.ForeColor = System.Drawing.Color.ForestGreen;
            this.tb_user.Location = new System.Drawing.Point(93, 237);
            this.tb_user.Margin = new System.Windows.Forms.Padding(2);
            this.tb_user.Multiline = true;
            this.tb_user.Name = "tb_user";
            this.tb_user.Size = new System.Drawing.Size(146, 41);
            this.tb_user.TabIndex = 1;
            // 
            // tb_password
            // 
            this.tb_password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_password.Font = new System.Drawing.Font("Bahnschrift Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_password.ForeColor = System.Drawing.Color.ForestGreen;
            this.tb_password.Location = new System.Drawing.Point(93, 297);
            this.tb_password.Margin = new System.Windows.Forms.Padding(2);
            this.tb_password.Name = "tb_password";
            this.tb_password.PasswordChar = '*';
            this.tb_password.Size = new System.Drawing.Size(146, 29);
            this.tb_password.TabIndex = 2;
            // 
            // pb_pass
            // 
            this.pb_pass.Image = global::ProjetoFinal.Properties.Resources.icons8_password_100;
            this.pb_pass.Location = new System.Drawing.Point(62, 297);
            this.pb_pass.Margin = new System.Windows.Forms.Padding(2);
            this.pb_pass.Name = "pb_pass";
            this.pb_pass.Size = new System.Drawing.Size(27, 30);
            this.pb_pass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_pass.TabIndex = 2;
            this.pb_pass.TabStop = false;
            // 
            // pb_profile
            // 
            this.pb_profile.Image = global::ProjetoFinal.Properties.Resources.icons8_user_100;
            this.pb_profile.Location = new System.Drawing.Point(62, 241);
            this.pb_profile.Margin = new System.Windows.Forms.Padding(2);
            this.pb_profile.Name = "pb_profile";
            this.pb_profile.Size = new System.Drawing.Size(27, 26);
            this.pb_profile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_profile.TabIndex = 2;
            this.pb_profile.TabStop = false;
            // 
            // pb_logo
            // 
            this.pb_logo.Image = global::ProjetoFinal.Properties.Resources.CRM_Logo_1;
            this.pb_logo.Location = new System.Drawing.Point(80, 16);
            this.pb_logo.Margin = new System.Windows.Forms.Padding(2);
            this.pb_logo.Name = "pb_logo";
            this.pb_logo.Size = new System.Drawing.Size(145, 151);
            this.pb_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_logo.TabIndex = 0;
            this.pb_logo.TabStop = false;
            // 
            // cb_mostrar_password
            // 
            this.cb_mostrar_password.AutoSize = true;
            this.cb_mostrar_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_mostrar_password.Location = new System.Drawing.Point(224, 308);
            this.cb_mostrar_password.Name = "cb_mostrar_password";
            this.cb_mostrar_password.Size = new System.Drawing.Size(15, 14);
            this.cb_mostrar_password.TabIndex = 7;
            this.cb_mostrar_password.UseVisualStyleBackColor = true;
            this.cb_mostrar_password.CheckedChanged += new System.EventHandler(this.cb_mostrar_password_CheckedChanged);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(308, 486);
            this.Controls.Add(this.cb_mostrar_password);
            this.Controls.Add(this.tb_password);
            this.Controls.Add(this.lbl_sair);
            this.Controls.Add(this.lbl_limpar);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pb_pass);
            this.Controls.Add(this.pb_profile);
            this.Controls.Add(this.lbl_login);
            this.Controls.Add(this.pb_logo);
            this.Controls.Add(this.tb_user);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pb_pass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_profile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_logo;
        private System.Windows.Forms.Label lbl_login;
        private System.Windows.Forms.PictureBox pb_profile;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pb_pass;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Label lbl_limpar;
        private System.Windows.Forms.Label lbl_sair;
        private System.Windows.Forms.TextBox tb_user;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.CheckBox cb_mostrar_password;
    }
}

