<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<FormAuthDemo.Models.StudentModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Student List
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <p>
        <%: Html.ActionLink("Create new Student", "Create") %>
    </p>

    <table>
        <tr align="center">            
            <th>StudentID</th>
            <th>StudentName</th>
            <th>DateOfBirth</th>
            <th>Sex</th>
            <th>Admission</th>
            <th>Income</th>
            <th></th>
            <th></th>
        </tr>
    <% foreach (var student in Model) { %>
    
        <tr>
            <td> <%: student.StudentID %> </td>
            <td> <%: student.StudentName %> </td>
            <td> <%: student.DateOfBirth %> </td>
            <td> <%: student.Sex %> </td>
            <td> <%: student.Adminssion %> </td>
            <td> <%: student.Income %> </td>            
            <td> <%: Html.ActionLink("Edit", "Edit", new { id = student.StudentID })%> </td>
            <td> <%: Html.ActionLink("Details", "Details", new { id = student.StudentID })%> </td>
            <td> <%: Html.ActionLink("Delete", "Delete", new { id = student.StudentID })%> </td>
        </tr>        

    <% } %>
    </table>

</asp:Content>
