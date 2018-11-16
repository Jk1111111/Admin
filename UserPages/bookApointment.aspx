<%@ Page Title="" Language="C#" MasterPageFile="~/UserPages/Share2.master" AutoEventWireup="true" CodeFile="bookApointment.aspx.cs" Inherits="UserPages_bookApointment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../UserCss/share2.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="../UserCss/bookapointment.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="book_container">
        <table style="width:80%; margin:0% 10%;">
            <tr>
                <td>
                    <div class="box">
                        <span style="color:#000000;font-family:Verdana;font-size:16px;font-weight:600;">Doctor Name :</span>
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label><br />
                        <span style="color:#000000;font-family:Verdana;font-size:16px;font-weight:600;">Hospital Belongs To :</span>
                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label><br />
                        <span style="color:#000000;font-family:Verdana;font-size:16px;font-weight:600;">Specialist in :</span>
                        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label><br />
                        <span style="color:#000000;font-family:Verdana;font-size:16px;font-weight:600;">Email :</span>
                        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label><br />
                        <span style="color:#000000;font-family:Verdana;font-size:16px;font-weight:600;">Mobile No. :</span>
                         <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label><br />
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <span style="color:#ff0000;font-family:Verdana;font-size:20px;font-weight:600;margin-top:5px;">Fill your details to meet with doctor</span>
                </td>
            </tr>
            <tr>

                <td>
                    <asp:TextBox ID="nmtxt" runat="server" CssClass="txt" placeholder="User Name"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="emailtxt" runat="server" CssClass="txt" placeholder="Your Email Id" TextMode="Email"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="mobtxt" runat="server" CssClass="txt" placeholder="Your Mobile No." TextMode="Phone"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="sujectlist" runat="server" CssClass="ddl">
                        <asp:ListItem Selected="True">Choose Your Subject</asp:ListItem>
                        <asp:ListItem>Main Surgery</asp:ListItem>
                        <asp:ListItem>Plastic Surgery</asp:ListItem>
                        <asp:ListItem>Dental</asp:ListItem>
                        <asp:ListItem>Other</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="msgtxt" runat="server" CssClass="multxt" placeholder="Your Message" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Book Apointment" CssClass="btn" OnClick="Button1_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

