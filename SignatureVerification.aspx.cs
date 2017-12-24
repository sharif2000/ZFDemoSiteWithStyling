using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography.X509Certificates;
using Org.BouncyCastle.X509;
using System.IO;
using EmiratesId.AE.Exceptions;
using EmiratesId.AE.PKI;
using System.Configuration;

namespace ZFDemoSite
{
    public partial class SignatureVerification : System.Web.UI.Page
    {
        private string validationMethodConf;
        private string ocspUrl;
        private string issuersPath;
        private string crlsPath;

        protected void Page_Load(object sender, EventArgs e)
        {
            validationMethodConf = ConfigurationSettings.AppSettings["ValidationMethod"];
            ocspUrl = ConfigurationSettings.AppSettings["OCSP_URL"];
            issuersPath = Request.MapPath("~/ca_certs");
            crlsPath = Request.MapPath("~/crls");

            byte[] data = null;
            byte[] signature = null;
            X509Certificate2 cert = null;

            String signType = Request.Params["signType"];

            if ("Auth".Equals(signType))
            {
                data = (byte[])Session["Challenge"];
            }
            else if ("Sign".Equals(signType))
            {
                data = System.Text.Encoding.ASCII.GetBytes(Request.Params["SignData"]);
            }

            String signatureB64 = Request.Params["signature"];
            signature = Convert.FromBase64String(signatureB64);

            String certificateB64 = Request.Params["certificate"];
            byte[] certBin = Convert.FromBase64String(certificateB64);
            try
            {
                cert = new X509Certificate2(certBin);
            }
            catch (Exception ex)
            {
            }

            PKIFacade pkiFacade = new PKIFacade();
            bool sigVerified = false;
            bool certVerified = false;
            try
            {
                certVerified = ValidateCerificate(cert);
                if (certVerified)
                    sigVerified = pkiFacade.Verify(data, cert, signature);
            }
            catch (Exception ex)
            {

            }

            SignatureVerified.Text = sigVerified.ToString();
            CertificateVerified.Text = certVerified.ToString();

            ValidationMethod.Text = validationMethodConf;
        }

        private bool ValidateCerificate(X509Certificate2 cert)
        {

            PKIFacade pkiFacade = new PKIFacade();

            if (validationMethodConf.ToUpper().Equals("OCSP"))
            {
                X509Certificate2 issuer = GetCertificateIssuer(cert, issuersPath);
                if (issuer == null)
                    return false;
                try
                {
                    return pkiFacade.ValidateCertificateOCSP(cert, issuer, ocspUrl);
                }
                catch (MiddlewareException ex)
                {
                    return false;
                }

            }
            else if (validationMethodConf.ToUpper().Equals("CRL"))
            {
                X509Crl crl = GetCertificateCRL(cert, crlsPath);
                if (crl == null)
                    return false;
                try
                {
                    return pkiFacade.ValidateCertificateOffline(cert, crl);
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else if (validationMethodConf.ToUpper().Equals("CDP"))
            {
                try
                {
                    return pkiFacade.ValidateCertificateCDP(cert);
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return false;
        }

        private X509Certificate2 GetCertificateIssuer(X509Certificate2 cert, String issuersPath)
        {
            DirectoryInfo di = new DirectoryInfo(issuersPath);
            FileInfo[] files = di.GetFiles();

            for (int i = 0; i < files.Length; i++)
            {
                try
                {
                    X509Certificate2 issuer = new X509Certificate2(files[i].FullName);
                    if (issuer.Subject.Equals(cert.Issuer))
                        return issuer;
                }
                catch (Exception ex)
                {
                    continue;
                }
            }
            return null;
        }

        private X509Crl GetCertificateCRL(X509Certificate2 cert, String crlsPath)
        {
            DirectoryInfo di = new DirectoryInfo(crlsPath);
            FileInfo[] files = di.GetFiles();

            for (int i = 0; i < files.Length; i++)
            {
                try
                {
                    FileStream fs = new FileStream(files[i].FullName, FileMode.Open, FileAccess.Read);
                    X509Crl crl = new Org.BouncyCastle.X509.X509CrlParser().ReadCrl(fs);
                    fs.Close();
                    X500DistinguishedName crlIssuer = new X500DistinguishedName(crl.IssuerDN.GetEncoded());
                    if (crlIssuer.Name.Equals(cert.Issuer))
                        return crl;
                }
                catch (Exception ex)
                {
                    continue;
                }
            }
            return null;
        }
    }
}
