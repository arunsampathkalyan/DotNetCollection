<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<FirstApplicationDemo.Models.User>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Users List
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Users</h2>

    <table>
        <tr>            
            <th>
                UserId
            </th>
            <th>
                AuthorityId
            </th>
            <th>
                Username
            </th>                  
            <th>
                JobDescription
            </th>
            <th>
                CompanyName
            </th>            
            <th>
                StreetName
            </th>
            <th>
                Town
            </th>            
            <th>
                Country
            </th>
            <th>
                Postcode
            </th>
            <th>
                Telephone
            </th>            
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <%--<td>
                <%: Html.ActionLink("Edit", "Edit", new { id=item.UserId }) %> |
                <%: Html.ActionLink("Details", "Details", new { id=item.UserId })%> |
                <%: Html.ActionLink("Delete", "Delete", new { id=item.UserId })%>
            </td>--%>
            <td>
                <%: item.UserId %>
            </td>
            <td>
                <%: item.AuthorityId %>
            </td>
            <td>
                <%: item.Username %>
            </td>                                    
            <td>
                <%: item.JobDescription %>
            </td>
            <td>
                <%: item.CompanyName %>
            </td>            
            <td>
                <%: item.StreetName %>
            </td>
            <td>
                <%: item.Town %>
            </td>            
            <td>
                <%: item.Country %>
            </td>
            <td>
                <%: item.Postcode %>
            </td>
            <td>
                <%: item.Telephone %>
            </td>            
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

