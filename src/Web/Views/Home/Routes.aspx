<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HomeModel>" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">

    <ul><% foreach (var route in ViewData.Model.Routes)
           { %>
        <li><%= route.Id%>: <%= route.Description%> - <a href="/Kml/Route/<%= route.Id%>">Route</a> <a href="/Kml/Stops/<%= route.Id%>">Stops</a></li><%
        } %>
    </ul>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>