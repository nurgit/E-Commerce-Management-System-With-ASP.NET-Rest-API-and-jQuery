let date = new Date().toISOString().
  replace(/T/, ' ').      
  replace(/\..+/, '') ;


$(document).ready(function(){
    //validate cookie
    console.log(date);
    if(document.cookie!="")
    {
        let cookieVal=JSON.parse(document.cookie);
        console.log(cookieVal.username);
        $("form").submit(function(e){
            e.preventDefault();
            let value = $("#postID").val();
            if(value!="")
            {
                console.log(value);
                 $.ajax({
                    url:"http://localhost:62009/api/posts",
                    method: 'POST',
                    data:{
                        "PostContent":$("#postID").val(),
                        "PostPic":'',
                        "CreatedAt":date,
                        "CreatedBy":cookieVal.username,
                    },
                    success: function(res) {
                       if(res!=undefined)
                       {
                         alert("post created");
                       }
                       else
                       {
                            alert("not created")
                       }
                    }
                }); 
            }
            else
            {
                alert("can not submit empty post ");
            }
        });
       
    }
    else
    {
        window.location.href = "http://localhost/InventoryDB/views/index.html";
    }
});