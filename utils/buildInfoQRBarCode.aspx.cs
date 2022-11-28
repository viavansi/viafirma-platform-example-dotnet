using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.IO;
using Viafirma;
using System.Reflection;

namespace EjemploWebViafirmaClientDotNet.utils
{
    public partial class buildInfoQRBarCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void GenerarQRButton_Click(object sender, EventArgs e)
        {
            //Recuperamos la instancia del cliente
            ViafirmaClient clienteViafirma = ViafirmaClientFactory.GetInstance();

            // Recuperamos el documento a firmar.
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fs = assembly.GetManifestResourceStream(Global.DEMO_FILE_XML_PATH);
            byte[] datos_a_firmar = new byte[fs.Length];
            fs.Read(datos_a_firmar, 0, datos_a_firmar.Length);
            
            // Firmamos el documento en el servidor y nos devuelve el identificador de la firma.
            string idFirma = clienteViafirma.signByServerWithTypeFileAndFormatSign("FicheroEjemploServer.xml", datos_a_firmar, Global.ALIAS_CERT, Global.PASS_CERT, typeFile.XML, typeFormatSign.XADES_EPES_ENVELOPED);
            byte [] reciboQR = clienteViafirma.buildInfoQRBarCode(idFirma);

            System.IO.Stream stream = null;
            try
            {
                // Open the file into a stream. 
                stream = new System.IO.MemoryStream(reciboQR);
                // Total bytes to read: 
                long bytesToRead = stream.Length;
                Response.ContentType = "image/png";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + "reciboQR.png");
                // Read the bytes from the stream in small portions. 
                while (bytesToRead > 0)
                {
                    // Make sure the client is still connected. 
                    if (Response.IsClientConnected)
                    {
                        // Read the data into the buffer and write into the 
                        // output stream. 
                        byte[] buffer = new Byte[10000];
                        int length = stream.Read(buffer, 0, 10000);
                        Response.OutputStream.Write(buffer, 0, length);
                        Response.Flush();
                        // We have already read some bytes.. need to read 
                        // only the remaining. 
                        bytesToRead = bytesToRead - length;
                    }
                    else
                    {
                        // Get out of the loop, if user is not connected anymore.. 
                        bytesToRead = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                // An error occurred.. 
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
        }
    }
}
