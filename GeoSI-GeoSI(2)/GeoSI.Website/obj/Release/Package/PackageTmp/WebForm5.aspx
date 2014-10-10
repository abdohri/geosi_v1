<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm5.aspx.cs" Inherits="GeoSI.Website.WebForm5" %>

<script runat="server">
    [DirectMethod(Namespace = "CompanyX")]
    public void ShowMsg(string msg)
    {
        X.Msg.Notify("Message", msg).Show();
    }
</script>
    
<!DOCTYPE html>

<html>
<head id="Head1" runat="server">
    <title>Remote Data Calendar - Ext.NET Examples</title>
    
    <link rel="stylesheet" href="../Shared/resources/css/main.css" />
    
    <script src="../Shared/resources/js/common.js"></script>
     <script src="../../Ressources/Scripts/common/override.js"></script>
   
</head>
<body>
    <form id="Form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" Namespace="CompanyX" />
        
        <ext:Viewport ID="Viewport1" runat="server" Layout="Border">
            <Items>
                <ext:Panel ID="Panel1" 
                    runat="server" 
                    Height="35" 
                    Border="false" 
                    Region="North" 
                    Cls="app-header" 
                    BodyCls="app-header-content">
                    <Content>
                        <div id="app-logo">
                            <div class="logo-top">&nbsp;</div>
                            <div id="logo-body">&nbsp;</div>
                            <div class="logo-bottom">&nbsp;</div>
                        </div>
                        <h1>My Calendar</h1>
                        <span id="app-msg" class="x-hidden"></span>
                    </Content>
                </ext:Panel>
                
                <ext:Panel 
                    ID="Panel2" 
                    runat="server" 
                    Title="..." 
                    Layout="Border" 
                    Region="Center" 
                    Cls="app-center">
                    <Items>
                        <ext:Panel ID="Panel3" 
                            runat="server" 
                            Width="176" 
                            Region="West" 
                            Border="false" 
                            Cls="app-west">
                            <Items>
                                <ext:DatePicker ID="DatePicker1" runat="server" Cls="ext-cal-nav-picker">
                                    <Listeners>
                                        <Select Fn="CompanyX.setStartDate" Scope="CompanyX" />
                                    </Listeners>
                                </ext:DatePicker>
                            </Items>
                            <TopBar>
                                <ext:Toolbar ID="Toolbar1" runat="server">
                                    <Items>
                                        <ext:Button ID="Button1" 
                                            runat="server" 
                                            Text="Save All Events" 
                                            Icon="Disk" 
                                            Handler="CompanyX.record.saveAll();" 
                                            />
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                        </ext:Panel>
                        
                        <ext:CalendarPanel
                            ID="CalendarPanel1" 
                            runat="server"
                            Region="Center"
                            ActiveIndex="2"
                            Border="false">
                            <CalendarStore ID="CalendarStore1" runat="server">
                                <Calendars>
                                    <ext:CalendarModel CalendarId="1" Title="Home" />
                                    <ext:CalendarModel CalendarId="2" Title="Work" />
                                    <ext:CalendarModel CalendarId="3" Title="School" />
                                </Calendars>
                            </CalendarStore>
                            <EventStore ID="EventStore1" runat="server" NoMappings="true">
                                <Proxy>
                                    <ext:AjaxProxy Url="../Shared/Code/RemoteService.asmx/GetEvents" Json="true">                                        
                                        <ActionMethods Read="POST" />
                                        <Reader>
                                            <ext:JsonReader Root="d" />
                                        </Reader>
                                    </ext:AjaxProxy>
                                </Proxy>        
                                <Mappings>
                                    <ext:ModelField Name="StartDate" Type="Date" DateFormat="M$" /> 
                                    <ext:ModelField Name="EndDate" Type="Date" DateFormat="M$" />
                                </Mappings>
                                <Listeners>
                                    <BeforeSync Handler="Ext.Msg.alert('Sync', 'The EventStore initiates a sync request after that action. The EventStore synchronization is not implemented in that example.'); 
                                                         this.commitChanges();
                                                         return false;" />
                                </Listeners>
                            </EventStore>
                            <MonthView ID="MonthView1" 
                                runat="server" 
                                ShowHeader="true" 
                                ShowWeekLinks="true" 
                                ShowWeekNumbers="true" 
                                />  
                            <Listeners>
                                <ViewChange  Fn="CompanyX.viewChange" Scope="CompanyX" />
                                <EventClick  Fn="CompanyX.record.show" Scope="CompanyX" />
                                <DayClick    Fn="CompanyX.dayClick" Scope="CompanyX" />
                                <RangeSelect Fn="CompanyX.rangeSelect" Scope="CompanyX" />

                                <EventMove   Fn="CompanyX.record.move" Scope="CompanyX" />
                                <EventResize Fn="CompanyX.record.resize" Scope="CompanyX" />

                                <EventAdd    Fn="CompanyX.record.addFromEventDetailsForm" Scope="CompanyX" />
                                <EventUpdate Fn="CompanyX.record.updateFromEventDetailsForm" Scope="CompanyX" />
                                <EventDelete Fn="CompanyX.record.removeFromEventDetailsForm" Scope="CompanyX" />
                            </Listeners>                          
                        </ext:CalendarPanel>
                    </Items>
                </ext:Panel>
            </Items>
        </ext:Viewport>
        
        <ext:EventWindow 
            ID="EventWindow1" 
            runat="server"
            Hidden="true" 
            CalendarStoreID="CalendarStore1">
            <Listeners>
                <EventAdd    Fn="CompanyX.record.add" Scope="CompanyX" />
                <EventUpdate Fn="CompanyX.record.update" Scope="CompanyX" />
                <EditDetails Fn="CompanyX.record.edit" Scope="CompanyX" />
                <EventDelete Fn="CompanyX.record.remove" Scope="CompanyX" />
            </Listeners>
        </ext:EventWindow>
    </form>
