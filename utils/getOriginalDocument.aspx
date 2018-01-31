<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="getOriginalDocument.aspx.cs" Inherits="EjemploWebViafirmaClientDotNet.utils.getOriginalDocument" %>
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
				<h2>Recuperación del original de un documento firmado</h2>
				
				<div class="group">
					<div class="col width-53 append-02">
						<div class="box">
							<h3 class="box-title">Recuperar documento original</h3>
							<div class="box-content">
								<p>En este ejemplo se realiza la firma de un documento y se recupera el documento original que fue firmado.</p>
								
								<% if (docu == null) {%>
				                <form id="form2" runat="server">
				                        <asp:button id="Button" runat="server" text="Iniciar recuperación original" 
                                            onClick="IniciarOriginalButton_Click" Width="245px" PostBackUrl=""/>
                                </form>
                                <%} %>
							</div>
						</div>
						
						<% if (docu != null) {%>
                        <div class="box">
							<h2 class="box-title">Ejemplo</h2> 
							<div class="box-content">
                                <form id="form1" runat="server">
                                <p>
                                    <strong>Id de firma:</strong> <%= docu.id%><br />
                                    <strong>Formatode la firma:</strong> <%= docu.typeFormatSign%><br />
                                    <br />
                                          <asp:button id="Button1" runat="server" text="Recuperar documento original" 
                                            onClick="GetOriginalButton_Click" Width="245px" PostBackUrl=""/>
                                    <br />
                                </p>
                                </form>
                             </div>
						</div>
                        <%} %>
									
					</div>
					
					<div class="col width-45">
						<div class="box">
							<h3 class="box-title">Métodos utilizados</h3>
							<div class="box-content">
								<ul>
									<li>signByServerWithTypeFileAndFormatSign</li>
									<li>getOriginalDocument</li>
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