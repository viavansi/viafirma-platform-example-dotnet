<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="firmarCadesDetached.aspx.cs" Inherits="EjemploWebViafirmaClientDotNet.firmaPolicy.firmarCadesDetached" %>

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
					<div class="col width-53 append-02">
						<div class="box">
							<h3 class="box-title">Firma PDF</h3>
							
							<div class="box-content">
								<p>En este ejemplo implementa la firma de un documento docx con firma CAdES-T DETACHED.</p>
							
								<form id="formCadesT" runat="server">
				                        <asp:button id="buttonCadesT" runat="server" text="Firmar documento docx de ejemplo" 
                                            onClick="FirmarUserCADES_DETACHED" />
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
