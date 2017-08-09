<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<FormAuthDemo.Models.LoginModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Login</h2>
       
    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true, "Login was unsuccessful. Please correct the errors and try again.") %>
    <div>        
        <table>
            <tr>
                <td>
                    Username:
                </td>
                <td>
                    <%: Html.TextBoxFor(m => m.UserName) %>
                </td>
            </tr>
            <tr>
                <td>
                    Password:
                </td>
                <td>
                    <%: Html.PasswordFor(m => m.Password) %>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="right">
                    <input type="submit" value="LogIn" />
                </td>
            </tr>
        </table>
    </div>
    <% } %>
</asp:Content>
