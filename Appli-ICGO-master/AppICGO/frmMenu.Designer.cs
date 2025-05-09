namespace AppICGO
{
    partial class frmMenu
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
            this.menuICGO = new System.Windows.Forms.MenuStrip();
            this.mnuFichier = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuitter = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAgence = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMajAgence = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRecrutement = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMajCompetence = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMajFormateur = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCatalogue = new System.Windows.Forms.ToolStripMenuItem();
            this.munMajModule = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMajStage = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMajSession = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInscription = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInscrireStagiaire = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConfirmerInscription = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStagiaire = new System.Windows.Forms.ToolStripMenuItem();
            this.menuICGO.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuICGO
            // 
            this.menuICGO.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFichier,
            this.mnuAgence,
            this.mnuRecrutement,
            this.mnuCatalogue,
            this.mnuInscription});
            this.menuICGO.Location = new System.Drawing.Point(0, 0);
            this.menuICGO.Name = "menuICGO";
            this.menuICGO.Size = new System.Drawing.Size(1081, 24);
            this.menuICGO.TabIndex = 3;
            this.menuICGO.Text = "menuStrip1";
            // 
            // mnuFichier
            // 
            this.mnuFichier.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuQuitter});
            this.mnuFichier.Name = "mnuFichier";
            this.mnuFichier.Size = new System.Drawing.Size(54, 20);
            this.mnuFichier.Text = "&Fichier";
            // 
            // mnuQuitter
            // 
            this.mnuQuitter.Name = "mnuQuitter";
            this.mnuQuitter.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.mnuQuitter.Size = new System.Drawing.Size(154, 22);
            this.mnuQuitter.Text = "&Quitter";
            this.mnuQuitter.Click += new System.EventHandler(this.mnuQuitter_Click);
            // 
            // mnuAgence
            // 
            this.mnuAgence.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMajAgence});
            this.mnuAgence.Name = "mnuAgence";
            this.mnuAgence.Size = new System.Drawing.Size(59, 20);
            this.mnuAgence.Text = "&Agence";
            // 
            // mnuMajAgence
            // 
            this.mnuMajAgence.Name = "mnuMajAgence";
            this.mnuMajAgence.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.mnuMajAgence.Size = new System.Drawing.Size(215, 22);
            this.mnuMajAgence.Text = "Mise à jour &agence";
            this.mnuMajAgence.Click += new System.EventHandler(this.mnuMajAgence_Click);
            // 
            // mnuRecrutement
            // 
            this.mnuRecrutement.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMajCompetence,
            this.mnuMajFormateur});
            this.mnuRecrutement.Name = "mnuRecrutement";
            this.mnuRecrutement.Size = new System.Drawing.Size(87, 20);
            this.mnuRecrutement.Text = "&Recrutement";
            // 
            // mnuMajCompetence
            // 
            this.mnuMajCompetence.Name = "mnuMajCompetence";
            this.mnuMajCompetence.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mnuMajCompetence.Size = new System.Drawing.Size(243, 22);
            this.mnuMajCompetence.Text = "Mise à jour &compétence";
            this.mnuMajCompetence.Click += new System.EventHandler(this.mnuMajCompetence_Click);
            // 
            // mnuMajFormateur
            // 
            this.mnuMajFormateur.Name = "mnuMajFormateur";
            this.mnuMajFormateur.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.mnuMajFormateur.Size = new System.Drawing.Size(243, 22);
            this.mnuMajFormateur.Text = "Mise à jour &formateur";
            this.mnuMajFormateur.Click += new System.EventHandler(this.mnuMajFormateur_Click);
            // 
            // mnuCatalogue
            // 
            this.mnuCatalogue.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.munMajModule,
            this.mnuMajStage,
            this.mnuMajSession});
            this.mnuCatalogue.Name = "mnuCatalogue";
            this.mnuCatalogue.Size = new System.Drawing.Size(73, 20);
            this.mnuCatalogue.Text = "&Catalogue";
            // 
            // munMajModule
            // 
            this.munMajModule.Name = "munMajModule";
            this.munMajModule.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.munMajModule.Size = new System.Drawing.Size(260, 22);
            this.munMajModule.Text = "Mise à jour &module";
            this.munMajModule.Click += new System.EventHandler(this.munMajModule_Click);
            // 
            // mnuMajStage
            // 
            this.mnuMajStage.Name = "mnuMajStage";
            this.mnuMajStage.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuMajStage.Size = new System.Drawing.Size(260, 22);
            this.mnuMajStage.Text = "Mise à jour &stage";
            this.mnuMajStage.Click += new System.EventHandler(this.mnuMajStage_Click);
            // 
            // mnuMajSession
            // 
            this.mnuMajSession.Name = "mnuMajSession";
            this.mnuMajSession.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.mnuMajSession.Size = new System.Drawing.Size(260, 22);
            this.mnuMajSession.Text = "Mise à jour s&ession de stage";
            this.mnuMajSession.Click += new System.EventHandler(this.mnuMajSession_Click);
            // 
            // mnuInscription
            // 
            this.mnuInscription.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInscrireStagiaire,
            this.mnuConfirmerInscription,
            this.mnuStagiaire});
            this.mnuInscription.Name = "mnuInscription";
            this.mnuInscription.Size = new System.Drawing.Size(75, 20);
            this.mnuInscription.Text = "&Inscription";
            // 
            // mnuInscrireStagiaire
            // 
            this.mnuInscrireStagiaire.Name = "mnuInscrireStagiaire";
            this.mnuInscrireStagiaire.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.mnuInscrireStagiaire.Size = new System.Drawing.Size(224, 22);
            this.mnuInscrireStagiaire.Text = "Inscrire s&tagiaire";
            this.mnuInscrireStagiaire.Click += new System.EventHandler(this.mnuInscrireStagiaire_Click);
            // 
            // mnuConfirmerInscription
            // 
            this.mnuConfirmerInscription.Name = "mnuConfirmerInscription";
            this.mnuConfirmerInscription.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.mnuConfirmerInscription.Size = new System.Drawing.Size(224, 22);
            this.mnuConfirmerInscription.Text = "Confirmer &inscription";
            this.mnuConfirmerInscription.Click += new System.EventHandler(this.mnuConfirmerInscription_Click);
            // 
            // mnuStagiaire
            // 
            this.mnuStagiaire.Name = "mnuStagiaire";
            this.mnuStagiaire.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.mnuStagiaire.Size = new System.Drawing.Size(224, 22);
            this.mnuStagiaire.Text = "Mise à jour sta&giaire";
            this.mnuStagiaire.Click += new System.EventHandler(this.mnuStagiaire_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 649);
            this.Controls.Add(this.menuICGO);
            this.IsMdiContainer = true;
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ICGO Formation";
            this.menuICGO.ResumeLayout(false);
            this.menuICGO.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuICGO;
        private System.Windows.Forms.ToolStripMenuItem mnuFichier;
        private System.Windows.Forms.ToolStripMenuItem mnuQuitter;
        private System.Windows.Forms.ToolStripMenuItem mnuAgence;
        private System.Windows.Forms.ToolStripMenuItem mnuMajAgence;
        private System.Windows.Forms.ToolStripMenuItem mnuRecrutement;
        private System.Windows.Forms.ToolStripMenuItem mnuMajCompetence;
        private System.Windows.Forms.ToolStripMenuItem mnuMajFormateur;
        private System.Windows.Forms.ToolStripMenuItem mnuCatalogue;
        private System.Windows.Forms.ToolStripMenuItem munMajModule;
        private System.Windows.Forms.ToolStripMenuItem mnuMajStage;
        private System.Windows.Forms.ToolStripMenuItem mnuMajSession;
        private System.Windows.Forms.ToolStripMenuItem mnuInscription;
        private System.Windows.Forms.ToolStripMenuItem mnuInscrireStagiaire;
        private System.Windows.Forms.ToolStripMenuItem mnuConfirmerInscription;
        private System.Windows.Forms.ToolStripMenuItem mnuStagiaire;
    }
}