<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<JabMvcAjaxDemo.Models.StudentModel>" %>

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
                <td colspan="2" style="padding-right: 10px;" align="right">
                    <input type="submit" value="Create" />
                </td>
            </tr>
        </table>
    </fieldset>
</div>

