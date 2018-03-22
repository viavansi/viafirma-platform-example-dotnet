<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signatureDirectViafirmaDesktop.aspx.cs" Inherits="EjemploWebViafirmaClientDotNet.signatureDirectViafirmaDesktop" Async="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
		<title>Viafirma - Kit para desarrolladores</title>
		
		<link rel="stylesheet" href="css/framework.css" type="text/css" media="screen" />
		<link rel="stylesheet" href="css/styles.css" type="text/css" media="screen" />
	</head>
	<body>
		<div id="wrapper">
			<h1 id="header"><a href=".."><img src="images/content/logo.png" alt="Viafirma" /></a></h1>
			
			<div id="content">
				<h2>Firmar usando llamada a Viafirma Desktop por protocolo (requiere Javascript)</h2>
				
				<div class="group">
					<div class="col width-63 append-02">
						<div class="box">
							<h3 class="box-title">Firma con Viafirma Desktop</h3>
							<div class="box-content">
								<p>En este ejemplo se realiza la firma de un documento utilizando Javascript para la invocación a Viafirma Desktop por protocolo. Requiere código Javascript local.</p>
                                <form id="form1" runat="server">    
                                    <%  if (desktopInvocation == null) { %>
								    <p>
			                            <asp:button  ID="firmarBoton" runat="server" 
                                                Text="Iniciar proceso de firma"  OnClick="Firmar_ClickAsync" 
                                                Width="245px"  />
                                    </p>
                                    <% }
                                        else
                                        {
                                    %>
                                    <script src="<%=Viafirma.ViafirmaClientFactory.GetInstance().UrlPublica%>/viafirma.js">
                             		    // Include this remote Javascript is mandatory, it includes the polling logic
                                    </script>
                                    <script>
                                        // Customize this in your own client webapp... this is just a sample!
                                        // When the polling detects an error, it invokes this function
                                        function showError(response) {
                                            document.getElementById("loading").style = "display: none;";
                                            document.getElementById("signatureError").innerHTML = "Ocurrió un problema durante la firma: " + JSON.stringify(response);
                                        }
                                        // If the user cancels the operation in Viafirma Desktop app, this function is invoked
                                        function showCancel(response) {
                                            document.getElementById("loading").style = "display: none;";
                                            document.getElementById("signatureCancel").innerHTML = "La firma fue cancelada: " + JSON.stringify(response);
                                        }
                                        // If the signature operation runs ok, this function is invoked - customize it with your own logic 
                                        // For instance, probably you will need to invoke an internal REST service that receives the signature response object
                                        function showSuccess(response) {
                                            document.getElementById("loading").style = "display: none;";

                                            document.getElementById("signatureSuccess").innerHTML = "<p>Operación de firma realizada con éxito. Información obtenida:</p><ul>" +
                                                "<li><strong>ID de operación</strong>: " + response.operationId + "</li>" +
                                                "<li><strong>Identificación usuario</strong>: " + response.certificateValidationData.numberUserId + "</li>" +
                                                "<li><strong>Usuario</strong>: " + response.certificateValidationData.name + " " + response.certificateValidationData.surname1 + " " + response.certificateValidationData.surname2 + "</li>" +
                                                "<li><strong>CA</strong>: " + response.certificateValidationData.shortCa + "</li>" +
                                                "<li><strong>ID Firma</strong>: " + response.signatureId + "</li>" +
                                                "</ul>";
                                        }
                                        // Here we initialize the viafirma.js polling 
                                        function initSignature() {
                                            document.getElementById("signatureButton").style = "display: none;";
                                            document.getElementById("loading").innerHTML = "<img src='./images/icons/ajax-loader.gif' />";

                                            // Start the viafirma JS client: watch the status of a given operationId
                                            // - if the operation fails, "errorCallback" will be called
                                            // - if the operation is cancelled, "cancelCallback" will be called
                                            // - if the operation is completed: "successCallback" will be called
                                            viafirma.init({
                                               // Here we include 
                                                operationId: "<%=desktopInvocation.OperationId%>",
                                                viafirmaUrl: "<%=Viafirma.ViafirmaClientFactory.GetInstance().UrlPublica%>/",
                                                errorCallback: function (response) {
                                                   showError(response);
                                                },
                                                 successCallback: function (response) {
                                                   showSuccess(response);
                                                },
                                                cancelCallback: function (response) {
                                                   showCancel(response);
                                                }
                                            });
                                        }
                                </script>
                                <p id="signatureError"></p>
                                <p id="signatureCancel"></p>
                                <p id="signatureSuccess"></p>
                                <p id="loading"></p>
                                <p id="signatureButton">
                                    <a class="button" href="<%=desktopInvocation.ViafirmaDesktopInvocationLink%>" onClick="initSignature();">Firmar con Viafirma Desktop</a>
                                </p>                                    
                                    <% }
                                    %>
                                </form>
							</div>
						</div>
					</div>
					
					<div class="col width-35">
						<div class="box">
							<h3 class="box-title">Métodos utilizados</h3>
							
							<div class="box-content">
								<ul>
									<li><code>prepareSignatureForDirectDesktop</code></li>
                                    <li><code>javascript: viafirma.init()</code></li>
								</ul>
							</div>
						</div>
					</div>
				</div>
				
				<p>
					<a href="../">&larr; Inicio</a>
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

