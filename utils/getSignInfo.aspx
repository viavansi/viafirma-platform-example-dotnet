<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="getSignInfo.aspx.cs" Inherits="EjemploWebViafirmaClientDotNet.utils.getSignInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
		<title>Ejemplo</title>
		<style type="text/css" media="screen">
			@import url('../css/screen.css');
		</style>
	</head>
	<body>
		<div id="global">

			<div id="cabecera">	</div>
            <div id="cuerpo">
                <h1>
                    Métodos de utilidad</h1>
                <h2>
                    Recuperar información firma</h2>
                <p>
                    En este ejemplo se realiza la firma de un documento y se recupera la información
                    relativa a la firma.</p>
                <h3>
                    Métodos utilizados</h3>
                <ul>
                    <li>signByServerWithTypeFileAndFormatSign</li>
                    <li>getSignInfo</li>
                </ul>
                <br />
                <form id="form2" runat="server">
				        <asp:button id="noValidoButton" runat="server" text="Firma no valida" 
                            onClick="ComprobarNoValidoButton_Click" Width="120px" PostBackUrl=""/>
                </form>
                
                <% if (infoFirma!=null) {%>
                <h2>Ejemplo:</h2>
                <p>
                    <strong>¿Es valido?: </strong><%= infoFirma.valid%><br />
                    <strong>Id de firma:</strong><%= infoFirma.signId%><br />
                    <strong>CA:</strong> <%= infoFirma.caName%><br />
                </p>
                <%} %>
				<div style="text-align:center;">
					<p><a href="../"> Inicio </a></p>
				</div>
				
			</div>
		</div>
	</body>
</html>