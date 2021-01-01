$(document).ready(function(){
	var uctgrst;
$("#addctgry").click(function(){
		Addcategory();
	}); 
	$("#updateCategorylist").change(function(){
		$("#updateCategoryName").val($("#updateCategorylist option:selected").text());
		uctgrst=$("#updateCategorylist option:selected").val();
	});
  $("#updatesbtnctgrs").click(function(){
    UpdateCategory();
	});
	$("#deleteCategorySelect").change(function(){
		split=$("#deleteCategorySelect").val().split("--");		
	});
	$("#deleteBtnss").click(function(){
     DeleteCategory();
	});

	var Categorylist=function(){
	$.ajax({
		url:"http://localhost:9799/api/categorys",
		method:"GET",
		complete:function(xmlhttp,status){
			if(xmlhttp.status==200)
			{
				var data=xmlhttp.responseJSON;
			    var ctgrlst='';
			    var uctgr='';
			    var dctgrstrForSelect='';
			    for(var i=0;i<data.length;i++)
				{
					ctgrlst+="<tr><td>"+data[i].CategoryId+"</td><td>"+data[i].CategoryName+"</td><td>"+data[i].IsActive+"</td><td>"+data[i].IsDelete+"</td><tr>";
					uctgr+="<option value="+data[i].CategoryId+">"+data[i].CategoryName+"</option>";
					dctgrstrForSelect+="<option value="+data[i].CategoryId+">"+data[i].CategoryName+"</option>";
					//strspcfcpst+="<option value="+data[i].Post1+">"+data[i].PostID+"</option>";
			}
			$("#CategoryList tbody").html(ctgrlst);
			$("#updateCategorylist").html(uctgr);
			$("#deleteCategorySelect").html(dctgrstrForSelect);	
			}
            else{
            	$("#categrmsg").html(xmlhttp.status+":"+xmlhttp.statusText);
            }
        }
		});
}
Categorylist();
var Addcategory=function(){
	$.ajax({
		url:"http://localhost:9799/api/categorys",
		method:"POST",
		header:"Content-Type:application/jason",
		data:{
			CategoryName:$("#addctgrname").val(),
		},
		complete:function(xmlhttp,status){
			if(xmlhttp.status==201)
			{
				$("#categraddmsgs").html("Category Added");
			  Categorylist();	
			}
            else{
            	$("#categraddmsgs").html(xmlhttp.status+":"+xmlhttp.statusText);
            }
        }
		});
}
	var UpdateCategory=function(){
$.ajax({
		url:"http://localhost:9799/api/categorys/"+uctgrst,
		method:"PUT",
		header:"Content-Type:application/jason",
		data:{
			CategoryName:$("#updateCategoryName").val()
		},
		complete:function(xmlhttp,status){
			if(xmlhttp.status==200)
			{
				$("#upctmsg").html("Category Updated");
				Categorylist(); 
			}
            else{
            	$("#upctmsg").html(xmlhttp.status+":"+xmlhttp.statusText);
            }
        }
		});
		}
function DeleteCategory()
{
	$.ajax({
			url:"http://localhost:9799/api/categorys/"+split[0],
			method:"delete",
			headers:{
				contentType:"application/json"
			},
			complete:function(xmlHttp,status){
				if(xmlHttp.status==204)
				{
					$("#deletectgrMsg").html("Category Deleted");
					
					Categorylist();
					//ComboSelectLoadPosts();

				}
				else
				{
					$("#deletectgrMsg").html("Error");
					console.log(xmlHttp.status+":"+xmlHttp.statusText);
				}
			}
		});
    }
});
