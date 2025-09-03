using System;
using System.Web;

using System.IO;
using Viafirma;
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
            //String signId = Request.Form["signId"];

            HttpPostedFile PostedFile = Request.Files["SignedFile"];

           // Instaciamos la clase encargada de añadir los parámetros
            verificationSignatureRequest verificationSignatureRequest = VerifyUtil.newVerify();

            // Vamos añadiendo los parámetros al listado

            // SignatureStandard
            string signatureStandardKey = VerifyParams.SIGNATURE_STANDARD_KEY;
            //string signatureStandardValue = VerifyParams.PADES_SIGNATURE_STANDARD;
            string signatureStandardValue = Request.Form["signatureStandard"];
            // Añadimos el parámetro SignatureStandard
            VerifyUtil.AddParameter(verificationSignatureRequest, signatureStandardKey, signatureStandardValue);

            // TypeSign
            string typeSignKey = VerifyParams.TYPE_SIGN_KEY;
            string typeSignValue = VerifyParams.ATTACHED_TYPE_SIGN;
            // Añadimos el parámetro TypeSign
            VerifyUtil.AddParameter(verificationSignatureRequest, typeSignKey, typeSignValue);

            if (PostedFile != null && PostedFile.ContentLength > 0)
            {
                verificationSignatureRequest.signedDocument = new BinaryReader(PostedFile.InputStream).ReadBytes(PostedFile.ContentLength);
            }

            /* Sign ID
            String signIdKey = VerifyParams.SIGNATURE_ID_KEY;
            String signIdValue = signId;
            // Añadimos el parámetro TypeSign
            VerifyUtil.AddParameter(verificationSignatureRequest, signIdKey, signIdValue); */

            signatureVerification = viafirmaClient.verifySignature(verificationSignatureRequest);

        }
    }
}