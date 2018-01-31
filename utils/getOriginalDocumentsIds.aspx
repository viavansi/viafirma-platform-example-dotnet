<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="getOriginalDocumentsIds.aspx.cs" Inherits="EjemploWebViafirmaClientDotNet.utils.getOriginalDocumentsIds" %>
<% if(stream == null){ %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
		<title>Viafirma - Kit para desarrolladores</title>
		
		<link rel="stylesheet" href="../../css/framework.css" type="text/css" media="screen" />
		<link rel="stylesheet" href="../../css/styles.css" type="text/css" media="screen" />
	</head>
	<body>
		<div id="wrapper">
			<h1 id="header"><a href="../../"><img src="../../images/content/logo.png" alt="Viafirma" /></a></h1>
			
			<div id="content">
				<h2>Recuperación del listado de firmas de un lote</h2>
				
				<div class="group">
					<div class="col width-63 append-02">
						<div class="box">
							<h3 class="box-title">Recuperar informacion de documentos originales</h3>
							<div class="box-content">
								<p>En este ejemplo se realiza la firma de un lote de documentos, se recupera el listado de identificadores y se recuperan los documentos originales que fueron firmados.</p>
								
								<% if (docuList == null){%>
				                    <form id="form1" runat="server">
				                            <asp:button id="Button1" runat="server" text="Recuperación listado originales" 
                                                onClick="GetOriginalDocumentIdsButton_Click" Width="245px" PostBackUrl=""/>
                                    </form>
                                 <%} %>
							</div>
						</div>
								<% if (docuList != null){%>
									<div class="box">
										<h2 class="box-title">Ejemplo</h2> 
										<div class="box-content">
									<%foreach (documento docu in docuList) { %>
                                        <p>
                                            <strong>ID:</strong> <%= docu.id%><br />
                                            <strong>Nombre:</strong><%= docu.nombre%><br/>
			                                <strong>Tamaño:</strong><%= docu.datos.Length%><br/>
			                                <strong>Tipo de Documento:</strong> <%= docu.tipo%>
                                        </p>
                
                                    <%} %>
								        </div>
							        </div>	
						        <%}	%>
					</div>
					
					<div class="col width-35">
						<div class="box">
							<h3 class="box-title">Métodos utilizados</h3>
							<div class="box-content">
								<ul>
									<li><code>iniciarFirmaEnLotes</code></li>
									<li><code>addDocumentoFirmaEnLote</code></li>
									<li><code>signByServerEnLotes</code></li>
									<li><code>getOriginalDocumentsIds</code></li>
									<li><code>getOriginalDocument</code></li>
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