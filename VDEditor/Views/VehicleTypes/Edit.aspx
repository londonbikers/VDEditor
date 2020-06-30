<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<VDEditor.Models.VehicleTypeCreateEditModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit Vehicle Type: <%= Model.Name %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit Vehicle Type: <%= Model.Name %></h2>

    <div>
        <% using (Html.BeginForm("Delete", "VehicleTypes", new { id = Model.Id })) { %>
            <input type="submit" value="Delete vehicle type" onclick="return confSubmit(this.form)" />
        <% } %>
    </div>

    <% using (Html.BeginForm()) { %>

        <%= Html.ValidationSummary(true, "We've got a problem! Please correct the errors and try again.") %>

        <%= Html.HiddenFor(q=>q.Id) %>
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

        <input type="submit" value="Submit" />
    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>
