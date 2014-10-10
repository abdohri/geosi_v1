<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoadTrajet.aspx.cs" Inherits="GeoSI.Website.Modules.Trajet.LoadTrajet" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../Ressources/Styles/common/colorbox.css" rel="stylesheet" type="text/css" />
    <title></title>
    <style>
        #partie2
        {
            border: 2px dashed inset red;
            width: 200px;
            height: 100px;
            background-color: red;
            /*position: absolute;*/
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
 
    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false"></script>
    <script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false&v=3&libraries=geometry"></script>


    <script>
        eval(function (p, a, c, k, e, r) { e = function (c) { return (c < a ? '' : e(parseInt(c / a))) + ((c = c % a) > 35 ? String.fromCharCode(c + 29) : c.toString(36)) }; if (!''.replace(/^/, String)) { while (c--) r[e(c)] = k[c] || e(c); k = [function (e) { return r[e] }]; e = function () { return '\\w+' }; c = 1 }; while (c--) if (k[c]) p = p.replace(new RegExp('\\b' + e(c) + '\\b', 'g'), k[c]); return p }('7 m(a){2.3=a;2.8=V.1E("1u");2.8.4.C="I: 1m; J: 1g;";2.k=V.1E("1u");2.k.4.C=2.8.4.C}m.l=E 6.5.22();m.l.1Y=7(){n c=2;n h=t;n f=t;n j;n b;n d,K;n i;n g=7(e){p(e.1v){e.1v()}e.2b=u;p(e.1t){e.1t()}};2.1s().24.G(2.8);2.1s().20.G(2.k);2.11=[6.5.9.w(V,"1o",7(a){p(f){a.s=j;i=u;6.5.9.r(c.3,"1n",a)}h=t;6.5.9.r(c.3,"1o",a)}),6.5.9.o(c.3.1P(),"1N",7(a){p(h&&c.3.1M()){a.s=E 6.5.1J(a.s.U()-d,a.s.T()-K);j=a.s;p(f){6.5.9.r(c.3,"1i",a)}F{d=a.s.U()-c.3.Z().U();K=a.s.T()-c.3.Z().T();6.5.9.r(c.3,"1e",a)}}}),6.5.9.w(2.k,"1d",7(e){c.k.4.1c="2i";6.5.9.r(c.3,"1d",e)}),6.5.9.w(2.k,"1D",7(e){c.k.4.1c=c.3.2g();6.5.9.r(c.3,"1D",e)}),6.5.9.w(2.k,"1C",7(e){p(i){i=t}F{g(e);6.5.9.r(c.3,"1C",e)}}),6.5.9.w(2.k,"1A",7(e){g(e);6.5.9.r(c.3,"1A",e)}),6.5.9.w(2.k,"1z",7(e){h=u;f=t;d=0;K=0;g(e);6.5.9.r(c.3,"1z",e)}),6.5.9.o(2.3,"1e",7(a){f=u;b=c.3.1b()}),6.5.9.o(2.3,"1i",7(a){c.3.O(a.s);c.3.D(2a)}),6.5.9.o(2.3,"1n",7(a){f=t;c.3.D(b)}),6.5.9.o(2.3,"29",7(){c.O()}),6.5.9.o(2.3,"28",7(){c.D()}),6.5.9.o(2.3,"27",7(){c.N()}),6.5.9.o(2.3,"26",7(){c.N()}),6.5.9.o(2.3,"25",7(){c.16()}),6.5.9.o(2.3,"23",7(){c.15()}),6.5.9.o(2.3,"21",7(){c.13()}),6.5.9.o(2.3,"1Z",7(){c.L()}),6.5.9.o(2.3,"1X",7(){c.L()})]};m.l.1W=7(){n i;2.8.1r.1q(2.8);2.k.1r.1q(2.k);1p(i=0;i<2.11.1V;i++){6.5.9.1U(2.11[i])}};m.l.1T=7(){2.15();2.16();2.L()};m.l.15=7(){n a=2.3.z("Y");p(H a.1S==="P"){2.8.W=a;2.k.W=2.8.W}F{2.8.G(a);a=a.1R(u);2.k.G(a)}};m.l.16=7(){2.k.1Q=2.3.1O()||""};m.l.L=7(){n i,q;2.8.S=2.3.z("R");2.k.S=2.8.S;2.8.4.C="";2.k.4.C="";q=2.3.z("q");1p(i 1L q){p(q.1K(i)){2.8.4[i]=q[i];2.k.4[i]=q[i]}}2.1l()};m.l.1l=7(){2.8.4.I="1m";2.8.4.J="1g";p(H 2.8.4.B!=="P"){2.8.4.1k="1j(B="+(2.8.4.B*1I)+")"}2.k.4.I=2.8.4.I;2.k.4.J=2.8.4.J;2.k.4.B=0.1H;2.k.4.1k="1j(B=1)";2.13();2.O();2.N()};m.l.13=7(){n a=2.3.z("X");2.8.4.1h=-a.x+"v";2.8.4.1f=-a.y+"v";2.k.4.1h=-a.x+"v";2.k.4.1f=-a.y+"v"};m.l.O=7(){n a=2.1G().1F(2.3.Z());2.8.4.12=a.x+"v";2.8.4.M=a.y+"v";2.k.4.12=2.8.4.12;2.k.4.M=2.8.4.M;2.D()};m.l.D=7(){n a=(2.3.z("14")?-1:+1);p(H 2.3.1b()==="P"){2.8.4.A=2h(2.8.4.M,10)+a;2.k.4.A=2.8.4.A}F{2.8.4.A=2.3.1b()+a;2.k.4.A=2.8.4.A}};m.l.N=7(){p(2.3.z("1a")){2.8.4.Q=2.3.2f()?"2e":"1B"}F{2.8.4.Q="1B"}2.k.4.Q=2.8.4.Q};7 19(a){a=a||{};a.Y=a.Y||"";a.X=a.X||E 6.5.2d(0,0);a.R=a.R||"2c";a.q=a.q||{};a.14=a.14||t;p(H a.1a==="P"){a.1a=u}2.1y=E m(2);6.5.18.1x(2,1w)}19.l=E 6.5.18();19.l.17=7(a){6.5.18.l.17.1x(2,1w);2.1y.17(a)};', 62, 143, '||this|marker_|style|maps|google|function|labelDiv_|event|||||||||||eventDiv_|prototype|MarkerLabel_|var|addListener|if|labelStyle|trigger|latLng|false|true|px|addDomListener|||get|zIndex|opacity|cssText|setZIndex|new|else|appendChild|typeof|position|overflow|cLngOffset|setStyles|top|setVisible|setPosition|undefined|display|labelClass|className|lng|lat|document|innerHTML|labelAnchor|labelContent|getPosition||listeners_|left|setAnchor|labelInBackground|setContent|setTitle|setMap|Marker|MarkerWithLabel|labelVisible|getZIndex|cursor|mouseover|dragstart|marginTop|hidden|marginLeft|drag|alpha|filter|setMandatoryStyles|absolute|dragend|mouseup|for|removeChild|parentNode|getPanes|stopPropagation|div|preventDefault|arguments|apply|label|mousedown|dblclick|none|click|mouseout|createElement|fromLatLngToDivPixel|getProjection|01|100|LatLng|hasOwnProperty|in|getDraggable|mousemove|getTitle|getMap|title|cloneNode|nodeType|draw|removeListener|length|onRemove|labelstyle_changed|onAdd|labelclass_changed|overlayMouseTarget|labelanchor_changed|OverlayView|labelcontent_changed|overlayImage|title_changed|labelvisible_changed|visible_changed|zindex_changed|position_changed|1000000|cancelBubble|markerLabels|Point|block|getVisible|getCursor|parseInt|pointer'.split('|'), 0, {}))
        var tab_polyline=new Array();
        var nbr=0;
        var carte = null;
        var creator;
        var mTempMakerPoi = null;

        var route;
        var directionsService = new google.maps.DirectionsService();
        

      
        function RemplirPoly()
        {
            
            var poly="";
            var i=2;
           
            poly=tab_polyline[0]+" "+tab_polyline[1];
             
           
            // for (i=2 ; i<nbr ; i+2)
            while(i<tab_polyline.length)
            {
              
                poly = poly+","+tab_polyline[i]+" "+tab_polyline[i+1];
               
                i=i+2;
            
            }
            
            document.getElementById("polyline-inputEl").value=poly;
            tab_polyline=[];
            nbr=0;
        }
        function AjouterAuTrajet()
        {
            var _lat = document.getElementById("latitude-inputEl").value;
            var _long = document.getElementById("longitude-inputEl").value;
            if(_lat != "")
            {
                tab_polyline[nbr]=_lat;
                tab_polyline[nbr+1]=_long;
                nbr=nbr+2;
               
            }
        }
        function AfficherPoi()
        {
            
            var _lat = document.getElementById("latitude-inputEl").value;
            var _long = document.getElementById("longitude-inputEl").value;
            if(_lat != "")
            {
                //    tab_polyline[nbr]=_lat;
                //    tab_polyline[nbr+1]=_long;
                //    nbr=nbr+2;
                
           
                var latlng = new google.maps.LatLng(parseFloat(_lat), parseFloat(_long));
                // var latlng = new google.maps.LatLng(_record.data.latitude, _record.data.longitude);
                var icon = new google.maps.MarkerImage("../../Ressources/Images/Drapeau_Bleu.png",
                         new google.maps.Size(20, 26),
                         new google.maps.Point(0, 0),
                         new google.maps.Point(10, 25));
                mTempMakerPoi = new google.maps.Marker({

                    map: carte,
                    position: latlng,
                    icon: icon,
                    zoom: 13,
               
                    draggable: true
                });
            }
            carte.setCenter(latlng);
            carte.setZoom(14);
        }

       
        function AfficherTrajet(_poly)

        {
            var start = new Array();
            var end = new Array();
            var route = new Array();
            

            initialiser();
           
            
            var tableauPointsPolyline =_poly.split(';'); 
            alert(_poly)
            for(var i=0; i<tableauPointsPolyline.length; ++i){
                tableauPointsPolyline[i] = eval(tableauPointsPolyline[i]);
                var icon;
                if(i==0)
                {
                    icon = new google.maps.MarkerImage("../../Ressources/Images/Drapeau_Orange.png",
                  new google.maps.Size(20, 26),
                  new google.maps.Point(0, 0),
                  new google.maps.Point(10, 25));
                }
                else
                {
                    icon = new google.maps.MarkerImage("../../Ressources/Images/Drapeau_Bleu.png",
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
           /////////////////////////////////////////// 
            var n = tableauPointsPolyline.length;
            var j = 1;
            var k = 0;

            ////// Fill start point and end point ///////
            for(var i=0; i<n-1;i++)
            {
                start[i] = tableauPointsPolyline[k];
                end[i] = tableauPointsPolyline[j];
                j++;
                k++;
            }


            for(var i=0; i<n ; i++){


                var request = {
                    origin: start[i],
                    destination: end[i],
                    travelMode: google.maps.TravelMode.DRIVING
                };

            
                    directionsService.route(request, function(response, status) {
                        if (status == google.maps.DirectionsStatus.OK) {
                    
                            route[i] = response.routes[0];
                            var optionsPolyline = {
                                map: carte,
                                path: route[i].overview_path
                            };
                            var maPolyline = new google.maps.Polyline( optionsPolyline );
                    
                        }

                        else {alert("pas service");}
                    });
            }
            ///////////////////////////////////////////////////////////
            
            carte.setCenter(tableauPointsPolyline[0]);
            carte.setZoom(13);
           
            
        }
        function AjouterPoi()
        {
            document.getElementById("poiid-inputEl").value = "";
            var latlng = new google.maps.LatLng(33.5561882, -7.5539764);
            var icon = new google.maps.MarkerImage("../../Ressources/Images/poi.png",
                     new google.maps.Size(20, 26),
                     new google.maps.Point(0, 0),
                     new google.maps.Point(10, 25));
            mTempMakerPoi = new google.maps.Marker({
                map: carte,
                position: latlng,
                icon: icon,
                draggable: true
            });
            document.getElementById("latitude-inputEl").value = carte.getCenter().lat();

            document.getElementById("longitude-inputEl").value = carte.getCenter().lng();

            google.maps.event.addListener(mTempMakerPoi, 'click', function () {

                var point = mTempMakerPoi.getPosition();

                document.getElementById("latitude-inputEl").value = point.lat();

                document.getElementById("longitude-inputEl").value = point.lng();

            }
            );

            carte.setCenter(latlng);
            carte.setZoom(14);
        }
        function initialiser() {

            var latlng = new google.maps.LatLng(33.5561882, -7.5539764);

            var options =
                {
                    center: latlng,
                    zoom: 13,
                    mapTypeId: google.maps.MapTypeId.ROADMAP,
                    zoomControl: true,
                    zoomControlOptions: {
                        style: google.maps.ZoomControlStyle.SMALL
                    }
                };
            carte = new google.maps.Map(document.getElementById("carte"), options);
          
            // google.maps.event.addDomListener(carte, 'click', AjouterPoi);
        }
        google.maps.event.addDomListener(window, 'load', initialiser);
        //Fermeture du div
        function closediv() {

            // Ext.getCmp("Checkbox1").setValue(false);
            Ext.getCmp("Panel2").setVisible(false);
        }
        // Reduire le div
        function reduirediv() {
            if (Ext.getCmp("Panel4").height == 200) {
                Ext.getCmp("Panel4").setHeight(40);
            } else {
                Ext.getCmp("Panel4").setHeight(200);
            }

        }
       
        function EditTrajet(_recod) {

            document.getElementById("trajetid-inputEl").value = _recod.data.trajetid;
            document.getElementById("trajet-inputEl").value = _recod.data.trajet;
            document.getElementById("datetrajet-inputEl").value = _recod.data.datetrajet;
            document.getElementById("vehiculeid-inputEl").value = _recod.data.vehicule
            
        }
        function codeAddress() {
           
            var geocoder= new google.maps.Geocoder();
            var address = document.getElementById("adresse-inputEl").value;
          
            geocoder.geocode(
                { 'address': address}, 
                function(results, status)
                {
                    if (status == google.maps.GeocoderStatus.OK) 
                    {
                       
                        carte.setCenter(results[0].geometry.location);
                        var mTempMakerPoi = new google.maps.Marker({
                            map: carte,
                            position:results[0].geometry.location
                        });
                        var point=mTempMakerPoi.getPosition();
                        document.getElementById("latitude-inputEl").value =point.lat();
                        document.getElementById("longitude-inputEl").value =point.lng();

                    }
                    else 
                    {
                        alert("Geocode was not successful for the following reason: " + status);
                    }
                });
            //X.Recherche();
        }


       
    </script>

    <script src="../../Ressources/Scripts/common/jquery.colorbox.js" type="text/javascript"></script>
    <script src="../../Ressources/Scripts/common/js_common_module.js" type="text/javascript"></script>
    <ext:XScript ID="XScript1" runat="server">
      <script type="text/javascript">            //Filtres du grid 
          //Application des filtres       
          var applyFilter = function (field) {                
              var store = #{GridTrajet}.getStore();
              store.filterBy(getRecordFilter());                                                
          };
          //Vider les champs des filtres
          var clearFilter = function () 
          {
              #{TrajetFilter}.reset();
              #{DateFilter}.reset();
              #{ComboBox1}.reset();
              #{StoreTrajet}.clearFilter();
          } 
          //Méthode pour filtrer un String
          var filterString = function (value, dataIndex, record) {
              var val = record.get(dataIndex);
                
              if (typeof val != "string") {
                  return value.length == 0;
              }
                
              return val.toLowerCase().indexOf(value.toLowerCase()) > -1;
          };
          //Méthode pour filtrer un date
          var filterDate = function (value, dataIndex, record) {
              var val = Ext.Date.clearTime(record.get(dataIndex), true).getTime();
 
              if (!Ext.isEmpty(value, false) && val != Ext.Date.clearTime(value, true).getTime()) {
                  return false;
              }
              return true;
          };
          //Méthode pour filtrer un Number
          var filterNumber = function (value, dataIndex, record) {
              var val = record.get(dataIndex);                
 
              if (!Ext.isEmpty(value, false) && val != value) {
                  return false;
              }
                
              return true;
          };
          //Définition des filtres pour chaque champs du grid 
          var getRecordFilter = function () {
              var f = [];
 
              f.push({
                  filter: function (record) {                         
                      return filterString(#{TrajetFilter}.getValue(), "trajet", record);
                  }
              });
                  
            
             
              f.push({
                  filter: function (record) {                         
                      return filterString(#{DateFilter}.getValue(), "datetrajet", record);
                  }
              }); 

              f.push({
                  filter: function (record) {                         
                      return filterString(#{ComboBox1}.getValue()||"", "vehicule", record);
                  }
              });
             
 
              var len = f.length;
                 
              return function (record) {
                  for (var i = 0; i < len; i++) {
                      if (!f[i].filter(record)) {
                          return false;
                      }
                  }
                  return true;
              };
          };
        </script>
    </ext:XScript>
</head>
<body>
    <form id="form1" runat="server">

        <ext:ResourceManager ID="ResourceManager2" runat="server" />

        <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout">

            <Items>

                <ext:Panel ID="Panel2"
                    runat="server"
                    Border="false"
                    Region="West"
                    Width="400px"
                    Height="100px"
                    Header="false">
                    <%-- BodyStyle="background-color: red"--%>
                    <%-- <ext:Button ID="button_Save" runat="server" Text="Button2" OnDirectClick="UpdateTimeStamp"></ext:Button>--%>

                    <Content>
                        <%--                        <div id="COUNTDOWNINFO" style="position: absolute;margin-bottom:200px;bottom:200px; top: 0; left: 0; width:100%; height: 100px; z-index: 9999; background: blue;">
                            Div actualisation


                        </div>--%>

                        <ext:FormPanel StandardSubmit="true" ID="UserForm" Frame="true" runat="server" Method="POST">
                            <Items>
                                <ext:TextField ID="trajetid" Hidden="true" runat="server" Width="310" MaxLength="30" />

                                <ext:TextField ID="trajet" runat="server" FieldLabel="<%$ Resources:Resource,Trajet_Trajet%>" Width="310" Vtype="num" AllowBlank="false" MaxLength="30" />

                                <ext:DateField ID="datetrajet"
                                    runat="server"
                                    Width="310"
                                    FieldLabel="<%$ Resources:Resource,Trajet_Date%> ">
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="false"></ext:FieldTrigger>
                                    </Triggers>
                                    <Listeners>
                                        <TriggerClick Handler="this.setValue('');"></TriggerClick>
                                    </Listeners>

                                </ext:DateField>
                                <ext:ComboBox ID="vehiculeid" DisplayField="matricule" Width="310" MinChars="1" TypeAhead="true"
                                    ForceSelection="true" ValueField="vehiculeid" runat="server" FieldLabel="<%$ Resources:Resource,Trajet_Vehicule%>">
                                    <Store>
                                        <ext:Store ID="Store4" runat="server">
                                            <Model>
                                                <ext:Model ID="Model2" runat="server">
                                                    <Fields>
                                                        <ext:ModelField Name="vehiculeid" />
                                                        <ext:ModelField Name="matricule" />
                                                    </Fields>
                                                </ext:Model>
                                            </Model>
                                        </ext:Store>
                                    </Store>
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Listeners>
                                        <Select Handler="this.getTrigger(0).show();" />
                                        <BeforeQuery Handler="this.getTrigger(0)[this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                        <TriggerClick Handler="if (index == 0) { 
                                           this.clearValue(); 
                                           this.getTrigger(0).hide();
                                       }" />
                                    </Listeners>
                                </ext:ComboBox>



                                <ext:Button ID="Button2" runat="server" Text="<%$ Resources:Resource,Trajet_Position%>" Icon="Add">
                                    <Listeners>
                                        <Click Handler="AjouterPoi();" />
                                    </Listeners>
                                </ext:Button>

                                <ext:TextField ID="latitude" runat="server" FieldLabel="<%$ Resources:Resource,Trajet_Latitude%>" Width="310" />

                                <ext:TextField ID="longitude" runat="server" FieldLabel="<%$ Resources:Resource,Trajet_Longitude%> " Width="310">
                                    <Listeners>
                                        <Change Handler="AfficherPoi();" />
                                    </Listeners>
                                </ext:TextField>

                                <ext:ComboBox ID="poiid" DisplayField="libelle" Width="310" Editable="false"
                                    ValueField="poiid" runat="server" FieldLabel="<%$ Resources:Resource,VehiculeProche_Poi%>"
                                    OnDirectChange="GetPosition">
                                    <Store>
                                        <ext:Store ID="StorePoint" runat="server">
                                            <Model>
                                                <ext:Model ID="Model6" runat="server">
                                                    <Fields>
                                                        <ext:ModelField Name="poiid" />
                                                        <ext:ModelField Name="libelle" />
                                                    </Fields>
                                                </ext:Model>
                                            </Model>
                                        </ext:Store>
                                    </Store>
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="false"></ext:FieldTrigger>
                                    </Triggers>
                                    <Listeners>
                                        <TriggerClick Handler="this.setValue('');"></TriggerClick>

                                    </Listeners>


                                </ext:ComboBox>
                                <ext:TextField ID="polyline" runat="server" Hidden="true" FieldLabel="polyline" Width="310" />
                                <ext:Button ID="Button1" runat="server" Text="<%$ Resources:Resource,Trajet_AjouterAuTrajet%>" Icon="Add">
                                    <Listeners>
                                        <Click Handler="AjouterAuTrajet();" />
                                    </Listeners>
                                </ext:Button>
                                <ext:Button ID="bsave" runat="server" Icon="Disk" Text="<%$ Resources:Resource,btnsave%>" OnDirectClick="Save">
                                    <Listeners>
                                        <Click Handler="RemplirPoly();" />
                                    </Listeners>
                                </ext:Button>
                                <ext:Button ID="button6" runat="server" Text="<%$ Resources:Resource,btnsupp%>" OnDirectClick="DeleteRows" Icon="Delete"></ext:Button>
                                <ext:Button ID="button4" runat="server" Text="<%$ Resources:Resource,btnvider%>" OnDirectClick="Vider"></ext:Button>

                                <ext:Button ID="Button" runat="server" Text="<%$ Resources:Resource,btnclearmap%>" Icon="Map">
                                    <Listeners>
                                        <Click Handler="initialiser();" />
                                    </Listeners>
                                </ext:Button>



                            </Items>
                        </ext:FormPanel>
                    </Content>

                </ext:Panel>


                <ext:Panel ID="Panel1"
                    runat="server"
                    Border="false"
                    Region="Center"
                    Header="false">
                    <%-- <ext:Button ID="button_Save" runat="server" Text="Button2" OnDirectClick="UpdateTimeStamp"></ext:Button>--%>
                    <Content>

                        <div style="width: 100%; height: 100%; overflow: hidden; position: relative;">
                            <div id="carte" style="width: 100%; height: 600px;">
                            </div>
                        </div>
                    </Content>

                </ext:Panel>


                <ext:Panel ID="Panel3"
                    runat="server"
                    Region="South"
                    Header="false"
                    Height="200px"
                    Hidden="false"
                    BodyStyle="background-color:#F1F1F1;"
                    Cls="panelsouth">
                    <Content>
                        <a href="#" onclick="closediv();" style="position: absolute; top: 0; right: 0; margin-top: 2px; margin-right: 5px; z-index: 99; width: 22px; height: 24px; background-image: url(../../Ressources/Images/close_icon.png);"></a>
                        <a href="#" onclick="reduirediv();" style="position: absolute; top: 0; right: 0; margin-top: 2px; margin-right: 35px; z-index: 99; width: 22px; height: 22px; background-image: url(../../Ressources/Images/collapse.png);"></a>
                    </Content>
                    <Items>
                        <ext:Panel
                            ID="Panel4"
                            runat="server"
                            Title="Liste Des Trajets"
                            Height="200px"
                            AutoScroll="true"
                            Icon="ChartLine">


                            <Items>
                                <ext:GridPanel ID="GridTrajet" runat="server" Layout="FitLayout" ForceFit="true" Border="false" Header="false">
                                    <Store>
                                        <ext:Store ID="StoreTrajet" runat="server">
                                            <Model>
                                                <ext:Model ID="Model1" runat="server" OnReadData="MyData_Refresh" IDProperty="trajetid">
                                                    <Fields>
                                                        <ext:ModelField Name="trajetid" Type="Int" UseNull="true" />
                                                        <ext:ModelField Name="trajet" />
                                                        <ext:ModelField Name="vehicule" />
                                                        <ext:ModelField Name="datetrajet" />
                                                        <ext:ModelField Name="polyline" />

                                                    </Fields>
                                                </ext:Model>
                                            </Model>
                                        </ext:Store>
                                    </Store>

                                    <ColumnModel ID="ColumnModel1" runat="server">
                                        <Columns>

                                            <ext:Column ID="Column1" runat="server" Text="N°" DataIndex="trajetid" Hidden="true" />

                                            <ext:Column ID="Column2" runat="server" Text="<%$ Resources:Resource,Trajet_Trajet%>" DataIndex="trajet">
                                                <HeaderItems>
                                                    <ext:TextField ID="TrajetFilter" runat="server" EnableKeyEvents="true">
                                                        <Listeners>
                                                            <KeyUp Handler="applyFilter(this);" Buffer="250" />
                                                        </Listeners>
                                                    </ext:TextField>
                                                </HeaderItems>
                                            </ext:Column>

                                            <ext:DateColumn ID="DateColumn3" runat="server" Text="<%$ Resources:Resource,Trajet_Date%>" DataIndex="datetrajet">
                                                <HeaderItems>
                                                    <ext:DateField ID="DateFilter" runat="server" Editable="false">
                                                        <Listeners>
                                                            <Select Handler="applyFilter(this);" />
                                                        </Listeners>
                                                    </ext:DateField>
                                                </HeaderItems>
                                            </ext:DateColumn>

                                            <ext:Column ID="Column6" runat="server" Text="<%$ Resources:Resource,Trajet_Vehicule%>"
                                                 DataIndex="vehicule">
                                                <HeaderItems>
                                                    <ext:ComboBox
                                                        ID="ComboBox1"
                                                        runat="server"
                                                        TriggerAction="All"
                                                        DisplayField="vehciule"
                                                        ValueField="vehicule"
                                                        Editable="false">
                                                        <Store>
                                                            <ext:Store ID="Store2" runat="server">
                                                                <Model>
                                                                    <ext:Model ID="Model3" runat="server">
                                                                        <Fields>
                                                                            <ext:ModelField Name="vehicule" />
                                                                        </Fields>
                                                                    </ext:Model>
                                                                </Model>
                                                            </ext:Store>
                                                        </Store>
                                                        <Listeners>
                                                            <Select Handler="applyFilter(this);" />
                                                        </Listeners>
                                                    </ext:ComboBox>
                                                </HeaderItems>
                                            </ext:Column>


                                            <ext:Column ID="Column3" runat="server" Hidden="true" Text="p" DataIndex="polyline">
                                                <HeaderItems>
                                                    <ext:TextField ID="TextField1" runat="server" EnableKeyEvents="true">
                                                    </ext:TextField>
                                                </HeaderItems>
                                            </ext:Column>

                                            <ext:CommandColumn ID="CommandColumn2" runat="server" Width="30">
                                                <Commands>
                                                    <ext:GridCommand Icon="NoteEdit" CommandName="Edit" Cls="ajax">
                                                        <ToolTip Text="<%$ Resources:Resource,GridEdit%>" />
                                                    </ext:GridCommand>
                                                </Commands>
                                                <Listeners>
                                                    <Command Handler="EditTrajet(record);" />
                                                </Listeners>
                                            </ext:CommandColumn>

                                            <ext:CommandColumn ID="CommandColumn1" runat="server" Width="30">
                                                <Commands>
                                                    <ext:GridCommand Icon="MapGo" CommandName="Edit" Cls="ajax">
                                                        <ToolTip Text="<%$ Resources:Resource,AfficherTrajet%>" />
                                                    </ext:GridCommand>
                                                </Commands>
                                                <Listeners>
                                                    <Command Handler="AfficherTrajet(record.data.polyline);" />
                                                </Listeners>
                                            </ext:CommandColumn>



                                        </Columns>
                                    </ColumnModel>
                                    <%--    Barre des boutons (ajouter, filterer)--%>
                                    <BottomBar>
                                        <ext:PagingToolbar ID="PagingToolbar1" runat="server" />
                                    </BottomBar>
                                    <TopBar>

                                        <ext:Toolbar ID="Toolbar1" runat="server">
                                            <Items>


                                                <ext:ToolbarFill ID="ToolbarFill1" runat="server" />
                                                <ext:Button ID="Button3" runat="server" Text="<%$ Resources:Resource,DeleteFiltre%>">
                                                    <Listeners>
                                                        <Click Handler="clearFilter(null);" />
                                                    </Listeners>
                                                </ext:Button>
                                            </Items>
                                        </ext:Toolbar>
                                    </TopBar>
                                    <SelectionModel>
                                        <ext:CheckboxSelectionModel ID="CheckboxSelectionModel1" runat="server" Mode="Multi" />
                                    </SelectionModel>
                                </ext:GridPanel>

                            </Items>



                        </ext:Panel>
                    </Items>
                </ext:Panel>

            </Items>
        </ext:Viewport>
    </form>
</body>
</html>
