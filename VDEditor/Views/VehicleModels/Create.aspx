<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<VDEditor.Models.VehicleModelCreateEditModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create a Model
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create a Model</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.TypeId) %>
            </div>
            <div class="editor-field">
                <%: Html.DropDownListFor(q=>q.TypeId, Model.VehicleTypes) %>
                <%: Html.ValidationMessageFor(model => model.TypeId) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.ManufacturerId) %>
            </div>
            <div class="editor-field">
                <%: Html.DropDownListFor(q=>q.ManufacturerId, Model.VehicleManufacturers) %>
                <%: Html.ValidationMessageFor(model => model.ManufacturerId) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Name) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Name) %>
                <%: Html.ValidationMessageFor(model => model.Name) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.EngineSizeCc) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.EngineSizeCc) %>
                <%: Html.ValidationMessageFor(model => model.EngineSizeCc) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.WikipediaId) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.WikipediaId) %>
                <%: Html.ValidationMessageFor(model => model.WikipediaId) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.YearIntroduced) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.YearIntroduced) %>
                <%: Html.ValidationMessageFor(model => model.YearIntroduced) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.YearStopped) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.YearStopped) %>
                <%: Html.ValidationMessageFor(model => model.YearStopped) %>
            </div>
            
        </fieldset>

        <p>
            <input type="submit" value="Create" />
        </p>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "List") %>
    </div>

</asp:Content>

