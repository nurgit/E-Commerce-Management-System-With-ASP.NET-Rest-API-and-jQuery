//////Registration function
$(document).ready(function(){
	$("#adduser").click(function(){
		Registration();
	});
	var Userlist=function(){
	$.ajax({
		url:"http://localhost:9799/api/userregistration",
		method:"GET",
		complete:function(xmlhttp,status){
			if(xmlhttp.status==200)
			{
				var data=xmlhttp.responseJSON;
			    var uslst='';
			    for(var i=0;i<data.length;i++)
				{
					uslst+="<tr><td>"+data[i].UId+"</td><td>"+data[i].UEmail+"</td><td>"+data[i].Uname+"</td><tr>";
					
					//strspcfcpst+="<option value="+data[i].Post1+">"+data[i].PostID+"</option>";
			}
			$("#UsersList tbody").html(uslst);	
			}
            else{
            	$("#uinmsg").html(xmlhttp.status+":"+xmlhttp.statusText);
            }
        }
		});
}
Userlist();

var Registration=function(){
	$.ajax({
		url:"http://localhost:9799/api/userregistration",
		method:"POST",
		header:"Content-Type:application/jason",
		data:{
			UEmail:$("#useremail").val(),
            Uname:$("#username").val(),
            Upassword:$("#passwords").val(),
		},
		complete:function(xmlhttp,status){
			if(xmlhttp.status==201)
			{
				$("#rmz").html("Registration Successful");
				Userlist();
				
			}
            else{
            	$("#rmz").html(xmlhttp.status+":"+xmlhttp.statusText);
            }
        }
		});
}
});

