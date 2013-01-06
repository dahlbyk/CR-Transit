<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HomeModel>" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <ul id="routes"><% foreach (var route in ViewData.Model.Routes)
           { %>
        <li>
            <input type="checkbox" title="<%= route.Name %> Route" class="route" value="http://github.com/dahlbyk/CR-Transit/raw/data/data/kml/<%= route.Id%>.route.kml" />
            <input type="checkbox" title="<%= route.Name %> Stops" class="stops" value="http://github.com/dahlbyk/CR-Transit/raw/data/data/kml/<%= route.Id%>.stops.kml" />
            <a href="http://github.com/dahlbyk/CR-Transit/raw/data/data/kml/<%= route.Id%>.route.kml"><%= route.Id%>: <%= route.Description%></a>
        </li><%
        } %>
    </ul>
    <script src="/Scripts/jquery-1.3.2.js" type="text/javascript"></script>
    <script src="http://maps.google.com/maps?file=api&amp;v=2&amp;sensor=true_or_false&amp;key=ABQIAAAAZr7GL1i7DpdhPruqKgZr_BRczQwZsodpfxckFpvfra2tA6e9IBSAdhrDJQsG5zlW1V1nNnHvsV9Vpw" type="text/javascript"></script>
    <script type="text/javascript">
        var map = null;
        $(function() {
            if (GBrowserIsCompatible()) {
                map = new GMap2(document.getElementById("map"));
                map.addControl(new GHierarchicalMapTypeControl());
                map.addMapType(G_PHYSICAL_MAP);
                map.addControl(new GLargeMapControl());
                map.addControl(new GOverviewMapControl());
                map.setCenter(new GLatLng(41.9697953829611, -91.660023271759), 12);

                // Display train lines from KML file
                $('#routes input')
                    .click(function() {
                        if (!this.overlay) {
                            this.overlay = new GGeoXml(this.value);
                            map.addOverlay(this.overlay);
                        } else if (this.overlay.isHidden()) {
                            this.overlay.show();
                        } else {
                            this.overlay.hide();
                        }
                        return true;
                    });
            }
        });

    </script>
    <div id="map" style="width: 1200px; height: 900px"></div>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>