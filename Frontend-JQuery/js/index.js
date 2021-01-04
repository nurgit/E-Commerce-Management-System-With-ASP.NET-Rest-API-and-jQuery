$(document).ready(function(){
    $("form").submit(function(e){
         e.preventDefault();
         $("#usernameErr").html('');
         $("#passwordErr").html('');
         let User = {
            username:$("#username").val(),
            password:$("#password").val()

         }
         let res=validate(User);
         //console.log( Object.keys(res).length);
         if(Object.keys(res).length==0)
         {
             $.ajax({
                url:"http://localhost:9799/api/ulogin",
                 method: 'POST',
                 data:{
                     
                
                     "Uname": User.username,
                     "Upassword": User.password
                 },
                 success: function(res) {
                    if(res!=undefined)
                    {
                        let cookieVal = {
                            username:User.username
                        }





                        document.cookie = JSON.stringify(cookieVal);
                        window.location.href = "http://localhost/E-Commerce-Management-System-With-ASP.NET-Rest-API-and-jQuery/Frontend-JQuery/Userdashboard.html";
                        alert("Authorized");
                    }
                  else
                  alert("Not Filled Up Properly");
                    
                },
                error:function(res) {
                    if(res==undefined)
                    {
                        alert("Wrong Username or Password");
                    }
                  else
                  alert("Wrong Username or Password");
                    
                }

            });
        }
        else
        {
            alert("Not Filled Up Properly");


         }
         /* $.ajax({
             url:"http://localhost:62009/api/users",
             method: 'POST',
             data:{
                 "Username":User.username,
                 "Password":User.password
             },
             success: function(data) {
                 console.log("success ", data);
             },
             failure: function(data) {
                 console.log("failed ",data);
             },
         }); */
     });
    
 
 });
 
 function validate(User)
 {
     let errorLog =  {};
     for (let key in User) {
         
         if(User[key]=="")
         {
             errorLog[key+"Err"]=key+" can not be empty";
         }
 
       }
       return errorLog;
 }