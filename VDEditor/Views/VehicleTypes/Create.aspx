<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<VDEditor.Models.VehicleTypeCreateModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create a Vehicle Type
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create a Vehicle Type</h2>

    <% using (Html.BeginForm()) { %>
    
        <%: Html.ValidationSummary(true, "We've got a problem! Please correct the errors and try again.") %>

        <fieldset>
            <legend>Basic Details</legend>
            <div class="editor-label">
                <%= Html.LabelFor(q=>q.Name) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(q=>q.Name) %>
                <%= Html.ValidationMessageFor(q=>q.Name)%>
            </div>
        </fieldset>

        <input type="submit" value="Create" />
    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>
