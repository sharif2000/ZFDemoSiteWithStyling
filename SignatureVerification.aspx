<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignatureVerification.aspx.cs" Inherits="ZFDemoSite.SignatureVerification" %>

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
  <div class="content">
  <form id="form1" runat="server">
    </form>
    <br/>
    <h3>Signature Verification report</h3>
    <table cellpadding="2" cellspacing="2" align="center">
        <tr>
            <td>Certificate Validation Method</td>
            <td align="center"><asp:Label runat="server" ID="ValidationMethod"></asp:Label></td>
        </tr>
        <tr>
            <td>Certificate Validated</td>
            <td align="center"><asp:Label runat="server" ID="CertificateVerified"></asp:Label></td>
        </tr>
        <tr>
            <td>Signature Validated</td>
            <td align="center"><asp:Label runat="server" ID="SignatureVerified"></asp:Label></td>
        </tr>
    </table>
    <!-- end .content --></div>
  <div class="footer">
    <p>&nbsp;EIDA &copy; 2012</p>
    <!-- end .footer --></div>
  <!-- end .container --></div>
</body>
</html>
