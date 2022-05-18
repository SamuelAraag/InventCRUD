﻿namespace CRUD_CadastroCliente
{
    partial class FormNovoCliente
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
            this.caixaCPF = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.caixaTelefone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.caixaEmail = new System.Windows.Forms.TextBox();
            this.botaoSalvar = new System.Windows.Forms.Button();
            this.botaoSair = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "NOME";
            // 
            // caixaNome
            // 
            this.caixaNome.Location = new System.Drawing.Point(16, 30);
            this.caixaNome.Name = "caixaNome";
            this.caixaNome.Size = new System.Drawing.Size(346, 20);
            this.caixaNome.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "CPF";
            // 
            // caixaCPF
            // 
            this.caixaCPF.Location = new System.Drawing.Point(16, 92);
            this.caixaCPF.Name = "caixaCPF";
            this.caixaCPF.Size = new System.Drawing.Size(346, 20);
            this.caixaCPF.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "TELEFONE";
            // 
            // caixaTelefone
            // 
            this.caixaTelefone.Location = new System.Drawing.Point(19, 158);
            this.caixaTelefone.Name = "caixaTelefone";
            this.caixaTelefone.Size = new System.Drawing.Size(343, 20);
            this.caixaTelefone.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "EMAIL";
            // 
            // caixaEmail
            // 
            this.caixaEmail.Location = new System.Drawing.Point(19, 226);
            this.caixaEmail.Name = "caixaEmail";
            this.caixaEmail.Size = new System.Drawing.Size(343, 20);
            this.caixaEmail.TabIndex = 7;
            // 
            // botaoSalvar
            // 
            this.botaoSalvar.BackColor = System.Drawing.Color.PaleGreen;
            this.botaoSalvar.Location = new System.Drawing.Point(19, 372);
            this.botaoSalvar.Name = "botaoSalvar";
            this.botaoSalvar.Size = new System.Drawing.Size(149, 37);
            this.botaoSalvar.TabIndex = 8;
            this.botaoSalvar.Text = "SALVAR";
            this.botaoSalvar.UseVisualStyleBackColor = false;
            this.botaoSalvar.Click += new System.EventHandler(this.botaoSalvar_Click);
            // 
            // botaoSair
            // 
            this.botaoSair.BackColor = System.Drawing.Color.IndianRed;
            this.botaoSair.Location = new System.Drawing.Point(208, 372);
            this.botaoSair.Name = "botaoSair";
            this.botaoSair.Size = new System.Drawing.Size(154, 38);
            this.botaoSair.TabIndex = 9;
            this.botaoSair.Text = "SAIR";
            this.botaoSair.UseVisualStyleBackColor = false;
            // 
            // FormNovoCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 446);
            this.Controls.Add(this.botaoSair);
            this.Controls.Add(this.botaoSalvar);
            this.Controls.Add(this.caixaEmail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.caixaTelefone);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.caixaCPF);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.caixaNome);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormNovoCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NOVO CLIENTE";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox caixaNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox caixaCPF;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox caixaTelefone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox caixaEmail;
        private System.Windows.Forms.Button botaoSalvar;
        private System.Windows.Forms.Button botaoSair;
    }
}