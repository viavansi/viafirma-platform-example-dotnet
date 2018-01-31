<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="checkVerificateCert.aspx.cs" Inherits="EjemploWebViafirmaClientDotNet.utils.checkVerificateCert" %>

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
				
                <h2>Comprobación de validez de certificador cliente</h2>
				<div class="group">
					<div class="col width-58 append-02">
						<div class="box">
							<h3 class="box-title">Verificar que el certificado sea válido</h3>
							
							<div class="box-content">
								<p>En este ejemplo se realiza la comprobación de un certificado si es válido y si está caducado. Se le pasará al servidor la clave pública del certificado a validar.</p>
								<form id="form1" runat="server">
									<p>
										PEM Encodig:    
										<textarea style="width: 100%; height: 400px;" name="pem"></textarea>
									</p>
                                    <asp:Button id="Button1" runat="server" text="Verificar certificado" 
                                            onClick="ComprobarCertificadoPemButton_Click" PostBackUrl=""/>
								</form>
							</div>
						</div>
								
					</div>
					
					<div class="col width-40">
						<div class="box">
							<h3 class="box-title">Metodos utilizados</h3>
							<div class="box-content">
								<ul>
									<li>verifyCertificate</li>
								</ul>
							</div>
						</div>
					</div>
				</div>
				
                <% if (certificateResponse != null)
                    { %>
                    <div class="box">
					    <h2 class="box-title">Ejemplo</h2> 
					    <div class="box-content">
						    <p><%="(" + certificateResponse.numberUserId + ") " + certificateResponse.firstName + " " + certificateResponse.lastName%><br/></p>
						    <p><strong>Estado: </strong><%=certificateResponse.certificateStatus%><br/></p>
                            <p><strong>Subject: </strong><%=certificateResponse.subjectDN %></p>
                            <p><strong>Type legal: </strong><%=certificateResponse.typeLegal %></p>
                            <p><strong>Propiedades:</strong><br/>

                             <%                       

                                if (certificateResponse.properties != null) { 
                                    for (int i = 0; i < certificateResponse.properties.Length; i++)
                                    {
                                     %>
                                        <p><strong><%=certificateResponse.properties[i].key%>: </strong><%=certificateResponse.properties[i].value%></p>
                                     <% 
                                    }
                                }
					        %>
					    </div>
				    </div>
                <%} %>

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
