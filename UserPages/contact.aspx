<%@ Page Title="" Language="C#" MasterPageFile="~/UserPages/Share2.master" AutoEventWireup="true" CodeFile="contact.aspx.cs" Inherits="UserPages_contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../UserCss/share2.css" rel="stylesheet" />
    <link href="../UserCss/contact.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box_con">
        <h1 style="font-size:33px;font-family:Arial;text-align:center;margin:0px;letter-spacing:2px;">Contact Us</h1>
        <h1 style="font-size:20px;font-family:Arial;text-align:center;color:#8f4242;word-spacing:8px;margin:0;font-weight:100;letter-spacing:8px;">Get  in touch...</h1>
        <div class="box_">
            <div class="box">
                <span style="margin-left:60px;font-weight:bold;font-size:24px;font-family:'Arial Unicode MS'">Address</span><br />
                <span  style="margin-left:60px;font-weight:normal;font-size:14px;font-family:'Arial Unicode MS'">LPU, Jalandhar</span>
            </div>
            <div class="box">
                <span style="margin-left:60px;font-weight:bold;font-size:24px;font-family:'Arial Unicode MS'">Call Us</span><br />
                <span  style="margin-left:60px;font-weight:normal;font-size:16px;font-family:'Arial Unicode MS'">+91 8195884441</span>
            </div>
            <div class="box">
                <span style="margin-left:60px;font-weight:bold;font-size:24px;font-family:'Arial Unicode MS'">Email</span><br />
                <span  style="margin-left:60px;font-weight:normal;font-size:16px;font-family:'Arial Unicode MS'">hospicefriendly@gmail.com</span>
            </div>
        </div>
        <table style="width:83%;margin-left:9%;margin-right:8%;">
            <tr>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="txt" placeholder="Name"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" TextMode="Email" CssClass="txt" placeholder="Email"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" TextMode="Phone" CssClass="txt" placeholder="Phone Number"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server" CssClass="txt" placeholder="Subject"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox ID="TextBox5" runat="server" TextMode="MultiLine" CssClass="multxt" placeholder="Message"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="Button1" runat="server" Text="Send Message" CssClass="btn"/>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

