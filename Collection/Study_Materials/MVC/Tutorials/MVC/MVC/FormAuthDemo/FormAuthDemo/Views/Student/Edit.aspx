<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<FormAuthDemo.Models.StudentModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Update Student Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

       <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true, "User creation was unsuccessful. Please correct the errors and try again.") %>
    <div>
        <fieldset>
            <legend>Create Student Account</legend>
            <table>
                <tr>
                    <td>
                        Student Name:
                    </td>
                    <td>
                        <%: Html.TextBoxFor(m => m.StudentName) %>
                    </td>
                </tr>                            
                <tr>
                    <td>
                        Date of Birth:
                    </td>
                    <td>
                        <%: Html.TextBoxFor(m => m.DateOfBirth) %>
                    </td>
                </tr>
                <tr>
                    <td>
                        Sex:
                    </td>
                    <td>
                        <%: Html.TextBoxFor(m => m.Sex) %>
                    </td>
                </tr>
                <tr>
                    <td>
                        Admission:
                    </td>
                    <td>
                       <%: Html.TextBoxFor(m => m.Adminssion) %>
                    </td>
                </tr>
                <tr>
                    <td>
                        Income
                    </td>
                    <td>
                        <%: Html.TextBoxFor(m => m.Income) %>
                    </td>
                </tr>    
                <tr>
                    <td colspan="2" style="padding-right:10px;" align="right">
                        <input type="submit" value="Update" />
                    </td>
                </tr>            
        </fieldset>
    </div>
    <% } %>

</asp:Content>
