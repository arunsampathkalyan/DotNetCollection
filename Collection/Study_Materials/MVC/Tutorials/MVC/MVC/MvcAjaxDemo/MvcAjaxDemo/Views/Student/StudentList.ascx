<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<MvcAjaxDemo.Models.StudentModel>>" %>

    <table>
        <tr>
            
            <th>
                StudentID
            </th>
            <th>
                StudentName
            </th>
            <th>
                DateOfBirth
            </th>
            <th>
                Sex
            </th>
            <th>
                Adminssion
            </th>
            <th>
                Income
            </th>
            <th></th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>            
            <td>
                <%: item.StudentID %>
            </td>
            <td>
                <%: item.StudentName %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.DateOfBirth) %>
            </td>
            <td>
                <%: item.Sex %>
            </td>
            <td>
                <%: item.Adminssion %>
            </td>
            <td>
                <%: String.Format("{0:F}", item.Income) %>
            </td>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new {  id=item.StudentID }) %> |
                <%: Html.ActionLink("Details", "Details", new {  id=item.StudentID })%> |
                <%: Html.ActionLink("Delete", "Delete", new {  id=item.StudentID })%>
            </td>
        </tr>
    
    <% } %>

    </table>
   <%= Ajax.ActionLink("Create", "Create1", new AjaxOptions() { UpdateTargetId = "AddStudentDetails" })%>

    

