<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="firmarSelloRotado.aspx.cs" Inherits="EjemploWebViafirmaClientDotNet.firmaPolicy.firmarSelloRotado" %>

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
				<h2>Firma pdf con sello generado por viafirma</h2>
				
				<div class="group">
					<div class="col width-53 append-02">
						<div class="box">
							<h3 class="box-title">Firma pdf con sello generado por viafirma rotado</h3>
							
							<div class="box-content">
								<p>Ejemplo de firma de documanto pdf con sello diseñado por viafirma que contiene el QRCode, Bar Code, 
								    texto con información de la firma e id de firma en el que se indica como rotar el sello 90º o 270º.</p>
							
								<form id="form1" runat="server">
				                        <asp:button id="Button2" runat="server" text="Firmar documento PDF de ejemplo" 
                                            onClick="Firmar_Button_Click" />
                                </form>
							</div>
						</div>
					</div>
					
					<div class="col width-45">
						<div class="box">
							<h3 class="box-title">Métodos utilizados</h3>
							<div class="box-content">
								<ul>
									<li>PrepareSignWithPolicy</li>
					                <li>Sign</li>
								</ul>
							</div>                            
						</div>
                        <div class="box">
                            <h3 class="box-title">Propiedades y Parámetros utilizados</h3>
							<div class="box-content">
								<ul>
									<li>TypeFormatSign</li>
									<li>TypeSign</li>
									<li>DIGITAL_SIGN_PAGE</li>
									<li>DIGITAL_SIGN_RECTANGLE</li>
									<li>DIGITAL_SIGN_STAMPER_HIDE_STATUS</li>
									<li>DIGITAL_SIGN_IMAGE_STAMPER</li>
									<li>DIGITAL_SIGN_STAMPER_TEXT</li>
									<li>DIGITAL_SIGN_STAMPER_TYPE</li>
									<li>DIGITAL_SIGN_STAMPER_ROTATION_ANGLE</li>>
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
					Acceda a <a href="http://www.viafirma.com">Viafirma</a> o consulte más información técnica en <a href="http://developers.viafirma.com/">Viafirma Developers</a> 
				</p>
				<p>
					<small>Versión 2.9.60</small>
				</p>
			</div>
		</div>
	</body>
</html>
