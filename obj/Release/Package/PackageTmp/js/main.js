$(document).ready(function(){
    $('.tooltips-general').tooltip('hide');
    $('.mobile-menu-button').on('click', function(){
        var mobileMenu=$('.navbar-lateral');	
        if(mobileMenu.css('display')=='none'){
            mobileMenu.fadeIn(300);
        }else{
            mobileMenu.fadeOut(300);
        }
    });
    $('.dropdown-menu-button').on('click', function(){
        var dropMenu=$(this).next('ul');
        dropMenu.slideToggle('slow');
    });
    $('.exit-system-button').on('click', function(e){
        e.preventDefault();
        var LinkExitSystem=$(this).attr("data-href");
        swal({
            title: "Salir del sistema",
            text: "Quieres salir del sistema y cerrar la sesion actual",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#5cb85c",
            confirmButtonText: "Si, salir",
            cancelButtonText: "No, cancelar",
            animation: "slide-from-top",
            closeOnConfirm: false 
        },function(){
            window.location=LinkExitSystem; 
        });  
    });
    
       $("#mySelect").change(function(event) {
    if($(this)[0].selectedIndex==0)
      {
        $(this).prop('required',true);
        $("#txtFin").val('');
      }
      else
      {
      	$(this).prop('required',false);
      	$("#txtFin").val($("#mySelect option:selected").val());
      }
  });
    
      $('.eliminar').on('click', function(e){
        e.preventDefault();
        var LinkExitSystem=$(this).attr("data-href");
        swal({
            title: "Eliminar usuario",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#D3322D",
            confirmButtonText: "Confirmar",
            cancelButtonText: "Cancelar",
            animation: "slide-from-top",
            closeOnConfirm: false 
        },function(){
            window.location=LinkExitSystem; 
        });  
    });
    
      $('.insertar').on('click', function(e){
        e.preventDefault();
        swal({
            title: "Insertar datos",
  type: "warning",
  showCancelButton: true,
  confirmButtonClass: "btn-danger",
   confirmButtonColor: '#61DE56',
   cancelButtonColor: '#D54736',
  confirmButtonText: "Confirmar",
  cancelButtonText: "Cancelar",
  closeOnConfirm: false
        },function(){
             document.forms["ingreso"].submit();
        });  
    });
    
          $('.modificar').on('click', function(e){
        e.preventDefault();
        swal({
            title: "Modificar datos",
  type: "warning",
  showCancelButton: true,
  confirmButtonClass: "btn-danger",
   confirmButtonColor: '#61DE56',
   cancelButtonColor: '#D54736',
  confirmButtonText: "Confirmar",
  cancelButtonText: "Cancelar",
  closeOnConfirm: false
        },function(){
             document.forms["modificarr"].submit();
        });  
    });
    
   
    
        $('.retirar').on('click', function(e){
        e.preventDefault();
        swal({
            title: "Retirar Parte",
  type: "warning",
  showCancelButton: true,
  confirmButtonClass: "btn-danger",
   confirmButtonColor: '#61DE56',
   cancelButtonColor: '#D54736',
  confirmButtonText: "Confirmar",
  cancelButtonText: "Cancelar",
  closeOnConfirm: false
        },function(){
             document.forms["retiro"].submit();
        });  
    });
    
    $('.search-book-button').click(function(e){
        e.preventDefault();
        var LinkSearchBook=$(this).attr("data-href");
        swal({
           title: "¿Qué producto busca?",
           text: "Por favor escribe el nombre del producto",
           type: "input",   
           showCancelButton: true,
           closeOnConfirm: false,
           animation: "slide-from-top",
           cancelButtonText: "Cancelar",
           confirmButtonText: "Buscar",
           confirmButtonColor: "#3598D9",
           inputPlaceholder: "Escribe aquí el nombre del producto" }, 
      function(inputValue){
           if (inputValue === false) return false;  

           if (inputValue === "") {
               swal.showInputError("Debes escribir el nombre del producto");     
               return false;   
           } 
            window.location=LinkSearchBook+"?bookName="+inputValue;
       });
    });
    $('.btn-help').on('click', function(){
        $('#ModalHelp').modal({
            show: true,
            backdrop: "static"
        });
    });
});
(function($){
    $(window).load(function(){
        $(".custom-scroll-containers").mCustomScrollbar({
            theme:"dark-thin",
            scrollbarPosition: "inside",
            autoHideScrollbar: true,
            scrollButtons:{ enable: true }
        });
    });
}
        
        )(jQuery);


       function doSearch()
        {
            
            const tableReg = document.getElementById('datos');
            const searchText = document.getElementById('searchTerm').value.toLowerCase();
            let total = 0;
 
            // Recorremos todas las filas con contenido de la tabla
            for (let i = 1; i < tableReg.rows.length; i++) {
                // Si el td tiene la clase "noSearch" no se busca en su cntenido
                if (tableReg.rows[i].classList.contains("noSearch")) {
                    continue;
                }
 
                let found = false;
                const cellsOfRow = tableReg.rows[i].getElementsByTagName('td');
                // Recorremos todas las celdas
                for (let j = 0; j < cellsOfRow.length && !found; j++) {
                    const compareWith = cellsOfRow[j].innerHTML.toLowerCase();
                    // Buscamos el texto en el contenido de la celda
                    if (searchText.length == 0 || compareWith.indexOf(searchText) > -1) {
                        found = true;
                        total++;
                    }
                }
                if (found) {
                    tableReg.rows[i].style.display = '';
                } else {
                    // si no ha encontrado ninguna coincidencia, esconde la
                    // fila de la tabla
                    tableReg.rows[i].style.display = 'none';
                }
            }
 
            // mostramos las coincidencias
            const lastTR=tableReg.rows[tableReg.rows.length-1];
            const td=lastTR.querySelector("td");
            lastTR.classList.remove("hide", "red");
            if (searchText == "") {
                lastTR.classList.add("hide");
            } else if (total) {
                td.innerHTML="Se ha encontrado "+total+" coincidencia"+((total>1)?"s":"");
            } else {
                lastTR.classList.add("red");
                td.innerHTML="No se han encontrado coincidencias";
            }
        }