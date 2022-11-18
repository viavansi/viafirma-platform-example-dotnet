<%@ Page Language="C#" AutoEventWireup="true" Async="true" CodeBehind="exampleSignatureViafirmaDesktopResult.aspx.cs" Inherits="EjemploWebViafirmaClientDotNet.exampleSignatureViafirmaDesktopResult" %>

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

        <h1 id="header"><a href="..">
            <img src="../images/content/logo.png" alt="Viafirma" /></a></h1>

        <div id="content">
            <h2>Resultado del proceso de firma por invocación directa a Viafirma Desktop</h2>

            <p><strong>ID de Operación: </strong><%=operationId%></p>

            <p><strong>Datos del certificado</strong></p>

            <asp:DataList ID="DataListResult" runat="server">

                <ItemTemplate>

                    <table>

                        <tbody>

                            <tr>
                                <th class="width-20"><strong>First Name</strong> </th>
                                <td><%# Eval("certificateValidationData.name") %></td>
                            </tr>

                            <tr>
                                <th class="width-20"><strong>Last Name</strong></th>
                                <td><%# Eval("certificateValidationData.surname1") %> <%# Eval("certificateValidationData.surname2") %></td>
                            </tr>

                            <tr>
                                <th class="width-20"><strong>Number User Id</strong></th>
                                <td><%# Eval("certificateValidationData.numberUserId") %></td>
                            </tr>

                            <tr>
                                <th class="width-20"><strong>E-mail</strong></th>
                                <td><%# Eval("certificateValidationData.email") %></td>
                            </tr>

                            <tr>
                                <th class="width-20"><strong>Ca Name</strong></th>
                                <td><%# Eval("certificateValidationData.ca") %></td>
                            </tr>

                            <tr>
                                <th class="width-20"><strong>Oids</strong></th>
                                <td><%# Eval("certificateValidationData.certificatesPropertiesHTML") %></td>
                            </tr>

                            <tr>
                                <th class="width-20"><strong>Type Certificate</strong></th>
                                <td><%# Eval("certificateValidationData.type") %></td>
                            </tr>

                        </tbody>

                    </table>
                  </ItemTemplate>
            </asp:DataList>

            <p><strong>Resultado del proceso de firma. Documentos firmados</strong></p>

            <asp:DataList ID="SignatureListResult" runat="server">
                <ItemTemplate>
                    <%# Eval("Id")%> <br \ />
                    <p class="codBarras">
                        <img alt="Imagen QR de justificante del resultado de la firma del fichero" width="500" src="<%=global_asax.URL_VIAFIRMA %>/downloadComprobanteQR?codFirma=<%# Eval("Id")%>&amp;tipo=png" title="Imagen QR de justificante del resultado de la firma del fichero" />
                    </p>

                   <p class="descargaComprobante">
                        <a class="descarga" target="_blank" href="<%=global_asax.URL_VIAFIRMA%>/v/<%# Eval("Id")%>?j" title="Descargar Comprobante">Descarga de comprobante de firma</a>
                    </p>

                    <p class="descargaComprobante">
                        <a class="descarga" target="_blank" href="<%=global_asax.URL_VIAFIRMA%>/v/<%# Eval("Id")%>?d" title="Descargar Documento firmado">Descarga de documento firmado</a>
                    </p>

                    <p class="descargaComprobante">
                        <a class="descarga" target="_blank" href="<%=global_asax.URL_VIAFIRMA%>/v/<%# Eval("Id")%>?o" title="Descargar Documento firmado">Descarga de documento original</a>
                    </p>

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

