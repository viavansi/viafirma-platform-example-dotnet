<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EjemploWebViafirmaClientDotNet.indice" %>

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
			<h1 id="header"><a href="."><img src="images/content/logo.png" alt="Viafirma" /></a></h1>
			
			<div id="content">
				<p class="message">La aplicación de ejemplo está actualmente configurada para utilizar el servicio<br /><strong><%=global_asax.URL_VIAFIRMA %></strong></p>
				
				<div class="group">
					<div class="col width-49 append-01">
						<div class="box">
							<h2 class="box-title">Autenticación</h2>
							
							<div class="box-content">
								<ul>
					                <li><a href="login.aspx" title="Autenticar al usuario con Viafirma">Autenticar al usuario con Viafirma</a></li>
				                </ul>
							</div>
						</div>
					</div>
					
					<div class="col width-49 prepend-01">
						<div class="box">
							<h2 class="box-title">Firma</h2>
							
							<div class="box-content">
								<ul>
				                    <li><a href="firmaUser/default.aspx" 
                                            title="Firmar un documento con intervencion del usuario">Firmar un documento con intervención del usuario</a></li>

				                    <li><a href="firmaServer/default.aspx" 
                                            title="Firmar un documento sin intervencion del usuario">Firmar un documento sin intervencion del usuario</a></li>
                                    
                                    <li><a href="firmaPolicy/default.aspx" 
                                            title="Otros ejemplos de firma">Otros ejemplos de firma</a></li>
                                     
			                    </ul>
							</div>
						</div>
					</div>
				</div>
				
				<div class="box">
					<h2 class="box-title">Métodos de utilidad</h2>
					
					<div class="box-content">
						<ul>
							<li><a href="utils/buildInfoQRBarCode.aspx">Generar resguardo de seguimiento con codigo QR</a></li>
				            <li><del><a href="utils/checkDocumentSigned.aspx">Verificar documento firmado</a></del></li>
                            <li><del><a href="utils/checkOrignalDocumentSigned.aspx">Verificar correspondencia entre documento original y firma</a></del></li>
                            <li><del><a href="utils/checkSignedDocumentValidity.aspx">Comprobar la validez de una firma</a></del></li>
                            <li><a href="utils/getDocumentoCustodiado.aspx">Recuperar documento custodiado</a></li>
                            <li><a href="utils/getOriginalDocument.aspx">Recuperar documento original de una firma</a></li>
                            <li><a href="utils/getOriginalDocumentsIds.aspx">Recuperar listado de firmas de un lote</a></li>
                            <li><del><a href="utils/checkCertificate.aspx">Comprobación de validez de certificado cliente (clave pública)</a></del></li>
                            <li><del><a href="utils/checkCertificateByAlias.aspx">Comprobación de validez de certificado en el servidor</a></del></li>
                            <li><a href="utils/checkVerificateCert.aspx">Comprobación de validez de certificado cliente (clave pública)</a></li>
                            <li><a href="utils/checkVerificateSign.aspx">Comprobar la validez de una firma</a></li>
                           <!-- <li><a href="getSignInfo.aspx">Recuperar información de una firma</a></li> -->
						</ul>
					</div>
				</div>
			</div>
			<div id="footer">
				<p class="left">
					Acceda a <a href="http://www.viafirma.com">Viafirma</a> o consulte más información técnica en <a href="https://doc.viafirma.com/viafirma-platform/integration/">Manual de integración de viafirma platform</a> 
				</p>
				<p>
					3.0.0
				</p>
			</div>
		</div>
	</body>
</html>