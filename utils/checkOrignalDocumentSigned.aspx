<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="checkOrignalDocumentSigned.aspx.cs" Inherits="EjemploWebViafirmaClientDotNet.utils.checkOrignalDocumentSigned" %>

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
				<h2>Verificación de correspondencia entre el documento original y el firmado</h2>
				
				<div class="group">
					<div class="col width-58 append-02">
						<div class="box">
							<h3 class="box-title">Comprobar original firmado</h3>
							
							<div class="box-content">
								<p>Este ejemplo, recupera un documento xml original, que previamente ha sido firmado con Viafirma, y comprueba que el documento no ha sido modificado, y corresponde con la versión custodiada en Viafirma.</p>
								
								<form id="formu" runat="server">
								    <p>
				                        <asp:button id="valido_Button" runat="server" text="Firma valida" 
                                            onClick="ComprobarValidoButton_Click" Width="120px" PostBackUrl=""/>
                                        <asp:button id="noValido_Button" runat="server" text="Firma no valida" 
                                            onClick="ComprobarNoValidoButton_Click" Width="120px" PostBackUrl=""/>
                                    </p>
                                </form>
							</div>
						</div>			
						<% if (infoFirma!=null) {%>
                				<div class="box">
									<h2 class="box-title">Ejemplo</h2> 
									<div class="box-content">
										<p>
                                            <strong>¿Es valido?: </strong><%= infoFirma.valid%><br />
                                            <strong>Id de firma:</strong><%= infoFirma.signId%><br />
                                            <strong>CA:</strong> <%= infoFirma.caName%><br />
                                        </p>
                        			</div>
								</div>
						<%}%>
					</div>
					
					<div class="col width-40">
						<div class="box">
							<h3 class="box-title">Métodos utilizados</h3>
							<div class="box-content">
								<ul>
									<li>signByServerWithTypeFileAndFormatSign</li>
									<li>checkOrignalDocumentSigned</li>
								</ul>
							</div>
						</div>
					</div>
				</div>
				
				<p><a href="../">&larr; Volver</a></p>
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