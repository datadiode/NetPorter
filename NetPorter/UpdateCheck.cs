using System;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;

// --- Anwendungshinweise ---
//
// Ein ganz einfacher Aufruf dieser Klasse sieht wie folgt aus und kann z.B. beim
// Programmstart oder beim Klicken auf eine Schaltfläche oder einen Menübefehl
// stattfinden:
//
//   UpdateCheck.Check("http://beta.unclassified.de/code/dotnet/updatecheck/update.xml");
//
// Stattdessen sind auch komplexere Anwendungen möglich, bei denen zuerst das Objekt
// erstellt und anschließend gezielt auf Methoden und Eigenschaften zugegriffen wird:
//
//   UpdateCheck uc = new UpdateCheck(myUrl);
//   if (uc.NewerAvailable) doSomething();
//
// Die aktuelle Version des eigenen Programms kann in der Datei AssemblyInfo.cs wie
// folgt festgelegt werden: (eine ähnliche Zeile ist dort bereits vorhanden)
//
//   [assembly: AssemblyVersion("2006.4.24.11")]

namespace NetPorter
{
	/// <summary>
	/// Prüft anhand einer Web-XML-Ressource, ob Updates zu einer Anwendung existieren.
	/// </summary>
	public class UpdateCheck
	{
		private string xmlUri = "";
		private WebClient myWebClient = null;
		private XmlDocument xdoc = null;
		private bool acceptTesting = false;

		// Deutsche Meldungen
		//private const string msgErrorLoadingXml = "Fehler beim Laden der XML-Ressource.";
		//private const string msgXmlIncomplete = "XML-Ressource ist unvollständig.";
		//private const string msgInvalidWebsite = "Ungültige Webseite: ";
		//private const string msgVersionIsUpToDate = "Diese Version ist bereits aktuell.";
		//private const string msgVersionCheckTitle = "Versionsprüfung";
		//private const string msgErrorChecking = "Beim Prüfen der Programmversion ist ein Fehler aufgetreten.";
		//private const string msgVersionAlert = "Versionshinweis";

		// English messages
		private const string msgErrorLoadingXml = "Error loading the XML resource.";
		private const string msgXmlIncomplete = "XML resource is incomplete.";
		private const string msgInvalidWebsite = "Invalid website: ";
		private const string msgVersionIsUpToDate = "This version is already up-to-date.";
		private const string msgVersionCheckTitle = "Version check";
		private const string msgErrorChecking = "An error occured while checking the programme version.";
		private const string msgVersionAlert = "Version alert";

		/// <summary>
		/// Gibt die Web-Adresse der XML-Ressource an.
		/// </summary>
		public string XmlUri
		{
			get
			{
				return xmlUri;
			}
		}

		/// <summary>
		/// Gibt an oder legt fest, ob auch Testversionen akzeptiert werden. (Vorgabe: false)
		/// </summary>
		public bool AcceptTesting
		{
			get
			{
				return acceptTesting;
			}
			set
			{
				acceptTesting = value;
			}
		}

		private bool Loaded
		{
			get
			{
				return xdoc != null;
			}
		}

		/// <summary>
		/// Initialisiert das Objekt mit einer Web-Adresse der XML-Ressource.
		/// </summary>
		/// <param name="xmlUri"></param>
		public UpdateCheck(string xmlUri)
		{
			this.xmlUri = xmlUri;
			myWebClient = new WebClient();
			Load();
		}

		private void Load()
		{
			byte[] bytes = myWebClient.DownloadData(xmlUri);
			string xml;
			int codepage;
			int offset = 0;
			if (bytes[0] == 0xEF && bytes[1] == 0xBB && bytes[2] == 0xBF)
			{
				codepage = 65001;   // UTF-8
				offset = 3;
			}
			else if (bytes[0] == 0xFF && bytes[1] == 0xFE)
			{
				codepage = 1200;   // UTF-16LE
				offset = 2;
			}
			else if (bytes[0] == 0xFE && bytes[1] == 0xFF)
			{
				codepage = 1201;   // UTF-16BE
				offset = 2;
			}
			else
			{
				codepage = 28591;   // ISO-8859-1
			}
			xml = Encoding.GetEncoding(codepage).GetString(bytes, offset, bytes.Length - offset);

			xdoc = new XmlDocument();
			try
			{
				xdoc.LoadXml(xml);
			}
			catch (XmlException ex)
			{
				xdoc = null;
				throw new ApplicationException(msgErrorLoadingXml, ex);
			}

			if (xdoc.DocumentElement == null)
			{
				xdoc = null;
				throw new ApplicationException(msgXmlIncomplete);
			}
		}

