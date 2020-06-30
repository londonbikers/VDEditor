<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<VDEditor.Models.VehicleModelIndexModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Models Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Models Index</h2>

    <p><%: Html.ActionLink("Create a new Model", "Create") %></p>

    <p>Choose a Manufacturer to view the models for.</p>

    <div class="mt20 mb20">
        <% using (Html.BeginForm()) { %>
            <%=Html.DropDownListFor(q => q.VehicleManufacturerId, Model.Manufacturers)%>
            <input type="submit" value="filter" />
        <% }%>
    </div>

    <% if (Model.Manufacturer != null) {%>
    <table>
        <tr>
            <th></th>
            <th>Name</th>
            <th>Year Introduced</th>
            <th>Variant Name</th>
            <th>Wikipedia Id</th>
            <th></th>
        </tr>
        <% foreach (var item in Model.Models) {%>
            <tr>
                <td><%:Html.ActionLink("Edit", "Edit", new { id = item.Id })%></td>
                <td><%= item.Name %></td>
                <td><%= item.YearIntroduced %></td>
                <td><%= item.VariantName %></td>
                <td><i><%= item.WikipediaId %></i></td>
                <td><%:Html.ActionLink("Copy", "Create", new { id = item.Id })%></td>
            </tr>
        <% } %>
    </table>
    <% } %>

</asp:Content>