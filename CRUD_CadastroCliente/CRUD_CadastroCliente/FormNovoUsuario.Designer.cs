namespace CRUD_CadastroCliente
{
    partial class FormNovoUsuario
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
            this.label1 = new System.Windows.Forms.Label();
            this.caixaNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.caixaSenha = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.caixaEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.caixaDataNascimento = new System.Windows.Forms.MaskedTextBox();
            this.botaoSalvar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.CaixaId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.caixaDataCriacao = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome";
            // 
            // caixaNome
            // 
            this.caixaNome.Location = new System.Drawing.Point(104, 50);
            this.caixaNome.Name = "caixaNome";
            this.caixaNome.Size = new System.Drawing.Size(258, 20);
            this.caixaNome.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Senha";
            // 
            // caixaSenha
            // 
            this.caixaSenha.Location = new System.Drawing.Point(104, 86);
            this.caixaSenha.Name = "caixaSenha";
            this.caixaSenha.PasswordChar = '*';
            this.caixaSenha.Size = new System.Drawing.Size(258, 20);
            this.caixaSenha.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "E-mail";
            // 
            // caixaEmail
            // 
            this.caixaEmail.Location = new System.Drawing.Point(104, 120);
            this.caixaEmail.Name = "caixaEmail";
            this.caixaEmail.Size = new System.Drawing.Size(258, 20);
            this.caixaEmail.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Data Nascimento";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Data Criação";
            // 
            // caixaDataNascimento
            // 
            this.caixaDataNascimento.Location = new System.Drawing.Point(104, 157);
            this.caixaDataNascimento.Mask = "00/00/0000";
            this.caixaDataNascimento.Name = "caixaDataNascimento";
            this.caixaDataNascimento.Size = new System.Drawing.Size(86, 20);
            this.caixaDataNascimento.TabIndex = 12;
            this.caixaDataNascimento.ValidatingType = typeof(System.DateTime);
            // 
            // botaoSalvar
            // 
            this.botaoSalvar.BackColor = System.Drawing.SystemColors.Control;
            this.botaoSalvar.Location = new System.Drawing.Point(12, 254);
            this.botaoSalvar.Name = "botaoSalvar";
            this.botaoSalvar.Size = new System.Drawing.Size(86, 27);
            this.botaoSalvar.TabIndex = 14;
            this.botaoSalvar.Text = "Salvar";
            this.botaoSalvar.UseVisualStyleBackColor = false;
            this.botaoSalvar.Click += new System.EventHandler(this.botaoSalvar_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(104, 254);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 27);
            this.button1.TabIndex = 15;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CaixaId
            // 
            this.CaixaId.Location = new System.Drawing.Point(104, 12);
            this.CaixaId.Name = "CaixaId";
            this.CaixaId.Size = new System.Drawing.Size(86, 20);
            this.CaixaId.TabIndex = 17;
            this.CaixaId.TextChanged += new System.EventHandler(this.CaixaId_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Id";
            // 
            // caixaDataCriacao
            // 
            this.caixaDataCriacao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.caixaDataCriacao.Location = new System.Drawing.Point(104, 194);
            this.caixaDataCriacao.Name = "caixaDataCriacao";
            this.caixaDataCriacao.Size = new System.Drawing.Size(86, 20);
            this.caixaDataCriacao.TabIndex = 18;
            // 
            // FormNovoUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 290);
            this.Controls.Add(this.caixaDataCriacao);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.botaoSalvar);
            this.Controls.Add(this.caixaDataNascimento);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.caixaEmail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.caixaSenha);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.caixaNome);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CaixaId);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormNovoUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Novo Usuário";
            this.Load += new System.EventHandler(this.FormNovoUsuario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox caixaNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox caixaSenha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox caixaEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox caixaDataNascimento;
        private System.Windows.Forms.Button botaoSalvar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox CaixaId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker caixaDataCriacao;
    }
}