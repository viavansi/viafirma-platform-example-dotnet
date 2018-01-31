<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="multisignXML.aspx.cs" Inherits="EjemploWebViafirmaClientDotNet.firmaUser.multisignXML" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
		<title>Viafirma - Kit para desarrolladores</title>
		
		<link rel="stylesheet" href="../css/framework.css" type="text/css" media="screen" />
		<link rel="stylesheet" href="../css/styles.css" type="text/css" media="screen" />
</head>
<body>
   <div id="wrapper">
			<h1 id="header"><a href="../"><img src="../images/content/logo.png" alt="Viafirma" /></a></h1>
			
			<div id="content">
				<h2>Firmas con intervención del usuario</h2>
				
				<div class="group">
					<div class="col width-53 append-02">
						<div class="box">
							<h3 class="box-title">Firma XML</h3>
							<div class="box-content">
								<p>En este ejemplo se realiza la firma de un documento XML con formato XAdES en Viafirma con la intervención directa del usuario.</p>
                                    <form id="multiSignForm" runat="server">
                                        <asp:Button id="MultisignBtnId" runat="server" text="Multifirma XML"
                                            OnClick="MultiSign_OnClick" Width="245" />
                                    </form>
                             </div>
                         </div>
                     </div>
                     <div class="col width-45">
						<div class="box">
							<h3 class="box-title">Métodos utilizados</h3>
							<div class="box-content">
								<ul>
									<li>PrepareFirmaWithTypeFileAndFormatSign</li>
									<li>enabledMultiSign</li>
					                <li>Sign</li>
								</ul>
							</div>
						</div>
					</div>
                 </div>
                 <p>
					<a href="./">&larr; Volver</a>
				</p>
            </div>
            <div id="footer">
				<p class="left">
					Acceda a <a href="http://www.viafirma.com">Viafirma</a> o consulte más información técnica en <a href="http://developers.viafirma.com/">Viafirma Developers</a> 
				</p>
				<p>
					<small>Version 0.asp</small>
				</p>
			</div>
        </div>
    </body>
</html>
