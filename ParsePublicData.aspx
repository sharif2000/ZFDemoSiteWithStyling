<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ParsePublicData.aspx.cs" Inherits="ZFDemoSite.ParsePublicData" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Zero Footprint Components Demo</title>
<link href="css/style.css" rel="stylesheet" type="text/css" />
<link href="css/top_menu.css" rel="stylesheet" type="text/css" />
</head>

<body>

<div class="container">
  <div id="header">
  <a href="Default.aspx">
    <img class="logo-uae" width="142" height="121" alt="United Arab Emirates" src="images/logo-uae-new.gif" /><img class="flash-banner" width="683" height="119" alt="" src="images/eida-national-day-en.gif" /><img width="142" height="121" alt="Emirates Identity Authority" src="images/logo-eida-new.gif" />
  </a>
  <div>
  <ul class="menu black">
    <li><a href="Default.aspx" title="">Applet Home</a></li>
    <li><a href="Default_activex.aspx" title="">ActiveX Home</a></li>
    <li><a href="#" title="" >About EIDA</a></li>
    <li><a href="#" title="">Contact</a></li>
</ul>
  </div>
    <!-- end .header --></div>
  <div class="content2">
    <form id="form1" runat="server">
    </form>
    <br/>
    <h3>Public Data Verification report</h3>
    
    <table cellpadding="2" cellspacing="2" align="center">
        <tr>   
            <td><strong>File</strong></td>
            <td><strong>Valid Signature?</strong></td>
        </tr>
        <tr>
            <td>Non-Modifiable Data (SF3)</td>
            <td align="center"><asp:Label runat="server" ID="NonMod"></asp:Label></td>
        </tr>
        <tr>
            <td>Modifiable Data (SF5)</td>
            <td align="center"><asp:Label runat="server" ID="Mod"></asp:Label></td>
        </tr>
        <tr>
            <td>Holder Signature Image (SF7)</td>
            <td align="center"><asp:Label runat="server" ID="SignImage"></asp:Label></td>
        </tr>
        <tr>
            <td>Photography</td>
            <td align="center"><asp:Label runat="server" ID="Photo"></asp:Label></td>
        </tr>
        <tr>
            <td>Home Address</td>
            <td align="center"><asp:Label runat="server" ID="HomeAddress"></asp:Label></td>
        </tr>
        <tr>
            <td>Work Address</td>
            <td align="center"><asp:Label runat="server" ID="WorkAddress"></asp:Label></td>
        </tr>
    </table>
    
    <br/>
    <h3>Card Holder Information</h3>
    <div style="padding-left: 30px; font-size: 8pt">
    <table align="center">
        <tr>
            <td><strong>Name</strong></td>
            <td style="padding-right: 20px;"><asp:Label runat="server" ID="FullName"/></td>
        
            <td><strong>IDN:&nbsp;&nbsp;&nbsp;&nbsp;</strong></td>
            <td><asp:Label runat="server" ID="IDN"></asp:Label></td>
            
            <td><strong>Mother Name:&nbsp;</strong></td>
            <td style="padding-right: 20px;"><asp:Label runat="server" ID="MotherName"/></td>
        </tr>
        <tr>
            <td><strong>Name (Ar)</strong></td>
            <td style="padding-right: 20px;"><asp:Label runat="server" ID="FullName_ar"/></td>
            
            <td><strong>Card Number:&nbsp;</strong></td>
            <td><asp:Label runat="server" ID="CardNumber"/></td>
            
            <td><strong>Mother Name (Ar):&nbsp;</strong></td>
            <td><asp:Label runat="server" ID="MotherName_ar"/></td>
            
        </tr>
        <tr>
            <td><strong>Title:&nbsp;</strong></td>
            <td><asp:Label runat="server" ID="Title"/></td>
            
            <td><strong>Nationality:&nbsp;</strong></td>
            <td><asp:Label runat="server" ID="Nationality"/></td>
            
             <td><strong>Family ID:&nbsp;</strong></td>
            <td><asp:Label runat="server" ID="FamilyId"/></td>
        </tr>
        <tr>
            <td><strong>Title(Ar):&nbsp;</strong></td>
            <td><asp:Label runat="server" ID="Title_ar"/></td>
        
            <td><strong>Nationality(Ar):&nbsp;</strong></td>
            <td><asp:Label runat="server" ID="Nationality_ar"/></td>
            
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td><strong>Issue Date:&nbsp;</strong></td>
            <td><asp:Label runat="server" ID="IssueDate"/></td>
            
            <td><strong>Sex:&nbsp;</strong></td>
            <td><asp:Label runat="server" ID="Sex"/></td>
            
            <td><strong>Sponsor Type:&nbsp;</strong></td>
            <td><asp:Label runat="server" ID="SponsorType"/></td>
        </tr>
        <tr>
            <td><strong>Expiry Date:&nbsp;</strong></td>
            <td><asp:Label runat="server" ID="ExpiryDate"/></td>
            
            <td><strong>Date of Birth:&nbsp;</strong></td>
            <td><asp:Label runat="server" ID="DoB"/></td>
            
            <td><strong>Sponsor Name:&nbsp;</strong></td>
            <td><asp:Label runat="server" ID="SponsorName"/></td>
        </tr>
        <tr>
            <td><strong>Marital Status:&nbsp;</strong></td>
            <td><asp:Label runat="server" ID="MaritalStatus"/></td>
            
            <td><strong>Husband IDN:&nbsp;</strong></td>
            <td><asp:Label runat="server" ID="HusbandIDN"/></td>
            
            <td><strong>Sponsor Number:&nbsp;</strong></td>
            <td><asp:Label runat="server" ID="SponsorUnifiedNumber"/></td>
        </tr>
        
        <tr>
            <td><strong>Residency Type:&nbsp;</strong></td>
            <td><asp:Label runat="server" ID="ResidencyType"/></td>
       
            <td><strong>Residency Number:&nbsp;</strong></td>
            <td><asp:Label runat="server" ID="ResidencyNumber"/></td>
            
            <td><strong>Residency Expiry:&nbsp;</strong></td>
            <td><asp:Label runat="server" ID="ResidencyExpiryDate"/></td>
        </tr>
        
        <tr>
            <td><strong>ID Type:&nbsp;</strong></td>
            <td><asp:Label runat="server" ID="IdType"/></td>
       
            <td><strong>Occupation:&nbsp;</strong></td>
            <td><asp:Label runat="server" ID="Occupation"/></td>
            
            <td><strong>Occupation Field:&nbsp;</strong></td>
            <td><asp:Label runat="server" ID="OccupationField"/></td>
        </tr>
        <tr>
            <td><strong>Photo</strong></td>
            <td style="padding-right: 20px;">
                <img alt="Photo" src="" id="PhotoBase64" runat="server"></img>
            </td>
        
            <td colspan="2"><strong>Signature Image</strong></td>
            <td colspan="2">
            <img alt="TIFF format is supported by this browser!" src="" id="SignaturePhotoBase64" runat="server"></img>
            </td>
        </tr>
    </table>
    
   </div>
    
    <br/>
    <!-- end .content --></div>
  <div class="footer">
    <p>&nbsp;EIDA &copy; 2012</p>
    <!-- end .footer --></div>
  <!-- end .container --></div>
</body>
</html>
