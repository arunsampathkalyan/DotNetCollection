<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%= Html.Encode(ViewData["Message"]) %></h2>
    <p>
        Page Rendered:
        <%= DateTime.Now.ToLongTimeString() %>
    </p>
   
    
    <br />
     <div id="statusMessage1">No Status</div>
    <br />
    <br />
    <% using (Ajax.BeginForm("UpdateForm", new AjaxOptions { UpdateTargetId = "statusMessage1" }))
       { %>
    <%= Html.TextBox("textBox1","Enter text")%>
    <%= Ajax.ActionLink("Update Status", "GetStatus", new AjaxOptions { UpdateTargetId = "textEntered" })%>
    <input type="submit" value="Submit" /><br />
    <span id="textEntered">Nothing Entered</span>
    <% } %>
</asp:Content>
