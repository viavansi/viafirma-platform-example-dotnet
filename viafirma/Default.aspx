<%@ Page  Language="C#" Inherits="Viafirma.ViafirmaClient"  %>
<%-- 
Página para la gestión de la comunicación con Viafirma.
Nota: Esta página nunca sera visible por el usuario, solo es utilizada para gestionar las refirecciones y configuración específica.
--%>
<script runat="server" >

    // Al gargar la página se realiza todo el procesado para el intercambio de información con Viafirma.
public void Page_Load(Object sender, EventArgs e){
    //Es posible enviar ciertos parametros al servidor en este punto para obtener algunas funcionalidades adicinales
    //this.AddOptionalRequest(PEM); //Obliga a que el servidor envíe el certificado firmante
    //this.AddOptionalRequest(AUTO_SEND); //Si la plataforma detecta solo un certificado, lo utiliza por defecto
    try
    {
        ProcessViafirma();
    }
    catch (InvalidOperationException exc)
    {
        System.Console.WriteLine(exc.Message);
        String messageError = exc.Message;
        Uri url = new Uri(HttpContext.Current.Request.Url, HttpContext.Current.Response.ApplyAppPathModifier("~/errorPage.aspx?errorMessage=" + exc.Message));
        HttpContext.Current.Response.Redirect(url.AbsoluteUri);	
    }   
 	
}

override public void ProcessResponseAutenticaction(Viafirma.Estado estado,Viafirma.UsuarioGenericoViafirma usuario){
	Viafirma.Log.Debug("Autenticación Viafirma realizada correctamente.");
	// Aquí ya tenemos todos los datos asociados al cliente. y redireccionar al usuario a la página destino
	// considerando el usuario ya autenticado.
	if(Viafirma.Estado.OK== estado){
		Session["resultadoAutenticacion"]= usuario;
		Uri url=new Uri(HttpContext.Current.Request.Url, HttpContext.Current.Response.ApplyAppPathModifier("~/resultadoAutenticacion.aspx"));
		HttpContext.Current.Response.Redirect(url.AbsoluteUri);		
	}else if(Viafirma.Estado.FAIL==estado)
    {
        string error = getCodError();
        string mensage = getMessage();
        System.Console.WriteLine("Hay problemas al realizar la verificacion CodError="+ error + " Mensage="+mensage);
        Uri url = new Uri(HttpContext.Current.Request.Url, HttpContext.Current.Response.ApplyAppPathModifier("~/"));
        HttpContext.Current.Response.Redirect(url.AbsoluteUri);	
    }else if(Viafirma.Estado.CANCEL==estado)
    {
        System.Console.WriteLine("El usuario canceló la operación");
        Uri url = new Uri(HttpContext.Current.Request.Url, HttpContext.Current.Response.ApplyAppPathModifier("~/"));
        HttpContext.Current.Response.Redirect(url.AbsoluteUri);
    }else{
        throw new Exception("Se ha producido un error al autenticar.");
	}
}

override public void ProcessResponseSign(Viafirma.Estado estado,Viafirma.FirmaInfoViafirma firma){
	Viafirma.Log.Debug("Firma Viafirma realizada correctamente.");
	// Aquí ya tenemos todos los datos asociados al cliente y a su firma.
    //redireccionamos al usuario a la página destino considerando el usuario ya ha finalizado la firma.
	if(Viafirma.Estado.OK== estado)
    {
		Session["resultadoFirma"]= firma;            
		Uri url=new Uri(HttpContext.Current.Request.Url, HttpContext.Current.Response.ApplyAppPathModifier("~/resultadoFirma.aspx"));
		HttpContext.Current.Response.Redirect(url.AbsoluteUri);
    }
    else if (Viafirma.Estado.FAIL == estado)
    {
        string error = getCodError();
        string mensage = getMessage();
        // Hay problemas al validar.
        System.Console.WriteLine("Hay problemas al realizar la firma CodError="+ error + " Mensage="+mensage);
        throw new Exception("Hay problemas al realizar la verificacion CodError="+ error + " Mensage="+mensage);
    }
    else if (Viafirma.Estado.CANCEL == estado)
    {
        System.Console.WriteLine("El usuario canceló la operación");
        Uri url = new Uri(HttpContext.Current.Request.Url, HttpContext.Current.Response.ApplyAppPathModifier("~/"));
        HttpContext.Current.Response.Redirect(url.AbsoluteUri);

    }
    else
    {
        System.Console.WriteLine("Proceso cancelado por el usuario");
        // throw new Exception("Proceso cancelado por el usuario");
    
    }
} 
</script>