<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginDirectViafirmaDesktop.aspx.cs" Inherits="EjemploWebViafirmaClientDotNet.loginDirectViafirmaDesktop" Async="true" %>

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
				<h2>Autenticar al usuario usando llamada a Viafirma Desktop por protocolo (requiere Javascript)</h2>
				
				<div class="group">
					<div class="col width-63 append-02">
						<div class="box">
							<h3 class="box-title">Autenticación del usuario con Viafirma</h3>
							<div class="box-content">
								<p>En este ejemplo se realiza la autenticación del usuario utilizando Javascript para la invocación a Viafirma Desktop por protocolo. Requiere código Javascript local.</p>
                                <form id="form1" runat="server">    
                                <% //(Request.Params["autenticar"]
                                        if (desktopInvocation == null) { %>
								    <p>
			                            <asp:button  ID="autenticarBoton" runat="server" 
                                                Text="Iniciar proceso de autenticación"  OnClick="Autenticar_ClickAsync" 
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
                                            document.getElementById("loading").innerHTML = "";
                                            document.getElementById("authError").innerHTML = "Ocurrió un problema durante la autenticación: " + JSON.stringify(response);
                                        }
                                        // If the user cancels the operation in Viafirma Desktop app, this function is invoked
                                        function showCancel(response) {
                                            document.getElementById("loading").innerHTML = "";
                                            document.getElementById("authCancel").innerHTML = "La autenticación fue cancelada: " + JSON.stringify(response);
                                        }
                                        // If the authentication runs ok, this function is invoked - customize it with your own logic 
                                        // For instance, probably you will need to invoke an internal REST service that receives the authentication response object
                                        function showSuccess(response) {
                             	            window.location.replace("./exampleAuthenticationViafirmaDesktopResult.aspx?operationId=" + response.operationId);
                                	        // This code shows operation data in screen... but it is just a sample. It would not be safe to invoke a service with this data,
                                	        // since (probably) any attacker could invoke the same service with fake data, being able to impersonate a 3rd user
                                            //document.getElementById("loading").innerHTML = "";

                                            //document.getElementById("authSuccess").innerHTML = "<p>Operación de autenticación realizada con éxito. Información obtenida:</p><ul>" +
                                            //    "<li><strong>ID de operación</strong>: " + response.operationId + "</li>" +
                                            //    "<li><strong>Identificación usuario</strong>: " + response.numberUserId + "</li>" +
                                            //    "<li><strong>Usuario</strong>: " + response.name + " " + response.surname1 + " " + response.surname2 + "</li>" +
                                            //    "<li><strong>CA</strong>: " + response.shortCa + "</li>" +
                                            //    "</ul>";
                                        }
                                        // Here we initialize the viafirma.js polling 
                                        function initAuth() {
                                            document.getElementById("authButton").style = "display: none;";
                                            document.getElementById("loading").innerHTML = "<img src='./images/icons/ajax-loader.gif' />";

                                            // Start the viafirma JS client: watch the status of a given operationId
                                            // - if the operation fails, "errorCallback" will be called
                                            // - if the operation is cancelled, "cancelCallback" will be called
                                            // - if the operation is completed: "successCallback" will be called
                                            viafirma.init({
                                                // Here we include 
                                               operationId: "<%=desktopInvocation.OperationId%>",
                                                viafirmaUrl: "<%=Viafirma.ViafirmaClientFactory.GetInstance().UrlPublica%>/",
                                                unloadedTime: 30,
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
                                    <p id="authError"></p>
                                    <p id="authCancel"></p>
                                    <p id="authSuccess"></p>
                                    <p id="loading"></p>
                                    <p id="authButton">
                                        <a class="button" href="<%=desktopInvocation.ViafirmaDesktopInvocationLink%>" onClick="initAuth();">Autenticar con Viafirma Desktop</a>
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
									<li><code>prepareAuthForDirectDesktop</code></li>
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
