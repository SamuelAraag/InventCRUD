﻿namespace CRUD_CadastroUsuario
{
    partial class FormularioConsultaUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormularioConsultaUsuarios));
            this.botaoNovo = new System.Windows.Forms.Button();
            this.botaoAtualizar = new System.Windows.Forms.Button();
            this.botaoDeletar = new System.Windows.Forms.Button();
            this.botaoOk = new System.Windows.Forms.Button();
            this.botaoCancelar = new System.Windows.Forms.Button();
            this.listaUsuariosGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.listaUsuariosGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // botaoNovo
            // 
            this.botaoNovo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.botaoNovo.Location = new System.Drawing.Point(426, 359);
            this.botaoNovo.Name = "botaoNovo";
            this.botaoNovo.Size = new System.Drawing.Size(75, 23);
            this.botaoNovo.TabIndex = 0;
            this.botaoNovo.Text = "Novo";
            this.botaoNovo.UseVisualStyleBackColor = true;
            this.botaoNovo.Click += new System.EventHandler(this.AoClicarEmNovo);
            // 
            // botaoAtualizar
            // 
            this.botaoAtualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.botaoAtualizar.Location = new System.Drawing.Point(507, 359);
            this.botaoAtualizar.Name = "botaoAtualizar";
            this.botaoAtualizar.Size = new System.Drawing.Size(75, 23);
            this.botaoAtualizar.TabIndex = 1;
            this.botaoAtualizar.Text = "Atualizar";
            this.botaoAtualizar.UseVisualStyleBackColor = true;
            this.botaoAtualizar.Click += new System.EventHandler(this.AoClicarEmAtualizar);
            // 
            // botaoDeletar
            // 
            this.botaoDeletar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.botaoDeletar.Location = new System.Drawing.Point(588, 359);
            this.botaoDeletar.Name = "botaoDeletar";
            this.botaoDeletar.Size = new System.Drawing.Size(75, 23);
            this.botaoDeletar.TabIndex = 2;
            this.botaoDeletar.Text = "Deletar";
            this.botaoDeletar.UseVisualStyleBackColor = true;
            this.botaoDeletar.Click += new System.EventHandler(this.AoClicarEmDeletar);
            // 
            // botaoOk
            // 
            this.botaoOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.botaoOk.Location = new System.Drawing.Point(13, 359);
            this.botaoOk.Name = "botaoOk";
            this.botaoOk.Size = new System.Drawing.Size(75, 23);
            this.botaoOk.TabIndex = 4;
            this.botaoOk.Text = "Ok";
            this.botaoOk.UseVisualStyleBackColor = true;
            this.botaoOk.Click += new System.EventHandler(this.AoClicarEmOk);
            // 
            // botaoCancelar
            // 
            this.botaoCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.botaoCancelar.Location = new System.Drawing.Point(94, 359);
            this.botaoCancelar.Name = "botaoCancelar";
            this.botaoCancelar.Size = new System.Drawing.Size(75, 23);
            this.botaoCancelar.TabIndex = 5;
            this.botaoCancelar.Text = "Cancelar";
            this.botaoCancelar.UseVisualStyleBackColor = true;
            this.botaoCancelar.Click += new System.EventHandler(this.AoClicarEmCancelar);
            // 
            // listaUsuariosGrid
            // 
            this.listaUsuariosGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listaUsuariosGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listaUsuariosGrid.Location = new System.Drawing.Point(12, 13);
            this.listaUsuariosGrid.Name = "listaUsuariosGrid";
            this.listaUsuariosGrid.Size = new System.Drawing.Size(651, 328);
            this.listaUsuariosGrid.TabIndex = 6;
            // 
            // FormularioConsultaUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 396);
            this.Controls.Add(this.listaUsuariosGrid);
            this.Controls.Add(this.botaoCancelar);
            this.Controls.Add(this.botaoOk);
            this.Controls.Add(this.botaoDeletar);
            this.Controls.Add(this.botaoAtualizar);
            this.Controls.Add(this.botaoNovo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormularioConsultaUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de usuários";
            ((System.ComponentModel.ISupportInitialize)(this.listaUsuariosGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button botaoNovo;
        private System.Windows.Forms.Button botaoAtualizar;
        private System.Windows.Forms.Button botaoDeletar;
        private System.Windows.Forms.Button botaoOk;
        private System.Windows.Forms.Button botaoCancelar;
        private System.Windows.Forms.DataGridView listaUsuariosGrid;
    }
}

