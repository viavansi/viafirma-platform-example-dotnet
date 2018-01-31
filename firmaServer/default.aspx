<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="EjemploWebViafirmaClientDotNet.firmaServer._default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
		<title>Viafirma - Kit para desarrolladores</title>
		
		<link rel="stylesheet" href="../css/framework.css" type="text/css" media="screen" />
		<link rel="stylesheet" href="../css/styles.css" type="text/css" media="screen" />
	</head>
	<body>
		<div id="wrapper">
			<h1 id="header"><a href="../"><img src="../images/content/logo.png" alt="Viafirma" /></a></h1>
			
			<div id="content">
				<h2>Firmas sin intervención del usuario</h2>
				<p>Las firmas realizadas sin intervención del usuario son realizadas a través del servidor.</p>
				<p>Para el correcto funcionamiento de los siguientes ejemplos, el certificado debe estar instalado en el servidor.</p>
				
				<div class="group">
					<div class="col width-49 append-01">
						<div class="box">
							<h3 class="box-title">Firmas simples</h3>
							<div class="box-content">
								<ul>
									<li><a href="signaturePDF.aspx">Firmar documento PDF en formato PDF Signature</a></li>
                                    <li><a href="signaturePDFImage.aspx">Firmar documento PDF en formato PDF Signature e incluyendo una imagen como sello de firma</a></li>
									<li><a href="signatureXML.aspx">Firmar documento XML en formato XAdES</a></li>
								</ul>
							</div>
						</div>
					</div>
					
					<div class="col width-49 prepend-01">
						<div class="box">
							<h3 class="box-title">Firmas en lote</h3>
							<div class="box-content">
								<ul>
									<li><a href="signatureBatch.aspx">Firmar documentos en lote formato XAdES</a></li>
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
	</body>
</html>