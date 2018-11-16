<%@ Page Title="" Language="C#" MasterPageFile="~/UserPages/Share2.master" AutoEventWireup="true" CodeFile="doctorInfoFill.aspx.cs" Inherits="UserPages_doctorInfoFill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../UserCss/share2.css" rel="stylesheet" />
    <link href="../UserCss/hosInfo.css" rel="stylesheet" />
    <link href="../Css/adiminbodies.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br />
<table style="width:100%;">
      <tr>
        <td>
          <asp:Button Text="ADD" BorderStyle="None" ID="Tab1" CssClass="Initial" runat="server" OnClick="Tab1_Click" style="border-right:2px solid white;" />
          <asp:Button Text="DELETE" BorderStyle="None" ID="Tab2" CssClass="Initial" runat="server" OnClick="Tab2_Click" style="border-right:2px solid white;"/>
          <asp:Button Text="SHOW" BorderStyle="None" ID="Tab3" CssClass="Initial" runat="server" OnClick="Tab3_Click" style="border-right:2px solid white;"/>
           <asp:Button Text="UPDATE" BorderStyle="None" ID="Tab4" CssClass="Initial" runat="server" OnClick="Tab4_Click" />
          <asp:MultiView ID="MainView" runat="server">
            <asp:View ID="View1" runat="server">
              <table style="width: 100%; border-width: 2px; border-color: #2a75b5; border-style: solid">
                <tr>
                  <td>
                    <div class="container">
                        <table>
                            <tr>
                                <th colspan="2"> Adding information about Doctors</th>
                            </tr>
                            <tr>
                                <td style="width:50%;">
                                    <asp:FileUpload ID="FileUpload1" runat="server"/>
                                    <asp:Button ID="Button2" runat="server" Text="Upload Hospital Image" OnClick="Button2_Click"/>

                                </td>
                                <td style="width:50%;">
                                    <asp:Image ID="Image1" runat="server" style="height:80px;width:120px;border:2px solid #2a75b5;" Visible="true" ImageUrl="~/Image/calander.jpg" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width:50%;">
                                    <asp:Label ID="Label15" runat="server" Text="Label" CssClass="lbl">Doctor Name</asp:Label>
                                    <asp:TextBox ID="addName" runat="server" CssClass="txt" placeholder="Doctor Name...."></asp:TextBox>
                                </td>
                                <td style="width:50%;">
                                    <asp:Label ID="Label2" runat="server" Text="Label" CssClass="lbl">Select Category</asp:Label>
                                    <asp:DropDownList runat="server" ID="addCategoryList">
                                        <asp:ListItem>--Select Category--</asp:ListItem>
                                        <asp:ListItem>Anesthesiologists</asp:ListItem>
                                        <asp:ListItem>Neurologist</asp:ListItem>
                                        <asp:ListItem>Endocrinologists</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="Label1" runat="server" Text="Label" CssClass="lbl">About Doctor</asp:Label>
                                    <asp:TextBox ID="addDes" runat="server" style="height:100px;width:100%;border-radius:5px;border:1px solid #808080;" placeholder="Description...." TextMode="MultiLine"></asp:TextBox>
                                </td>
                
                             </tr>
                             <tr>
                                 <td style="width:50%;">
                                    <asp:Label ID="Label3" runat="server" Text="Label" CssClass="lbl">Email</asp:Label>
                                    <asp:TextBox ID="addEmail" runat="server" CssClass="txt" placeholder="xyz@gmail.com" TextMode="Email"></asp:TextBox>
                                </td>
                                <td style="width:50%;">
                                     <asp:Label ID="Label4" runat="server" Text="Label" CssClass="lbl">Mobile</asp:Label>
                                     <asp:TextBox ID="addMob" runat="server" CssClass="txt" placeholder="+91 xxxxxxxxxx"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:50%;">
                                    <asp:Label ID="Label5" runat="server" Text="Label" CssClass="lbl">Hospitals Id </asp:Label>
                                    <asp:TextBox ID="addHosId" runat="server" CssClass="txt" placeholder="Hospital Id..."></asp:TextBox>
                                </td>
                                <td style="width:50%;">
                                    <asp:Label ID="Label6" runat="server" Text="Label" CssClass="lbl">Working Time</asp:Label>
                                    <asp:TextBox ID="addTime" runat="server" CssClass="txt" placeholder="00:00AM to 00:00PM"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="Button1" runat="server" Text="Add Details" CssClass="btn" OnClick="Button1_Click" />
                                </td>
                            </tr>
                         </table>        
                     </div>
                  </td>
                </tr>
              </table>
            </asp:View>
            <asp:View ID="View2" runat="server">
              <table style="width: 100%; border-width: 2px; border-color: #2a75b5; border-style: solid">
                <tr>
                  <td>
                     <asp:Label ID="Label7" runat="server" Text="Enter Hospital Id " CssClass="lbl"></asp:Label>
                     <asp:TextBox ID="delId" runat="server" CssClass="txt"></asp:TextBox>
                     <asp:Button ID="Button6" runat="server" Text="Delete" CssClass="btn" OnClick="Button6_Click" />
                  </td>
                </tr>
              </table>
            </asp:View>
            <asp:View ID="View3" runat="server">
              <table style="width: 100%; border-width: 2px; border-color: #2a75b5; border-style: solid">
                <tr>
                  <td>
                      <asp:GridView ID="GridView1" runat="server" AllowPaging="true" PageSize="50" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                                    HeaderStyle-CssClass="heade" RowStyle-CssClass="rows" OnPageIndexChanging="GridView1_PageIndexChanging" >
                      </asp:GridView>
                  </td>
                </tr>
              </table>
            </asp:View>
            <asp:View ID="View4" runat="server">
              <table style="width: 100%; border-width: 1px; border-color: #2a75b5; border-style: solid">
                <tr>
                  <td>
                     <div class="container">
                        <table>
                            <tr>
                                <th colspan="2"> <h2 style="color:#0094ff;font-family:'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;text-align:center">Update information about hospitals</h2></th>
                             </tr>
                            <tr>
                                <td style="width:30%;">
                                    <asp:TextBox ID="updId" runat="server" CssClass="txt" placeholder="Enter Doctor ID to  search"></asp:TextBox>
                                </td>
                                <td style="width:70%;">
                                    <asp:Button ID="Button3" runat="server" Text="Search ID" CssClass="btn" OnClick="Button3_Click"/>
                                </td>
                            </tr>
                             <tr>
                                <td style="width:50%;">
                                    <asp:FileUpload ID="FileUpload2" runat="server"/>
                                    <asp:Button ID="Button5" runat="server" Text="Upload Hospital Image" OnClick="Button5_Click"/>

                                </td>
                                <td style="width:50%;">
                                    <asp:Image ID="Image2" runat="server" style="height:80px;width:120px;border:2px solid #2a75b5;" Visible="true"/>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:50%;">
                                    <asp:Label ID="Label8" runat="server" Text="Label" CssClass="lbl">Doctor Name</asp:Label>
                                    <asp:TextBox ID="updName" runat="server" CssClass="txt" placeholder="Enter New Doctor Name...."></asp:TextBox>
                                </td>
                                <td style="width:50%;">
                                    <asp:Label ID="Label9" runat="server" Text="Label" CssClass="lbl" style="border-radius:5px">Select Category</asp:Label>
                                    <asp:DropDownList runat="server" ID="updCategory">
                                        <asp:ListItem>--Select Category--</asp:ListItem>
                                        <asp:ListItem>Anesthesiologists</asp:ListItem>
                                        <asp:ListItem>Neurologist</asp:ListItem>
                                        <asp:ListItem>Endocrinologists</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="Label10" runat="server" Text="Label" CssClass="lbl">Doctor Description</asp:Label>
                                    <asp:TextBox ID="updDes" runat="server" style="height:100px;width:100%;border-radius:5px;border:none;" placeholder="Tell me new story about doctor" TextMode="MultiLine"></asp:TextBox>
                                </td>
                
                             </tr>
                             <tr>
                                 <td style="width:50%;">
                                    <asp:Label ID="Label11" runat="server" Text="Label" CssClass="lbl">Email Id</asp:Label>
                                    <asp:TextBox ID="updEmail" runat="server" CssClass="txt" placeholder="xyz@gmail.com"></asp:TextBox>
                                </td>
                                <td style="width:50%;">
                                     <asp:Label ID="Label12" runat="server" Text="Label" CssClass="lbl">Mobile No.</asp:Label>
                                     <asp:TextBox ID="updMob" runat="server" CssClass="txt" placeholder="+91 xxxxxxxxx"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:50%;">
                                    <asp:Label ID="Label13" runat="server" Text="Label" CssClass="lbl">Hospital Name </asp:Label>
                                    <asp:TextBox ID="updHosId" runat="server" CssClass="txt" placeholder="Hospital Name"></asp:TextBox>
                                </td>
                                <td style="width:50%;">
                                    <asp:Label ID="Label14" runat="server" Text="Label" CssClass="lbl">Working Time</asp:Label>
                                    <asp:TextBox ID="updTime" runat="server" CssClass="txt" placeholder="00:00AM to 00:00PM"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                 <td colspan="2">
                                    <asp:Button ID="Button4" runat="server" Text="Update Record" CssClass="btn" OnClick="Button4_Click"/>
                                 </td>
                            </tr>
                        </table>        
                    </div>
                  </td>
                </tr>
              </table>
            </asp:View>
          </asp:MultiView>
        </td>
      </tr>
    </table>
</asp:Content>

