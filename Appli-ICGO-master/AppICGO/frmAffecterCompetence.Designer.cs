namespace AppICGO
{
    partial class frmAffecterCompetence
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAffecterCompetence));
            this.dgvCompetence = new System.Windows.Forms.DataGridView();
            this.colCodeCompetence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLibelle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSupprimer = new System.Windows.Forms.DataGridViewImageColumn();
            this.lstCompetence = new System.Windows.Forms.ListBox();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFermer = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrenomFormateur = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNomFormateur = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNumFormateur = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompetence)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCompetence
            // 
            this.dgvCompetence.AllowUserToAddRows = false;
            this.dgvCompetence.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompetence.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodeCompetence,
            this.colLibelle,
            this.colSupprimer});
            this.dgvCompetence.Location = new System.Drawing.Point(196, 272);
            this.dgvCompetence.Name = "dgvCompetence";
            this.dgvCompetence.ReadOnly = true;
            this.dgvCompetence.Size = new System.Drawing.Size(458, 132);
            this.dgvCompetence.TabIndex = 54;
            this.dgvCompetence.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCompetence_CellContentClick);
            this.dgvCompetence.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvCompetence_UserDeletingRow);
            // 
            // colCodeCompetence
            // 
            this.colCodeCompetence.HeaderText = "Code";
            this.colCodeCompetence.Name = "colCodeCompetence";
            this.colCodeCompetence.ReadOnly = true;
            // 
            // colLibelle
            // 
            this.colLibelle.HeaderText = "Libellé";
            this.colLibelle.Name = "colLibelle";
            this.colLibelle.ReadOnly = true;
            this.colLibelle.Width = 250;
            // 
            // colSupprimer
            // 
            this.colSupprimer.HeaderText = "";
            this.colSupprimer.Image = ((System.Drawing.Image)(resources.GetObject("colSupprimer.Image")));
            this.colSupprimer.Name = "colSupprimer";
            this.colSupprimer.ReadOnly = true;
            this.colSupprimer.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSupprimer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // lstCompetence
            // 
            this.lstCompetence.FormattingEnabled = true;
            this.lstCompetence.Location = new System.Drawing.Point(196, 152);
            this.lstCompetence.Name = "lstCompetence";
            this.lstCompetence.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstCompetence.Size = new System.Drawing.Size(231, 95);
            this.lstCompetence.TabIndex = 53;
            // 
            // btnAjouter
            // 
            this.btnAjouter.Location = new System.Drawing.Point(219, 410);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(92, 35);
            this.btnAjouter.TabIndex = 52;
            this.btnAjouter.Text = "&Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 253);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 17);
            this.label2.TabIndex = 51;
            this.label2.Text = "Liste des compétences";
            // 
            // btnFermer
            // 
            this.btnFermer.Location = new System.Drawing.Point(490, 410);
            this.btnFermer.Name = "btnFermer";
            this.btnFermer.Size = new System.Drawing.Size(83, 35);
            this.btnFermer.TabIndex = 50;
            this.btnFermer.Text = "&Fermer";
            this.btnFermer.UseVisualStyleBackColor = true;
            this.btnFermer.Click += new System.EventHandler(this.btnFermer_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 17);
            this.label3.TabIndex = 49;
            this.label3.Text = "Choisir les compétences";
            // 
            // txtPrenomFormateur
            // 
            this.txtPrenomFormateur.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrenomFormateur.Location = new System.Drawing.Point(196, 106);
            this.txtPrenomFormateur.Name = "txtPrenomFormateur";
            this.txtPrenomFormateur.ReadOnly = true;
            this.txtPrenomFormateur.Size = new System.Drawing.Size(231, 23);
            this.txtPrenomFormateur.TabIndex = 48;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(121, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 17);
            this.label6.TabIndex = 47;
            this.label6.Text = "Prénom";
            // 
            // txtNomFormateur
            // 
            this.txtNomFormateur.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomFormateur.Location = new System.Drawing.Point(196, 54);
            this.txtNomFormateur.Name = "txtNomFormateur";
            this.txtNomFormateur.ReadOnly = true;
            this.txtNomFormateur.Size = new System.Drawing.Size(231, 23);
            this.txtNomFormateur.TabIndex = 46;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(141, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 17);
            this.label5.TabIndex = 45;
            this.label5.Text = "Nom";
            // 
            // txtNumFormateur
            // 
            this.txtNumFormateur.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumFormateur.Location = new System.Drawing.Point(196, 15);
            this.txtNumFormateur.Name = "txtNumFormateur";
            this.txtNumFormateur.ReadOnly = true;
            this.txtNumFormateur.Size = new System.Drawing.Size(100, 23);
            this.txtNumFormateur.TabIndex = 44;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(55, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 17);
            this.label1.TabIndex = 43;
            this.label1.Text = "Numéro formateur";
            // 
            // frmAffecterCompetence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 454);
            this.Controls.Add(this.dgvCompetence);
            this.Controls.Add(this.lstCompetence);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnFermer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPrenomFormateur);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNomFormateur);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNumFormateur);
            this.Controls.Add(this.label1);
            this.Name = "frmAffecterCompetence";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Affecter les competences";
            this.Load += new System.EventHandler(this.frmAffecterCompetence_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompetence)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCompetence;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodeCompetence;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLibelle;
        private System.Windows.Forms.DataGridViewImageColumn colSupprimer;
        private System.Windows.Forms.ListBox lstCompetence;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFermer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPrenomFormateur;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNomFormateur;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNumFormateur;
        private System.Windows.Forms.Label label1;
    }
}