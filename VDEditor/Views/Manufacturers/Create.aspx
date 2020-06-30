<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<VDEditor.Models.VehicleManufacturerCreateEditModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create a Manufacturer
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create a Manufacturer</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true, "We've got a problem! Please correct the errors and try again.") %>

        <fieldset>
            <legend>Basic Details</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Name) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Name) %>
                <%: Html.ValidationMessageFor(model => model.Name) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.WikipediaId) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.WikipediaId) %>
                <%: Html.ValidationMessageFor(model => model.WikipediaId) %>
            </div>
            
        </fieldset>

        <p>
            <input type="submit" value="Create" />
        </p>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

