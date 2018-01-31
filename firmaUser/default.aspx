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
				<h2>Firmas con intervención del usuario</h2>
				
				<p>La firma se realizará a través del applet de Viafirma, siendo necesaria la intervención del usuario para completar el proceso de firma</p>
				
				<div class="group">
					<div class="col width-49 append-01">
						<div class="box">
							<h3 class="box-title">Firmas simples</h3>
				
							<div class="box-content">
								<ul>
									<li><a href="signaturePDF.aspx"> Firmar documento PDF en formato PAdES</a></li>
                                    <li><a href="signaturePDFImage.aspx"> Firmar documento PDF en formato PDF Signature con Sello de firma SIMPLE</a></li>
                                    <li><a href="signatureXML.aspx"> Firmar documento XML en formato XAdES</a></li>
									<li><a href="signaturePreviousSigned.aspx"> Firmar documento XML que previamente ya ha sido firmado. </a></li>
                                    <li><a href="firmarHash.aspx"> Firmar conociendo solo el Hash del documento original. </a></li>
                                    <li><a href="signatureCadesTDetached.aspx"> Firmar en bucle de documento docx en CAdES_T Detached. </a></li>
								</ul>
							</div>
						</div>
					</div>
					<div class="group">
					<div class="col width-49 prepend">
						<div class="box">
							<h3 class="box-title">Firmas en lote</h3>
				
							<div class="box-content">
								<ul>
									<li><a href="signatureBatch.aspx"> Firmar documentos en lote en formato XAdES</a></li>
								</ul>
							</div>
						</div>
						
						<div class="box">
							<h3 class="box-title">Firmas de varios documentos en bucle</h3>
				
							<div class="box-content">
								<ul>
									<li><a href="signatureLoop.aspx"> Firmar en bucle varios documentos en firmas independientes y una sola transacción con formato XAdES</a></li>
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
