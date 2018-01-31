<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="buildInfoQRBarCode.aspx.cs" Inherits="EjemploWebViafirmaClientDotNet.utils.buildInfoQRBarCode" %>

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
				<h2>Metodos de utilidad</h2>
				
				<div class="group">
					<div class="col width-58 append-02">
						<div class="box">
							<h3 class="box-title">Generar Resguardo con QRBarCode</h3>
							<div class="box-content">
								<p>En este ejemplo se realiza la firma de un documento y se recupera el resguardo de la firma con codigo de seguimiento QR.</p>
						
								<form id="form1" runat="server">
								    <p>
				                            <asp:button id="Button1" runat="server" text="Generar reguardo con código QR" 
                                                onClick="GenerarQRButton_Click" Width="245px" />
                                    </p>
                                </form>
								
							</div>
						</div>
					</div>
					
					<div class="col width-40">
						<div class="box">
							<h3 class="box-title">Métodos utilizados</h3>
							<div class="box-content">
								<ul>
									<li><code>signByServerWithTypeFileAndFormatSign</code></li>
									<li><code>buildInfoQRBarCode</code></li>
								</ul>
							</div>
						</div>
					</div>
				</div>
				
				<p><a href="../">&larr; Volver</a></p>
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