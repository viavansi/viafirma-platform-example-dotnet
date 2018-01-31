<%@ Page Language="C#"  %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    protected void FirmarButton_Click(object sender, EventArgs e)
    {
        string idFirma = (String)Session["multi"];
        Viafirma.ViafirmaClientFactory.GetInstance().Sign(idFirma);
        
        
    }


    protected void DownloadDoc_Click(object sender, EventArgs e)
    {
        // The file path to download.
        // The file name used to save the file to the client's system..
        System.IO.Stream stream = null;
        Viafirma.ViafirmaClient clienteViafirma = Viafirma.ViafirmaClientFactory.GetInstance();
        String id = ((Viafirma.FirmaInfoViafirma)Session["resultadoFirma"]).SignId;
        if (id.Contains(";"))
        {
            //En este ejemplo si la firma es en bucle, nos quedamos solo con el primer id firma
            id = id.Split(';')[0];
        }
        byte[] documento = clienteViafirma.getDocumentoCustodiado(id);

        try
        {
            // Open the file into a stream. 
            stream = new System.IO.MemoryStream(documento);
            // Total bytes to read: 
            long bytesToRead = stream.Length;
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + "documento" + Session["extension"]);
            Response.Buffer = true;
            ((System.IO.MemoryStream)stream).WriteTo(Response.OutputStream);
            Response.End();
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
</script>

<html>
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
		<title>Viafirma - Examples</title>
		
		<link rel="stylesheet" href="css/framework.css" type="text/css" media="screen" />
		<link rel="stylesheet" href="css/styles.css" type="text/css" media="screen" />
	</head>
	<body>
		<div id="wrapper">
			<h1 id="header"><a href="/"><img src="images/content/logo.png" alt="Viafirma" /></a></h1>
			
			<div id="content">	
				<h2>Resultado del proceso de firma</h2>

				<p><strong>Sellado de tiempo:</strong><%=  ( (Viafirma.FirmaInfoViafirma) Session["resultadoFirma"]).SignTimeStamp %></p>
				<p><strong>Codigo de firma:</strong><%=  ( (Viafirma.FirmaInfoViafirma) Session["resultadoFirma"]).SignId %></p>
					
					
					<table>
							<tr><td>First Name</td><td><%=((Viafirma.UsuarioGenericoViafirma)Session["resultadoFirma"]).FirstName%></td></tr>
							<tr><td>Last Name</td><td><%=((Viafirma.UsuarioGenericoViafirma)Session["resultadoFirma"]).LastName%></td></tr>
							<tr><td>Number User Id</td><td><%=  ((Viafirma.UsuarioGenericoViafirma)Session["resultadoFirma"]).NumberUserId%></td></tr>
							<tr><td>E-mail</td><td><%=  ((Viafirma.UsuarioGenericoViafirma)Session["resultadoFirma"]).Email%></td></tr>
							<tr><td>Ca Name</td><td><%=  ((Viafirma.UsuarioGenericoViafirma)Session["resultadoFirma"]).CaName%></td></tr>
						<!--<tr><td>Oids</td><td></td></tr>-->
							<tr><td>Type Certificate</td><td><%=  ((Viafirma.UsuarioGenericoViafirma)Session["resultadoFirma"]).TypeCertificate%></td></tr>
							<tr><td>Type Legal</td><td><%=  ((Viafirma.UsuarioGenericoViafirma)Session["resultadoFirma"]).TypeLegal%></td></tr>
					</table>
				
				<p>Properties:</p>
				    <table>
					<%
                        Viafirma.UsuarioGenericoViafirma usuario = (Viafirma.UsuarioGenericoViafirma)Session["resultadoFirma"];
			            foreach( string key in usuario.Properties.Keys){
                            %><tr> <td><%=key%></td> <td><%=usuario.Properties[key]%></td></tr><%
                        }
					  %>
					</table>
				
				<%
					if(Session["idMultifirma"]!=null){
						String idMultifirma = (String)Session["idMultifirma"];
						Session.Remove("idMultifirma");                        
				%>	
    			<p>
					Para volver a firmar este fichero siga este enlace:
					<a href="firmaUser/multisignatureXML.aspx?firmar&&idMultifirma=<%=idMultifirma %>" title="Volver a firmar con otro firmante">Volver a firmar el fichero con otro firmante</a>
				</p>
				<%
					}	
				%>	
		        <form id="form1" runat="server">
                    <p><asp:Button ID="Button1" runat="server" onclick="DownloadDoc_Click" 
                        Text="Descargar documento firmado" />
                    </p>
                </form>
				<p>
				    <a href="./">&larr; Volver</a>
				</p>
			</div>
			<div id="footer">
				<p class="left">
					Acceda a <a href="http://www.viafirma.com">Viafirma</a> o consulte más información técnica en <a href="http://developers.viafirma.com/">Viafirma Developers</a> 
				</p>
				<p>
					Versión 2.9.60
				</p>
			</div>
		</div>
	</body>
</html>
