<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="checkDocumentSigned.aspx.cs" Inherits="EjemploWebViafirmaClientDotNet.utils.checkDocumentSigned" %>

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
								    <p>
				                        <asp:button id="Button1" runat="server" text="Firma valida" 
                                            onClick="ComprobarValidoButton_Click" Width="120px" PostBackUrl=""/>
                                        <asp:button id="Button2" runat="server" text="Firma no valida" 
                                            onClick="ComprobarNoValidoButton_Click" Width="120px" PostBackUrl=""/>
                                    </p>
                                </form>
                                
							</div>
						</div>	
						<% if (infoFirma!=null) {%>
						<div class="box">
							<h2 class="box-title">Ejemplo</h2> 
							<div class="box-content">
								<p>
                                    <strong>¿Es valido?: </strong><%= infoFirma.valid%><br />
                                    <strong>Id de firma:</strong><%= infoFirma.signId%><br />
                                    <strong>CA:</strong> <%= infoFirma.caName%><br />
                                    <strong>Propiedades</strong>{
					                <%                        
                                        for (int i = 0; i < infoFirma.properties.Length; i++){
                                             %>[<%=infoFirma.properties[i].key%>=<%=infoFirma.properties[i].value%>],<%
                                        }
					                %>

                                    }
                                </p>
							</div>
						</div>
						<%} %>
					</div>

					<div class="col width-40">
						<div class="box">
							<h3 class="box-title">Metodos utilizados</h3>
							<div class="box-content">
								<ul>
									<li>signByServerWithTypeFileAndFormatSign</li>
									<li>getDocumentoCustodiado</li>
									<li>checkDocumentSigned</li>
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