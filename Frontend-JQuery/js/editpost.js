let date = new Date().toISOString().
  replace(/T/, ' ').      
  replace(/\..+/, '') ;
  const cookieVal=JSON.parse(document.cookie);
if(document.cookie=="") 
{
    window.location.href = "http://localhost/InventoryDB/views/index.html";
}
$(document).ready(function(){
    var getUrlParameter = function getUrlParameter(sParam) {
        var sPageURL = window.location.search.substring(1),
            sURLVariables = sPageURL.split('&'),
            sParameterName,
            i;
        
        for (i = 0; i < sURLVariables.length; i++) {
            sParameterName = sURLVariables[i].split('=');
        
            if (sParameterName[0] === sParam) {
                return sParameterName[1] === undefined ? true : decodeURIComponent(sParameterName[1]);
            }
        }
        };
        var postId = getUrlParameter('id');
        console.log("http://localhost:62009/api/posts/"+postId);

        // load post data to textarea
        $.ajax({
            url:"http://localhost:62009/api/posts/"+postId,
            method:"GET",
            success:function(res){
                console.log('here');
                console.log(res);
                $("#postID").val(res.PostContent);
            }
        });



        $("form").submit(function(e){
            e.preventDefault();
            console.log('to update');
            console.log($("#postID").val());
            if($("#postID").val()!="")
            {
                //simulate put ajax request
                $.ajax({
                    url:"http://localhost:62009/api/posts/"+postId,
                    method: 'PUT',
                    data:{
                        "PostContent": $("#postID").val(),
                        "CreatedAt":date,
                        "CreatedBy":cookieVal.username
                    },
                    success: function(res) {
                        alert('Your Post Has Been Updated');
                        window.location.href = "http://localhost/InventoryDB/views/myhome.html";
                    }
                });
            }
            else
            {
                alert("Post can not be empty! ");
            }
            
            
        });

});