		/// <summary>
		/// Gibt den Anwendungsnamen aus der XML-Ressource an.
		/// </summary>
		public string AppName
		{
			get
			{
				if (xdoc == null || xdoc.DocumentElement == null) return "";
				XmlNode appNode = xdoc.DocumentElement.SelectSingleNode("appname");
				if (appNode == null) return "";
				return appNode.InnerText;
			}
		}

		/// <summary>
		/// Gibt die aktuellste Programmversion an. Abhängig von AcceptTesting.
		/// </summary>
		public string LatestVersion
		{
			get
			{
				if (xdoc == null || xdoc.DocumentElement == null) return "";
				string path = acceptTesting ? "testing" : "latest";
				XmlNode latestNode = xdoc.DocumentElement.SelectSingleNode("versions/" + path);
				if (latestNode == null && acceptTesting)
				{
					path = "latest";
					latestNode = xdoc.DocumentElement.SelectSingleNode("versions/" + path);
				}
				if (latestNode == null) return "";
				return latestNode.InnerText;
			}
		}

		/// <summary>
		/// Gibt an, ob eine neuere Programmversion verfügbar ist.
		/// </summary>
		public bool NewerAvailable
		{
			get
			{
				Assembly me = Assembly.GetCallingAssembly();
				//MessageBox.Show(me.GetName().Version.ToString());
				//MessageBox.Show(new Version(LatestVersion).ToString());
				return me.GetName().Version.CompareTo(new Version(LatestVersion)) < 0;
			}
		}

		/// <summary>
		/// Gibt die Webseite aus der XML-Ressource an.
		/// </summary>
		public string Website
		{
			get
			{
				if (xdoc == null || xdoc.DocumentElement == null) return "";
				XmlNode websiteNode = xdoc.DocumentElement.SelectSingleNode("website");
				if (websiteNode == null) return "";
				return websiteNode.InnerText;
			}
		}

		/// <summary>
		/// Öffnet die angegebene Webseite.
		/// </summary>
		public void OpenWebsite()
		{
			string uri = Website;
			if (uri.StartsWith("http://") || uri.StartsWith("https://"))
				Process.Start(uri);
			else
				throw new ApplicationException(msgInvalidWebsite + uri);
		}

		/// <summary>
		/// Öffnet die angegebene Webseite, falls eine neuere Programmversion verfügbar ist, und zeigt sonst eine einfache Meldung an.
		/// </summary>
		public void OpenWebsiteIfNewer()
		{
			if (NewerAvailable)
				OpenWebsite();
			else
				MessageBox.Show(msgVersionIsUpToDate,
					msgVersionCheckTitle,
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);
		}

		/// <summary>
		/// Öffnet die angegebene Webseite, siehe OpenWebsiteIfNewer. Behandelt Exceptions.
		/// </summary>
		public void SafeOpenWebsiteIfNewer()
		{
			try
			{
				OpenWebsiteIfNewer();
			}
			catch (Exception ex)
			{
				MessageBox.Show(msgErrorChecking + "\n\n" + ex.Message,
					msgVersionCheckTitle,
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// Gibt eine Warnmeldung an.
		/// </summary>
		public string Alert
		{
			get
			{
				if (xdoc == null || xdoc.DocumentElement == null) return "";
				XmlNode alertNode = xdoc.DocumentElement.SelectSingleNode("alert");
				if (alertNode == null) return "";
				string alert = alertNode.InnerText;
				return alert;
			}
		}

		/// <summary>
		/// Zeigt die Warnmeldung an, falls sie vorhanden ist.
		/// </summary>
		public void ShowAlert()
		{
			string alert = Alert;
			if (alert != "")
				MessageBox.Show(alert,
					msgVersionAlert,
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
		}

		/// <summary>
		/// Zeigt die Warnmeldung an, falls sie vorhanden ist. Behandelt Exceptions.
		/// </summary>
		public void SafeShowAlert()
		{
			try
			{
				ShowAlert();
			}
			catch (Exception ex)
			{
				MessageBox.Show(msgErrorChecking + "\n\n" + ex.Message,
					msgVersionCheckTitle,
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// Führt die Versionsprüfung durch, zeige Warnungen an und öffnet ggf. die Webseite
		/// </summary>
		/// <param name="uri">Web-Adresse der XML-Ressource</param>
		public static void Check(string uri)
		{
			try
			{
				UpdateCheck uc = new UpdateCheck(uri);
				uc.SafeShowAlert();
				uc.SafeOpenWebsiteIfNewer();
			}
			catch (Exception ex)
			{
				MessageBox.Show(msgErrorChecking + "\n\n" + ex.Message,
					msgVersionCheckTitle,
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}
	}
}





