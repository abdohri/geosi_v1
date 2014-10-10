<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="GeoSI.Website.WebForm4" %>



<!DOCTYPE html>
<html>
  <head>
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no">
    <meta charset="utf-8">
    <title>Custom controls</title>
    <style>
      html, body, #map-canvas {
        height: 400px;
       width:700px;
        margin: 0px;
        padding: 0px
      }
      .style1 {
		background: red;
		height: 150px;
		border: solid 10px black;
		padding: 10px;
	}

	.style1 span {
		font: small-caps xx-large bold;
		color: black;
	}

	.style2 {
		background: yellow;
		height: 350px;
		width: 20%;
		margin-left: 30%;
		border: double 10px green;
		padding-top: 25px;
		text-align: center;
	}

	.style2 span {
		font-size: x-large;
		font-style: italic;
		color: red;
	}

    </style>
    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false"></script>
    <script>
        var map;
        var chicago = new google.maps.LatLng(41.850033, -87.6500523);

        /**
         * The HomeControl adds a control to the map that simply
         * returns the user to Chicago. This constructor takes
         * the control DIV as an argument.
         * @constructor
         */
        function HomeControl(controlDiv, map) {

            // Set CSS styles for the DIV containing the control
            // Setting padding to 5 px will offset the control
            // from the edge of the map
            controlDiv.style.padding = '5px';
            controlDiv.style.width = '200px';
            controlDiv.style.height = '100px';
            controlDiv.style.backgroundColor = 'red';

            //// Set CSS for the control border
            //var controlUI = document.createElement('div');
            //controlUI.style.backgroundColor = 'white';
            //controlUI.style.borderStyle = 'solid';
            //controlUI.style.borderWidth = '2px';
            //controlUI.style.cursor = 'pointer';
            //controlUI.style.textAlign = 'center';
            //controlUI.title = 'Click to set the map to Home';
            //controlDiv.appendChild(controlUI);

            //// Set CSS for the control interior
            //var controlText = document.createElement('div');
            //controlText.style.fontFamily = 'Arial,sans-serif';
            //controlText.style.fontSize = '12px';
            //controlText.style.paddingLeft = '4px';
            //controlText.style.paddingRight = '4px';
            //controlText.innerHTML = '<b>Home</b>';
            //controlUI.appendChild(controlText);

            //// Setup the click event listeners: simply set the map to
            //// Chicago
            //google.maps.event.addDomListener(controlUI, 'click', function () {
            //    map.setCenter(chicago)
            //});

        }

        function initialize() {
            var mapDiv = document.getElementById('map-canvas');
            var mapOptions = {
                zoom: 12,

                center: chicago
            }
            map = new google.maps.Map(mapDiv, mapOptions);

            // Create the DIV to hold the control and
            // call the HomeControl() constructor passing
            // in this DIV.
            //          var homeControlDiv = document.createElement('div');
            ////          document.getElementById(homeControlDiv).setAttribute("class", "style1");
            //          var homeControl = new HomeControl(homeControlDiv, mapp);

            //          homeControlDiv.index = 1;
            //          mapp.controls[google.maps.ControlPosition.TOP_RIGHT].push(homeControlDiv);
            google.maps.event.addListener(map, "rightclick", function () {

                alert(map.getCenter());

            }
              );
        }

        google.maps.event.addDomListener(window, 'load', initialize);



    </script>
  </head>
  <body>
    <div id="map-canvas"></div>
  </body>
</html>

