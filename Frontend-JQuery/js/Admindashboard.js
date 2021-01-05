  const cookieVal=JSON.parse(document.cookie);
  $(document).ready(function(){
      if(document.cookie!="")
      {
          console.log(cookieVal.username);
          $("#mymsg").html("Welcome "+cookieVal.username+"!");
          
      }
    
    });