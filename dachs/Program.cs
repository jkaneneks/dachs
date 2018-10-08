﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;

namespace dachs
{
    /// <summary>
    /// dachs  Programm
    /// </summary>
    class Program
    {
        #region Fields
        /// <summary>
        /// URL zur Webseite.
        /// </summary>
        const string _URL = "https://adressen.leipzig.de/";
        /// <summary>
        /// Statischer Parameter für die Abfrage.
        /// </summary>
        static string __EVENTVADILATION = "%2FwEdAAT4a%2F0VhriQbIVD9%2FbvKbrtDlSBEqzYFlt%2BcOr2YiDfOlyVpOm4%2BiOnL8lQyfdNrJtLXopOGbu3LzPW1UTL9bhKS%2BMv%2F%2By7F6VC1D3JVQ3sXhGOuJWb0beY%2BmRTiGE9bws%3D";
        /// <summary>
        /// Statischer Parameter für die Abfrage.
        /// </summary>
        static string __VIEWSTAT = "%2FwEPDwUKMTA1MzQ4MjU4NQ9kFgJmD2QWAgIBD2QWBAIFDxBkZBYAZAITDxBkZBYAZGQ8SBK%2FYB%2BUaXwCWdo0khKeMVwn0MkW9YllXaUUgCdq5Q%3D%3D";
        /// <summary>
        /// Statischer Parameter für die Abfrage.
        /// </summary>
        static string __VIEWSTATEGENERATOR = "90059987";
        /// <summary>
        /// Statischer Parameter für die Abfrage.
        /// </summary>
        static string btnFindStreet = "Suche+starten";

        /// <summary>
        /// Hausnummer.
        /// </summary>
        static string txtHnr = "";
        /// <summary>
        /// Straßenname.
        /// </summary>
        static string txtStreet = "";
        #endregion

        string cookie = "wt_cdbeid=1; wt3_sid=%3B498716889887543; wt_geid=815296688990039019590195; wt_rla=498716889887543%2C4%2C1538654274799; wt3_eid=%3B498716889887543%7C2152966889852904860%232153865497300881676";

        /// <summary>
        /// Haupteinstiegspunkt.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            foreach (string street in GetAllStreets())
            {
                Console.WriteLine(street);
            }

            Console.Write("\n\npress any key to quit..\n");
            Console.ReadKey();
        }

        public static IEnumerable<string> GetAllStreets()
        {
            try
            {
                string response = Post(_URL, new NameValueCollection() {
                    { nameof(__EVENTVADILATION), __EVENTVADILATION },
                    { nameof(__VIEWSTAT), __VIEWSTAT },
                    { nameof(__VIEWSTATEGENERATOR), __VIEWSTATEGENERATOR },
                    { nameof(btnFindStreet), btnFindStreet },
                    { nameof(txtHnr), string.Empty },
                    { nameof(txtStreet), string.Empty }
                });

                List<string> result = new List<string>();



                return result;
            }
            catch
            {

            }
            
            return null;
        }

        /// <summary>
        /// Hollt alle Hausnummern der Straße.
        /// </summary>
        /// <param name="street">Straßenname.</param>
        /// <returns>Liste aller Hausnummern.</returns>
        public static IEnumerable<string> GetAllNumbers(string street)
        {
            try
            {
                string response = Post(_URL, new NameValueCollection() {
                    { nameof(__EVENTVADILATION), __EVENTVADILATION },
                    { nameof(__VIEWSTAT), __VIEWSTAT },
                    { nameof(__VIEWSTATEGENERATOR), __VIEWSTATEGENERATOR },
                    { nameof(btnFindStreet), btnFindStreet },
                    { nameof(txtHnr), txtHnr },
                    { nameof(txtStreet), txtStreet }
                });
            }
            catch
            {

            }

            return null;
        }

        /// <summary>
        /// Abfrage vom Server.
        /// </summary>
        /// <param name="uri">URL.</param>
        /// <param name="pairs">Parameter.</param>
        /// <returns>Webseite als String.</returns>
        public static string Post(string uri, NameValueCollection pairs)
        {
            byte[] response = null;
            using (WebClient client = new WebClient())
            {
                response = client.UploadValues(uri, pairs);
            }
            return System.Text.Encoding.Default.GetString(response); ;
        }
        
    }
}
