


function EditLightbox(upd) {
    $.colorbox({ width: "80%", height: "80%", iframe: true, href: "GeoForm.aspx?id=" + upd });
}
function AddLightbox() {
    $.colorbox({ width: "80%", height: "80%", iframe: true, href: "GeoForm.aspx?id=0" });
}


function EditLightboxe(upd)
{
    $.colorbox({ width: "80%", height: "90%", iframe: true, href: "conForm.aspx?id=" + upd });
}

function addPdf(upd)
{
    $.colorbox({ width: "50%", height: "60%", iframe: true, href: "pdf.aspx?id=" + upd });
}


function AddLight()
{
    $.colorbox({ width: "400px", height: "400px", iframe: true, href: "GeoForm.aspx?id=0" });
}

function addPdfo(upd)
{
    $.colorbox({ width: "50%", height: "60%", iframe: true, href: "RAcExcel.aspx?id=" + upd });
}

function tree_Load() {
    alert("xxx");
    X.tree_Load();
}


function HistoriqueTrajet() {
    X.HistoriqueTrajet();
}

function UpdateVue(id) {
    X.UpdateVisibilite(id);
}
function GridDelete(id) {
    X.DeleteRowsBehind(id);
}
function GridDesactiver(id) {
    X.DesactiverRowsBehind(id);
}

function GridActiver(id) {
    X.GridActiver(id);
}

function GridPdf(id) {
    X.GeneratePDF(id);
}

//function GridExcel() {
   // X.GenerateEXCEL();
//}


function GridPdfActiv() {

    X.make_pdf();
}





//////////////////////////////// Rapports

function rtpdf(upd) {
    $.colorbox({ width: "50%", height: "60%", iframe: true, href: "RTpdf.aspx?id=" + upd });
}

function rtexcel(upd) {
    $.colorbox({ width: "50%", height: "60%", iframe: true, href: "RTExcel.aspx?id=" + upd });
}

function rjpdf(upd) {
    $.colorbox({ width: "50%", height: "60%", iframe: true, href: "RJpdf.aspx?id=" + upd });
}

function rjexcel(upd) {
    $.colorbox({ width: "50%", height: "60%", iframe: true, href: "RJExcel.aspx?id=" + upd });
}

function rapdf(upd) {
    $.colorbox({ width: "50%", height: "60%", iframe: true, href: "RApdf.aspx?id=" + upd });
}

function raexcel(upd) {
    $.colorbox({ width: "50%", height: "60%", iframe: true, href: "RAExcel.aspx?id=" + upd });
}

function rppdf(upd) {
    $.colorbox({ width: "50%", height: "60%", iframe: true, href: "RPpdf.aspx?id=" + upd });
}

function rpexcel(upd) {
    $.colorbox({ width: "50%", height: "60%", iframe: true, href: "RPExcel.aspx?id=" + upd });
}

function ralpdf(upd) {
    $.colorbox({ width: "50%", height: "60%", iframe: true, href: "RALpdf.aspx?id=" + upd });
}

function ralexcel(upd) {
    $.colorbox({ width: "50%", height: "60%", iframe: true, href: "RALExcel.aspx?id=" + upd });
}

/////////////////////////////////