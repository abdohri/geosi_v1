$(document).ready(function(){
    
    
    var result = true;
    
   //var ck_password = /^[A-Za-z0-9!@#$%^&*()_]{6,20}$/;
    
  $('form').submit(function(){
      
      // champs est vide
      if($('#pseudo').val()=="")
      {
          $('#pseudo').css('border-color','#ff0000');
          $('#pseudo').next('#error1').fadeIn('fast').text('champ obligatoire');
          result = false;
      }
      
      // champs est vide
      if($('#password').val()=="")
      {
          $('#password').css('border-color','#ff0000');
          $('#password').next('#error2').fadeIn('fast').text('champ obligatoire');
          result = false;
      }
      return result;
  }) ;
  
  //champ doit contenir au minimum 4 caractere
  $('#pseudo').keyup(function(){
      
      if($('#pseudo').val().length<4)
      {
          $('#pseudo').css('border-color','#ff0000');
          $('#pseudo').next('#error1').fadeIn('fast').text('Le pseudo doit contenir au minimum 4 caractere');
          result = false;
      }else{
          $('#pseudo').css('border-color','#00ff00');
          $('#pseudo').next('#error1').fadeOut(5000).text("champ valide");
          result = true;
      }
      
      return result;
      
  } )
  
  //champ doit contenir au minimum 4 caractere
  
  $('#password').keyup(function(){
      
      if($('#password').val().length<4)
      {
          $('#password').css('border-color','#ff0000');
          $('#password').next('#error2').fadeIn('fast').text('Le pseudo doit contenir au minimum 4 caractere');
          result = false;
      }else{
          $('#password').css('border-color','#00ff00');
          $('#password').next('#error2').fadeOut(5000).text("champ valide");
          result = true;
      }
      
      return result;
      
  } )
  
  
  
 
  
  
  
  
})

