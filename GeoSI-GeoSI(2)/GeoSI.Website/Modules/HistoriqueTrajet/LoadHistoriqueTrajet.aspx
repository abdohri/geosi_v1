<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoadHistoriqueTrajet.aspx.cs" Inherits="GeoSI.Website.Modules.Historique.LoadHistoriqueTrajet" %>



<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false"></script>
    <script src="http://maps.google.com/maps/api/js?sensor=false&v=3&libraries=geometry"></script>
    <script src="../../Ressources/Scripts/common/jquery-1.4.1.js"></script>
    <script src="../../Ressources/Scripts/common/GMaps.js"></script>
    <script src="../../Ressources/Scripts/common/js_common_module.js" type="text/javascript"></script>
    <link href="../../Ressources/Styles/common/css_module.css" rel="stylesheet" type="text/css" />
    <script src="../../Ressources/Scripts/common/js_common_form.js" type="text/javascript"></script>
    <script>
        var onKeyUp = function () {
            var me = this,
                v = me.getValue(),
                field;

            if (me.startDateField) {
                field = Ext.getCmp(me.startDateField);
                field.setMaxValue(v);
                me.dateRangeMax = v;
            } else if (me.endDateField) {
                field = Ext.getCmp(me.endDateField);
                field.setMinValue(v);
                me.dateRangeMin = v;
            }

            field.validate();
        };
    </script>
    <style type="text/css">
        .voiturecls
        {
            width: 23px;
            height: 16px;
            background-image: url("../../Ressources/Images/voituretree.png") !important;
            background-repeat: no-repeat;
        }

        .camioncls
        {
            width: 23px;
            height: 16px;
            background-image: url("../../Ressources/Images/camiontree.png") !important;
            background-repeat: no-repeat;
        }

        #btnplay
        {
            display: block;
            border: 0px;
            width: 24px;
            height: 24px;
            background-image: url(../../Ressources/Images/play.png);
            margin-left: 2px;
            margin-right: 2px;
            float: left;
        }

        .x-grid-row .custom-column
        {
            font-weight: bold;
        }

        #btnplayleft
        {
            float: left;
            display: block;
            width: 24px;
            height: 24px;
            background: url(../../Ressources/Images/rewind.png);
            margin-left: 2px;
            margin-right: 2px;
        }

        #btnplayright
        {
            float: left;
            display: block;
            width: 24px;
            height: 24px;
            background-image: url(../../Ressources/Images/forward.png);
            margin-left: 2px;
            margin-right: 2px;
        }

        #DateField1-inputEl
        {
            border-top-left-radius: 4px;
            border-bottom-left-radius: 4px;
        }

        #ComboBoxFilter
        {
            margin-left: 25px;
            margin-right: 5px;
        }

        #tableInfo a:link
        {
            color: #666;
            font-weight: bold;
            text-decoration: none;
        }

        #tableInfo a:visited
        {
            color: #999999;
            font-weight: bold;
            text-decoration: none;
        }

        #tableInfo a:active,
        #tableInfo a:hover
        {
            color: #bd5a35;
            text-decoration: underline;
        }

        #tableInfo
        {
            width: 100%;
            font-family: Arial, Helvetica, sans-serif;
            color: #666;
            font-size: 12px;
            text-shadow: 1px 1px 0px #fff;
            background: #eaebec;
        }



            #tableInfo tr
            {
                text-align: center;
            }

                #tableInfo tr td:first-child
                {
                    text-align: left;
                    border-left: 0;
                }

                #tableInfo tr td
                {
                    padding: 10px;
                    border-top: 1px solid #ffffff;
                    border-bottom: 1px solid #e0e0e0;
                    border-left: 1px solid #e0e0e0;
                    padding-left: 30px;
                    padding-right: 20px;
                    background: #fafafa;
                    background: -webkit-gradient(linear, left top, left bottom, from(#fbfbfb), to(#fafafa));
                    background: -moz-linear-gradient(top, #fbfbfb, #fafafa);
                }

                #tableInfo tr.even td
                {
                    background: #f6f6f6;
                    background: -webkit-gradient(linear, left top, left bottom, from(#f8f8f8), to(#f6f6f6));
                    background: -moz-linear-gradient(top, #f8f8f8, #f6f6f6);
                }

                #tableInfo tr:last-child td
                {
                    border-bottom: 0;
                }


                #tableInfo tr:hover .tdTableVehicule
                {
                    background: #f2f2f2;
                    background: -webkit-gradient(linear, left top, left bottom, from(#f2f2f2), to(#f0f0f0));
                    background: -moz-linear-gradient(top, #f2f2f2, #f0f0f0);
                }

        /// #tableInfo1 a:link
        {
            color: #666;
            font-weight: bold;
            text-decoration: none;
        }

        #tableInfo1 a:visited
        {
            color: #999999;
            font-weight: bold;
            text-decoration: none;
        }

        #tableInfo1 a:active,
        #tableInfo1 a:hover
        {
            color: #bd5a35;
            text-decoration: underline;
        }

        #tableInfo1
        {
            width: 100%;
            font-family: Arial, Helvetica, sans-serif;
            color: #666;
            font-size: 12px;
            text-shadow: 1px 1px 0px #fff;
            background: #eaebec;
        }



            #tableInfo1 tr
            {
                text-align: center;
            }

                #tableInfo1 tr td:first-child
                {
                    text-align: left;
                    border-left: 0;
                }

                #tableInfo1 tr td
                {
                    padding: 10px;
                    border-top: 1px solid #ffffff;
                    border-bottom: 1px solid #e0e0e0;
                    border-left: 1px solid #e0e0e0;
                    padding-left: 30px;
                    padding-right: 20px;
                    background: #fafafa;
                    background: -webkit-gradient(linear, left top, left bottom, from(#fbfbfb), to(#fafafa));
                    background: -moz-linear-gradient(top, #fbfbfb, #fafafa);
                }

                #tableInfo1 tr.even td
                {
                    background: #f6f6f6;
                    background: -webkit-gradient(linear, left top, left bottom, from(#f8f8f8), to(#f6f6f6));
                    background: -moz-linear-gradient(top, #f8f8f8, #f6f6f6);
                }

                #tableInfo1 tr:last-child td
                {
                    border-bottom: 0;
                }


                #tableInfo1 tr:hover .tdTableVehicule
                {
                    background: #f2f2f2;
                    background: -webkit-gradient(linear, left top, left bottom, from(#f2f2f2), to(#f0f0f0));
                    background: -moz-linear-gradient(top, #f2f2f2, #f0f0f0);
                }

        #TabPanel2
        {
            padding-top: 7px;
        }


        #TabPanel1
        {
            padding-top: 5px;
        }

        #Panel2-splitter, #Panel1-splitter
        {
            background-color: #DAE2F5;
        }

        #Panel4_Content
        {
            width: 100%;
            height: 100%;
            border: 0;
        }

        .divinfo
        {
            border: 1px solid #AAA;
            width: 579px;
            height: 227px;
            position: absolute;
            right: -579px;
            top: 22%;
            z-index: 10000;
            background-color: #F1F1F1;
        }

        #siteNotice
        {
            margin: 0;
            padding: 0;
            background-color: Red;
            height: 100px;
            width: 400px;
        }

        .labels
        {
            color: red;
            background-color: White;
            font-family: "Lucida Grande", "Arial", sans-serif;
            font-size: 10px;
            font-weight: bold;
            text-align: center;
            width: 80px;
            border: 2px solid black;
            white-space: nowrap;
        }
    </style>
    <script src="../../Ressources/Scripts/common/gc.js" type="text/javascript"></script>
    <script src="../../Ressources/Scripts/common/oXHR.js" type="text/javascript"></script>
    <script src="../../Ressources/Scripts/common/elabel.js" type="text/javascript"></script>

    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false"></script>
    <script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false&v=3&libraries=geometry"></script>
    <script type="text/javascript">
        var gCurrDevice = null;
        var lineSymbol = {
            path: google.maps.SymbolPath.FORWARD_CLOSED_ARROW,
            scale: 1.5
        };

        var carte = null;

        var route;
        var directionsService = new google.maps.DirectionsService();

        var x;

        function checkchange(node, checked) {

            gCurrDevice = node.getId();

            if (checked) {
                //mCountDown();
                LiveTracking(gCurrDevice, TrajetSuivi, "../../Handler/HandlerLiveTracking.ashx");
                x = window.setInterval(function () { LiveTracking(gCurrDevice, TrajetSuivi, "../../Handler/HandlerLiveTracking.ashx") }, 20000);

                // LiveTracking(gCurrDevice, mSetMapPosition, "../../Handler/HandlerLiveTracking.ashx");
            }
            else {

                window.clearInterval(x);

                clearOverlays();
                initialiser();
                arrylistPointGPS = new Array();
            }


        }




        function suivi(node, checked) {
            gCurrDevice = node.getId();
            if (checked) {
                mCountDown();

                //LiveTracking(gCurrDevice, TrajetSuivi, "../../Handler/HandlerLiveTracking.ashx");
                // LiveTracking(gCurrDevice, mSetMapPosition, "../../Handler/HandlerLiveTracking.ashx");
            }
            else {
                clearOverlays();
                arrylistPointGPS = new Array();
            }


        }
        var nodeLoad = function (store, operation, options) {
            var node = operation.node;

            App.direct.NodeLoad(node.getId(), {
                success: function (result) {
                    node.set('loading', false);
                    node.set('loaded', true);
                    var data = Ext.decode(result);
                    node.appendChild(data, undefined, true);
                    node.expand();
                },

                failure: function (errorMsg) {
                    Ext.Msg.alert('Failure', errorMsg);
                }
            });

            return false;
        };
        function TrajetSimple() {

            var dateTime = Ext.getCmp('DateField1').getRawValue();
            var hjh = gCurrDevice;
            LiveTracking(gCurrDevice, mSetMapTrajet, "../../Handler/GetterPositionTrajet.ashx", dateTime);

            //if (document.getElementById('btnplay').style.backgroundImage == 'url("../../Ressources/Images/pause.png")') {
            //    document.getElementById('btnplay' ).style.backgroundImage = 'url("../../Ressources/Images/play.png")';
            //} else {
            //    document.getElementById('btnplay').style.backgroundImage = 'url("../../Ressources/Images/pause.png")';
            //}


        }
        function overimag() {
            document.getElementById('img').style.background = '#dedede';
        }
        function testchek() {
            if (Ext.getCmp("Panel2").hidden == true) {
                Ext.getCmp("Panel2").setVisible(true);
            }
            else {
                Ext.getCmp("Panel2").setVisible(false);
            }
        }
        //Resuire leftSide
        function reduirePanelGauche() {

            if (!Ext.getCmp('TreePanel1').collapsed) {
                Ext.getCmp('TreePanel1').collapse(Ext.Component.DIRECTION_left, true);
                document.getElementById('a_collapse_index').style.left = "0";

            } else {
                Ext.getCmp('TreePanel1').toggleCollapse();
                document.getElementById('a_collapse_index').style.left = "279px";
            }

        }
        //Fermeture du div
        function closediv() {

            Ext.getCmp("Checkbox1").setValue(false);
            Ext.getCmp("Panel2").setVisible(false);
        }
        // Reduire le div
        function reduirediv() {
            if (Ext.getCmp("Panel2").height == 200) {
                Ext.getCmp("Panel2").setHeight(40);
            } else {
                Ext.getCmp("Panel2").setHeight(200);
            }

        }

        //Affichage de la carte
        function AfficheCadreDroit() {

            $('.divinfo').animate({
                right: '0px'
            }, 600);

        }
        // Fermeture de la carte
        function fermeCadreDroit() {

            $('.divinfo').animate({
                right: '-579px'
            }, 600);

        }

        function appelPanel() {
            request(readData);
        }

        var myArrowIcon = new Image();
        //function mSetOrientationCanvas(course, arrowColor, canvaId) {
        //    var angleDegrees = course * 1 - 90;
        //    var canvas = document.getElementById(canvaId).getContext('2d');
        //    angleRadians = (angleDegrees / 180) * Math.PI;
        //    canvas.clearRect(0, 0, 44, 44);
        //    canvas.save();
        //    //Après avoir mis l'image au centre du canva (0,10.5), on calcule les nouvelles coordonnées du centre de l'image par rapport au repère original (22,21.5): 44/2-0/2=22, 44/2-23/2=21.5
        //    canvas.translate(22, 21.5);
        //    canvas.rotate(angleRadians);
        //    canvas.translate(-22, -21.5);
        //    if (arrowColor == 1)
        //        canvas.drawImage(myArrowIcon, 0, 10.5);
        //    else
        //        canvas.drawImage(myArrowIconBlack, 0, 10.5);
        //    canvas.restore();
        //}

        //function attachSecretMessage(markerVal) {


        //    google.maps.event.addListener(markerVal, 'click', function () {

        //        if (markerVal) {
        //            alert('aa');
        //        }

        //    });
        //}

        eval(function (p, a, c, k, e, r) { e = function (c) { return (c < a ? '' : e(parseInt(c / a))) + ((c = c % a) > 35 ? String.fromCharCode(c + 29) : c.toString(36)) }; if (!''.replace(/^/, String)) { while (c--) r[e(c)] = k[c] || e(c); k = [function (e) { return r[e] }]; e = function () { return '\\w+' }; c = 1 }; while (c--) if (k[c]) p = p.replace(new RegExp('\\b' + e(c) + '\\b', 'g'), k[c]); return p }('7 m(a){2.3=a;2.8=V.1E("1u");2.8.4.C="I: 1m; J: 1g;";2.k=V.1E("1u");2.k.4.C=2.8.4.C}m.l=E 6.5.22();m.l.1Y=7(){n c=2;n h=t;n f=t;n j;n b;n d,K;n i;n g=7(e){p(e.1v){e.1v()}e.2b=u;p(e.1t){e.1t()}};2.1s().24.G(2.8);2.1s().20.G(2.k);2.11=[6.5.9.w(V,"1o",7(a){p(f){a.s=j;i=u;6.5.9.r(c.3,"1n",a)}h=t;6.5.9.r(c.3,"1o",a)}),6.5.9.o(c.3.1P(),"1N",7(a){p(h&&c.3.1M()){a.s=E 6.5.1J(a.s.U()-d,a.s.T()-K);j=a.s;p(f){6.5.9.r(c.3,"1i",a)}F{d=a.s.U()-c.3.Z().U();K=a.s.T()-c.3.Z().T();6.5.9.r(c.3,"1e",a)}}}),6.5.9.w(2.k,"1d",7(e){c.k.4.1c="2i";6.5.9.r(c.3,"1d",e)}),6.5.9.w(2.k,"1D",7(e){c.k.4.1c=c.3.2g();6.5.9.r(c.3,"1D",e)}),6.5.9.w(2.k,"1C",7(e){p(i){i=t}F{g(e);6.5.9.r(c.3,"1C",e)}}),6.5.9.w(2.k,"1A",7(e){g(e);6.5.9.r(c.3,"1A",e)}),6.5.9.w(2.k,"1z",7(e){h=u;f=t;d=0;K=0;g(e);6.5.9.r(c.3,"1z",e)}),6.5.9.o(2.3,"1e",7(a){f=u;b=c.3.1b()}),6.5.9.o(2.3,"1i",7(a){c.3.O(a.s);c.3.D(2a)}),6.5.9.o(2.3,"1n",7(a){f=t;c.3.D(b)}),6.5.9.o(2.3,"29",7(){c.O()}),6.5.9.o(2.3,"28",7(){c.D()}),6.5.9.o(2.3,"27",7(){c.N()}),6.5.9.o(2.3,"26",7(){c.N()}),6.5.9.o(2.3,"25",7(){c.16()}),6.5.9.o(2.3,"23",7(){c.15()}),6.5.9.o(2.3,"21",7(){c.13()}),6.5.9.o(2.3,"1Z",7(){c.L()}),6.5.9.o(2.3,"1X",7(){c.L()})]};m.l.1W=7(){n i;2.8.1r.1q(2.8);2.k.1r.1q(2.k);1p(i=0;i<2.11.1V;i++){6.5.9.1U(2.11[i])}};m.l.1T=7(){2.15();2.16();2.L()};m.l.15=7(){n a=2.3.z("Y");p(H a.1S==="P"){2.8.W=a;2.k.W=2.8.W}F{2.8.G(a);a=a.1R(u);2.k.G(a)}};m.l.16=7(){2.k.1Q=2.3.1O()||""};m.l.L=7(){n i,q;2.8.S=2.3.z("R");2.k.S=2.8.S;2.8.4.C="";2.k.4.C="";q=2.3.z("q");1p(i 1L q){p(q.1K(i)){2.8.4[i]=q[i];2.k.4[i]=q[i]}}2.1l()};m.l.1l=7(){2.8.4.I="1m";2.8.4.J="1g";p(H 2.8.4.B!=="P"){2.8.4.1k="1j(B="+(2.8.4.B*1I)+")"}2.k.4.I=2.8.4.I;2.k.4.J=2.8.4.J;2.k.4.B=0.1H;2.k.4.1k="1j(B=1)";2.13();2.O();2.N()};m.l.13=7(){n a=2.3.z("X");2.8.4.1h=-a.x+"v";2.8.4.1f=-a.y+"v";2.k.4.1h=-a.x+"v";2.k.4.1f=-a.y+"v"};m.l.O=7(){n a=2.1G().1F(2.3.Z());2.8.4.12=a.x+"v";2.8.4.M=a.y+"v";2.k.4.12=2.8.4.12;2.k.4.M=2.8.4.M;2.D()};m.l.D=7(){n a=(2.3.z("14")?-1:+1);p(H 2.3.1b()==="P"){2.8.4.A=2h(2.8.4.M,10)+a;2.k.4.A=2.8.4.A}F{2.8.4.A=2.3.1b()+a;2.k.4.A=2.8.4.A}};m.l.N=7(){p(2.3.z("1a")){2.8.4.Q=2.3.2f()?"2e":"1B"}F{2.8.4.Q="1B"}2.k.4.Q=2.8.4.Q};7 19(a){a=a||{};a.Y=a.Y||"";a.X=a.X||E 6.5.2d(0,0);a.R=a.R||"2c";a.q=a.q||{};a.14=a.14||t;p(H a.1a==="P"){a.1a=u}2.1y=E m(2);6.5.18.1x(2,1w)}19.l=E 6.5.18();19.l.17=7(a){6.5.18.l.17.1x(2,1w);2.1y.17(a)};', 62, 143, '||this|marker_|style|maps|google|function|labelDiv_|event|||||||||||eventDiv_|prototype|MarkerLabel_|var|addListener|if|labelStyle|trigger|latLng|false|true|px|addDomListener|||get|zIndex|opacity|cssText|setZIndex|new|else|appendChild|typeof|position|overflow|cLngOffset|setStyles|top|setVisible|setPosition|undefined|display|labelClass|className|lng|lat|document|innerHTML|labelAnchor|labelContent|getPosition||listeners_|left|setAnchor|labelInBackground|setContent|setTitle|setMap|Marker|MarkerWithLabel|labelVisible|getZIndex|cursor|mouseover|dragstart|marginTop|hidden|marginLeft|drag|alpha|filter|setMandatoryStyles|absolute|dragend|mouseup|for|removeChild|parentNode|getPanes|stopPropagation|div|preventDefault|arguments|apply|label|mousedown|dblclick|none|click|mouseout|createElement|fromLatLngToDivPixel|getProjection|01|100|LatLng|hasOwnProperty|in|getDraggable|mousemove|getTitle|getMap|title|cloneNode|nodeType|draw|removeListener|length|onRemove|labelstyle_changed|onAdd|labelclass_changed|overlayMouseTarget|labelanchor_changed|OverlayView|labelcontent_changed|overlayImage|title_changed|labelvisible_changed|visible_changed|zindex_changed|position_changed|1000000|cancelBubble|markerLabels|Point|block|getVisible|getCursor|parseInt|pointer'.split('|'), 0, {}))
        //Initialisation de la carte
        function initialiser() {

            myArrowIcon.src = "../../Ressources/Images/arrow.png";
            var latlng22 = new google.maps.LatLng(33.55684565747316, -7.591896057128906);

            var latlng = new google.maps.LatLng(33.5561882, -7.5539764);

            var options = {
                center: latlng,
                zoom: 13,
                mapTypeId: google.maps.MapTypeId.ROADMAP,
                zoomControl: true,
                zoomControlOptions: {
                    style: google.maps.ZoomControlStyle.SMALL
                }
            };
            carte = new google.maps.Map(document.getElementById("carte"), options);
        }


        google.maps.event.addDomListener(window, 'load', initialiser);

        function request(callback) {
            var xhr = getXMLHttpRequest();

            xhr.onreadystatechange = function () {
                if (xhr.readyState == 4 && (xhr.status == 200 || xhr.status == 0)) {
                    callback(xhr.responseText);
                }
            };


            xhr.open('GET', 'contenupan.aspx', true);
            xhr.send(null);
        }

        function readData(sData) {
            document.getElementById('panelbas').innerHTML = (sData);
        }
        function changerColor(color) {
            alert(color)
            document.getElementById('button-1056-btnEl').style.backgroundColor = color;
        }

        function AfficherTrajet(_poly, color) {


            var tableauPointsPolyline = _poly.split(';');

            for (var i = 0; i < tableauPointsPolyline.length; ++i) {
                tableauPointsPolyline[i] = eval(tableauPointsPolyline[i]);

                var icon;
                if (i == 0) {
                    icon = new google.maps.MarkerImage("../../Ressources/Images/start.png",
                  new google.maps.Size(20, 26),
                  new google.maps.Point(0, 0),
                  new google.maps.Point(10, 25));

                }
                else if (i == tableauPointsPolyline.length - 1) {
                    icon = new google.maps.MarkerImage("../../Ressources/Images/stop.png",
                         new google.maps.Size(20, 26),
                         new google.maps.Point(0, 0),
                         new google.maps.Point(10, 25));
                }
                else {
                    icon = new google.maps.MarkerImage("../../Ressources/Images/iconetransparant.png",
                        new google.maps.Size(20, 26),
                        new google.maps.Point(0, 0),
                        new google.maps.Point(10, 25));
                }
                markerStart = new google.maps.Marker({

                    map: carte,
                    position: tableauPointsPolyline[i],
                    icon: icon,
                    zoom: 13,
                    draggable: true
                });

            }

            var optionsPolyline = {
                strokeColor: color,
                strokeWeight: 7,
                map: carte,
                path: tableauPointsPolyline
            };

            var maPolyline = new google.maps.Polyline(optionsPolyline);


            carte.setCenter(tableauPointsPolyline[0]);
            carte.setZoom(12);
        }




    </script>
</head>
<body>
    <form id="form1" runat="server">

        <ext:ResourceManager ID="ResourceManager2" runat="server" />

        <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout">
            <%--  <Content>
                <a id="a_collapse_index" href="#" onclick="reduirePanelGauche();" style="position: absolute; top: 46%; left: 279px; z-index: 99; width: 30px; height: 30px; background-color: #FFF; border: 1px solid #AAA; border-left: 0px; border-top-right-radius: 5px; border-bottom-right-radius: 5px;">
                    <img src="../../Ressources/Images/collapse.png" style="margin-left: 3px; margin-top: 3px;" border="0" alt="Reduire Agrandir" /></a>
                <div id="COUNTDOWNINFO" style="position: absolute; top: 0; left: 0; width: 280px; height: 20px; z-index: 9999;">
                    Div actualisation


                </div>
                  <div id="Div1" style="position: absolute; top: 0; left: 0; width: 280px; height: 20px; z-index: 9999;">
                    

                      <ext:Button ID="Button"   runat="server" Text="<%$ Resources:Resource,btnclearmap%>" Icon="Map" Width="280" >
                                    <Listeners>
                                        <Click Handler="initialiser();"/>
                                    </Listeners>
                                </ext:Button>
                </div>
            </Content>--%>
            <Items>

                <ext:Panel ID="Panel4"
                    runat="server"
                    Border="false"
                    Region="Center"
                    Header="false">

                    <Content>

                        <div style="width: 100%; height: 100%; overflow: hidden; position: relative;">

                            <div id="carte" style="width: 100%; height: 100%;">
                            </div>
                        </div>
                    </Content>

                </ext:Panel>



                <ext:Panel ID="Panel2"
                    runat="server"
                    Region="South"
                    Header="false"
                    Height="200px"
                    Hidden="false"
                    AutoScroll="true"
                    BodyStyle="background-color:#F1F1F1;"
                    Cls="panelsouth">
                    <Content>
                
                        <a href="#" onclick="reduirediv();" style="position: absolute; top: 0; right: 0; margin-top: 2px; margin-right: 5px; z-index: 99; width: 22px; height: 24px; background-image: url(../../Ressources/Images/collapse.png);"></a>
                        <div style="width: 150px; height: 22px; position: absolute; top: 0; left: 29%; margin-top: 2px; z-index: 99;">
                            <ext:Label ID="label1" runat="server" Text="<%$ Resources:Resource,Trajet_Debut%>"/>
                            </div>
                             <div style="width: 150px; height: 22px; background-color: #FF0; position: absolute; top: 0; left: 33%; margin-top: 2px; z-index: 99;">
                            <ext:DateField
                                ID="DateField1"
                                runat="server"
                                Vtype="daterange"
                                EnableKeyEvents="true">
                              
                                <CustomConfig>
                                    <ext:ConfigItem Name="endDateField" Value="DateField2" Mode="Value" />
                                </CustomConfig>
                                <Listeners>
                                    <KeyUp Fn="onKeyUp" />
                                </Listeners>
                            </ext:DateField>
                        </div>
                        <div style="width: 150px; height: 22px; background-color: #FF0; position: absolute; top: 0; left: 45%; margin-top: 2px; z-index: 99;">
                            <ext:TimeField
                                ID="TimeField1"
                                runat="server"
                                MinTime="00:00"
                                MaxTime="23:59"
                                Increment="15"
                                SelectedTime="09:00"
                                Format="H:mm" />

                        </div>
                         <div style="width: 150px; height: 22px; position: absolute; top: 0; left: 58%; margin-top: 2px; z-index: 99;">
                         <ext:Label ID="label2" runat="server" Text="<%$ Resources:Resource,Trajet_Fin%>"/>
                             </div>
                        <div style="width: 150px; height: 22px; background-color: #FF0; position: absolute; top: 0; left: 63%; margin-top: 2px; z-index: 99;">


                            <ext:DateField
                                ID="DateField2"
                                runat="server"
                                Vtype="daterange"
                                EnableKeyEvents="true"
                                  >
                                <CustomConfig>
                                    <ext:ConfigItem Name="startDateField" Value="DateField1" Mode="Value" />
                                </CustomConfig>
                                <Listeners>
                                    <KeyUp Fn="onKeyUp" />
                                </Listeners>
                            </ext:DateField>

                        </div>
                        <div style="width: 150px; height: 22px; background-color: #FF0; position: absolute; top: 0; left: 75%; margin-top: 2px; z-index: 99;">
                            <ext:TimeField
                                ID="TimeField2"
                                runat="server"
                                MinTime="00:00"
                                MaxTime="23:59"
                                Increment="15"
                                SelectedTime="09:00"
                                Format="H:mm" />

                        </div>
                        <div style="width: 150px; height: 22px;  position: absolute; top: 0; left: 8%; margin-top: 2px; z-index: 99;">
                            <ext:ComboBox ID="MultiCombo1" runat="server" ValueField="vehiculeid" FieldLabel="<%$ Resources:Resource,Historique_Matricule%>"
                                DisplayField="matricule" AllowBlank="true">
                                <Store>
                                    <ext:Store ID="Store2" runat="server">
                                        <Model>
                                            <ext:Model ID="Model3" runat="server">
                                                <Fields>
                                                    <ext:ModelField Name="vehiculeid" />
                                                    <ext:ModelField Name="matricule" />
                                                </Fields>
                                            </ext:Model>
                                        </Model>
                                    </ext:Store>
                                </Store>
                            </ext:ComboBox>
                        </div>
                        <div style="position: absolute; top: 0; left: 89%; z-index: 999; margin-top: 2px;">

                            <a href="#" onclick="mSetMapTrajetAnime();" id="btnplayleft"></a>
                            <a href="#" onclick="PAnimation()" id="btnplay"></a>
                            <a href="#" onclick="" id="btnplayright"></a>
                            <div style="clear: both;"></div>

                           
                            <%-- {GridPanelVoyage}.selModel.getSelected().data.polyline--%>

                        </div>
                        <%--          <div style="padding: 2px 4px 2px 4px; border: 1px solid #CCC; position: absolute; top: 0; left: 70%; margin-top: 2px; z-index: 99;">
                            <ext:Slider ID="sldScore" runat="server" Increment="1" MaxValue="100" Width="300">
                                <Plugins>
                                    <ext:SliderTip ID="SliderTip1" runat="server">
                                        <GetText Fn="function (slider) { return Ext.String.format('<b>{0}% </b>', slider.value); }" />
                                    </ext:SliderTip>
                                </Plugins>
                            </ext:Slider>
                        </div>--%>
                    </Content>
                    <Items>
                        <ext:GridPanel ID="GridPanelVoyage"
                            runat="server" Layout="FitLayout" ForceFit="true"
                            Border="false" Header="false">
                            <Store>
                                <ext:Store ID="Store1" runat="server" PageSize="12">
                                    <Model>
                                        <ext:Model ID="Model1" runat="server">
                                            <Fields>
                                                <ext:ModelField Name="id" />
                                                <ext:ModelField Name="conducteur" />

                                                <ext:ModelField Name="adrD" />
                                                <ext:ModelField Name="dateD" />
                                                <ext:ModelField Name="adrF" />
                                                <ext:ModelField Name="dateF" />

                                                <ext:ModelField Name="duree" />
                                                <ext:ModelField Name="vitesse" />
                                                <ext:ModelField Name="polyline" />
                                                <ext:ModelField Name="color" />
                                                <ext:ModelField Name="km" />
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                </ext:Store>
                            </Store>

                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
                                     <ext:Column ID="Column12" runat="server"  Hidden="true" DataIndex="id" />
                                    <ext:Column ID="Column1" runat="server" Text="<%$ Resources:Resource,Trajet_conducteur%> " DataIndex="conducteur" />
                                    <ext:Column ID="Column2" runat="server" Text="<%$ Resources:Resource,Trajet_AdresseDepart%> " DataIndex="adrD" />
                                    <ext:Column ID="Column3" runat="server" Text="<%$ Resources:Resource,Trajet_DateDepart%>" DataIndex="dateD" />
                                    <ext:Column ID="Column6" runat="server" Text="<%$ Resources:Resource,Trajet_AdresseArrivee%>" DataIndex="adrF" />
                                    <ext:Column ID="Column8" runat="server" Text="<%$ Resources:Resource,Trajet_DateArivee%>" DataIndex="dateF" />
                                    <ext:Column ID="Column4" runat="server" Text="<%$ Resources:Resource,Trajet_Duree%>" DataIndex="duree" />
                                    <ext:Column ID="Column5" runat="server" Text="<%$ Resources:Resource,Trajet_Vitesse%>" DataIndex="vitesse" />
                                    <ext:Column ID="Column7" runat="server" Hidden="true" Text="polyline" DataIndex="polyline" />
                                    <ext:Column ID="Column9" runat="server" Hidden="true" Text="color" DataIndex="color" />
                                    <ext:Column ID="Column10" runat="server" Text="<%$ Resources:Resource,Trajet_Distance%>" DataIndex="km" />
                                    <%--    <ext:CommandColumn ID="CommandColumn1" runat="server" Width="30">
                                        <Commands>
                                            <ext:GridCommand Icon="MapGo" CommandName="Edit" Cls="ajax">
                                                <ToolTip Text="<%$ Resources:Resource,AfficherTrajet%>" />
                                            </ext:GridCommand>
                                        </Commands>
                                        <Listeners>
                                            <Command Handler="AfficherTrajet(record.data.polyline, record.data.color);" />
                                        </Listeners>
                                    </ext:CommandColumn> --%>


                                    <ext:Column ID="Column11" runat="server" />
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:CheckboxSelectionModel ID="CheckboxSelectionModel1" runat="server" >
                                    <Listeners>
                                        <Select Handler="getpolygone(record.data.dateD,record.data.dateF,record.data.id);AfficherTrajet(record.data.polyline, record.data.color);" />
                                   
                                         </Listeners>
                                </ext:CheckboxSelectionModel>
                            </SelectionModel>
                            <TopBar>
                                <ext:Toolbar ID="Toolbar1" runat="server">
                                    <Items>
                                        <ext:Button ID="Button1" runat="server" Text="<%$ Resources:Resource,Trajet_trajets%>" OnDirectClick="HistoriqueTrajet">
                                           
                                        </ext:Button>

                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <BottomBar>
                                <ext:PagingToolbar ID="PagingToolbar1" runat="server" />
                            </BottomBar>

                        </ext:GridPanel>

                    </Items>
                </ext:Panel>
            </Items>
        </ext:Viewport>

    </form>
</body>
</html>
