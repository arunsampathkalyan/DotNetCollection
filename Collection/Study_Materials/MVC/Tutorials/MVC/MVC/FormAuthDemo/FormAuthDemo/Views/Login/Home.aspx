<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Home
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Welcome</h2>

    <p>
        You have been successfully logged in our website.           
    </p>
    <p>
        Click here to create student. <%: Html.ActionLink("Create Student", "Create", "Student") %>    
    </p>
</asp:Content>
