<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="checkCertificateByAlias.aspx.cs" Inherits="EjemploWebViafirmaClientDotNet.utils.checkCertificateByAlias" %>

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
				
                <h2>Comprobación de validez de certificador en el servidor</h2>
				<div class="group">
					<div class="col width-58 append-02">
						<div class="box">
							<h3 class="box-title">Verificar que el certificado sea válido</h3>
							
							<div class="box-content">
								<p>En este ejemplo se realiza la comprobación de un certificado si es válido y si está caducado. Este certificado se encuentra alojado en el caert del servidor.</p>
								<form id="form1" runat="server">
									<p>
										Alias del certificado:    
										<input style="width: 100%"type="text" value="" name="aliasCert">
									</p>
                                    <asp:Button id="Button1" runat="server" text="Verificar certificado" 
                                            onClick="ComprobarCertificadoAliasButton_Click" PostBackUrl=""/>
								</form>
							</div>
						</div>
								
					</div>
					
					<div class="col width-40">
						<div class="box">
							<h3 class="box-title">Metodos utilizados</h3>
							<div class="box-content">
								<ul>
									<li>checkCertificateByAlias</li>
								</ul>
							</div>
						</div>
					</div>
				</div>
				
                <% if (validationInfo != null){ %>
                    <div class="box">
					    <h2 class="box-title">Ejemplo</h2> 
					    <div class="box-content">
						    <p><%=validationInfo.certificate.subject%><br/></p>
						    <p><strong>¿Es válido?: </strong><%=validationInfo.validationResponse.validated%><br/></p>
						    <p><strong>¿Caducado?: </strong><%=validationInfo.validationResponse.expired%><br/></p>
                             <%                       
                                 String typeLegal = null;
                                 for (int i = 0; i < validationInfo.certificate.propertiesOID.Length; i++){
                                     if(validationInfo.certificate.propertiesOID[i].key == "typeLegal"){
                                         typeLegal = validationInfo.certificate.propertiesOID[i].value;
                                     }
                                 }
					        %>
                            <p><strong>Type Legal: </strong><%=typeLegal%><br/></p>
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
