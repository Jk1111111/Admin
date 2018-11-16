<%@ Page Title="" Language="C#" MasterPageFile="~/UserPages/Share2.master" AutoEventWireup="true" CodeFile="doctorDetails.aspx.cs" Inherits="UserPages_doctorDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../UserCss/share2.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <style>
        .contain{
            height:auto;
            width:80%;
            margin:4% 14%;
        }
        .box{
            height:220px;
            width:1000px;
            background-color:#faf6f6;
            border-bottom:2px solid #ff6a00;
            margin-top:10px;
        }
        .box .img{
            height:200px;
            width:200px;
            border-radius:150px;
            cursor:pointer;
            box-shadow:#808080 8px 8px 5px;
            float:left;
        }
        .box .img:hover{
            opacity:.8;
            transition:all ease-in-out;
        }
        .box .box1{
            width:750px;
            margin-left:50px;
            float:left;
        }
        .Btn{
            font-size:20px;
            font-weight:normal;
            color:#204379;
            float:left;
            margin-left:400px;
            margin-top:20px;
            border:2px solid #808080;
            border-radius:5px;
            padding:10px;
            transition: all 0.5s ease-in-out 0s;
            cursor:pointer;
        }
        .Btn:hover{
            color:#ff6a00;
            background-color:#000000;
            border:2px solid #ff6a00;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="contain">
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <div class="box">
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Image") %>' CssClass="img" />
                    <div class="box1">
                        <table style="margin-top:30px;">
                            <tr>
                                <th>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                    <span> From </span>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("HosName") %>'></asp:Label>
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <span>Specialist in :</span>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("Specialist") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span>Contact Me :</span>
                                    <asp:Label ID="Label8" runat="server" Text='<%# Eval("Email") %>'></asp:Label><span>,</span>
                                    <asp:Label ID="Label9" runat="server" Text='<%# Eval("Mobile") %>' ></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span>Availavel Time :</span>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("WorkTime") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label7" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="Button1" runat="server" Text="Book Appointment" CssClass="Btn" OnClick="Button1_click" CommandArgument='<%# Eval("DocId") %>'/>
                                </td>
                            </tr>
                        </table>
                    </div>
                    
                </div>
                
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

