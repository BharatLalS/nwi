<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="EmpSol.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 28px;
        }

        .auto-style2 {
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style:"border-spacing=10px">
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label1" runat="server" Text="Employee ID(EmpId)"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="EmpIdBox" runat="server" CssClass="auto-style1" ReadOnly="True"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="EmpIdBox" Display="Dynamic" ValidationGroup="Emp" ForeColor="Red" runat="server" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Employee Name(EmpName)"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="EmpNameBox" runat="server" CssClass="auto-style1"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="EmpNameBox" Display="Dynamic" ValidationGroup="Emp" ForeColor="Red" runat="server" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="EmpNameBox" ErrorMessage="Field can't have number or special character" ForeColor="#FF0066"  ValidationExpression="^[a-zA-Z\s]+$"></asp:RegularExpressionValidator>
                    
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Employee EmailId(EmpEmailId)"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="EmpEmailBox" runat="server" CssClass="auto-style1"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="EmpEmailBox" Display="Dynamic" ValidationGroup="Emp" ForeColor="Red" runat="server" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="EmpEmailBox" ErrorMessage="Please enter valid email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">  
                    </asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Employee Contact No.(EmpConId)"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="ContactBox" runat="server" CssClass="auto-style1" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="ContactBox" Display="Dynamic" ValidationGroup="Emp" ForeColor="Red" runat="server" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="ContactBox" ErrorMessage="Contact no. can be 10 digit,number only" ForeColor="Red" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>      
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Employee Salary(EmpSal)"></asp:Label>
                    </td>
                    <td>
                            <asp:HiddenField Id="hfId" runat="server" />
                        <asp:TextBox ID="SalBox" runat="server" CssClass="auto-style1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="SalBox" Display="Dynamic" ValidationGroup="Emp" ForeColor="Red" runat="server" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="SalBox" ErrorMessage="Salary can be number only" ForeColor="Red" ValidationExpression="^[0-9]{1,10}$"> </asp:RegularExpressionValidator>
                        </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="Submit Employee Image(EmpImage)"></asp:Label>
                    </td>
                    <td>
                        <asp:FileUpload ID="ImageUpload" runat="server" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="ImageUpload" Display="Dynamic" ValidationGroup="Emp" ForeColor="Red" runat="server" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                        </td>
                    <td>
                        <asp:Label ID="lblImage" runat="server" Visible="false"></asp:Label>
                        <asp:Image ID="ImageID" runat="server"/>
                    </td>
                </tr>

            </table>
            <asp:Button ID="BtnSubmit" runat="server" Text="Submit" OnClick="BtnSubmit_Click" />
        </div>

        <asp:GridView ID="GdView" AllowPaging="true" DataKeyNames="Id" PageSize="5" OnPageIndexChanging="GdView_PageIndexChanging" OnSelectedIndexChanging="GdView_SelectedIndexChanging" OnRowDeleting="GdView_RowDeleting" AutoGenerateColumns="false" runat="server" style="width: 651px">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="EmpId" HeaderText="EmpId" SortExpression="EmpId" />
                <asp:BoundField DataField="EmpName" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="EmpEmailId" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="EmpConNo" HeaderText="ContactNo" SortExpression="ContactNo" />
                <asp:BoundField DataField="EmpSal" HeaderText="Salary" SortExpression="Salary" />
                <asp:TemplateField HeaderText="Image">
                        <ItemTemplate>
                           <img src="<%# Eval("EmpImage") %>" style="max-height:50px"/>            
                         </ItemTemplate>
                    </asp:TemplateField>
                <asp:TemplateField HeaderText="Properties">
                        <ItemTemplate>
                            <asp:LinkButton ID="btEdit" runat="server" CommandName="Select">Edit</asp:LinkButton>
                            <asp:LinkButton ID="btDelete" runat="server" CommandName="Delete">Delete</asp:LinkButton>                 
                         </ItemTemplate>
                    </asp:TemplateField>
            </Columns>
        </asp:GridView>

    </form>
    </body>
</html>
