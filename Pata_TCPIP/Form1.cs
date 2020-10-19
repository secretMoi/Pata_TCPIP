using System;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pata_TCPIP
{
	public partial class Form1 : Form
	{
		private Socket _serveur, _client;
		private int _socketFlag; // 1 pour le serveur, 2 client
		private byte[] _buffer = new byte[256];

		public Form1()
		{
			InitializeComponent();
		}

		private void menuUtilitaireVerifier_Click(object sender, EventArgs e)
		{
			if (textBoxServeur.Text.Length > 0)
			{
				IPAddress ipServeur = AdresseValide(textBoxServeur.Text);

				if (ipServeur != null)
					MessageBox.Show(@"Ping réussi");
				else
					MessageBox.Show(@"Pas de ping");
			}
			else
				MessageBox.Show(@"Veuillez entrez un serveur !");
		}

		/**
		 * <summary>Récupère la première adresse IPv4 valide</summary>
		 */
		private IPAddress AdresseValide(string nomPc)
		{
			IPAddress ipReponse = null;

			if (nomPc.Length > 0)
			{
				IPAddress[] ipServeur = Dns.GetHostEntry(nomPc).AddressList;

				for (int i = 0; i < ipServeur.Length; i++)
				{
					Ping pingServeur = new Ping();
					PingReply pingReponse = pingServeur.Send(ipServeur[i]);

					if (pingReponse != null && pingReponse.Status == IPStatus.Success)
					{
						if (ipServeur[i].AddressFamily == AddressFamily.InterNetwork) // si addresse ipv4
						{
							ipReponse = ipServeur[i];

							break;
						}
					}
				}
			}

			return ipReponse;
		}

		private void menuQuitter_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void menuCommunicationClientEcouter_Click(object sender, EventArgs e)
		{
			menuCommunicationClientEcouter.Enabled = false;

			IPAddress ipLocal = AdresseValide(Dns.GetHostName()); // récupère l'adresse du serveur

			TcpListener listenerServeur = new TcpListener(ipLocal, 8000); // config du serveur (son ip et son port)
			listenerServeur.Start(); // attente en bloquant

			TcpClient client = listenerServeur.AcceptTcpClient(); // accepte une connexion client
			NetworkStream flux = client.GetStream(); // récupère le flux du client

			BinaryWriter binaryWriter = new BinaryWriter(flux); // crée la réponse du serveur
			binaryWriter.Write(@"Connexion initialisée"); // écrit la réponse

			BinaryReader binaryReader = new BinaryReader(flux); // lit la réponse du client
			listBoxEchange.Items.Add( binaryReader.ReadString()); // récupère ce qui est envoyé par le client

			binaryWriter.Write(@"Ordre de déconnexion"); // indique que le serveur va fermer la connexion

			listBoxEchange.Items.Add(binaryReader.ReadString()); // récupère la réponse du client

			// ferme les connexions
			client.Close();
			listenerServeur.Stop();

			menuCommunicationClientEcouter.Enabled = true;
		}

		private void menuCommunicationClientConnecter_Click(object sender, EventArgs e)
		{
			menuCommunicationClientEcouter.Enabled = false;

			IPAddress ipServeur = AdresseValide(textBoxServeur.Text); // récupération de l'ip du serveur
			TcpClient client = new TcpClient(); // création du client

			client.Connect(ipServeur, 8000); // connexion au serveur

			NetworkStream flux = client.GetStream();
			BinaryReader binaryReader = new BinaryReader(flux); // récupère le flux du serveur
			listBoxEchange.Items.Add(binaryReader.ReadString()); // lit ce flux

			BinaryWriter binaryWriter = new BinaryWriter(flux); // crée la réponse au serveur
			binaryWriter.Write(@"Machine " + AdresseValide(Dns.GetHostName()) + " connectée"); // écrit la réponse indiquant qui est le client
			listBoxEchange.Items.Add(binaryReader.ReadString()); // lit ce flux

			binaryWriter.Write(@"Déconnexion effectuée"); // indique que le sclient s'est bien déconnecté

			client.Close();

			menuCommunicationClientEcouter.Enabled = true;
		}

		private async void menuCommunicationUdpEcouter_Click(object sender, EventArgs e)
		{
			await ServeurAsync();
		}

		private Task ServeurAsync()
		{
			return Task.Run(ExecuteServer);
		}

		private void ExecuteServer()
		{
			// création serveur
			IPAddress ipLocal = AdresseValide(Dns.GetHostName()); // récupère l'adresse du serveur
			IPEndPoint ipEndPoint = new IPEndPoint(ipLocal, 8000);

			UpdateUI("Attente de clients...");

			UdpClient serveur = new UdpClient(ipEndPoint); // config du serveur (son ip et son port)

			// réception données
			IPEndPoint client = new IPEndPoint(IPAddress.Any, 0);
			var data = serveur.Receive(ref client);
			UpdateUI("Message : " + Encoding.ASCII.GetString(data));

			// envoie réponse
			UpdateUI("Envoie du message : Bienvenue sur le serveur");
			data = Encoding.ASCII.GetBytes("Bienvenue sur le serveur");
			serveur.Send(data, data.Length, client);

			UpdateUI("Fermeture du serveur");

			// fermeture
			serveur.Close();
		}

		private void UpdateUI(string text)
		{
			if (InvokeRequired) // permet de lancer cette méthode via un autre thread
			{
				BeginInvoke((MethodInvoker)delegate
				{
					UpdateUI(text);
				});
				return;
			}

			listBoxEchange.Items.Add(text);
		}

		private void menuCommunicationUdpConnecter_Click(object sender, EventArgs e)
		{
			// This constructor arbitrarily assigns the local port number.
			UdpClient udpClient = new UdpClient(6000);
			try
			{
				listBoxEchange.Items.Add("Connexion au serveur...");
				IPAddress ipLocal = AdresseValide(Dns.GetHostName()); // récupère l'adresse du serveur
				udpClient.Connect(ipLocal, 8000);

				// Sends a message to the host to which you have connected.
				listBoxEchange.Items.Add("Envoie du message : Coucou serveur");
				var sendBytes = Encoding.ASCII.GetBytes("Coucou serveur");
				udpClient.Send(sendBytes, sendBytes.Length);

				//IPEndPoint object will allow us to read datagrams sent from any source.
				IPEndPoint serveur = new IPEndPoint(IPAddress.Any, 0);

				// Blocks until a message returns on this socket from a remote host.
				Byte[] receiveBytes = udpClient.Receive(ref serveur);
				string returnData = Encoding.ASCII.GetString(receiveBytes);
				listBoxEchange.Items.Add("Réception du message : " + returnData);

				listBoxEchange.Items.Add("Fermeture de la connexion");
				udpClient.Close();
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception.ToString());
			}
		}

		private void menuCommunicationSocketEcouter_Click(object sender, EventArgs e)
		{
			menuCommunicationSocketEcouter.Enabled = false; // désactive le menu
			menuCommunicationSocketDeconnecter.Enabled = true; // permet de se déconnecter

			_socketFlag = 1;
			_client = null; // reset le client
			IPAddress ipServeur = AdresseValide(Dns.GetHostName()); // traduit le nom du pc en ip

			// socket ipv4, flux en tcp
			_serveur = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			_serveur.Bind(new IPEndPoint(ipServeur, 8000)); // associe le socket à notre ip et au port
			_serveur.Listen(1); // accepte au plus 1 client
			_serveur.BeginAccept(OnConnectionDemand, _serveur); // fonction à exécuter lors d'une connexion sur ce serveur
		}

		private void OnConnectionDemand(IAsyncResult asyncResult)
		{
			if(_socketFlag != 1) return; // si ce n'est pas le serveur

			Socket temp = (Socket) asyncResult.AsyncState;

			_client = temp.EndAccept(asyncResult); // accepte la connexion
			_client.Send(Encoding.Unicode.GetBytes("Connexion acceptée"));

			UpdateUI("Connexion effectuée par " + ((IPEndPoint) _client.RemoteEndPoint).Address);

			InitReception(_client);
		}

		private void InitReception(Socket socket)
		{
			_buffer = new byte[256];
			// recoit dans le buffer de l'emplacement 0 à sa longueur sans flag particulier, reception traitera ce socket
			socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, Reception, socket);
		}

		private void Reception(IAsyncResult asyncResult)
		{
			if (_socketFlag < 1) return; // si le flag est bien défini

			Socket temp = (Socket)asyncResult.AsyncState;
			int recu = temp.EndReceive(asyncResult); // retourne le nombre d'octets recus

			if (recu > 0)
			{
				UpdateUI(Encoding.Unicode.GetString(_buffer));
				InitReception(temp); // prépare la prochaine réception de message
			}
			else
			{
				temp.Disconnect(true); // déconnecte le socket
				temp.Close(); // ferme la connexion
				_serveur.BeginAccept(OnConnectionDemand, _serveur); // attend une nouvelle connexion
				_client = null; // reset le client
			}
		}

		private void menuCommunicationSocketConnecter_Click(object sender, EventArgs e)
		{
			if (textBoxServeur.Text.Length < 1)
			{
				MessageBox.Show(@"Renseigner le serveur");
				return;
			}

			menuCommunicationSocketConnecter.Enabled = false; // désactive le menu
			menuCommunicationSocketDeconnecter.Enabled = true; // permet de se déconnecter

			_socketFlag = 2;
			// socket ipv4, flux en tcp
			_client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			_client.Blocking = false; // empêche le socket de bloquer le thread
			IPAddress serveur = AdresseValide(textBoxServeur.Text); // récupère l'ip du serveur

			// établit au connexion au serveur et call back sur OnConnection
			_client.BeginConnect(new IPEndPoint(serveur, 8000), OnConnection, _client);
		}

		private void OnConnection(IAsyncResult asyncResult)
		{
			Socket temp = (Socket)asyncResult.AsyncState; // récupère le socket

			if (temp.Connected) // si la connexion a bien été établie
				InitReception(temp);
			else
				MessageBox.Show(@"Serveur inaccessible");
		}

		private void menuCommunicationSocketDeconnecter_Click(object sender, EventArgs e)
		{
			if (_socketFlag == 2) // si c'est le client
			{
				_client.Send(Encoding.Unicode.GetBytes("Déconnexion client"));

				_client.Shutdown(SocketShutdown.Both); // ferme la connexion du client ET du serveur

				// réinit les données
				_socketFlag = 0;
				menuCommunicationSocketConnecter.Enabled = true; // active le menu
				menuCommunicationSocketDeconnecter.Enabled = false; // permet de se déconnecter

				// demande de se déconnecter via la méthode callback OnDemandeDeconnect
				_client.BeginDisconnect(false, OnDemandeDeconnect, _client);
			}
			else if (_client == null) // si c'est le serveur
			{
				_serveur.Close();

				// réinit les données
				_socketFlag = 0;
				menuCommunicationSocketEcouter.Enabled = true; // active le menu
				menuCommunicationSocketDeconnecter.Enabled = false; // permet de se déconnecter
			}
			else
				MessageBox.Show(@"Client connecté = pas de déconnexion");
		}

		private void OnDemandeDeconnect(IAsyncResult asyncResult)
		{
			Socket temp = (Socket) asyncResult.AsyncState; // récupère le socket
			temp.EndDisconnect(asyncResult); // termine la déconnexion
		}

		private void buttonEnvoyer_Click(object sender, EventArgs e)
		{
			// envoie le message écrit
			_client.Send(Encoding.Unicode.GetBytes(textBoxMessage.Text));
		}
	}
}
