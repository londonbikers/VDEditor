<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<VDEditor.Models.VehicleTypesModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Vehicle Types
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Vehicle Types Index</h2>

    <p><%= Html.ActionLink("Create a new Vehicle Type", "Create") %></p>

    <table>
        <thead>
            <tr>
                <th></th>
                <th>Name</th>
            </tr>
        </thead>
        <% foreach (var vt in Model.VehicleTypes) {%>
        <tr>
            <td><%= Html.ActionLink("Edit", "Edit", new {id = vt.Id}) %></td>
            <td><%= vt.Name %></td>
        </tr>
        <% } %>
    </table>

</asp:Content>
