$(document).ready(function(){
	$("#addfdbkbtn").click(function(){
		AddFeedbacks();
	});
var Feedbacks=function(){
	$.ajax({
		url:"http://localhost:9799/api/feedbacks",
		method:"GET",
		complete:function(xmlhttp,status){
			if(xmlhttp.status==200)
			{
				var data=xmlhttp.responseJSON;
			    var fdbcklst='';
			    for(var i=0;i<data.length;i++)
				{
					fdbcklst+="<tr><td>"+data[i].FeedbackId+"</td><td>"+data[i].UId+"</td><td>"+data[i].Feedback1+"</td><tr>";
					
					
					//strspcfcpst+="<option value="+data[i].Post1+">"+data[i].PostID+"</option>";
			}
			$("#FeedbackList tbody").html(fdbcklst);
			}
            else{
            	$("#fdbmsg").html(xmlhttp.status+":"+xmlhttp.statusText);
            }
        }
		});
}
Feedbacks();
var AddFeedbacks=function(){
	$.ajax({
		url:"http://localhost:9799/api/feedbacks",
		method:"POST",
		header:"Content-Type:application/jason",
		data:{
			UId:$("#addusrId").val(),
			Feedback1:$("#addfdbck").val(),
		},
		complete:function(xmlhttp,status){
			if(xmlhttp.status==201)
			{
				$("#fdbckmsgs").html("New Feedback has Added");
			  Feedbacks();	
			}
            else{
            	$("#fdbckmsgs").html(xmlhttp.status+":"+xmlhttp.statusText);
            }
        }
		});
}
});