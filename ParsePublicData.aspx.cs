using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmiratesId.AE.PublicData;

namespace ZFDemoSite
{
    public partial class ParsePublicData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ef_idn_cn = Request.Params["ef_idn_cn"];
            string ef_non_mod_data = Request.Params["ef_non_mod_data"];
            string ef_mod_data = Request.Params["ef_mod_data"];
            string ef_sign_image = Request.Params["ef_sign_image"];
            string ef_photo = Request.Params["ef_photo"];
            string ef_root_cert = Request.Params["ef_root_cert"];
            string ef_home_address = Request.Params["ef_home_address"];
            string ef_work_address = Request.Params["ef_work_address"];

            string certsPath = Request.MapPath("~/data_signing_certs");

            bool nonMod = false;
            bool mod = false;
            bool signImage = false;
            bool photo = false;
            bool homeAddress = false;
            bool workAddress = false;
            PublicDataParser parser = null;

            try
            {
                parser = new PublicDataParser(ef_idn_cn, certsPath);
                nonMod = parser.parseNonModifiableData(ef_non_mod_data);
                mod = parser.parseModifiableData(ef_mod_data);
                photo = parser.parsePhotography(ef_photo);
                signImage = parser.parseSignatureImage(ef_sign_image);
                homeAddress = parser.parseHomeAddressData(ef_home_address);
                workAddress = parser.parseWorkAddressData(ef_work_address);
                parser.parseRootCertificate(ef_root_cert);
            }
            catch (Exception ex)
            {

            }

            NonMod.Text = nonMod.ToString();
            Mod.Text = mod.ToString();
            SignImage.Text = "".Equals(ef_sign_image) ? "N/A" : signImage.ToString();
            Photo.Text = "".Equals(ef_photo) ? "N/A" : photo.ToString();
            HomeAddress.Text = "".Equals(ef_home_address) ? "N/A" : homeAddress.ToString();
            WorkAddress.Text = "".Equals(ef_work_address) ? "N/A" : workAddress.ToString();

            FullName.Text = parser.getFullName();
            IDN.Text = parser.getIdNumber();
            CardNumber.Text = parser.getCardNumber();
            Title.Text = parser.getTitle();
            Nationality.Text = parser.getNationality();
            IssueDate.Text = parser.getIssueDate().Value.ToString("dd/MM/yyyy");
            ExpiryDate.Text = parser.getExpiryDate().Value.ToString("dd/MM/yyyy");

            IdType.Text = parser.getIdType();
            Sex.Text = parser.getSex();
            DoB.Text = parser.getDateOfBirth() == null ? "" : parser.getDateOfBirth().Value.ToString("dd/MM/yyyy");
            FullName_ar.Text = parser.getArabicFullName();
            MaritalStatus.Text = parser.getMaritalStatus();
            Occupation.Text = parser.getOccupation() == null ? "" : parser.getOccupation();
            OccupationField.Text = parser.getOccupationField() == null ? "" : parser.getOccupationField();
            Title_ar.Text = parser.getArabicTitle();
            Nationality_ar.Text = parser.getArabicNationality();
            MotherName.Text = parser.getMotherFullName() == null ? "" : parser.getMotherFullName();
            MotherName_ar.Text = parser.getMotherFullName_ar() == null ? "" : parser.getMotherFullName_ar();
            FamilyId.Text = parser.getFamilyID();
            HusbandIDN.Text = parser.getHusbandIDN();
            SponsorType.Text = parser.getSponsorType();
            SponsorName.Text = parser.getSponsorName();
            SponsorUnifiedNumber.Text = parser.getSponsorUnifiedNumber();
            ResidencyType.Text = parser.getResidencyType();
            ResidencyNumber.Text = parser.getResidencyNumber();
            ResidencyExpiryDate.Text = parser.getResidencyExpiryDate() == null ? "" : parser.getResidencyExpiryDate().Value.ToString("dd/MM/yyyy");

            if(parser.getPhotography() != null)
                PhotoBase64.Src = "data:image/jpeg;base64," + Convert.ToBase64String(parser.getPhotography());
            if (parser.getHolderSignatureImage() != null)
                SignaturePhotoBase64.Src = "data:image/tiff;base64," + Convert.ToBase64String(parser.getHolderSignatureImage());
        }
    }
}
