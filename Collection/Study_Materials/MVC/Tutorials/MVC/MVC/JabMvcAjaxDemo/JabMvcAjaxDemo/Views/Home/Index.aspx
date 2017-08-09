<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<JabMvcAjaxDemo.Models.StudentModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: ViewData["Message"] %></h2>

    <p>
        <b>This is MVC Ajax implemenation Demo</b>
    </p>

    <div id="UsersList">
        <% Html.RenderPartial("ViewUserDetails"); %>
    </div>

    <% using (Ajax.BeginForm("Create", "Home", new AjaxOptions() { UpdateTargetId = "UsersList" }))
       { %>
    <p>
        <%= Ajax.ActionLink("Create User(s)", "UserCreation", new AjaxOptions { UpdateTargetId = "dvUserDetails" })%>
    </p>
    <div id="dvUserDetails">
    </div>
    <%} %>
</asp:Content>
