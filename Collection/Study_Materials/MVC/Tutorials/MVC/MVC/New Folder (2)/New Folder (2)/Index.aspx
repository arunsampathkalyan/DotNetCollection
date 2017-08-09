<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Secova.NxG.BAS.Model.InteractiveQuestion>" %>
<%@ Import Namespace="Secova.NxG.BAS.Model" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <link href="../../Content/thickbox.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/thickbox.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">

        function RetrieveChecked(checkedValue, questionId) {

            //alert('checkedValue: ' + checkedValue);
            //alert('questionId: ' + questionId);

            var lblElement = document.getElementsByTagName("label");
            
            for (i = 0; i < lblElement.length; i++) {
                var idLblParentQuestionId = lblElement[i].id;
               // alert("idLblParentQuestionId : " + idLblParentQuestionId);
                var s = idLblParentQuestionId.substring(3);

                if (s == questionId) {
                    if (checkedValue == "Yes")
                        lblElement[i].style.visibility = "visible";
                    else
                        lblElement[i].style.visibility = "hidden";
                }

            }
        }

    </script>

    <h2>Admin</h2>
    <p>
        <%: Html.ActionLink("Create Interactive Questions", "Create") %>
    </p>
    <br />
    <% foreach (var dependantListItem in (ViewData["DependantTypeValues"] as List<SelectListItem>))
       {
           List<InteractiveQuestion> interactiveQuestionList = (ViewData["InteractiveQuestion" + dependantListItem.Text + "List"] as List<InteractiveQuestion>);
           if (interactiveQuestionList.Count > 0)
           { %>
             
    <fieldset>
    <legend>
    <%= dependantListItem.Text%>
    </legend>
    <table id="tblInteractiveQuestion">
        <tr>
            <th></th>
            <th style="Width: 30%">
                Question Title
            </th>
            <th>
                Answers
            </th>
        </tr>
         <% foreach (var item in interactiveQuestionList)
            {                        
               %>
          <tr>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new { id = item.QuestionId })%> |
                <%: Html.ActionLink("Delete", "Delete", new { id = item.QuestionId })%>
             <%--     
                   <div style="padding-bottom:10px;float:right">
                    <a class="thickbox"  href="../BAS/Delete?id=<%=item.QuestionId%>&TB_iframe=true&height=200&width=500&modal=true" title="Delete">Delete</a>
                </div>--%>
                </td>
            <td title="<%=item.QuestionText %>">
                <%: item.QuestionText%>
                 
                    <label id="lbl<%=item.ParentQuestionId%>" style="color:Red;visibility:hidden">*</label>
                 
               <% if (item.IsRequired == true)
                  { %>
                <label id="lbleIsMAndatory" style="color:Red">*</label>
                <% } %>
            </td>
           <td>
                <% if (item.LookupControlType.ControlTypeName == "Textbox")
                   { %>    
                   <input id="txtAnswers" name="txtAnswers" type="text"/>
                   
                   <% } %>

                   <% if (item.LookupControlType.ControlTypeName == "TextArea")
                   { %>    
                   <%: Html.TextArea("txtArea")%> 
                   <% } %>

                <% if (item.LookupControlType.ControlTypeName == "Radio")
                   {
                       foreach (var l in item.InteractiveQuestionDataLookup)
                       { %>
                     <input id="rbtn<%=l.OptionId%>" name="rbtn<%=item.QuestionId%>" type="radio" onclick="RetrieveChecked('<%=l.OptionName%>','<%=item.QuestionId%>')" />
                     <label for="rbtn<%=l.OptionId%>">   <%=l.OptionName%>  </label> 
                <%  }
                   } %>

                <% if (item.LookupControlType.ControlTypeName == "Checkbox")
                   {
                       foreach (var l in item.InteractiveQuestionDataLookup)
                       {%>
                     <input id="chkAnswers" name="chkAnswers" type="checkbox"/>
                     <label for="chkAnswers">   <%=l.OptionName%>  </label> 
                <%  }
                   } %>

                <% if (item.LookupControlType.ControlTypeName == "Dropdown")
                   { %>
                   <select id="idListOptions" name="idListOptions">  
                   <%  foreach (var l in item.InteractiveQuestionDataLookup)
                       { %>
                        <option> <%=l.OptionName%></option>
                        <% } %>
                        </select>
                <% } %>
            </td>
        </tr>
       <% 
        }
           %>
    </table>
    </fieldset>
   <% }
       }%>

</asp:Content>
