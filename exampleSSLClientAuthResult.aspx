<%@ Page Language="C#" AutoEventWireup="true" Async="true" CodeBehind="exampleSSLClientAuthResult.aspx.cs" Inherits="EjemploWebViafirmaClientDotNet.exampleSSLClientAuthResult" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">


		<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">

		<title>Viafirma - Examples</title>		

		<link rel="stylesheet" href="../css/framework.css" type="text/css" media="screen" />

		<link rel="stylesheet" href="../css/styles.css" type="text/css" media="screen" />

	</head>
<body>
<div id="wrapper">

			<h1 id="header"><a href=".."><img src="../images/content/logo.png" alt="Viafirma" /></a></h1>
		    <script type="text/javascript">
			    document.execCommand("ClearAuthenticationCache");
			    if(window.crypto) {
				    window.crypto.logout();
			    }
		    </script>
			<div id="content">
                <h2>Resultado del proceso de autenticación mediante SSL client auth</h2>
                <asp:DataList ID="DataListResult" runat="server">

                    <ItemTemplate>

                        <table>

					<tbody>

						<tr><th class="width-20"><strong>First Name</strong> </th><td><%# Eval("name") %></td></tr>

						<tr><th class="width-20"><strong>Last Name</strong></th><td><%# Eval("surname1") %> <%# Eval("surname2") %></td></tr>

						<tr><th class="width-20"><strong>Number User Id</strong></th><td><%# Eval("numberUserId") %></td></tr>

						<tr><th class="width-20"><strong>E-mail</strong></th><td> <%# Eval("email") %></td></tr>

						<tr><th class="width-20"><strong>Ca Name</strong></th><td> <%# Eval("ca") %></td></tr>

						<tr><th class="width-20"><strong>Oids</strong></th><td><%# Eval("certificatesPropertiesHTML") %></td></tr>

						<tr><th class="width-20"><strong>Type Certificate</strong></th><td> <%# Eval("type") %></td></tr>

					</tbody>

				</table>

                    </ItemTemplate>

                </asp:DataList>
                <p>
				    <a href="./">&larr; Volver</a>
				</p>
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
