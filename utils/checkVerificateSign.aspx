<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="checkVerificateSign.aspx.cs" Inherits="EjemploWebViafirmaClientDotNet.utils.checkVerificateSign" %>

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
				
                <h2>Comprobación de validez de una firma</h2>
				<div class="group">
					<div class="col width-58 append-02">
						<div class="box">
							<h3 class="box-title">Verificar que la firma sea válida</h3>
							
							<div class="box-content">
								<p>En este ejemplo se realiza la comprobación de una firma si es válido. Se le pasará al servidor el identificador de la firma a validar.</p>
								<form id="form1" runat="server">
									<p>
										Sign ID    
										<input type="text" name="signId"/>
									</p>
                                    <asp:Button id="Button1" runat="server" text="Verificar firma" 
                                            onClick="verifySignButton_Click" PostBackUrl=""/>
								</form>
							</div>
						</div>
								
					</div>
					
					<div class="col width-40">
						<div class="box">
							<h3 class="box-title">Metodos utilizados</h3>
							<div class="box-content">
								<ul>
									<li>verifySignature</li>
								</ul>
							</div>
						</div>
					</div>
				</div>
				
              
                <% if (signatureVerification != null){
                        int count = 0;
                        foreach (signatureVerification signatureVerify in signatureVerification) {
                            count++;
                %>
                    <div class="box">
					    <h2 class="box-title">Firma <%=count%></h2> 
					    <div class="box-content">
						    <p>Estado: <%=signatureVerify.signatureStatus%><br/></p>
                            <p>Mensaje: <%=signatureVerify.message%><br/></p>
                            <p>Fecha: <%=signatureVerify.signTimeStamp%><br/></p>
				        </div>
                    </div>   
                <%  }
                } %>


				<p><a href="../">&larr; Volver</a></p>
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
