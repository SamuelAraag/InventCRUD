namespace CRUD_CadastroCliente
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.botaoNovo = new System.Windows.Forms.Button();
            this.botaoAtualizar = new System.Windows.Forms.Button();
            this.botaoDeletar = new System.Windows.Forms.Button();
            this.caixaLista = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // botaoNovo
            // 
            this.botaoNovo.Location = new System.Drawing.Point(505, 405);
            this.botaoNovo.Name = "botaoNovo";
            this.botaoNovo.Size = new System.Drawing.Size(91, 33);
            this.botaoNovo.TabIndex = 0;
            this.botaoNovo.Text = "NOVO";
            this.botaoNovo.UseVisualStyleBackColor = true;
            this.botaoNovo.Click += new System.EventHandler(this.botaoNovo_Click);
            // 
            // botaoAtualizar
            // 
            this.botaoAtualizar.Location = new System.Drawing.Point(602, 405);
            this.botaoAtualizar.Name = "botaoAtualizar";
            this.botaoAtualizar.Size = new System.Drawing.Size(91, 33);
            this.botaoAtualizar.TabIndex = 1;
            this.botaoAtualizar.Text = "ATUALIZAR";
            this.botaoAtualizar.UseVisualStyleBackColor = true;
            this.botaoAtualizar.Click += new System.EventHandler(this.botaoAtualizar_Click);
            // 
            // botaoDeletar
            // 
            this.botaoDeletar.Location = new System.Drawing.Point(699, 405);
            this.botaoDeletar.Name = "botaoDeletar";
            this.botaoDeletar.Size = new System.Drawing.Size(91, 33);
            this.botaoDeletar.TabIndex = 2;
            this.botaoDeletar.Text = "DELETAR";
            this.botaoDeletar.UseVisualStyleBackColor = true;
            this.botaoDeletar.Click += new System.EventHandler(this.botaoDeletar_Click);
            // 
            // caixaLista
            // 
            this.caixaLista.FormattingEnabled = true;
            this.caixaLista.Location = new System.Drawing.Point(12, 12);
            this.caixaLista.Name = "caixaLista";
            this.caixaLista.Size = new System.Drawing.Size(778, 381);
            this.caixaLista.TabIndex = 3;
            this.caixaLista.SelectedIndexChanged += new System.EventHandler(this.caixaLista_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.caixaLista);
            this.Controls.Add(this.botaoDeletar);
            this.Controls.Add(this.botaoAtualizar);
            this.Controls.Add(this.botaoNovo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "CADASTRO DE USUARIOS";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button botaoNovo;
        private System.Windows.Forms.Button botaoAtualizar;
        private System.Windows.Forms.Button botaoDeletar;
        private System.Windows.Forms.ListBox caixaLista;
    }
}

