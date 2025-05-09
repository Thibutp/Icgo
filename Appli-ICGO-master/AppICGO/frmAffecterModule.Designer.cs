namespace AppICGO
{
    partial class frmAffecterModule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAffecterModule));
            this.dgvModule = new System.Windows.Forms.DataGridView();
            this.colNumModule = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLibelle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSupprimer = new System.Windows.Forms.DataGridViewImageColumn();
            this.lstModule = new System.Windows.Forms.ListBox();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFermer = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNomStage = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNumStage = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCodeCompetence = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModule)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvModule
            // 
            this.dgvModule.AllowUserToAddRows = false;
            this.dgvModule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvModule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNumModule,
            this.colLibelle,
            this.colSupprimer});
            this.dgvModule.Location = new System.Drawing.Point(190, 258);
            this.dgvModule.Name = "dgvModule";
            this.dgvModule.ReadOnly = true;
            this.dgvModule.Size = new System.Drawing.Size(529, 139);
            this.dgvModule.TabIndex = 66;
            this.dgvModule.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvModule_CellContentClick);
            this.dgvModule.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvModule_UserDeletingRow);
            // 
            // colNumModule
            // 
            this.colNumModule.HeaderText = "Numéro";
            this.colNumModule.Name = "colNumModule";
            this.colNumModule.ReadOnly = true;
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
            // 
            // lstModule
            // 
            this.lstModule.FormattingEnabled = true;
            this.lstModule.Location = new System.Drawing.Point(190, 145);
            this.lstModule.Name = "lstModule";
            this.lstModule.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstModule.Size = new System.Drawing.Size(231, 95);
            this.lstModule.TabIndex = 65;
            // 
            // btnAjouter
            // 
            this.btnAjouter.Location = new System.Drawing.Point(213, 403);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(92, 35);
            this.btnAjouter.TabIndex = 64;
            this.btnAjouter.Text = "&Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 246);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 17);
            this.label2.TabIndex = 63;
            this.label2.Text = "Liste des modules";
            // 
            // btnFermer
            // 
            this.btnFermer.Location = new System.Drawing.Point(484, 403);
            this.btnFermer.Name = "btnFermer";
            this.btnFermer.Size = new System.Drawing.Size(83, 35);
            this.btnFermer.TabIndex = 62;
            this.btnFermer.Text = "&Fermer";
            this.btnFermer.UseVisualStyleBackColor = true;
            this.btnFermer.Click += new System.EventHandler(this.btnFermer_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 17);
            this.label3.TabIndex = 61;
            this.label3.Text = "Choisir les modules";
            // 
            // txtNomStage
            // 
            this.txtNomStage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomStage.Location = new System.Drawing.Point(190, 99);
            this.txtNomStage.Name = "txtNomStage";
            this.txtNomStage.ReadOnly = true;
            this.txtNomStage.Size = new System.Drawing.Size(308, 23);
            this.txtNomStage.TabIndex = 60;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(134, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 17);
            this.label6.TabIndex = 59;
            this.label6.Text = "Nom";
            // 
            // txtNumStage
            // 
            this.txtNumStage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumStage.Location = new System.Drawing.Point(190, 52);
            this.txtNumStage.Name = "txtNumStage";
            this.txtNumStage.ReadOnly = true;
            this.txtNumStage.Size = new System.Drawing.Size(100, 23);
            this.txtNumStage.TabIndex = 58;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(74, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 17);
            this.label5.TabIndex = 57;
            this.label5.Text = "Numero stage";
            // 
            // txtCodeCompetence
            // 
            this.txtCodeCompetence.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodeCompetence.Location = new System.Drawing.Point(190, 11);
            this.txtCodeCompetence.Name = "txtCodeCompetence";
            this.txtCodeCompetence.ReadOnly = true;
            this.txtCodeCompetence.Size = new System.Drawing.Size(100, 23);
            this.txtCodeCompetence.TabIndex = 56;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 17);
            this.label1.TabIndex = 55;
            this.label1.Text = "Code compétence";
            // 
            // frmAffecterModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvModule);
            this.Controls.Add(this.lstModule);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnFermer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNomStage);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNumStage);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCodeCompetence);
            this.Controls.Add(this.label1);
            this.Name = "frmAffecterModule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Affecter les modules";
            this.Load += new System.EventHandler(this.frmAffecterModule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvModule)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvModule;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumModule;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLibelle;
        private System.Windows.Forms.DataGridViewImageColumn colSupprimer;
        private System.Windows.Forms.ListBox lstModule;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFermer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNomStage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNumStage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCodeCompetence;
        private System.Windows.Forms.Label label1;
    }
}