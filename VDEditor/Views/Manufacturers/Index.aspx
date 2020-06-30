<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<VDEditor.Models.VehicleManufacturersModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Manufacturers Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Manufacturers</h2>

    <p><%: Html.ActionLink("Create a new Manufacturer", "Create") %></p>

    <table>
        <thead>
            <tr>
                <th></th>
                <th>Name</th>
                <th>Wikipedia ID</th>
            </tr>
        </thead>
        <% foreach (var m in Model.VehicleManufacturers) {%>
        <tr>
            <td><%= Html.ActionLink("Edit", "Edit", new {id = m.Id}) %></td>
            <td><%= m.Name %></td>
            <td><i><%= m.WikipediaId %></i></td>
        </tr>
        <% } %>
    </table>

</asp:Content>
