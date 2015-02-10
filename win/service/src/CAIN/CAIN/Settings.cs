using System;
using System.Collections.Generic;

namespace CAIN
{
    /// <summary>
    /// Clase para el manejo del fichero de configuración.
    /// </summary>
    public class Settings
    {
        /// <summary>
        ///    Atributo que almacena la clave de registro para usar la API de AcoustID.
        /// </summary>
        public string AcoustIDApiKey { get; set; }

        /// <summary>
        ///    Atributo que almacena el email de registro para usar la API de Bass.Net.
        /// </summary>
        public string BassNetEmail { get; set; }

        /// <summary>
        ///    Atributo que almacena la clave de registro para usar la API de Bass.Net.
        /// </summary>
        public string BassNetApiKey { get; set; }

        /// <summary>
        ///    Atributo que almacena las rutas de las carpetas a escanear.
        /// </summary>
        public List<string> FolderPaths { get; set; }

        /// <summary>
        ///    Comprueba si la instancia del objeto <see cref="Settings" /> es válida.
        /// </summary>
        /// <returns>
        ///    True, si es válido. False, si no.
        /// </returns>
        public bool IsValid()
        {
            if (String.IsNullOrEmpty(this.AcoustIDApiKey) ||
                String.IsNullOrEmpty(this.BassNetEmail) ||
                String.IsNullOrEmpty(this.BassNetApiKey) ||
                this.FolderPaths.Count == 0)
                return false;
            else
                return true;
        }
        
        /// <summary>
        ///    Carga el fichero de configuración.
        /// </summary>
        /// <param name="file">
        ///    <see cref="string" /> que contiene el nombre del fichero.
        /// </param>
        /// <returns>
        ///    Una instancia del objeto <see cref="Settings" />.
        /// </returns>
        public static Settings Load(string file)
        {
            Settings settings = new Settings();

            if (!System.IO.File.Exists(file)) return settings;

            using (System.IO.StreamReader ini = System.IO.File.OpenText(file))
            {
                Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                settings = (Settings) serializer.Deserialize(ini, typeof(Settings));
            }

            return settings;
        }

        /// <summary>
        ///    Constructor.
        /// </summary>
        private Settings()
        {
            this.AcoustIDApiKey = String.Empty;
            this.BassNetEmail = String.Empty;
            this.BassNetApiKey = String.Empty;
            this.FolderPaths = new List<string>();
        }
    }
}
