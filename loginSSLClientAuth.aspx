﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginSSLClientAuth.aspx.cs" Inherits="EjemploWebViafirmaClientDotNet.loginSSLClientAuth" Async="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
		<title>Viafirma - Kit para desarrolladores</title>
		
		<link rel="stylesheet" href="css/framework.css" type="text/css" media="screen" />
		<link rel="stylesheet" href="css/styles.css" type="text/css" media="screen" />
	</head>
	<body>
		<div id="wrapper">
			<h1 id="header"><a href=".."><img src="images/content/logo.png" alt="Viafirma" /></a></h1>
			
			<div id="content">
				<h2>Autenticar al usuario mediante SSL client auth (sin cliente rico: applet, Viafirma Desktop...)</h2>
				
				<div class="group">
					<div class="col width-63 append-02">
						<div class="box">
							<h3 class="box-title">Autenticación del usuario con Viafirma - SSL client authentication</h3>
							<div class="box-content">
								<p>En este ejemplo se realiza la autenticación del usuario a través de Viafirma sin ningún tipo de cliente (SSL auth). 
								Requiere un conector adicional en la instalación de Viafirma Platform.</p>
                                <%
                                    if(sslAuthOperation == null)
                                    {
                                %>
                                <form id="form_ssl_client_auth" runat="server">
				                        <asp:button ID="SSL_client_Auth" runat="server" 
                                            Text="Autenticar al usuario con Viafirma (SSL)" 
                                            OnClick="Autenticar_SSL_ClickAsync" />
                                </form>
                                <%
                                    }
                                    else
                                    {
                                        Response.Redirect(sslAuthOperation.RedirectURL);
                                    }
                                %>
                                
							</div>
						</div>
					</div>
					
					<div class="col width-35">
						<div class="box">
							<h3 class="box-title">Métodos utilizados</h3>
							
							<div class="box-content">
								<ul>
									<li><code>prepare</code></li>
								</ul>
							</div>
						</div>
					</div>
				</div>
				
				<p>
					<a href="../">&larr; Inicio</a>
				</p> 
			</div>
			
			<div id="footer">
				<p class="left">
					Acceda a <a href="http://www.viafirma.com">Viafirma</a> o consulte más información técnica en <a href="http://developers.viafirma.com/">Viafirma Developers</a> 
				</p>
				<p>
					<small>Versión 2.9.60</small>
				</p>
			</div>
		</div>
	</body>
</html>
