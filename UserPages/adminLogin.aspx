<%@ Page Title="" Language="C#" MasterPageFile="~/UserPages/Share2.master" AutoEventWireup="true" CodeFile="adminLogin.aspx.cs" Inherits="UserPages_adminLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../UserCss/share2.css" rel="stylesheet" />
    <style>
        .box{
            margin:40px 380px;
            height:400px;
            width:500px;
            background-color:#2a75b5;
            border-radius:7px;
            border-collapse:collapse;
            box-shadow:#808080 8px 8px 5px;
        }

        .box tr th{
            padding-top:25px;
            color:#ffffff;
            font-size:large;
            font-family:Arial, Helvetica, sans-serif;
            text-align:center;
            font-size:20px;
        }
        .box tr td{
            padding:5px;
        }
        .lbl{
            color:#ffffff;
            font-family:Arial, Helvetica, sans-serif;
            font-size:16px;
            padding:5px;
            margin:5px 30px;
        }
        .txt{
            border:1px solid #ffffff;
            padding:5px;
            height:30px;
            width:400px;
            margin:10px 30px;
            opacity:.9;
            border-radius:5px;
        }
        .btn {
            margin: 20px 175px;
            text-align: center;
            background-color: #2a75b5;
            color: #ffffff;
            font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
            font-size: large;
            height: 40px;
            width: 100px;
            border: 2px solid #ffffff;
            cursor: pointer;
            transition: .2s;
        }
            .btn:hover {
                background-color: #ffffff;
                color: #2a75b5;
                transition: .2s;
                transition-delay: .2s;
                border-radius: 5px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="box">
        <tr>
            <th>Only Admin Login</th>
        </tr>
        <tr>
            <td>
                 <asp:Label ID="Label1" runat="server" Text="Admin Id" CssClass="lbl"></asp:Label><br />
                <asp:TextBox ID="admId" runat="server" CssClass="txt"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                 <asp:Label ID="Label2" runat="server" Text="Password" CssClass="lbl"></asp:Label><br />
                <asp:TextBox ID="admPass" runat="server" CssClass="txt" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                 <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" CssClass="lbl">
                     <asp:ListItem Value="Hospital"></asp:ListItem>
                     <asp:ListItem Value="Doctor"></asp:ListItem>
                 </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td><asp:Button ID="Button1" runat="server" Text="Submit" CssClass="btn" OnClick="Button1_Click" /></td>
        </tr>
    </table>
</asp:Content>

