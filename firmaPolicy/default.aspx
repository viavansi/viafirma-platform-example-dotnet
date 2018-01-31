<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="EjemploWebViafirmaClientDotNet.firmaUser._default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
		<title>Viafirma - Kit para desarrolladores</title>
		
		<link rel="stylesheet" href="../css/framework.css" type="text/css" media="screen" />
		<link rel="stylesheet" href="../css/styles.css" type="text/css" media="screen" />
	</head>
	<body>
		<div id="wrapper">
			<h1 id="header"><a href=".."><img src="../images/content/logo.png" alt="Viafirma" /></a></h1>
			
			<div id="content">
				<h2>Firmas con Policy</h2>
				
				<p>La firma se realizará a través del applet de Viafirma, siendo necesaria la intervención del usuario para completar el proceso de firma</p>
				
				<div class="group">
					<div class="col width-99 append-01">
						<div class="box">
							<h3 class="box-title">Firmas con Policy</h3>
				
							<div class="box-content">
								<ul>
									<li><a href="signatureGenericStamper.aspx"> Firma pdf con sello genérico </a></li>
									<li><a href="signatureGenericStamperText.aspx"> Firma pdf con sello genérico añadiendo texto personalizado </a></li>                                    
									<li><a href="signatureGenericStamperTextWithoutMark.aspx"> Firma pdf con sello genérico sin información de la validez de la firma </a></li>
                                    <li><a href="signatureWtihStamperAndImage.aspx"> Firma pdf con sello genérico con imagen de fondo</a></li>
                                    <li><a href="signatureGenericStamperCertificateText.aspx"> Firma pdf con sello genérico con texto personalizado obtenido del certificado </a></li>
                                    <li><a href="signatureCustomStamper.aspx"> Firma pdf con sello personalizado </a></li>
                                    <li><a href="signatureCustomStamperAndCustomText.aspx"> Firma pdf con sello personalizado y texto personalizado </a></li>
                                    <li><a href="signaturePDF417.aspx"> Firma pdf con sello PDF417 </a></li>
                                    <li><a href="firmarSelloCSV.aspx"> Firma pdf con sello generado por viafirma con URL de CSV personalizada </a></li>
                                    <li><a href="firmarSelloRotado.aspx"> Firma pdf con sello generado por viafirma rotado </a></li>
                                    <li><a href="firmarSelloTransparente.aspx"> Firma pdf con sello generado por viafirma transparente </a></li>
                                    <li><a href="firmarSelloSinQRCode.aspx"> Firma pdf con sello generado por viafirma ocultando el QRCode </a></li>
                                    <li><a href="firmarSelloSinBarCode.aspx"> Firma pdf con sello generado por viafirma ocultando el código de barras </a></li>
                                    <li><a href="firmarSelloTodasPaginas.aspx"> Firma pdf con sello generado por viafirma en una sola línea y en todas las páginas </a></li>
                                    <li><a href="signatureFiltersList.aspx"> Firma pdf con lista de filtros de certificado </a></li>
                                    <li><a href="firmarCadesDetached.aspx"> Firma cades-t detached </a></li>
                                    
								</ul>
							</div>
						</div>
					</div>
                    <div class="group">
					<div class="col width-99 append-01">
						<div class="box">
							<h3 class="box-title">Ejemplos filtros de certificados por policy</h3>
				
							<div class="box-content">
								<ul>
									<li><a href="filtroSNyCA.aspx" >Filtro por SN y CA</a></li>
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
					Acceda a <a href="http://www.viafirma.com">Viafirma</a> o consulte más información técnica en <a href="https://doc.viafirma.com/viafirma-platform/integration/">Manual de integración de viafirma platform</a> 
				</p>
				<p>
					<small>3.0.0</small>
				</p>
			</div>
		</div>
	</div>
	</body>
</html>
