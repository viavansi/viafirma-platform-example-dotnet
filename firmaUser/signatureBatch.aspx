<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signatureBatch.aspx.cs" Inherits="EjemploWebViafirmaClientDotNet.firmaUser.signatureBatch" %>

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
				<h2>Firmas con intervención del usuario</h2>
				
				<div class="group">
					<div class="col width-63 append-02">
						<div class="box">
							<h3 class="box-title">Firma en lote</h3>
							
							<div class="box-content">
								<p>En este ejemplo se realiza la firma de un lote compuesto por varios documentos en Viafirma con la intervención directa del usuario. El resultado de la firma es considerado como una única unidad</p>
							
								<form id="form2" runat="server">
			                        <asp:button id="firmarButton" runat="server" text="Firmar un lote de documentos" 
                                            onClick="FirmarLotesUserButton_Click" Width="245px" />
                                </form>
							</div>
						</div>
					</div>
					
					<div class="col width-33 append-02">
						<div class="box">
							<h3 class="box-title">Métodos utilizados</h3>
							<div class="box-content">
								<ul>
									<li>iniciarFirmaEnLotes</li>
				                    <li>addDocumentoFirmaEnLote</li>
				                    <li>Sign</li>
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