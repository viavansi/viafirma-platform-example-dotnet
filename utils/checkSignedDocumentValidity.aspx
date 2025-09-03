<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="checkOrignalDocumentSigned.aspx.cs" Inherits="EjemploWebViafirmaClientDotNet.utils.checkSignedDocumentValidity" %>

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
				<h2>Verificación de un documento firmado</h2>
				
				<div class="group">
					<div class="col width-58 append-02">
						<div class="box">
							<h3 class="box-title">Verificar que el documento está firmado</h3>
							
							<div class="box-content">
								<p>En este ejemplo se realiza la firma de un documento y se recupera el documento custodiado para posteriormente verificar su firma.</p>
								
								<form id="form2" runat="server">
				                        <asp:button id="validoButton" runat="server" text="Firma valida" 
                                            onClick="ComprobarValidoButton_Click" Width="120px" PostBackUrl=""/>
                                        <asp:button id="noValidoButton" runat="server" text="Firma no valida" 
                                            onClick="ComprobarNoValidoButton_Click" Width="120px" PostBackUrl=""/>
                                </form>
							</div>
						</div>
												
						<% if (info!=null) {%>
                        <div class="box">
							<h2 class="box-title">Ejemplo</h2> 
							<div class="box-content">
                                <form id="form1">
                                    <p>
                                        <!--<strong>Id de firma:</strong><%= idFirma%><br />-->
                                        <strong>¿Esta firmado?: </strong>
                                        <%if(info.signed){%>
                                            Si, está firmado
                                        <%}else{%>
                                            No, no está firmado
                                        <%}%><br />                                        
                                    </p>
                                    <p>
                                        <strong>¿Es Válido?: </strong>
                                        <%if(info.valid){%>
                                            Si, es válido
                                        <%}else{%>
                                            No, no es válido
                                        <%}%><br />                                        
                                    </p>
                                    <% if (info.signed) {%>
                                        <p><strong>CA:</strong>                  <%=info.caName %></p>
                                        <p><strong>Nombre:</strong>              <%=info.firstName %></p>
                                        <p><strong>Apellido:</strong>            <%=info.lastName %></p>                                        
                                        <p><strong>NIF:</strong>                 <%=info.numberUserId %></p>
                                        <p><strong>Tipo Certificado:</strong>    <%=info.typeCertificate %></p>
                                        <p><strong>Tipo Legal:</strong>          <%=info.typeLegal %></p>
                                        <p><strong>TimeStamp:</strong>           <%=info.signTimeStamp %></p>
                                        <p><strong>Mensaje:</strong>             <%=info.message %></p>
                                    <%} %>
                                    
                                 </form>
                            </div>
                        </div>
                        <%} %>
                        
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