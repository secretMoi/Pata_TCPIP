namespace Pata_TCPIP
{
	partial class Form1
	{
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		/// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Code généré par le Concepteur Windows Form

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.menuCommunication = new System.Windows.Forms.ToolStripMenuItem();
			this.menuCommunicationClient = new System.Windows.Forms.ToolStripMenuItem();
			this.menuCommunicationClientEcouter = new System.Windows.Forms.ToolStripMenuItem();
			this.menuCommunicationClientConnecter = new System.Windows.Forms.ToolStripMenuItem();
			this.menuCommunicationUdp = new System.Windows.Forms.ToolStripMenuItem();
			this.menuCommunicationUdpEcouter = new System.Windows.Forms.ToolStripMenuItem();
			this.menuCommunicationUdpConnecter = new System.Windows.Forms.ToolStripMenuItem();
			this.menuCommunicationSocket = new System.Windows.Forms.ToolStripMenuItem();
			this.menuCommunicationSocketEcouter = new System.Windows.Forms.ToolStripMenuItem();
			this.menuCommunicationSocketConnecter = new System.Windows.Forms.ToolStripMenuItem();
			this.menuCommunicationSocketDeconnecter = new System.Windows.Forms.ToolStripMenuItem();
			this.menuUtilitaire = new System.Windows.Forms.ToolStripMenuItem();
			this.menuUtilitaireVerifier = new System.Windows.Forms.ToolStripMenuItem();
			this.menuQuitter = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.labelServeur = new System.Windows.Forms.Label();
			this.textBoxServeur = new System.Windows.Forms.TextBox();
			this.textBoxMessage = new System.Windows.Forms.TextBox();
			this.labelMessage = new System.Windows.Forms.Label();
			this.buttonEnvoyer = new System.Windows.Forms.Button();
			this.labelEchange = new System.Windows.Forms.Label();
			this.listBoxEchange = new System.Windows.Forms.ListBox();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCommunication,
            this.menuUtilitaire,
            this.menuQuitter});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(415, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// menuCommunication
			// 
			this.menuCommunication.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCommunicationClient,
            this.menuCommunicationUdp,
            this.menuCommunicationSocket});
			this.menuCommunication.Name = "menuCommunication";
			this.menuCommunication.Size = new System.Drawing.Size(106, 20);
			this.menuCommunication.Text = "Communication";
			// 
			// menuCommunicationClient
			// 
			this.menuCommunicationClient.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCommunicationClientEcouter,
            this.menuCommunicationClientConnecter});
			this.menuCommunicationClient.Name = "menuCommunicationClient";
			this.menuCommunicationClient.Size = new System.Drawing.Size(180, 22);
			this.menuCommunicationClient.Text = "Listener / Client";
			// 
			// menuCommunicationClientEcouter
			// 
			this.menuCommunicationClientEcouter.Name = "menuCommunicationClientEcouter";
			this.menuCommunicationClientEcouter.Size = new System.Drawing.Size(129, 22);
			this.menuCommunicationClientEcouter.Text = "Ecouter";
			this.menuCommunicationClientEcouter.Click += new System.EventHandler(this.menuCommunicationClientEcouter_Click);
			// 
			// menuCommunicationClientConnecter
			// 
			this.menuCommunicationClientConnecter.Name = "menuCommunicationClientConnecter";
			this.menuCommunicationClientConnecter.Size = new System.Drawing.Size(129, 22);
			this.menuCommunicationClientConnecter.Text = "Connecter";
			this.menuCommunicationClientConnecter.Click += new System.EventHandler(this.menuCommunicationClientConnecter_Click);
			// 
			// menuCommunicationUdp
			// 
			this.menuCommunicationUdp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCommunicationUdpEcouter,
            this.menuCommunicationUdpConnecter});
			this.menuCommunicationUdp.Name = "menuCommunicationUdp";
			this.menuCommunicationUdp.Size = new System.Drawing.Size(180, 22);
			this.menuCommunicationUdp.Text = "UDP";
			// 
			// menuCommunicationUdpEcouter
			// 
			this.menuCommunicationUdpEcouter.Name = "menuCommunicationUdpEcouter";
			this.menuCommunicationUdpEcouter.Size = new System.Drawing.Size(129, 22);
			this.menuCommunicationUdpEcouter.Text = "Ecouter";
			this.menuCommunicationUdpEcouter.Click += new System.EventHandler(this.menuCommunicationUdpEcouter_Click);
			// 
			// menuCommunicationUdpConnecter
			// 
			this.menuCommunicationUdpConnecter.Name = "menuCommunicationUdpConnecter";
			this.menuCommunicationUdpConnecter.Size = new System.Drawing.Size(129, 22);
			this.menuCommunicationUdpConnecter.Text = "Connecter";
			this.menuCommunicationUdpConnecter.Click += new System.EventHandler(this.menuCommunicationUdpConnecter_Click);
			// 
			// menuCommunicationSocket
			// 
			this.menuCommunicationSocket.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCommunicationSocketEcouter,
            this.menuCommunicationSocketConnecter,
            this.menuCommunicationSocketDeconnecter});
			this.menuCommunicationSocket.Name = "menuCommunicationSocket";
			this.menuCommunicationSocket.Size = new System.Drawing.Size(180, 22);
			this.menuCommunicationSocket.Text = "Socket";
			// 
			// menuCommunicationSocketEcouter
			// 
			this.menuCommunicationSocketEcouter.Name = "menuCommunicationSocketEcouter";
			this.menuCommunicationSocketEcouter.Size = new System.Drawing.Size(180, 22);
			this.menuCommunicationSocketEcouter.Text = "Ecouter";
			this.menuCommunicationSocketEcouter.Click += new System.EventHandler(this.menuCommunicationSocketEcouter_Click);
			// 
			// menuCommunicationSocketConnecter
			// 
			this.menuCommunicationSocketConnecter.Name = "menuCommunicationSocketConnecter";
			this.menuCommunicationSocketConnecter.Size = new System.Drawing.Size(180, 22);
			this.menuCommunicationSocketConnecter.Text = "Connecter";
			this.menuCommunicationSocketConnecter.Click += new System.EventHandler(this.menuCommunicationSocketConnecter_Click);
			// 
			// menuCommunicationSocketDeconnecter
			// 
			this.menuCommunicationSocketDeconnecter.Enabled = false;
			this.menuCommunicationSocketDeconnecter.Name = "menuCommunicationSocketDeconnecter";
			this.menuCommunicationSocketDeconnecter.Size = new System.Drawing.Size(180, 22);
			this.menuCommunicationSocketDeconnecter.Text = "Déconnecter";
			this.menuCommunicationSocketDeconnecter.Click += new System.EventHandler(this.menuCommunicationSocketDeconnecter_Click);
			// 
			// menuUtilitaire
			// 
			this.menuUtilitaire.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUtilitaireVerifier});
			this.menuUtilitaire.Name = "menuUtilitaire";
			this.menuUtilitaire.Size = new System.Drawing.Size(63, 20);
			this.menuUtilitaire.Text = "Utilitaire";
			// 
			// menuUtilitaireVerifier
			// 
			this.menuUtilitaireVerifier.Name = "menuUtilitaireVerifier";
			this.menuUtilitaireVerifier.Size = new System.Drawing.Size(110, 22);
			this.menuUtilitaireVerifier.Text = "Vérifier";
			this.menuUtilitaireVerifier.Click += new System.EventHandler(this.menuUtilitaireVerifier_Click);
			// 
			// menuQuitter
			// 
			this.menuQuitter.Name = "menuQuitter";
			this.menuQuitter.Size = new System.Drawing.Size(56, 20);
			this.menuQuitter.Text = "Quitter";
			this.menuQuitter.Click += new System.EventHandler(this.menuQuitter_Click);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
			// 
			// labelServeur
			// 
			this.labelServeur.AutoSize = true;
			this.labelServeur.Location = new System.Drawing.Point(12, 24);
			this.labelServeur.Name = "labelServeur";
			this.labelServeur.Size = new System.Drawing.Size(44, 13);
			this.labelServeur.TabIndex = 2;
			this.labelServeur.Text = "Serveur";
			// 
			// textBoxServeur
			// 
			this.textBoxServeur.Location = new System.Drawing.Point(15, 40);
			this.textBoxServeur.Name = "textBoxServeur";
			this.textBoxServeur.Size = new System.Drawing.Size(388, 20);
			this.textBoxServeur.TabIndex = 3;
			this.textBoxServeur.Text = "3700X";
			// 
			// textBoxMessage
			// 
			this.textBoxMessage.Location = new System.Drawing.Point(15, 97);
			this.textBoxMessage.Name = "textBoxMessage";
			this.textBoxMessage.Size = new System.Drawing.Size(388, 20);
			this.textBoxMessage.TabIndex = 5;
			// 
			// labelMessage
			// 
			this.labelMessage.AutoSize = true;
			this.labelMessage.Location = new System.Drawing.Point(12, 81);
			this.labelMessage.Name = "labelMessage";
			this.labelMessage.Size = new System.Drawing.Size(50, 13);
			this.labelMessage.TabIndex = 4;
			this.labelMessage.Text = "Message";
			// 
			// buttonEnvoyer
			// 
			this.buttonEnvoyer.Location = new System.Drawing.Point(15, 138);
			this.buttonEnvoyer.Name = "buttonEnvoyer";
			this.buttonEnvoyer.Size = new System.Drawing.Size(388, 38);
			this.buttonEnvoyer.TabIndex = 6;
			this.buttonEnvoyer.Text = "Envoyer";
			this.buttonEnvoyer.UseVisualStyleBackColor = true;
			this.buttonEnvoyer.Click += new System.EventHandler(this.buttonEnvoyer_Click);
			// 
			// labelEchange
			// 
			this.labelEchange.AutoSize = true;
			this.labelEchange.Location = new System.Drawing.Point(12, 200);
			this.labelEchange.Name = "labelEchange";
			this.labelEchange.Size = new System.Drawing.Size(55, 13);
			this.labelEchange.TabIndex = 7;
			this.labelEchange.Text = "Echanges";
			// 
			// listBoxEchange
			// 
			this.listBoxEchange.FormattingEnabled = true;
			this.listBoxEchange.Location = new System.Drawing.Point(15, 216);
			this.listBoxEchange.Name = "listBoxEchange";
			this.listBoxEchange.Size = new System.Drawing.Size(388, 225);
			this.listBoxEchange.TabIndex = 8;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(415, 450);
			this.Controls.Add(this.listBoxEchange);
			this.Controls.Add(this.labelEchange);
			this.Controls.Add(this.buttonEnvoyer);
			this.Controls.Add(this.textBoxMessage);
			this.Controls.Add(this.labelMessage);
			this.Controls.Add(this.textBoxServeur);
			this.Controls.Add(this.labelServeur);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.Text = "TCP/IP";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem menuCommunication;
		private System.Windows.Forms.ToolStripMenuItem menuCommunicationClient;
		private System.Windows.Forms.ToolStripMenuItem menuCommunicationClientEcouter;
		private System.Windows.Forms.ToolStripMenuItem menuCommunicationClientConnecter;
		private System.Windows.Forms.ToolStripMenuItem menuCommunicationUdp;
		private System.Windows.Forms.ToolStripMenuItem menuCommunicationUdpEcouter;
		private System.Windows.Forms.ToolStripMenuItem menuCommunicationUdpConnecter;
		private System.Windows.Forms.ToolStripMenuItem menuCommunicationSocket;
		private System.Windows.Forms.ToolStripMenuItem menuCommunicationSocketEcouter;
		private System.Windows.Forms.ToolStripMenuItem menuCommunicationSocketConnecter;
		private System.Windows.Forms.ToolStripMenuItem menuCommunicationSocketDeconnecter;
		private System.Windows.Forms.ToolStripMenuItem menuUtilitaire;
		private System.Windows.Forms.ToolStripMenuItem menuUtilitaireVerifier;
		private System.Windows.Forms.ToolStripMenuItem menuQuitter;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.Label labelServeur;
		private System.Windows.Forms.TextBox textBoxServeur;
		private System.Windows.Forms.TextBox textBoxMessage;
		private System.Windows.Forms.Label labelMessage;
		private System.Windows.Forms.Button buttonEnvoyer;
		private System.Windows.Forms.Label labelEchange;
		private System.Windows.Forms.ListBox listBoxEchange;
	}
}

