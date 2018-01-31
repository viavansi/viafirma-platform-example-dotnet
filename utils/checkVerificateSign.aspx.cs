using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using Viafirma;
using System.Reflection;
using System.Text;
using ViafirmaClientDotNet.Helpers.Verify;

namespace EjemploWebViafirmaClientDotNet.utils
{
    public partial class checkVerificateSign : System.Web.UI.Page
    {
        public signatureVerification[] signatureVerification;
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void verifySignButton_Click(object sender, EventArgs e)
        {
            //Recuperamos la instancia del cliente
            ViafirmaClient viafirmaClient = ViafirmaClientFactory.GetInstance();
            //Recuperamos el identificador de la firma
            String signId = Request.Form["signId"];

            // Instaciamos la clase encargada de añadir los parámetros
            verificationSignatureRequest verificationSignatureRequest = VerifyUtil.newVerify();

            // Vamos añadiendo los parámetros al listado

            // SignatureStandard
            String signatureStandardKey = VerifyParams.SIGNATURE_STANDARD_KEY;
            String signatureStandardValue = VerifyParams.PADES_SIGNATURE_STANDARD;
            // Añadimos el parámetro SignatureStandard
            VerifyUtil.AddParameter(verificationSignatureRequest, signatureStandardKey, signatureStandardValue);

            // TypeSign
            String typeSignKey = VerifyParams.TYPE_SIGN_KEY;
            String typeSignValue = VerifyParams.ENVELOPED_TYPE_SIGN;
            // Añadimos el parámetro TypeSign
            VerifyUtil.AddParameter(verificationSignatureRequest, typeSignKey, typeSignValue);

            // Sign ID
            String signIdKey = VerifyParams.SIGNATURE_ID_KEY;
            String signIdValue = signId;
            // Añadimos el parámetro TypeSign
            VerifyUtil.AddParameter(verificationSignatureRequest, signIdKey, signIdValue);

            signatureVerification = viafirmaClient.verifySignature(verificationSignatureRequest);

        }
    }
}