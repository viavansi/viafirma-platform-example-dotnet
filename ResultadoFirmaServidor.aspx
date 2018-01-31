<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    protected void Button1_Click(object sender, EventArgs e)
    {
        // The file path to download.
        // The file name used to save the file to the client's system..
           System.IO.Stream stream = null;
           Viafirma.ViafirmaClient clienteViafirma = Viafirma.ViafirmaClientFactory.GetInstance();
           String id = (string)Session["idFirma"];
           byte[] documento = clienteViafirma.getDocumentoCustodiado(id);
                
        try{
            // Open the file into a stream. 
            stream = new System.IO.MemoryStream(documento);
            // Total bytes to read: 
            long bytesToRead = stream.Length; 
            Response.ContentType = "application/octet-stream"; 
            Response.AddHeader( "Content-Disposition", "attachment; filename=" + "documento" ); 
            // Read the bytes from the stream in small portions. 
            while ( bytesToRead > 0 ) 
            {
            // Make sure the client is still connected. 
                if ( Response.IsClientConnected ) 
                {
                    // Read the data into the buffer and write into the 
                    // output stream. 
                    byte[] buffer = new Byte[10000]; 
                    int length = stream.Read( buffer, 0, 10000 ); 
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
        catch(Exception ex) 
        {
            Response.Write(ex.Message); 
            // An error occurred.. 
        }
        finally 
        {
            if ( stream != null ) { 
            stream.Close(); 
        }
    }
}
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<title>Ejemplo resultado firma en servidor</title>
	<style type="text/css" media="screen">
		@import url('./css/screen.css');
	</style>
	
	<!--[if IE]>
		<link rel="stylesheet" href="./css/stylesIE.css" type="text/css" media="screen" />
	<![endif]-->
	
	<!--[if lte IE 6]>
		<link rel="stylesheet" href="./css/stylesIE6.css" type="text/css" media="screen" />
	<![endif]-->
	
	<!--[if gte IE 7]>
		<link rel="stylesheet" href="./css/stylesIE7.css" type="text/css" media="screen" />
	<![endif]-->
</head>
<body>
    <form id="form1" runat="server">
<div id="global">
	<div id="cabecera">
			<h1>Resultado del acceso a Viafirma</h1>
		</div>
		
		<div id="cuerpo">
		<h2>Resultado de la Firma en Servidor.</h2>
			<p>La Firma se ha realizado correctamente. [NOTA: Esta página nunca sera vista por el usuario en una aplicación real].</p>
<p>Id firma:<%=  Session["idFirma"] %></p>
<p><asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
        Text="Descargar documento firmado" />
            </p>
	<p><a href="Default.aspx" >volver</a></p>
		</div>
</div>
<p id="pie">Aplicación de ejemplo - 2009 Viavansi. Servicios Avanzados para las Instituciones. - versión: 2.x</p>
    </form>
</body>
</html>
