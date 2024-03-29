﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="xadesAReseal.aspx.cs" Inherits="EjemploWebViafirmaClientDotNet.firmaServer.xadesAReseal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
		<title>Viafirma - Kit para desarrolladores</title>
		
		<link rel="stylesheet" href="../css/framework.css" type="text/css" media="screen" />
		<link rel="stylesheet" href="../css/styles.css" type="text/css" media="screen" />
	</head>
	<body>
		<div id="wrapper">
			<h1 id="header"><a href="../"><img src="../images/content/logo.png" alt="Viafirma" /></a></h1>
			
			<div id="content">
				<h2>Firmas sin intervención del usuario</h2>
				<div class="group">
					<div class="col width-58 append-02">
						<div class="box">
							<h3 class="box-title">Firma XML</h3>
							<div class="box-content">
								<p>En este ejemplo se realiza la promoción a XAdES-A de un documento XML previamente firmado en el servidor con una firma XAdES-XL</p>
								<p>Para su correcto funcionamiento el certificado debe estar instalado en el servidor.</p>
								
								<% if ("".Equals(idFirma)) {%>
								<form id="form2" runat="server">
			                        <asp:button id="xadesAResealBtn" runat="server" text="Promover a XAdES-A una firma previa" 
                                        onClick="XAdESAResealButton_Click" Width="245px" />
                                </form>
                                 <%} %>
							</div>
						</div>
						
						<% if (!"".Equals(idFirma)) {%>
                        <div class="box">
							<h2 class="box-title">Ejemplo</h2> 
							<div class="box-content">
                                <form id="form1" runat="server">
                                    <p>
                                        <strong>Tipo de documento:</strong> Archivo XML<br />                                        
                                        <strong>Id de firma:</strong><%= idFirma%>
                                    </p>
                                    <p>
                                        <asp:Button ID="downloadButton" runat="server" text="Descargar documento firmado" 
                                            onClick="DownloadButton_Click" Width="245px" /><br />
                                    </p>
                                 </form>
                            </div>
                        </div>
                        <%} %>
						
						
					</div>
					<div class="col width-40">
						<div class="box">
							<h3 class="box-title">Métodos utilizados</h3>
							<div class="box-content">
								<ul>
									<li>SignByServerWithPolicy</li>
									<li>getDocumentoCustodiado</li>
									<li>XadesAReseal</li>
								</ul>
							</div>
						</div>
					</div>
				</div>
				
				<p>
					<a href="./">&larr; Volver</a>
				</p>
			</div>
			<div id="footer">
				<p class="left">
					Acceda a <a href="http://www.viafirma.com">Viafirma</a> o consulte más información técnica en <a href="https://doc.viafirma.com/viafirma-platform/integration/">Manual de integración de viafirma platform</a> 
				</p>
				<p>
					<small>3.0.0</small>
				</p>
			</div>
		</div>
	</body>
</html>
