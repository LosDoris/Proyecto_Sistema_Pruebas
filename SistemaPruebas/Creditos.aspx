<%@ Page EnableEventValidation="false"  Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Creditos.aspx.cs" Inherits="SistemaPruebas.Creditos" Async="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">

    <script>
        $(document).ready(function () {
            $('[data-toggle="popover"]').popover();

        });
</script>

    <script type="text/javascript">
document.getElementById("svg1").addEventListener("load", function() {
    var doc = this.getSVGDocument();
});
</script>
    <legend style="margin-top:45px"><h2>Equipo desarrollador</h2></legend>

<br />

        <div class="jumbotron" font-family: 'Roboto', 'Helvetica Neue', Helvetica, Arial, sans-serif;">
        <h1>¿Quiénes somos?</h1>
        <p class="lead">Los Doroteos es un grupo de cinco estudiantes de computación quienes, en su tercer año de universidad (algunos un poquitín más), han iniciado en el proceso para aprender los secretos ocultos detrás del &lt;div class=””&gt;.Frecuentemente sin respuestas claras y con excesos de preguntas se han esforzado por entregar los mejores productos posibles. Obsesiv@s, detallistas y legos del JavaScript...</p>
        
    </div>

			<div class="row">
                  <p style="text-align:center">
                <a href="#"><img src="Imagenes/tigre.png" /></a> 

                 <img src="Imagenes/panda.png" style="margin-left:65px; margin-right:65px"/>
                 <img src="Imagenes/leon.png" />

<div class="col-md-4">
<div class="panel panel-default" style="margin-left=20px">
  <div class="panel-body">
  <legend style="margin-top:15px"><h5>Ricardo</h5></legend>
      <p> Dícese de un cónyuge que cree, de manera ilusa que ‘todo sale’ y al final si le sale. Poco realista. Idealista. Un ser sin confianza para dejar abierto Telegram, como muestra de poca fe con sus congéneres. Es un joven proficiente en el uso de grids. Aunque no lo acepte, es ávido seguidor de Chayanne. Prueba de esto se encuentra en su cuenta de Spotify. Pronuncia la frase: “vistes” 50 veces en promedio al día. Oveja, Doroteo.</p>
  </div>
</div>
    </div>
                      <div class="col-md-4">
<div class="panel panel-default">
  <div class="panel-body">
   <legend style="margin-top:15px"><h5>Daniel</h5></legend>
       <p> Nacido en el reino encantado de las mariquitas, fue adoptado por una familia originaria de la bruma sagrada, quienes, exiliados en las praderas de las flores construyeron su casa y por poco su hogar. Semi institucionalizado desde corta edad (por decisión propia) y temeroso de las ovejas con piel de lobo, su infancia y adolescencia trascendió entre bolillos, máscaras, pinceles, buses y huelgas. 
Después de un medianamente largo viaje para identificarse como una mariquita -adoptada- ha logrado encontrarse, y en un loop finito espera poder discernir lo mejor posible en todo lo que, este AFND que conocemos como vida, le depare.</p>
  </div>
</div>
                          </div>
<div class="col-md-4">

    <div class="panel panel-default">
  <div class="panel-body">
    <legend style="margin-top:15px"><h5>Carolina</h5></legend>
       <p> Desde unas tierras lejanas, calientes y ubicadas cerca del “mejor clima del mundo” lidera la Scrum Master todo su grupo de Doroteos. Obsesiva con los colores, las posiciones de los objetos, las combinaciones y los detalles que ha simple vista son inobservables; siempre sin descuidar el trabajo de todo su grupo. El epíteto de Scrum sólo vino a decorar una característica que la acompaña desde pequeña.</p>
  </div>
</div>

    </div>
                      </p>


                    <p style="text-align:center">
                <asp:Image id="Image1" runat="server"
                AlternateText="Image text"
                ImageAlign="middle"
                ImageUrl="Imagenes/perro.png"/>
                
                <asp:Image id="Image2" runat="server"
           AlternateText="Image text"
           ImageAlign="middle"
           ImageUrl="Imagenes/lobo.png"/>

                        <div class="col-md-4">
<div class="panel panel-default" style="margin-left=20px">
  <div class="panel-body">
  <legend style="margin-top:15px"><h5>Helena</h5></legend>
      <p>Se destaca por su amplio conocimiento sobre todo. Le encanta el desarrollo de interfaces. No confía en nadie y por eso prefiere que los trabajos tengan sólo el mínimo pues cree que no van a salir . Es realista estimando costos, tiempo, esfuerzo y neuronas en las labores programadoras. Excelente compañera de trabajo. Fabulosa trayendo positivismo al ambiente trabajador. </p>
  </div>
</div>
    </div>
       </p>
			</div>


</asp:Content>