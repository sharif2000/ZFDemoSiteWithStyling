using EmiratesId.AE.PublicData;
using Microsoft.SharePoint.Client;
using System;

//using Microsoft.SharePoint;

namespace ZFDemoSite
{
    public partial class TestEIDReader : System.Web.UI.Page
    {
        protected void btnVerifyPubData_Click(object sender, EventArgs e)
        {
            try
            {
                #region Read Submitted EID Data

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

                if (parser.getPhotography() != null)
                    PhotoBase64.Src = "data:image/jpeg;base64," + Convert.ToBase64String(parser.getPhotography());
                if (parser.getHolderSignatureImage() != null)
                    SignaturePhotoBase64.Src = "data:image/tiff;base64," + Convert.ToBase64String(parser.getHolderSignatureImage());

                #endregion Read Submitted EID Data
            }
            catch
            {
                throw new Exception("Exception In Reading Submitted EID Data");
            }

            EIDData userData = new EIDData();
            try
            {
                #region Fill Data To an instance of EIDData Class

                userData.Sex = Sex.Text;
                userData.CardNumber = CardNumber.Text;
                userData.FullName = FullName.Text;
                userData.FullName_ar = FullName_ar.Text;
                userData.Photo = Photo.Text;
                userData.SignImage = SignImage.Text;
                userData.SponsorName = SponsorName.Text;
                userData.DoB = DoB.Text;
                userData.ExpiryDate = ExpiryDate.Text;
                userData.FamilyId = FamilyId.Text;
                userData.Nationality = Nationality.Text;
                userData.Nationality_ar = Nationality_ar.Text;
                userData.IDN = IDN.Text;
                userData.IssueDate = IssueDate.Text;

                #endregion Fill Data To an instance of EIDData Class
            }
            catch
            {
                throw new Exception("Exception In Filling Data To an instance of EIDData Class");
            }

            try
            {
                #region Save Data From EIDData to SharePoint List

                //using (SPSite site = new SPSite("Hajj url"))//Get the Site
                //using (SPWeb web = site.OpenWeb())//Get the Subsite
                //{
                //    web.AllowUnsafeUpdates = true;

                //    //Get the List
                //    SPList hajjList = web.Lists["ListName"];

                //    //Create Empty Item
                //    SPListItem newHajjItem = hajjList.Items.Add();

                //    //Fill Item Data
                //    newHajjItem["Field1InternalName"] = userData.CardNumber;
                //    newHajjItem["Field2InternalName"] = userData.DoB;
                //    newHajjItem["Field3InternalName"] = userData.ExpiryDate;
                //    newHajjItem["Field4InternalName"] = userData.FamilyId;

                //    //Save changes to SharePoint
                //    newHajjItem.SaveChanges();

                //    web.AllowUnsafeUpdates = false;
                //}

                #endregion Save Data From EIDData to SharePoint List

                //string filePath = @"C:\Users\spadmin.ZAYED\Desktop\images\controls.png";
                //string LibraryName = "Hajj";
                //string siteURL = "http://zf-sp/orgchart/ProgramsDepartment/hajj";
                //string FileNAme = filePath.Substring(filePath.LastIndexOf("\\") + 1);

                //using (ClientContext CTX = new ClientContext(siteURL))
                //{
                //    FileCreationInformation FcInfo = new FileCreationInformation();
                //    FcInfo.Url = FileNAme;
                //    FcInfo.Overwrite = true;
                //    FcInfo.Content = System.IO.File.ReadAllBytes(filePath);

                //    Web myweb = CTX.Web;
                //    List myPLibrary = myweb.Lists.GetByTitle(LibraryName);
                //    myPLibrary.RootFolder.Files.Add(FcInfo);
                //    CTX.ExecuteQuery();
                //}

                using (ClientContext CTX = new ClientContext("http://zf-sp/orgchart/ProgramsDepartment/hajj/"))
                {
                    Web myweb = CTX.Web;

                    //-----------------------------------Production List--------------------------------------------

                    List mylist = myweb.Lists.GetByTitle("طلب حج");

                    //----------------------------------Test List---------------------------------------------------

                    //List mylist = myweb.Lists.GetByTitle("Hajj");

                    ListItemCreationInformation ItemCreationInfo =
                        new ListItemCreationInformation();
                    Microsoft.SharePoint.Client.ListItem myItem = mylist.AddItem(ItemCreationInfo);

                    //------------------------------------Production list------------------------------------------

                    // myItem["_x0631__x0642__x0645__x0020__x06"] = userData.CardNumber;
                    myItem["_x0627__x0644__x0627__x0633__x060"] = userData.FullName;
                    myItem["_x0627__x0644__x0627__x0633__x06"] = userData.FullName_ar;
                    myItem["_x0627__x0633__x0645__x0020__x06"] = userData.MotherName_ar;
                    myItem["_x0627__x0644__x0646__x0648__x06"] = userData.Sex;
                    myItem["_x062a__x0627__x0631__x064a__x063"] = userData.ExpiryDate;
                    myItem["_x062a__x0627__x0631__x064a__x06"] = userData.DoB;
                    //myItem["_x0627__x0644__x0634__x0631__x06"] = userData.SponsorName;
                    //myItem["_x0631__x0642__x0645__x0020__x060"] = userData.Nationality;
                    myItem["_x0627__x0644__x062c__x0646__x060"] = userData.Nationality_ar;
                    myItem["_x0631__x0642__x0645__x0020__x062"] = userData.IDN;
                    myItem["_x062a__x0627__x0631__x064a__x061"] = userData.IssueDate;
                    myItem["_x062a__x0627__x0631__x064a__x062"] = userData.ResidencyExpiryDate;
                    myItem["Title"] = Req_ID.Text;
                    myItem["_x0627__x0644__x062d__x0627__x06"] = Married.Text;
                    myItem.Update();
                    CTX.ExecuteQuery();

                    // ----------------------------------------- test List---------------------------------------

                    //myItem["_x0631__x0642__x0645__x0020__x06"] = userData.CardNumber;
                    //myItem["_x0627__x0644__x0627__x0633__x06"] = userData.FullName;
                    //myItem["Title"] = userData.FullName_ar;
                    ////myItem[""] = userData.ResidencyExpiryDate;
                    ////myItem["_x0627__x0633__x0645__x0020__x06"] = userData.MotherName_ar;
                    //myItem["_x0627__x0644__x062c__x0646__x06"] = userData.Sex;
                    //myItem["_x062a__x0627__x0631__x064a__x060"] = userData.ExpiryDate;
                    //myItem["_x062a__x0627__x0631__x064a__x06"] = userData.DoB;
                    //myItem["_x0627__x0644__x0634__x0631__x06"] = userData.SponsorName;
                    //myItem["_x0631__x0642__x0645__x0020__x060"] = userData.Nationality;
                    //myItem["_x0627__x0644__x062c__x0646__x060"] = userData.Nationality_ar;
                    //myItem["_x0627__x0644__x0635__x0648__x06"] = userData.IDN;
                    //myItem["_x062a__x0627__x0631__x064a__x061"] = userData.IssueDate;
                    //myItem.Update();
                    //CTX.ExecuteQuery();
                }
            }
            catch
            {
                throw new Exception("Exception In Saving Data From EIDData to SharePoint List");
            }
        }
    }
}