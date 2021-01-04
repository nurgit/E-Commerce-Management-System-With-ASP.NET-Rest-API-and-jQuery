   $(document).ready(function(){
   	var itms1;
   	var itms2;
   	var itms3;
   	var itms4;

	$("#addprdct").click(function(){
		AddProducts();
	});
		$("#deleteprdctss").change(function(){
		split=$("#deleteprdctss").val().split("--");		
	});
	$("#deleteprdctbtn").click(function(){
DeleteProducts();
	});
	$("#itmlst1").change(function(){
		$("#itemlist1").val($("#itmlst1 option:selected").text());
		itms1=$("#itmlst1 option:selected").val();
	});
	$("#itmselectt").change(function(){
		$("#itemlist2").val($("#itmselectt option:selected").text());
		itms2=$("#itmselectt option:selected").val();
	});
	$("#itmlsts3").change(function(){
		$("#itemlist3").val($("#itmlsts3 option:selected").text());
		itms3=$("#itmlsts3 option:selected").val();
	});
	$("#itmlsts4").change(function(){
		$("#itemlist4").val($("#itmlsts4 option:selected").text());
		itms4=$("#itmlsts4 option:selected").val();
	});
  $("#addordrs").click(function(){
    Orderproducts();
	});
var ProductList=function(){
	$.ajax({
		url:"http://localhost:9799/api/products",
		method:"GET",
		complete:function(xmlhttp,status){
			if(xmlhttp.status==200)
			{
				var data=xmlhttp.responseJSON;
			    var prdctlst='';
			    var dltssprdcts='';
			    var slctprdct1='';
			      var slctprdct2='';
			        var slctprdct3='';

			        var slctprdct4='';
			    
			    for(var i=0;i<data.length;i++)
				{
					prdctlst+="<tr><td>"+data[i].ProductId+"</td><td>"+data[i].ProductName+"</td><td>"+data[i].CategoryId+"</td><td>"+data[i].Price+"</td><tr>";
					dltssprdcts+="<option value="+data[i].ProductId+">"+data[i].ProductName+"</option>";
					slctprdct1+="<option value="+data[i].ProductId+">"+data[i].ProductName+"</option>";
					 slctprdct2+="<option value="+data[i].ProductId+">"+data[i].ProductName+"</option>";
					  slctprdct3+="<option value="+data[i].ProductId+">"+data[i].ProductName+"</option>";
					   slctprdct4+="<option value="+data[i].ProductId+">"+data[i].ProductName+"</option>";
			}
			$("#ProductList tbody").html(prdctlst);
			$("#itmlst1").html(slctprdct1);
			$("#itmselectt").html(slctprdct2);
			$("#itmlsts3").html(slctprdct3);

			$("#itmlsts4").html(slctprdct4);
			}
            else{
            	$("#prdctmsgss").html(xmlhttp.status+":"+xmlhttp.statusText);
            }
        }
		});
}
ProductList();
var AddProducts=function(){
	$.ajax({
		url:"http://localhost:9799/api/products",
		method:"POST",
		header:"Content-Type:application/jason",
		data:{
			ProductName:$("#addprdctsname").val(),
			CategoryId:$("#addctgrs").val(),
			Price:$("#addprce").val(),
		},
		complete:function(xmlhttp,status){
			if(xmlhttp.status==201)
			{
				$("#addprdctmsgss").html("New Product has added");
			  ProductList();	
			}
            else{
            	$("#addprdctmsgss").html(xmlhttp.status+":"+xmlhttp.statusText);
            }
        }
		});
}
ProductList();
function DeleteProducts()
{
	$.ajax({
			url:"http://localhost:9799/api/products/"+split[0],
			method:"delete",
			headers:{
				contentType:"application/json"
			},
			complete:function(xmlHttp,status){
				if(xmlHttp.status==204)
				{
					$("#dprdctmsg").html("Product deleted");
					
					ProductList();
					//ComboSelectLoadPosts();

				}
				else
				{
					$("#dprdctmsg").html("Error");
					console.log(xmlHttp.status+":"+xmlHttp.statusText);
				}
			}
		});
}
ProductList();
 
var Orderlist=function(){
	$.ajax({
		url:"http://localhost:9799/api/orders",
		method:"GET",
		complete:function(xmlhttp,status){
			if(xmlhttp.status==200)
			{
				var data=xmlhttp.responseJSON;
			    var ordrrlst='';
			    var slctprdct1='';
			    var slctprdct2='';
			    var slctprdct3='';
			    var slctprdct4='';
			    
			    for(var i=0;i<data.length;i++)
				{
					ordrrlst+="<tr><td>"+data[i].OrderId+"</td><td>"+data[i].Product1+"</td><td>"+data[i].Product2+"</td><td>"+data[i].Product3+"</td><td>"+data[i].Product4+"</td><tr>";
					 slctprdct1+="<option value="+data[i].ProductId+">"+data[i].ProductName+"</option>";
					  slctprdct2+="<option value="+data[i].ProductId+">"+data[i].ProductName+"</option>";
					   slctprdct3+="<option value="+data[i].ProductId+">"+data[i].ProductName+"</option>";
					    slctprdct4+="<option value="+data[i].ProductId+">"+data[i].ProductName+"</option>";
			    

			}
			$("#Orderlists tbody").html(ordrrlst);
			$("#itmlst1").html(slctprdct1);
			$("#itmselectt").html(slctprdct2);
			$("#itemslcts3").html(slctprdct3);
			$("#itemslcts4").html(slctprdct4);
			}
            else{
            	$("#ordrmsgsssss").html(xmlhttp.status+":"+xmlhttp.statusText);
            }
        }
	});
	
}
Orderlist();
var Orderproducts=function(){
	$.ajax({
		url:"http://localhost:9799/api/orders",
		method:"POST",
		header:"Content-Type:application/jason",
		data:{
			Product1:$("#itemlist1").val(),
			Product2:$("#itemlist2").val(),
			Product3:$("#itemlist3").val(),
			Product4:$("#itemlist4").val(),
		},
		complete:function(xmlhttp,status){
			if(xmlhttp.status==201)
			{
				$("#ordrsn").html("Order has been sent");
			  Orderlist();	
			}
            else{
            	$("#ordrsn").html(xmlhttp.status+":"+xmlhttp.statusText);
            }
        }
		});
}
});

