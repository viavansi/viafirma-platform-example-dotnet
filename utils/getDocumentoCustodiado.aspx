<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="getDocumentoCustodiado.aspx.cs" Inherits="EjemploWebViafirmaClientDotNet.utils.getDocumentoCustodiado" %>
<% if(stream == null){ %>
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
				<h2>Recuperación de un documento custodiado</h2>
				
				<div class="group">
					<div class="col width-53 append-02">
						<div class="box">
							<h3 class="box-title">Recuperar documento</h3>
							<div class="box-content">
								<p>En este ejemplo se realiza la firma de un documento y se recupera el documento custodiado.</p>
								
							    <% if ("".Equals(idFirma)){%>
				                    <form id="form2" runat="server">
				                            <asp:button id="validoButton" runat="server" text="Iniciar recuperación de custodiado" 
                                                onClick="IniciarCustodiadoButton_Click" Width="245px" PostBackUrl=""/>
                                    </form>
                                <%} %>
							</div>
						</div>
							
							<%if (!("".Equals(idFirma))) {%>
						<div class="box">
							<h3 class="box-title">Recuperar documento</h3>
							<div class="box-content">
                                <form id="formu" runat="server">
                                    <p>
                                        <strong>Id de firma:</strong><%= idFirma%><br /><br />
                                              <asp:button id="Button1" runat="server" text="Recuperar documento custodiado" 
                                                onClick="GetCustodiadoButton_Click" Width="245px" PostBackUrl=""/>
                                        <br />
                                    </p>
                                </form> 
                            </div>
						</div>
                            <%} %>															
					</div>
					
					<div class="col with 45">
						<div class="box">	
							<h3 class="box-title">Métodos utilizados</h3>
							<div class="box-content">
								<ul>
									<li><code>signByServerWithTypeFileAndFormatSign</code></li>
									<li><code>getDocumentoCustodiado</code></li>
								</ul>
							</div>
						</div>
					</div>
				</div>
				
				<p><a href="../">&larr; Inicio</a></p>
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
 <%} %>
