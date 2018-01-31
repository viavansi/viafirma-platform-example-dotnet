<%@ Page Language="C#"  %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    // Al gargar la página se realiza todo el procesado para el intercambio de información con Viafirma.
    public void Page_Load(Object sender, EventArgs e)
    {
        System.Console.Write("HOLA");
    }
    
    //Metodo que se llama con el boton incluido en esta pagina para firmar 
    //un documento con un certificado previamente autenticado
    protected void SignWithFilterButton_Click(object sender, EventArgs e)
    {
        Viafirma.ViafirmaClient cliente=Viafirma.ViafirmaClientFactory.GetInstance();
        Viafirma.UsuarioGenericoViafirma usuarioGenerico = ((Viafirma.UsuarioGenericoViafirma)Session["resultadoAutenticacion"]);
        byte[] datos_a_firmar = System.Text.ASCIIEncoding.ASCII.GetBytes("Contenido del documento firmado");
        string id = cliente.PrepareFirmaWithTypeFileAndFormatSignAndFilterCertificate("FicheroEjemplo.txt", typeFile.txt, typeFormatSign.XADES_EPES_ENVELOPED, datos_a_firmar, usuarioGenerico);
        cliente.Sign(id);    
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
			<h1 id="header"><a href=""><img src="images/content/logo.png" alt="Viafirma" /></a></h1>
			
			<div id="content">	
				<h2>Resultado del proceso de autenticacion</h2>

					
					<table>
							<tr><td>First Name</td><td><%=((Viafirma.UsuarioGenericoViafirma)Session["resultadoAutenticacion"]).FirstName%></td></tr>
							<tr><td>Last Name</td><td><%=((Viafirma.UsuarioGenericoViafirma)Session["resultadoAutenticacion"]).LastName%></td></tr>
							<tr><td>Number User Id</td><td><%=  ((Viafirma.UsuarioGenericoViafirma)Session["resultadoAutenticacion"]).NumberUserId%></td></tr>
							<tr><td>E-mail</td><td><%=  ((Viafirma.UsuarioGenericoViafirma)Session["resultadoAutenticacion"]).Email%></td></tr>
							<tr><td>Ca Name</td><td><%=  ((Viafirma.UsuarioGenericoViafirma)Session["resultadoAutenticacion"]).CaName%></td></tr>
						<!--<tr><td>Oids</td><td><%=  ((Viafirma.UsuarioGenericoViafirma)Session["resultadoAutenticacion"]).Properties%></td></tr>-->
							<tr><td>Type Certificate</td><td><%=  ((Viafirma.UsuarioGenericoViafirma)Session["resultadoAutenticacion"]).TypeCertificate%></td></tr>
							<tr><td>Type Legal</td><td><%=  ((Viafirma.UsuarioGenericoViafirma)Session["resultadoAutenticacion"]).TypeLegal%></td></tr>
					</table>
					
					<p>Properties:</p>
				    <table>
					<%
                        Viafirma.UsuarioGenericoViafirma usuario = (Viafirma.UsuarioGenericoViafirma)Session["resultadoAutenticacion"];
			            foreach( string key in usuario.Properties.Keys){
                            %><tr> <td><%=key%></td> <td><%=usuario.Properties[key]%></td></tr><%
                        }
					  %>
					</table>
				
				
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