</body>
</html>
<%--<!DOCTYPE html>
<html>
  <head>
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no">
    <meta charset="utf-8">
    <title>Adding a Custom Overlay</title>
    <style>
      html, body, #map-canvas {
        height: 100%;
        margin: 0px;
        padding: 0px
      }
    </style>
    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false"></script>
    <script>
        // [START region_initialization]
        // This example creates a custom overlay called USGSOverlay, containing
        // a U.S. Geological Survey (USGS) image of the relevant area on the map.

        // Set the custom overlay object's prototype to a new instance
        // of OverlayView. In effect, this will subclass the overlay class.
        // Note that we set the prototype to an instance, rather than the
        // parent class itself, because we do not wish to modify the parent class.

        var overlay;
        USGSOverlay.prototype = new google.maps.OverlayView();

        // Initialize the map and the custom overlay.

        function initialize() {
            var mapOptions = {
                zoom: 11,
                center: new google.maps.LatLng(62.323907, -150.109291),
                mapTypeId: google.maps.MapTypeId.SATELLITE
            };

            var map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);

            var swBound = new google.maps.LatLng(62.281819, -150.287132);
            var neBound = new google.maps.LatLng(62.400471, -150.005608);
            var bounds = new google.maps.LatLngBounds(swBound, neBound);

            // The photograph is courtesy of the U.S. Geological Survey.
            var srcImage = 'https://developers.google.com/maps/documentation/javascript/';
            srcImage += 'examples/full/images/talkeetna.png';

            // The custom USGSOverlay object contains the USGS image,
            // the bounds of the image, and a reference to the map.
            overlay = new USGSOverlay(bounds, srcImage, map);
        }
        // [END region_initialization]

        // [START region_constructor]
        /** @constructor */
        function USGSOverlay(bounds, image, map) {

            // Initialize all properties.
            this.bounds_ = bounds;
            this.image_ = image;
            this.map_ = map;

            // Define a property to hold the image's div. We'll
            // actually create this div upon receipt of the onAdd()
            // method so we'll leave it null for now.
            this.div_ = null;

            // Explicitly call setMap on this overlay.
            this.setMap(map);
        }
        // [END region_constructor]

        // [START region_attachment]
        /**
         * onAdd is called when the map's panes are ready and the overlay has been
         * added to the map.
         */
        USGSOverlay.prototype.onAdd = function () {

            var div = document.createElement('div');
            div.style.borderStyle = 'none';
            div.style.borderWidth = '2px';
            div.style.backgroundColor = 'red';
            div.style.position = 'absolute';
            div.style.width = '200px';
            div.style.height = '30px';
            div.style.left = '100px';


            // Create the img element and attach it to the div.
            //var img = document.createElement('img');
            //img.src = this.image_;
            //img.style.width = '100%';
            //img.style.height = '100%';
            //img.style.position = 'absolute';
            //div.appendChild(img);

            this.div_ = div;

            // Add the element to the "overlayLayer" pane.
            var panes = this.getPanes();
            panes.overlayLayer.appendChild(div);
        };
        // [END region_attachment]

        // [START region_drawing]
        USGSOverlay.prototype.draw = function () {

            // We use the south-west and north-east
            // coordinates of the overlay to peg it to the correct position and size.
            // To do this, we need to retrieve the projection from the overlay.
          //  var overlayProjection = this.getProjection();

        //    // Retrieve the south-west and north-east coordinates of this overlay
        //    // in LatLngs and convert them to pixel coordinates.
        //    // We'll use these coordinates to resize the div.
            //var sw = overlayProjection.fromLatLngToDivPixel(this.bounds_.getSouthWest());
            //var ne = overlayProjection.fromLatLngToDivPixel(this.bounds_.getNorthEast());

        //    // Resize the image's div to fit the indicated dimensions.
            var div = this.div_;
            //div.style.left = sw.x + 'px';
            //div.style.top = ne.y + 'px';
            //div.style.width = (ne.x - sw.x) + 'px';
            //div.style.height = (sw.y - ne.y) + 'px';
        };
        // [END region_drawing]

        // [START region_removal]
        // The onRemove() method will be called automatically from the API if
        // we ever set the overlay's map property to 'null'.
        USGSOverlay.prototype.onRemove = function () {
            this.div_.parentNode.removeChild(this.div_);
            this.div_ = null;
        };
        // [END region_removal]

        google.maps.event.addDomListener(window, 'load', initialize);

    </script>
  </head>
  <body>
    <div id="map-canvas"></div>
  </body>
</html>
--%>
