<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<FirstApplicationDemo.Models.User>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <script src="../../Scripts/MicrosoftAjax.js" type="text/javascript"></script>

    <script src="../../Scripts/MicrosoftMvcValidation.js" type="text/javascript"></script>

    <h2>Create</h2>

    <% Html.EnableClientValidation(); %>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.AuthorityId) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.AuthorityId) %>
                <%: Html.ValidationMessageFor(model => model.AuthorityId) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Username) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Username) %>
                <%: Html.ValidationMessageFor(model => model.Username) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Password) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Password) %>
                <%: Html.ValidationMessageFor(model => model.Password) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Firstname) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Firstname) %>
                <%: Html.ValidationMessageFor(model => model.Firstname) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Surname) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Surname) %>
                <%: Html.ValidationMessageFor(model => model.Surname) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.UserTypeId) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.UserTypeId) %>
                <%: Html.ValidationMessageFor(model => model.UserTypeId) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Active) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Active) %>
                <%: Html.ValidationMessageFor(model => model.Active) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.RegistrationId) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.RegistrationId) %>
                <%: Html.ValidationMessageFor(model => model.RegistrationId) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Suspended) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Suspended) %>
                <%: Html.ValidationMessageFor(model => model.Suspended) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.RegistrationNumber) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.RegistrationNumber) %>
                <%: Html.ValidationMessageFor(model => model.RegistrationNumber) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.JobDescription) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.JobDescription) %>
                <%: Html.ValidationMessageFor(model => model.JobDescription) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.CompanyName) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.CompanyName) %>
                <%: Html.ValidationMessageFor(model => model.CompanyName) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.BuildingName) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.BuildingName) %>
                <%: Html.ValidationMessageFor(model => model.BuildingName) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.StreetName) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.StreetName) %>
                <%: Html.ValidationMessageFor(model => model.StreetName) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Town) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Town) %>
                <%: Html.ValidationMessageFor(model => model.Town) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.CountyorDistrict) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.CountyorDistrict) %>
                <%: Html.ValidationMessageFor(model => model.CountyorDistrict) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Country) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Country) %>
                <%: Html.ValidationMessageFor(model => model.Country) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Postcode) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Postcode) %>
                <%: Html.ValidationMessageFor(model => model.Postcode) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Telephone) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Telephone) %>
                <%: Html.ValidationMessageFor(model => model.Telephone) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Email) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Email) %>
                <%: Html.ValidationMessageFor(model => model.Email) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.LastLogin) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.LastLogin) %>
                <%: Html.ValidationMessageFor(model => model.LastLogin) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.FailCount) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.FailCount) %>
                <%: Html.ValidationMessageFor(model => model.FailCount) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Approved) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Approved) %>
                <%: Html.ValidationMessageFor(model => model.Approved) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.DeletedOn) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.DeletedOn) %>
                <%: Html.ValidationMessageFor(model => model.DeletedOn) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.AddedBy) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.AddedBy) %>
                <%: Html.ValidationMessageFor(model => model.AddedBy) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.AddedOn) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.AddedOn) %>
                <%: Html.ValidationMessageFor(model => model.AddedOn) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.ModifiedBy) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.ModifiedBy) %>
                <%: Html.ValidationMessageFor(model => model.ModifiedBy) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.ModifiedOn) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.ModifiedOn) %>
                <%: Html.ValidationMessageFor(model => model.ModifiedOn) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.PrimaryVesselOwnerId) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.PrimaryVesselOwnerId) %>
                <%: Html.ValidationMessageFor(model => model.PrimaryVesselOwnerId) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.DateOfBirth) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.DateOfBirth) %>
                <%: Html.ValidationMessageFor(model => model.DateOfBirth) %>
            </div>
            
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

