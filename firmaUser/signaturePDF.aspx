﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signaturePDF.aspx.cs" Inherits="EjemploWebViafirmaClientDotNet.firmaUser.signaturePDF" %>

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
								<p>En este ejemplo se realiza la firma de un documento PDF con formato PDF Signature en Viafirma con la intervención directa del usuario.</p>
							
								<form id="form1" runat="server">
				                        <asp:button id="Button1" runat="server" text="Firma de PDF en formato PDF_PKCS7 (SIN timestamp)" 
                                            onClick="FirmarUserPDFButton_Click" CommandName="PDF_PKCS7"/>
                                        <br />
                                        <br />
                                        <asp:button id="Button2" runat="server" text="Firma de PDF en formato PDF_PKCS7_T (CON timestamp)" 
                                            onClick="FirmarUserPDFButton_Click" CommandName="PDF_PKCS7_T"/>
                                        <br />
                                        <br />
                                        <asp:button id="Button3" runat="server" text="Firma de PDF en formato PAdES_BASIC" 
                                            onClick="FirmarUserPDFButton_Click" CommandName="PAdES_BASIC"/>
                                        <br />
                                        <br />
                                        <asp:button id="Button4" runat="server" text="Firma de PDF en formato PAdES_BES" 
                                            onClick="FirmarUserPDFButton_Click" CommandName="PAdES_BES"/>
                                        <br />
                                        <br />
                                        <asp:button id="Button5" runat="server" text="Firma de PDF en formato PAdES_EPES" 
                                            onClick="FirmarUserPDFButton_Click" CommandName="PAdES_EPES"/>
                                       
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