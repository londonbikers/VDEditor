<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<VDEditor.Models.VehicleManufacturerCreateEditModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit Manufacturer: <%= Model.Name %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit Manufacturer: <%= Model.Name %></h2>

    <div class="mb20">
        <%: Html.ActionLink("View models for this manufacturer", "List", "VehicleModels", new { id = Model.Id }, null) %>
    </div>

    <div>
        <% using (Html.BeginForm("Delete", "Manufacturers", new { id = Model.Id })) { %>
            <input type="submit" value="Delete manufacturer" onclick="return confSubmit(this.form)" />
        <% } %>
    </div>

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
            <input type="submit" value="Save" />
        </p>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

